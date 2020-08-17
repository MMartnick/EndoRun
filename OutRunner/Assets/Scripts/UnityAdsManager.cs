using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityAdsManager : MonoBehaviour
{
    #region Instance
    private static UnityAdsManager instance;
    public static UnityAdsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UnityAdsManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned UnityAdsManager", typeof(UnityAdsManager)).GetComponent<UnityAdsManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value; 
        }
    }
    #endregion


    [Header("Config")]
        [SerializeField] private string gameId = "";
        [SerializeField] private bool testMode = true;
        [SerializeField] private string rewardVideoPlacementId;
        [SerializeField] private string regularPlacementId;

        private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Advertisement.Initialize(gameId, testMode);
    }
    public void ShowRegularAd(Action<ShowResult> callback)
    {
#if UNITY_ADS
        if (Advertisement.IsReady(regularPlacementId))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callback;
            Advertisement.Show(regularPlacementId, so);
        }
#else
        Debug.Log("Ads not supported");
#endif
    }


    public void ShowRewardedAd(Action<ShowResult> callback)
    {
#if UNITY_ADS
        if (Advertisement.IsReady(rewardVideoPlacementId))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callback;
            Advertisement.Show(rewardVideoPlacementId, so);
        }
#else
        Debug.Log("Ads not supported");
#endif
    }
}
