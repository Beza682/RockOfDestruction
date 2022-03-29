using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDestruction : MonoBehaviour
{
    public static HintDestruction Instance;

    [SerializeField] private Transform spawnObjects;


    private void Awake()
    {
        Instance = this;
    }

    public void ObjectUnlock()
    {
        if (spawnObjects.GetComponentsInChildren<PrefabCharacteristics>().Length > 0)
        {
            foreach (var prefab in spawnObjects.GetComponentsInChildren<PrefabCharacteristics>())
            {
                if ((prefab.objectStrength < PlayerCharacteristics.Instance.strength) && (prefab.objectStrength > 1) && !prefab.unlock)
                {
                    prefab.unlock = true;
                    foreach (var mesh in prefab.GetComponentsInChildren<MeshRenderer>())
                    {
                        mesh.material.color *= 8;
                    }
                }
            }
        }
    }
}