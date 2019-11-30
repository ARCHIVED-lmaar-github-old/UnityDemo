using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{
    public bool testMode = false;
    
    private string game_id = "3380334";
    private string video_id = "video";
    //private string rewarded_video_id = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(game_id, testMode);
        //Debug.Log("AD");
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.P))
        {
            PlayAd();
        }

    }

    public void PlayAd()
    {
        //Debug.Log("AD Z");

        if (Monetization.IsReady(video_id))
        {
            ShowAdPlacementContent ad = Monetization.GetPlacementContent(video_id) as ShowAdPlacementContent;

            if (ad != null) ad.Show(AdFinished);

            //Debug.Log("AD READY");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void AdFinished (ShowResult result)
    {
        Debug.Log("AD Result = " + result);
        FindObjectOfType<GameManagerScript>().RestartGame();

        /*
        // Define conditional logic for each ad completion status:
        if (result == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            Debug.Log("Ad Finished");
        }
        else if (result == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.Log("Ad Skipped");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.Log("Ad Failed");
        }
        */
    }
}
