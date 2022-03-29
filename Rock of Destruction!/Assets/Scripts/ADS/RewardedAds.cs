using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAds Instance;

    [SerializeField] private string androidAdUnitId = "Rewarded_Android";
    [SerializeField] private string iOSAdUnitId = "Rewarded_iOS";

    private string adUnitId;

    //internal (float, float, float) adBonus;
    internal (float bonusValue, float coefficient, float value) adBonus;
    //internal float value;
    //internal float bonusValue;
    //internal float coefficient;


    private void Awake()
    {
        Instance = this;

        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSAdUnitId
            : androidAdUnitId;
       
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        // ��������� �������

        Debug.Log("Loading Ad:" + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    public void ShowAd()
    {
        // ���������� �������

        Debug.Log("Showing Ad:" + adUnitId);
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // ������� ��������� � ������ � ������

        Debug.Log($"Loading ad Unit successfully: {adUnitId}");
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        // ������� �� ������� �����������

        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        // ��������� ������ ������ �������
        Debug.Log($"Error showing Ad Unit: {adUnitId} - {error} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId)
    {
        // ������ ������ �������
        LoadAd();
    }

    public void OnUnityAdsShowClick(string adUnitId)
    {
        // ���� �� �������
    }

    public void OnUnityAdsShowComplete(string adUnitId /*placementId*/, UnityAdsShowCompletionState showCompletionState)
    {
        // ��������� ��������� �������
        if (adUnitId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads rewarded ad completed!");

            //adBonus.Item3 += adBonus.Item1 * adBonus.Item2;
            Data.Instance.score.donatScore += adBonus.bonusValue * adBonus.coefficient;
            //Data.Instance.score.donatScore += adBonus.bonusValue * adBonus.coefficient;
            //value += bonusValue * coefficient;
        }
    }
}
