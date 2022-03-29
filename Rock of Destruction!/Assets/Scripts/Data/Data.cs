using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public static Data Instance;

    public Settings settings;
    public UpgradeLevel upgradeLevel;
    public Score score;

    public Data()
    {
        settings = new Settings()
        {
            music = false,
            effects = false,
            vibration = false,
            language = false
        };
        upgradeLevel = new UpgradeLevel()
        {
            strengthLevel = 1,
            sizeLevel = 1,
            offlineEarningsLevel = 1
        };           
        score = new Score()
        {
            simpleScore = 9000000,
            donatScore = 0
        };
    }

    [Serializable]
    public class Settings
    {
        public bool music;
        public bool effects;
        public bool vibration;
        public bool language;
    }
    
    [Serializable]
    public class UpgradeLevel
    {
        public int strengthLevel;
        public int sizeLevel;
        public int offlineEarningsLevel; //Пока отложить 
    }

    [Serializable]
    public class Score
    {
        public float simpleScore;
        public float donatScore;
    }  

}
