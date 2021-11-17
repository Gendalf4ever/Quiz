using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsScript : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _iOSGameId = "4456756";
    private string _androidGameId = "4456757";
    private string _video = "Interstitial_Android";
    private string _rewardedVideo = "Rewarded_Android";
    private string _banner = "Banner_Android";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_androidGameId, _testMode);

        #region Banner

        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        #endregion

    }
    public static void ShowAdsVideo(string placementID)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementID);
        }
        else
        {
            Debug.Log("Advertisement is not ready");
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(_banner);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            //действия, если реклама доступна
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
        //ошибка рекламы
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       // throw new System.NotImplementedException();
        //только запустили рекламу
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //обработка рекламы. Тут пишется про вознаграждение
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("Реклама просмотрена");
            //реклама до конца
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Реклама пропущена");
            //пропуск рекламы
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Ошибка воспроизвидения");
            //ошибка
        }
    }
}

