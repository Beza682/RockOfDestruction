using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("Location")]
    private float locationWidth = 100;
    private float locationLength = 500;
    private float prefabsZoneWidth = 90;

    public Transform spawnObjects;
    public GameObject ground;
    public GameObject lateralBorder;

    [Header("LargeObjects")]
    public int largeCount;
    public GameObject[] largePrefabs;

    [Header("MediumObjects")]
    public int mediumCount;
    public GameObject[] mediumPrefabs;

    [Header("SmallObjects")]
    public int smallCount;
    public GameObject[] smallPrefabs;

    [Header("ZoneObjects")]
    public GameObject passagePrefab;
    public GameObject wallPrefab;


    private GameObject elementOnScene;
    private List<GameObject> elementsOnScene = new List<GameObject>();


    private float objectStrength;


    private float playerPositionZ;
    private float playerPositionX;

    private float startSpawnPosition;
    private float spawnPosition;
    private float firstSpawnZone;
    private float secondSpawnZone;



    void Start()
    {

        //destrObject = destrObject = ObjectType.ObjectTyp(destructiblePrefabs);
        //prefabsZoneWidth = locationWidth - 10;
        //GameHelper.Instance.destructibleObjects = destructibleObjects;
        DestructionOfObjects.destructibleObjects = elementsOnScene;

        spawnPosition = 0;
        firstSpawnZone = locationLength;
        secondSpawnZone = locationLength * 2;

        LocationSpawn(spawnPosition, firstSpawnZone);
        ZoneSpawner(firstSpawnZone);

        LocationSpawn(firstSpawnZone, secondSpawnZone);
        ZoneSpawner(secondSpawnZone);
        //MediumObjectsSpawn(spawnPosition, firstSpawnZone);
        //MediumObjectsSpawn(firstSpawnZone, secondSpawnZone);
        LargeObjectsSpawn(spawnPosition, firstSpawnZone);
        LargeObjectsSpawn(firstSpawnZone, secondSpawnZone);

        //SpawnDestructibleObjects();

    }

    void Update()
    {
        playerPositionZ = GameHelper.Instance.player.transform.position.z;

        if (playerPositionZ >= spawnPosition)
        {
            playerPositionX = Mathf.Round(GameHelper.Instance.player.transform.position.x);
            //Debug.Log(playerPositionX);
            spawnPosition += locationLength;
            firstSpawnZone = spawnPosition + locationLength;
            secondSpawnZone = firstSpawnZone + locationLength;
            LocationSpawn(firstSpawnZone, secondSpawnZone);
            ZoneSpawner(secondSpawnZone);
            //MediumObjectsSpawn(firstSpawnZone, secondSpawnZone);
            LargeObjectsSpawn(firstSpawnZone, secondSpawnZone);

            RemoveElements(elementsOnScene);

        }
    }
  
    private void ZoneSpawner(float finishZone)
    {
        var passagePoint = new Vector3(Random.Range(-50, 50), 0, finishZone);
        elementOnScene = Instantiate(passagePrefab, passagePoint, Quaternion.identity, spawnObjects);
        ElementComplexity(elementOnScene);

        for (float x = (-prefabsZoneWidth - 2.5f); x <= prefabsZoneWidth + 2.5f; x += 5f)
        {
            if (x < (passagePoint.x - 10f) || x > (passagePoint.x + 10f))
            {
                elementOnScene = Instantiate(wallPrefab, new Vector3(x, 0, finishZone), Quaternion.identity, spawnObjects);
                ElementComplexity(elementOnScene);
            }
        }
    }
    private void GenerateRandomElements(GameObject[] generatedElements, int count, float startSpawn, float finishSpawn)
    {
        while (count > 0)
        {
            count--;

            var indexElement = Random.Range(0, generatedElements.Length);
            elementOnScene = generatedElements[indexElement];
            var offset = generatedElements[indexElement].GetComponent<Collider>().transform.localScale.x / 2;
            var position = new Vector3(Random.Range(-prefabsZoneWidth + offset, prefabsZoneWidth - offset), 0, Random.Range(startSpawn, finishSpawn));
            
            
            //if (Random.Range(0, 100) < spawnChance && count > 0)
            {

                elementOnScene = Instantiate(generatedElements[indexElement], position, Quaternion.identity, spawnObjects);
                ElementComplexity(elementOnScene);
                //GenerateElement(spawnPoints[i].transform.position, generatedElements[randomElement]);
            }
        }
    }
    void SpawnDestructibleObjects()
    {
        //var random = Random.Range(0, destructiblePrefabs.Length);
        //objects = destructible[random];

        //objects = destructible[Random.Range(0, destructiblePrefabs.Length)];
        //objects = destructible[0];
        for (float z = playerPositionZ + 100, x = -prefabsZoneWidth; x < prefabsZoneWidth + 10; x += 20)
        {
            var mediumRandom = Random.Range(0, mediumPrefabs.Length);
            //objects = destructible[random];

            //switch (objects) // подумать о том как граммотно его удалить
            //{
            //    case Objects.Alcove:
            //        //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;
            //        //Debug.Log(objectStrength);



            //        break;
            //    case Objects.Passage:
            //        //objectStrength = destructiblePrefabs[random]..GetComponentInChildren<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;


            //        break;
            //    case Objects.House:
            //        //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;


            //        break;
            //    case Objects.Tower:
            //        //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;

            //        break;
            //    case Objects.Wall:
            //        //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;


            //        break;
            //    case Objects.People:
            //        //objectStrength = destructiblePrefabs[random].GetComponentInChildren<DestructionOfObjects>().objectStrength;

            //        break;
            //    case Objects.Tree:
            //        //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength;

            //        break;
            //    case Objects.Barrier:
            //        //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength;

            //        break;

            //}
            elementOnScene = Instantiate(mediumPrefabs[mediumRandom], new Vector3(x, 0, z), Quaternion.identity);

            //if (destrObject.GetComponent<DestructionOfObjects>() == null)
            //{
            //    destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
            //}
            //else
            //{
            //    destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
            //}
            elementOnScene.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;

            elementsOnScene.Add(elementOnScene);

        }
    }
    private void SmallObjectsSpawn()
    {
        var smallRandom = Random.Range(0, smallPrefabs.Length);

        int spawnCount = smallCount;

        while (spawnCount > 0)
        {
            spawnCount--;
            Vector3 treePosition = new Vector3(Random.Range(playerPositionX - 20, playerPositionX + 20), 0, Random.Range(playerPositionZ + 380, playerPositionZ + 420));
            elementOnScene = Instantiate(smallPrefabs[0], treePosition, Quaternion.identity, spawnObjects);
            ElementComplexity(elementOnScene);

        }
    }
    private void MediumObjectsSpawn(float startSpawn, float finishSpawn)
    {

        int spawnCount = mediumCount;

        //while (spawnCount > 0)
        {
            //var mediumRandom = Random.Range(0, mediumPrefabs.Length);
            //spawnCount--;
            //Vector3 position = new Vector3(Random.Range(-prefabsZoneWidth, prefabsZoneWidth), 0, Random.Range(startSpawn + 40, finishSpawn - 40));
            //destrObject = Instantiate(mediumPrefabs[mediumRandom], position, Quaternion.identity, spawnObjects);
             
            for (float z = startSpawn + 100; z <= finishSpawn - 40; z += Random.Range(20, 25))
            {
                for (float x = -prefabsZoneWidth; x <= prefabsZoneWidth; x += Random.Range(20, 25))
                {
                    var mediumRandom = Random.Range(0, mediumPrefabs.Length);
                    if (Random.Range(0, 100) < 20 && spawnCount > 0)
                    {
                        spawnCount--;
                        Debug.Log(spawnCount);
                        elementOnScene = Instantiate(mediumPrefabs[mediumRandom], new Vector3(x, 0, z), Quaternion.identity, spawnObjects);
                        ElementComplexity(elementOnScene);
                    }

                }
            }

        }

    }
    private void LargeObjectsSpawn(float startSpawn, float finishSpawn)
    {
        int largeSpawnCount = largeCount;
        int smallSpawnCount = smallCount;
        int mediumSpawnCount = mediumCount;

        for (float z = startSpawn + 100; z <= finishSpawn - 40; z += Random.Range(20, 25))
        {
            for (float x = -prefabsZoneWidth; x <= prefabsZoneWidth; x += Random.Range(20, 25))
            {
                var objectType = Random.Range(0, 3);

                Debug.Log(objectType);

                switch (objectType)
                {
                    case 0:
                            var smallRandom = Random.Range(0, smallPrefabs.Length);
                            elementOnScene = Instantiate(smallPrefabs[smallRandom], new Vector3(x, 0, z), Quaternion.identity, spawnObjects);
                        break;
                    case 1:
                        if (Random.Range(0, 100) < 40)
                        {
                            var mediumRandom = Random.Range(0, mediumPrefabs.Length);
                            elementOnScene = Instantiate(mediumPrefabs[mediumRandom], new Vector3(x, 0, z), Quaternion.identity, spawnObjects);
                        }
                        break;
                    case 2:
                        if (Random.Range(0, 100) < 10 && largeSpawnCount > 0)
                        {
                            largeSpawnCount--;

                            var largeRandom = Random.Range(0, largePrefabs.Length);
                            Debug.Log(largeRandom);
                            elementsOnScene.Add(Instantiate(largePrefabs[largeRandom], new Vector3(x, 0, z), Quaternion.identity, spawnObjects));

                        }
                        break;

                }
            }
        }

    }


    private void LocationSpawn(float startSpawn, float finishSpawn)
    {
        for (float z = startSpawn; z <= finishSpawn; z += 10)
        {
            for (float x = -locationWidth; x <= locationWidth; x += 10)
            {
                //var exist = locationObjects.Exists(c => c.gameObject.transform.position.x == x && c.gameObject.transform.position.z == z);

                if ((x == -locationWidth || x == locationWidth)/* && !exist*/)
                {
                    elementOnScene = Instantiate(lateralBorder, new Vector3(x, 0, z), Quaternion.identity, spawnObjects);
                    elementsOnScene.Add(elementOnScene);
                }
                else if (!(x == -locationWidth || x == locationWidth) /* && !exist*/)
                {
                    elementOnScene = Instantiate(ground, new Vector3(x, 0, z), Quaternion.identity, spawnObjects);
                    elementsOnScene.Add(elementOnScene);
                }
            }
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
    private void RemoveElements(List<GameObject> listGameObject)
    {
        while (listGameObject[0].gameObject.transform.position.z < GameHelper.Instance.transform.position.z)
        {
            Destroy(listGameObject[0].gameObject);
            listGameObject.RemoveAt(0);
        }
    }
}
