using System.Collections.Generic;
using UnityEngine;

static class ExtensionMethods
{
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
    public static GameObject GetRandom(this GameObject[] objects)
    {
        return objects[Random.Range(0, objects.Length)];
    }  
    public static Transform GetRandom(this Transform[] transforms)
    {
        return transforms[Random.Range(0, transforms.Length)];
    }
    public static AudioClip GetRandom(this AudioClip[] audioClip)
    {
        return audioClip[Random.Range(0, audioClip.Length)];
    }
}