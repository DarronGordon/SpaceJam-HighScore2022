using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class MainMenuLeaderboard : MonoBehaviour
{
     int leaderboardID = 5519;

           [SerializeField]TextMeshProUGUI playerNames;

    
    [SerializeField]TextMeshProUGUI playerScores;
    void Start()
    {
      Invoke("GetLeaderboard",1.5f);
    }

    public void GetLeaderboard(){
 StartCoroutine("FetchTopHighscoresRoutine");
    }


    public IEnumerator FetchTopHighscoresRoutine()
{
    Debug.Log("FETCHING SCORES");
    bool done = false;
    LootLockerSDKManager.GetScoreList(leaderboardID, 5, 0,(response)=>{
        if(response.success)
        {
            string tempPlayerNames = "Names\n";
            string tempPlayerScores = "Scores\n";

            LootLockerLeaderboardMember[] members = response.items;

            for(int i =0; i< members.Length;i++)
            {
                tempPlayerNames+=members[i].rank + ". ";
                if(members[i].player.name != null)
                {
                    tempPlayerNames += members[i].player.name;
                }
                else
                {
                    tempPlayerNames += members[i].player.id;
                }
                tempPlayerScores += members[i].score + "\n";
                tempPlayerNames += "\n";
            }
            done = true;
            playerNames.text = tempPlayerNames;
            playerScores.text = tempPlayerScores;
        }
        else{
            Debug.Log("Failed "+ response);
            done = true;
        }
    });
    yield return new WaitWhile(() => done == false);
}
}
