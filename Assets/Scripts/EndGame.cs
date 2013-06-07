using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
	Clock clock;
	CoffeeShop cafe;
	
	enum EndGameType {None,Bankruptcy,TimeWin,TimeLose}
	
	EndGameType currentEndGameType = EndGameType.None;
	

	// Use this for initialization
	void Start ()
	{
		clock = GameObject.Find("GUI").GetComponent<Clock>();
		cafe = GameObject.FindGameObjectWithTag("GameController").GetComponent<CoffeeShop>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(cafe.moneyManager.funds <= 0){ //If funds falls below 0
			currentEndGameType = EndGameType.Bankruptcy;//Set bankruptcy
		}
		if(clock.days == GameConstants.maxNumberOfDays){
			if(cafe.moneyManager.funds >= GameConstants.moneyGoalWin){ //If funds exceeds goal
				currentEndGameType = EndGameType.TimeWin; //Set win
			} else{
				currentEndGameType = EndGameType.TimeLose; //Otherwise set lost
			}
		}
	}
	
	void OnGUI(){
		//Call functions based on end game condition
		displayEndGameScreen(currentEndGameType);
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayEndGameScreen
  Purpose:  Shows end game screen depending on condition
  Receive:  condition that ended game
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void displayEndGameScreen(EndGameType type){
		if(type == EndGameType.None){
			return;
		}
		clock.pause();
		const int endGameX = 200;
		const int endGameY = 100;
		int endGameW = Screen.width - 400;
		int endGameH = Screen.height - 200;
		
		GUI.Window((int)type,new Rect(endGameX,endGameY,endGameW,endGameH),EndGameWindow,"Game Over!");
	}

	
/*---------------------------------------------------------------------------
  Name   :  EODWindow
  Purpose:  displays end of day report
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void EndGameWindow(int windowID){
		int windowPaddingX = 5;
		int y = 20;
		int w = Screen.width - 400 - windowPaddingX * 2;
		int h = 20;
		
		string endGameText = "";
		
		switch(windowID){
		case 1:
			endGameText = "You have gone Bankrupt! You Lose!";
			break;
		case 2:
			endGameText = "You've made " + GameConstants.moneyGoalWin + " in " + (GameConstants.maxNumberOfDays - 1) + "! You Win!";
			break;
		case 3:
			endGameText = "You've only made " + cafe.moneyManager.funds + " in " + (GameConstants.maxNumberOfDays - 1) + "! You Lose!";
			break;
		}
		
		GUI.Label (new Rect(windowPaddingX,y,w,h),endGameText);

		/*
		// If click on advance day button
		if(GUI.Button(new Rect(windowPaddingX, eodWindowH - y * 2,w,h),"Advance Day"))
		{ 
			clock.advanceDay(); //Advances day
		}
		*/
	}
}

