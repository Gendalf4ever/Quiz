using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAds : MonoBehaviour, IUnityAdsListener
{

    [SerializeField] private bool _testMode = true;
    [SerializeField] private Button _adsButton;
    private string _androidGameId = "4456757";
    private string _rewardedVideo = "Rewarded Android";

    void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);
        if (_adsButton)
            _adsButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(_androidGameId, true);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo);
    }

    public void OnUnityAdsDidError(string message)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
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

    public void OnUnityAdsDidStart(string placementId)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            _adsButton.interactable = true; //и другие действия
        }
    }

    
}
