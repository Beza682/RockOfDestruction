using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerV2 : MonoBehaviour
{
    [Header("Location")]
    [SerializeField] private Transform spawnObjects;
    [SerializeField] private Transform locationObjects;
    [SerializeField] private GameObject location;
    [SerializeField] private GameObject spawnPoint;

    private float locationLength = 500;
    private float prefabsZoneWidth = 90;

    private float spawnPosition;
    private float firstSpawnZone;
    private float secondSpawnZone;
    private float spawnStep = 100;

    [Header("LargeObjects")]
    [SerializeField] private int largeCount;
    [SerializeField] private Transform[] largePoints;
    [SerializeField] private GameObject[] largePrefabs;

    [Header("MediumObjects")]
    [SerializeField] private int mediumCount;
    [SerializeField] private Transform[] mediumPoints;
    [SerializeField] private GameObject[] mediumPrefabs;

    [Header("SmallObjects")]
    [SerializeField] private int smallCount;
    [SerializeField] private Transform[] smallPoints;
    [SerializeField] private GameObject[] smallPrefabs;

    [Header("ZoneObjects")]
    [SerializeField] private GameObject passagePrefab;
    [SerializeField] private Transform[] passagePoints;
    [SerializeField] private GameObject wallPrefab;


    private float objectStrength;


    private void Start()
    {
        spawnPosition = 0;
        firstSpawnZone = locationLength;
        secondSpawnZone = locationLength * 2;

        LocationSpawner(spawnPosition - 100, secondSpawnZone);

        for (float i = spawnPosition; i < firstSpawnZone; i += spawnStep)
        {
            GenerateRandomElements(smallPoints, smallPrefabs, smallCount);
            GenerateRandomElements(mediumPoints, mediumPrefabs, mediumCount);
            GenerateRandomElements(largePoints, largePrefabs, largeCount);
            MoveSpawner(spawnStep);
        }

        ZoneSpawner(passagePoints, firstSpawnZone);

        for (float i = firstSpawnZone; i < secondSpawnZone; i += spawnStep)
        {
            GenerateRandomElements(smallPoints, smallPrefabs, smallCount);
            GenerateRandomElements(mediumPoints, mediumPrefabs, mediumCount);
            GenerateRandomElements(largePoints, largePrefabs, largeCount);
            MoveSpawner(spawnStep);
        }

        ZoneSpawner(passagePoints, secondSpawnZone);

        spawnPosition = locationLength;
    }

    private void Update()
    {

        if (PlayerController.Instance.gameObject.transform.position.z >= spawnPosition)
        {

            spawnPosition += locationLength;
            firstSpawnZone = spawnPosition + locationLength;
            secondSpawnZone = firstSpawnZone + locationLength;


            LocationSpawner(spawnPosition, firstSpawnZone);

            for (float i = spawnPosition; i < firstSpawnZone; i += spawnStep)
            {
                GenerateRandomElements(smallPoints, smallPrefabs, smallCount);
                GenerateRandomElements(mediumPoints, mediumPrefabs, mediumCount);
                GenerateRandomElements(largePoints, largePrefabs, largeCount);
                MoveSpawner(spawnStep);
            }
            ZoneSpawner(passagePoints, firstSpawnZone);
        }
    }
    private void ZoneSpawner(Transform[] spawnPoints, float finishZone)
    {
        var passagePoint = spawnPoints.GetRandom();

        ChangingAnObject(Instantiate(passagePrefab, passagePoint.transform.position, Quaternion.identity, spawnObjects));

        for (float x = (-prefabsZoneWidth - 2.5f); x <= prefabsZoneWidth + 2.5f; x += 5f)
        {
            if (x < (passagePoint.transform.position.x - 10f) || x > (passagePoint.transform.position.x + 10f))
            {
                ChangingAnObject(Instantiate(wallPrefab, new Vector3(x, 0, finishZone), Quaternion.identity, spawnObjects));
            }
        }

    }
    private void GenerateRandomElements(Transform[] spawnPoints, GameObject[] generatedElements, int count)
    {
        List<Transform> points = new List<Transform>();
        points.AddRange(spawnPoints);
        while (count > 0)
        {
            count--;
            var randomPoint = points.GetRandom();

            ChangingAnObject(Instantiate(generatedElements.GetRandom(), randomPoint.transform.position, Quaternion.identity, spawnObjects)); ;
            points.Remove(randomPoint);
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
            Instantiate(location, new Vector3(0, 0, z), Quaternion.identity, locationObjects);
        }
    }

    private GameObject ChangingAnObject(GameObject generatedElement)
    {
        if (generatedElement.GetComponentsInChildren<PrefabCharacteristics>().Length > 0)
        {
            foreach (var prefab in generatedElement.GetComponentsInChildren<PrefabCharacteristics>())
            {
                if (prefab.objectStrength != 1)
                {
                    prefab.objectStrength += spawnPoint.transform.position.z * 0.002f;
                }

                if (prefab.objectStrength > PlayerCharacteristics.Instance.strength)
                {
                    prefab.unlock = false;
                    foreach (var mesh in prefab.GetComponentsInChildren<MeshRenderer>())
                    {
                        mesh.material.color /= 8;
                    }
                }
                else if (prefab.objectStrength < PlayerCharacteristics.Instance.strength)
                {
                    prefab.unlock = true;
                }
            }
        }
        return generatedElement;
    }
}
