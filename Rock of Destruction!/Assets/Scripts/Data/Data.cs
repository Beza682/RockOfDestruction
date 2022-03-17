using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public static Data Instance;

    public Settings settings;

    public Data()
    {
        settings = new Settings()
        {
            music = false,
            //effects = false,
            //vibration = false,
        };
    }



    [Serializable]
    public class Settings
    {
        public bool music;
        //public bool effects;
        //public bool vibration;
    }
}
