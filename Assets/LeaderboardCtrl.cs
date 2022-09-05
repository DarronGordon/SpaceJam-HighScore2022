using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardCtrl : MonoBehaviour
{

    public static LeaderboardCtrl instance;
    private void Awake() {
    if(instance==null)
    {
        instance=this;
                LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }
    else{
        Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
 }
    void Start()
    {

    }


}
