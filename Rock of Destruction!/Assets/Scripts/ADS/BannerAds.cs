using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    public static BannerAds Instance;

    public BannerPosition bannerPosition;
    [SerializeField] private string androidAdUnitId = "Banner_Android";
    [SerializeField] private string iOSAdUnitId = "Banner_iOS";

    private string adUnitId;

    private void Awake()
    {
        Instance = this;

        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? iOSAdUnitId
            : androidAdUnitId;

        Advertisement.Banner.SetPosition(bannerPosition);

    }

    private void Start()
    {
        LoadBanner();
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        Advertisement.Banner.Load(adUnitId, options);
    }

    private void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    private void OnBannerError(string message)
    {
        Debug.Log($"Banner error: {message}");
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        Advertisement.Banner.Show(adUnitId, options);
    }

    private void OnBannerClicked()
    {

    }

    private void OnBannerShown()
    {

    }

    private void OnBannerHidden()
    {

    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}
