using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{
    private string game_id = "3380334";
    private string video_id = "video";
    //private string rewarded_video_id = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        Monetization.Initialize(game_id, false);
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

            if (ad != null) ad.Show();

            //Debug.Log("AD READY");
        }
    }
}
