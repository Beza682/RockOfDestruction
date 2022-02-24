using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private Objects objects;

    public GameObject[] destructiblePrefabs;
    private GameObject destrObject;
    private List<GameObject> destructibleObjects = new List<GameObject>();
    private List<Objects> destructible = new List<Objects> { Objects.Alcove, Objects.Passage, Objects.House, Objects.Tower, Objects.Wall, Objects.People, Objects.Tree, Objects.Barrier };

    public GameObject[] locationPrefabs;
    public GameObject locObject;
    private List<GameObject> locationObjects = new List<GameObject>();
    
    
    private float objectStrength;


    public int locationWidth;
    private int prefabsZone;
    private int playerPosition;
    private int spawnPosition;

    void Start()
    {
        prefabsZone = locationWidth - 10;
        //GameHelper.Instance.destructibleObjects = destructibleObjects;
        DestructionOfObjects.destructibleObjects = destructibleObjects;


        StartLocationSpawn();
        SpawnDestructibleObjects();


    }

    void Update()
    {
        playerPosition = Mathf.RoundToInt(GameHelper.Instance.player.transform.position.z);
        spawnPosition = Mathf.RoundToInt(locationObjects[0].gameObject.transform.position.z + 10);

        if (playerPosition == spawnPosition)
        {
            LocationSpawn();
            SpawnDestructibleObjects();
        }

        //Debug.Log(playerPosition % 100);

    }
    void ZoneLimiter()
    {
        for (int z = playerPosition + 170; z < playerPosition + 180; z += 10)
        {
            for (int x = -prefabsZone; x < prefabsZone + 1; x += 5)
            {
                var exist = destructibleObjects.Exists(c => c.gameObject.transform.position.x == x && c.gameObject.transform.position.z == z);

                if (!exist)
                {
                    if(playerPosition % 100 == 0)
                    {
                        
                        //GameObject passage = Instantiate(destructiblePrefabs[1], new Vector3(x, 0, z), Quaternion.identity);
                        GameObject wall = Instantiate(destructiblePrefabs[4], new Vector3(x, 0, z), Quaternion.identity);

                        //destructibleObjects.Add(passage);
                        destructibleObjects.Add(wall);
                    }
                }
                //Debug.Log(locationObjects.Count);

                while (destructibleObjects.Count > prefabsZone * 4)
                {
                    Destroy(destructibleObjects[0].gameObject);
                    destructibleObjects.RemoveAt(0);
                }
            }
        }
    }
    
    void SpawnDestructibleObjects()
    {
        //var random = Random.Range(0, destructiblePrefabs.Length);
        //objects = destructible[random];

        //objects = destructible[Random.Range(0, destructiblePrefabs.Length)];
        //objects = destructible[0];

        for (int z = playerPosition + 100, x = -prefabsZone; x < prefabsZone + 10; x += 20)
        {
            var random = Random.Range(0, destructiblePrefabs.Length);
            objects = destructible[random];

            switch (objects)
            {
                case Objects.Alcove:
                    //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;
                    //Debug.Log(objectStrength);



                    break;
                case Objects.Passage:
                    //objectStrength = destructiblePrefabs[random]..GetComponentInChildren<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;


                    break;
                case Objects.House:
                    //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;


                    break;
                case Objects.Tower:
                    //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;

                    break;
                case Objects.Wall:
                    //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength + playerPosition * 0.02f;


                    break;
                case Objects.People:
                    //objectStrength = destructiblePrefabs[random].GetComponentInChildren<DestructionOfObjects>().objectStrength;

                    break;
                case Objects.Tree:
                    //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength;

                    break;
                case Objects.Barrier:
                    //objectStrength = destructiblePrefabs[random].GetComponent<DestructionOfObjects>().objectStrength;

                    break;

            }
            destrObject = Instantiate(destructiblePrefabs[random], new Vector3(x, 0, z), Quaternion.identity);

            //if (destrObject.GetComponent<DestructionOfObjects>() == null)
            //{
            //    destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
            //}
            //else
            //{
            //    destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;
            //}
            //destrObject.GetComponent<DestructionOfObjects>().objectStrength = objectStrength;

            destructibleObjects.Add(destrObject);

        }

        while (destructibleObjects[0].gameObject.transform.position.z < playerPosition)
        {
            Destroy(destructibleObjects[0].gameObject);
            destructibleObjects.RemoveAt(0);
        }


    }
    void StartLocationSpawn()
    {
        for (int z = playerPosition; z < playerPosition + 220; z += 10)
        {
            for (int x = -locationWidth; x < locationWidth + 10; x += 10)
            {
                //var exist = locationObjects.Exists(c => c.gameObject.transform.position.x == x && c.gameObject.transform.position.z == z);

                if ((x == -locationWidth || x == locationWidth)/* && !exist*/)
                {
                    locObject = Instantiate(locationPrefabs[1], new Vector3(x, 0 , z), Quaternion.identity);
                    locationObjects.Add(locObject);
                }
                else if (!(x == -locationWidth || x == locationWidth) /* && !exist*/)
                {
                    locObject = Instantiate(locationPrefabs[0], new Vector3(x, 0, z), Quaternion.identity);
                    locationObjects.Add(locObject);
                }
            }
        }
    }
    void LocationSpawn()
    {
        for (int z = playerPosition + 200, x = -locationWidth; x < locationWidth + 10; x += 10)
        {
            if ((x == -locationWidth || x == locationWidth))
            {
                locObject = Instantiate(locationPrefabs[1], new Vector3(x, 0, z), Quaternion.identity);
                locationObjects.Add(locObject);
            }
            else if (!(x == -locationWidth || x == locationWidth))
            {
                locObject = Instantiate(locationPrefabs[0], new Vector3(x, 0, z), Quaternion.identity);
                locationObjects.Add(locObject);
            }
        }
        while (locationObjects[0].gameObject.transform.position.z < playerPosition)
        {
            Destroy(locationObjects[0].gameObject);
            locationObjects.RemoveAt(0);
        }
    }
}
