using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerV2 : MonoBehaviour
{
    [Header("Location")]
    private float locationLength = 500;
    private float prefabsZoneWidth = 90;

    private float startSpawnPosition;
    private float spawnPosition;
    private float firstSpawnZone;
    private float secondSpawnZone;
    private float spawnStep = 100;

    [SerializeField] private Transform spawnObjects;
    [SerializeField] private GameObject location;
    [SerializeField] private GameObject spawnPoint;

    [Header("LargeObjects")]
    [SerializeField] private int largeCount;
    [SerializeField] private int largeSpawnChance;
    [SerializeField] private Transform[] largePoints;
    [SerializeField] private GameObject[] largePrefabs;

    [Header("MediumObjects")]
    [SerializeField] private int mediumCount;
    [SerializeField] private int mediumSpawnChance;
    [SerializeField] private Transform[] mediumPoints;
    [SerializeField] private GameObject[] mediumPrefabs;

    [Header("SmallObjects")]
    [SerializeField] private int smallCount;
    [SerializeField] private int smallSpawnChance;
    [SerializeField] private Transform[] smallPoints;
    [SerializeField] private GameObject[] smallPrefabs;

    [Header("ZoneObjects")]
    [SerializeField] private GameObject passagePrefab;
    [SerializeField] private Transform[] passagePoints;
    [SerializeField] private GameObject wallPrefab;


    private GameObject elementOnScene;
    private List<GameObject> elementsOnScene = new List<GameObject>();


    private float objectStrength;


    private void Start()
    {
        startSpawnPosition = 0;
        spawnPosition = locationLength;
        firstSpawnZone = locationLength;
        secondSpawnZone = locationLength * 2;

        DestructionOfObjects.destructibleObjects = elementsOnScene;

        LocationSpawner(startSpawnPosition, firstSpawnZone);

        for (float i = startSpawnPosition; i < firstSpawnZone; i += spawnStep)
        {
            GenerateRandomElements(smallPoints, smallPrefabs, smallCount, smallSpawnChance);
            GenerateRandomElements(mediumPoints, mediumPrefabs, mediumCount, mediumSpawnChance);
            GenerateRandomElements(largePoints, largePrefabs, largeCount, largeSpawnChance);
            MoveSpawner(spawnStep);
        }

        ZoneSpawner(passagePoints, firstSpawnZone);


        LocationSpawner(firstSpawnZone, secondSpawnZone);

        for (float i = firstSpawnZone; i < secondSpawnZone; i += spawnStep)
        {
            GenerateRandomElements(smallPoints, smallPrefabs, smallCount, smallSpawnChance);
            GenerateRandomElements(mediumPoints, mediumPrefabs, mediumCount, mediumSpawnChance);
            GenerateRandomElements(largePoints, largePrefabs, largeCount, largeSpawnChance);
            MoveSpawner(spawnStep);
        }

        ZoneSpawner(passagePoints, secondSpawnZone);

    }

    private void Update()
    {

        if (GameHelper.Instance.player.transform.position.z >= spawnPosition)
        {

            spawnPosition += locationLength;
            firstSpawnZone = spawnPosition + locationLength;
            secondSpawnZone = firstSpawnZone + locationLength;


            LocationSpawner(spawnPosition, firstSpawnZone);

            for (float i = spawnPosition; i < firstSpawnZone; i += spawnStep)
            {
                GenerateRandomElements(smallPoints, smallPrefabs, smallCount, smallSpawnChance);
                GenerateRandomElements(mediumPoints, mediumPrefabs, mediumCount, mediumSpawnChance);
                GenerateRandomElements(largePoints, largePrefabs, largeCount, largeSpawnChance);
                MoveSpawner(spawnStep);
            }
            ZoneSpawner(passagePoints, firstSpawnZone);

            RemoveElements(elementsOnScene);
        }
    }
    private void ZoneSpawner(Transform[] spawnPoints, float finishZone)
    {
        var passagePoint = Random.Range(0, passagePoints.Length);
        elementOnScene = Instantiate(passagePrefab, spawnPoints[passagePoint].transform.position, Quaternion.identity, spawnObjects);
        ChangingAnObject(elementOnScene);
        ElementComplexity(elementOnScene);

        for (float x = (-prefabsZoneWidth - 2.5f); x <= prefabsZoneWidth + 2.5f; x += 5f)
        {
            if (x < (spawnPoints[passagePoint].transform.position.x - 10f) || x > (spawnPoints[passagePoint].transform.position.x + 10f))
            {
                elementOnScene = Instantiate(wallPrefab, new Vector3(x, 0, finishZone), Quaternion.identity, spawnObjects);
                ChangingAnObject(elementOnScene);
                ElementComplexity(elementOnScene);
            }
        }

    }
    private void GenerateRandomElements(Transform[] spawnPoints, GameObject[] generatedElements, int count, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            var indexElement = Random.Range(0, generatedElements.Length);

            if (Random.Range(0, 100) < spawnChance && count > 0)
            {
                count--;

                elementOnScene = Instantiate(generatedElements[indexElement], spawnPoints[i].transform.position, Quaternion.identity, spawnObjects);
                ChangingAnObject(elementOnScene);
                ElementComplexity(elementOnScene);
                //GenerateElement(spawnPoints[i].transform.position, generatedElements[randomElement]);
            }
        }
    }
    private void MoveSpawner(float distanceZ)
    {
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z + distanceZ);
    }

    private void LocationSpawner(float startSpawn, float finishSpawn)
    {
        for (float z = startSpawn; z < finishSpawn; z += spawnStep)
        {
            elementsOnScene.Add(Instantiate(location, new Vector3(0, 0, z), Quaternion.identity, spawnObjects));
        }
    }
    private void ElementComplexity(GameObject generatedElement)
    {
        if (generatedElement.GetComponentsInChildren<DestructionOfObjects>().Length > 0)
        {
            for (int i = 0; i < generatedElement.GetComponentsInChildren<DestructionOfObjects>().Length; i++)
            {
                elementsOnScene.Add(generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].gameObject);
            }
        }
        else
        {
            elementsOnScene.Add(generatedElement);
        }
    }

    private GameObject ChangingAnObject(GameObject generatedElement)
    {
        if (generatedElement.GetComponentsInChildren<DestructionOfObjects>().Length > 0)
        {
            for (int i = 0; i < generatedElement.GetComponentsInChildren<DestructionOfObjects>().Length; i++)
            {
                //Debug.Log(generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength);

                if (generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength != 1)
                {
                    objectStrength = generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength + spawnPoint.transform.position.z * 0.002f;
                    generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength = objectStrength;

                }
                //else if (generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength == 1)
                //{
                //    objectStrength = GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength;
                //    generatedElement.GetComponentsInChildren<DestructionOfObjects>()[i].objectStrength = objectStrength;

                //}

            }
        }
        else
        {
            Debug.Log(generatedElement.GetComponent<DestructionOfObjects>().objectStrength);

            //objectStrength = generatedElement.GetComponent<DestructionOfObjects>().objectStrength + spawnPosition * 0.02f;
            //Debug.Log(objectStrength);
            //generatedElement.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
        }
        return generatedElement;
    }

    private void RemoveElements(List<GameObject> listGameObject)
    {
        while (listGameObject[0].gameObject.transform.position.z < GameHelper.Instance.transform.position.z)
        {
            Destroy(listGameObject[0].gameObject);
            listGameObject.RemoveAt(0);
        }
    }
}