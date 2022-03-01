using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [Header("Location")]
    public int locationWidth;
    public int locationLength;
    private float prefabsZone;
    public Transform spawnPoint;
    public GameObject[] locationPrefabs;

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



    private GameObject destrObject;
    private List<GameObject> destructibleObjects = new List<GameObject>();

    private GameObject locObject;
    private List<GameObject> locationObjects = new List<GameObject>();
    
    
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
        prefabsZone = locationWidth - 10;

        //GameHelper.Instance.destructibleObjects = destructibleObjects;
        DestructionOfObjects.destructibleObjects = destructibleObjects;

        spawnPosition = 0;
        secondSpawnZone = locationLength * 2;
        LocationSpawn(spawnPosition, secondSpawnZone);
        ZoneSpawner(secondSpawnZone);
        SpawnDestructibleObjects();

    }

    void Update()
    {
        playerPositionZ = GameHelper.Instance.player.transform.position.z;

        if (playerPositionZ >= spawnPosition)
        {
            playerPositionX = Mathf.Round(GameHelper.Instance.player.transform.position.x);
            Debug.Log(playerPositionX);
            spawnPosition += locationLength;
            firstSpawnZone = spawnPosition + locationLength;
            secondSpawnZone = firstSpawnZone + locationLength;
            LocationSpawn(firstSpawnZone, secondSpawnZone);
            ZoneSpawner(secondSpawnZone);
            //SpawnDestructibleObjects();
        }

        //Debug.Log(playerPosition % 100);

    }
    //void ZoneLimiter()
    //{
    //    for (int z = playerPosition + 170; z < playerPosition + 180; z += 10)
    //    {
    //        for (int x = -prefabsZone; x < prefabsZone + 1; x += 5)
    //        {
    //            var exist = destructibleObjects.Exists(c => c.gameObject.transform.position.x == x && c.gameObject.transform.position.z == z);

    //            if (!exist)
    //            {
    //                if(playerPosition % 100 == 0)
    //                {
                        
    //                    //GameObject passage = Instantiate(destructiblePrefabs[1], new Vector3(x, 0, z), Quaternion.identity);
    //                    GameObject wall = Instantiate(destructiblePrefabs[4], new Vector3(x, 0, z), Quaternion.identity);

    //                    //destructibleObjects.Add(passage);
    //                    destructibleObjects.Add(wall);
    //                }
    //            }
    //            //Debug.Log(locationObjects.Count);

    //            while (destructibleObjects.Count > prefabsZone * 4)
    //            {
    //                Destroy(destructibleObjects[0].gameObject);
    //                destructibleObjects.RemoveAt(0);
    //            }
    //        }
    //    }
    //}
    
    private void ZoneSpawner(float finishZone)
    {
        destrObject = Instantiate(passagePrefab, new Vector3(playerPositionX, 0, finishZone), Quaternion.identity);

        for (float /*z = finishZone - 10,*/ x = (-prefabsZone - 7.5f); x <= prefabsZone + 7.5f; x += 5f)
        {
            if (x < (playerPositionX - 10f) || x > (playerPositionX + 10f))
            {
                destrObject = Instantiate(wallPrefab, new Vector3(x, 0, finishZone), Quaternion.identity);
            }
        }
    }
    void SpawnDestructibleObjects()
    {
        //var random = Random.Range(0, destructiblePrefabs.Length);
        //objects = destructible[random];

        //objects = destructible[Random.Range(0, destructiblePrefabs.Length)];
        //objects = destructible[0];
        for (float z = playerPositionZ + 100, x = -prefabsZone; x < prefabsZone + 10; x += 20)
        {
            var random = Random.Range(0, mediumPrefabs.Length);
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
            destrObject = Instantiate(mediumPrefabs[random], new Vector3(x, 0, z), Quaternion.identity);

            //if (destrObject.GetComponent<DestructionOfObjects>() == null)
            //{
            //    destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
            //}
            //else
            //{
            //    destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
            //}
            destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;

            destructibleObjects.Add(destrObject);

        }

        while (destructibleObjects[0].gameObject.transform.position.z < playerPositionZ)
        {
            Destroy(destructibleObjects[0].gameObject);
            destructibleObjects.RemoveAt(0);
        }


    }
    private void LocationSpawn(float startSpawn, float finishSpawn)
    {
        for (float z = startSpawn; z <= finishSpawn; z += 10)
        {
            for (int x = -locationWidth; x < locationWidth + 10; x += 10)
            {
                //var exist = locationObjects.Exists(c => c.gameObject.transform.position.x == x && c.gameObject.transform.position.z == z);

                if ((x == -locationWidth || x == locationWidth)/* && !exist*/)
                {
                    locObject = Instantiate(locationPrefabs[1], new Vector3(x, 0, z), Quaternion.identity);
                    locationObjects.Add(locObject);
                }
                else if (!(x == -locationWidth || x == locationWidth) /* && !exist*/)
                {
                    locObject = Instantiate(locationPrefabs[0], new Vector3(x, 0, z), Quaternion.identity);
                    locationObjects.Add(locObject);
                }
            }
        }
        while (locationObjects[0].gameObject.transform.position.z < playerPositionZ)
        {
            Destroy(locationObjects[0].gameObject);
            locationObjects.RemoveAt(0);
        }
    }
}
