using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public static Data Instance;

    public Settings settings;
    public PurchasedUpgrades purchasedUpgrades;
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
        purchasedUpgrades = new PurchasedUpgrades()
        {
            strength = 0,
            size = 0,
            offlineEarnings = 0
        };        
        score = new Score()
        {
            simpleScore = 0,
            donatScore = 0,
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
    public class PurchasedUpgrades
    {
        public int strength;
        public int size;
        public int offlineEarnings;
    }
    [Serializable]
    public class Score
    {
        public int simpleScore;
        public int donatScore;
    }
}
