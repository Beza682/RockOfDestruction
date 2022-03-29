using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Sounds Dictionary", menuName = "Audio/Sounds Dictionary", order = 50)]
public class SoundEditor : ScriptableObject
{
    [Serializable]
    public class DictList
    {
        public string key;
        public AudioClip[] audioClips;
    }

    public string key;
    public List<DictList> sndList = new List<DictList>();

    public void Loading(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.Log("The 'Key' field is empty");
        }
        else
        {
            if (!sndList.Exists(x => x.key == key))
            {
                sndList.Add(new SoundEditor.DictList() { key = key });
                Debug.Log("Added!");
            }
            else
                Debug.Log("The Key already exists");
        }
    }

    public void Deleting(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.Log("The 'Key' field is empty");
        }
        else
        {
            if (sndList.Exists(x => x.key == key))
            {
                int keyId = sndList.FindIndex(x => x.key == key);
                sndList.RemoveAt(keyId);
                Debug.Log("Deleted!");
            }
            else
                Debug.Log("The Key doesn't exist!");
        }
    }
}
