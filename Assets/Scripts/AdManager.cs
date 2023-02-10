using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;
    
    public static AdManager Instance;

#if UNITY_ANDROID
        private string gameId = "5157507";
#elif UNITY_IOS
        private string gameId = "5157506";
#endif
    
    private GameOverHandler gameOverHandler;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ad Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Unity Ads Error: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Unity Ad Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Ad skipped");
                break;
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(showResult), showResult, null);
        }
    }
}
