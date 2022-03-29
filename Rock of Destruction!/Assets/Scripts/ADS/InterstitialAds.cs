using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InterstitialAds Instance;

    [SerializeField] private string androidAdUnitId = "Interstitial_Android";
    [SerializeField] private string iOSAdUnitId = "Interstitial_iOS";

    private string adUnitId;

    private int adsPersent;

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

    public void ViewAdsProbability(int persentShowAds)
    {
        adsPersent = Random.Range(0, 100);

        if (adsPersent < persentShowAds)
        {
            ShowAd();
        }
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
    }
}
