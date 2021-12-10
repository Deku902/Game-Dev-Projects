using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

public int scoreToWin;
public int curScore;

public bool gamePaused;
//instance of Game Manager
public static GameManager instance;

void awake()
{
    //set the instance of this script
    instance = this;

}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
{
    gamePaused = !gamePaused;
    Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

    //Toggle Pause Menu
    GameUI.instance.TogglePauseMenu(gamePaused);
     
}

   public void AddScore(int score)
   {
       curScore += score;
       
       //Update Score Text
       GameUi.Instance.UpdateScoreText(curScore);

       //Have we reached the score to win?
       if(curScore >= socreToWin)
           WinGame();
   }


   public void WinGame();
   {
       //Set endgame screen
       GameUI.instance.SetEndGameScreen(true,curScore);
   }
}


