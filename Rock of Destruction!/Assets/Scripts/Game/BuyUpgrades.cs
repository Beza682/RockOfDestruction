using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyUpgrades : MonoBehaviour
{
    public static BuyUpgrades Instance;

    [Header("Price change")]
    [SerializeField] private float markup;

    [Header("Strength")]
    [SerializeField] private int initialCostStrength;
    [SerializeField] private TMP_Text strengthPriceTMP;
    [SerializeField] private TMP_Text strengthLevelTMP;


    [Header("Size")]
    [SerializeField] private int initialCostSize;
    [SerializeField] private TMP_Text sizePriceTMP;
    [SerializeField] private TMP_Text sizeLevelTMP;

    [Header("Offline Earnings")]
    [SerializeField] private int initialCostOfflineEarnings;
    [SerializeField] private TMP_Text offlineEarningsPriceTMP;
    [SerializeField] private TMP_Text offlineEarningsLevelTMP;

    private int StrengthLevel
    {
        get { return Data.Instance.upgradeLevel.strengthLevel; }

        set 
        { 
            Data.Instance.upgradeLevel.strengthLevel = value;
            PlayerCharacteristics.Instance.strength = 2 + value / 2f;
            strengthLevelTMP.text = value.ToString(); 
        }
    }
    private int SizeLevel
    {
        get { return Data.Instance.upgradeLevel.sizeLevel; }
        set 
        {
            Data.Instance.upgradeLevel.sizeLevel = value;
            PlayerCharacteristics.Instance.size = 1 + value / 5f;
            sizeLevelTMP.text = value.ToString();
        }
    }
    private int OfflineEarningsLevel
    {
        get { return Data.Instance.upgradeLevel.offlineEarningsLevel; }
        set { Data.Instance.upgradeLevel.offlineEarningsLevel = value; }
    }
    private float SimpleScore
    {
        get { return Data.Instance.score.simpleScore; }
        set 
        { 
            Data.Instance.score.simpleScore = value;
            GameHelper.Instance.simpleScoreTMP.text = value.ToString(); 
        }
    }
    private void Awake()
    {
        Instance = this;
        strengthLevelTMP.text = StrengthLevel.ToString();
        sizeLevelTMP.text = SizeLevel.ToString();
        offlineEarningsLevelTMP.text = OfflineEarningsLevel.ToString();

        strengthPriceTMP.text = PriceCalculation(initialCostStrength, StrengthLevel).ToString();
        sizePriceTMP.text = PriceCalculation(initialCostSize, SizeLevel).ToString();
        offlineEarningsPriceTMP.text = PriceCalculation(initialCostOfflineEarnings, OfflineEarningsLevel).ToString();

    }
    void Start()
    {

    }

    void Update()
    {

    }
    public void BuyStrength() 
    {
        float strengthCost = PriceCalculation(initialCostStrength, StrengthLevel); // убрать

        if (SimpleScore > strengthCost)
        {        
            SimpleScore -= strengthCost;
            StrengthLevel++;

            strengthPriceTMP.text = PriceCalculation(initialCostStrength, StrengthLevel).ToString(); //Убрать

            HintDestruction.Instance.ObjectUnlock();
        }
    }
    public void BuySize()
    {
        float sizeCost = PriceCalculation(initialCostSize, SizeLevel);

        if (SimpleScore > sizeCost)
        {
            SimpleScore -= sizeCost;
            SizeLevel++;

            sizePriceTMP.text = PriceCalculation(initialCostSize, SizeLevel).ToString();

            PlayerCharacteristics.Instance.PlayerGrowth();
        }

    }
    public void BuyOfflineEarnings()
    {

    }
    private float PriceCalculation(int initialCost, int level)
    {
        return (initialCost * level * markup);
    }
}
