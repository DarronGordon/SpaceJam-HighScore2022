using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameCtrl : MonoBehaviour
{
     public static GameCtrl instance;

[SerializeField]TMP_InputField playerNameInputField;
    private void Awake() {
    if(instance==null)
    {
        instance=this;
    }
    else{
        Destroy(gameObject);
    }
        DontDestroyOnLoad(gameObject);
 }

  void Start()
    {
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


 public void SetPlayerName()
   {
    LootLockerSDKManager.SetPlayerName(playerNameInputField.text,(response)=>
    {
        if(response.success){
            Debug.Log("successfully set player name");
        }
        else 
        {
            Debug.Log("Could not set player name " + response.Error);
        }
    });
   }

 public void GameOver()
 {
    
ScoreCtrl.instance.SubmitScoreRoutine();

PlayerCtrl.instance.gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
 }

 public void LoadAScene(string name) {
    {
     SceneManager.LoadScene(name);
    }
 }
}
