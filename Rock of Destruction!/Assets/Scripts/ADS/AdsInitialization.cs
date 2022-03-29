using UnityEngine;
using UnityEngine.Advertisements;


public class AdsInitialization : MonoBehaviour, IUnityAdsInitializationListener /*, IUnityAdsLoadListener*/
{
    [SerializeField] private string androidGameId = "4681259";
    [SerializeField] private string iOSGameId = "4681258";
    [SerializeField] private bool testMode = true;

    private string gameId;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) 
            ? iOSGameId 
            : androidGameId;

        //Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization complete!: {error} - {message}");
    }
}
