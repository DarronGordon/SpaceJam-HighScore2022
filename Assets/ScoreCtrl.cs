using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class ScoreCtrl : MonoBehaviour
{
    int leaderboardID = 5519;
    public static ScoreCtrl instance;
    float score;
    int scoreInt;




    [SerializeField]TextMeshProUGUI scoreTxt;

    
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

 
    private void Start() {
        score=0f;
    }
    void Update()
    {
          if(score<PlayerCtrl.instance.gameObject.transform.position.y){
                  score = PlayerCtrl.instance.gameObject.transform.position.y;
        }
        else{
            return;
        }
    
       scoreInt = Mathf.RoundToInt(score);
       scoreTxt.text=scoreInt.ToString();
            Debug.Log(PlayerCtrl.instance.gameObject.transform.position.y);
       Debug.Log(scoreInt);
    }

    public int GetScore(){
        return scoreInt;
    }
  
 public void SubmitScoreRoutine()
 {
   

string memberID = name;


LootLockerSDKManager.SubmitScore(memberID, scoreInt, leaderboardID, (response) =>
{
    if (response.statusCode == 200) {
        UnityEngine.Debug.Log("Successful");
    } else {
        UnityEngine.Debug.Log("failed: " + response.Error);
    }
});

 }

 
}
