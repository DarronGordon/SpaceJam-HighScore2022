using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class GameOverPanelCtrl : MonoBehaviour
{  
  
   int currentscore;
   string currentName;

   [SerializeField]TextMeshProUGUI playerScore;
   [SerializeField]TextMeshProUGUI playerName;
    void Start()
    {
        currentscore = ScoreCtrl.instance.GetScore();

        playerName.text = currentName+" RIP";
        playerScore.text = "Score: "+currentscore.ToString();

    }
       

}
