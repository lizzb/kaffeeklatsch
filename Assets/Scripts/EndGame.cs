using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
	Clock clock;
	CoffeeShop cafe;
	
	bool isBankrupt = false;
	bool hasWon = false;
	bool hasLost = false;

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
			isBankrupt = true; //Set bankrupt to true
		}
		if(clock.days == GameConstants.maxNumberOfDays){
			if(cafe.moneyManager.funds >= GameConstants.moneyGoalWin){ //If funds exceeds goal
				hasWon = true; //Set win to true
			} else{
				hasLost = true; //Otherwise set lost to true
			}
		}
	}
	
	void OnGUI(){
		//Call functions based on end game condition
		bankrupt(isBankrupt); 
		timeWin (hasWon);
		timeLose (hasLost);
	}
	
/*---------------------------------------------------------------------------
  Name   :  bankrupt
  Purpose:  shows end of game if user goes bankrupt
  Receive:  value whether user has gone bankrupt
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	public void bankrupt(bool bankrupt){
		
	}
	
/*---------------------------------------------------------------------------
  Name   :  timeWin
  Purpose:  shows end of game if user has gotten to goal in time allotted
  Receive:  bool whether player has won
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	public void timeWin(bool win){
		
	}
	
/*---------------------------------------------------------------------------
  Name   :  timeLose
  Purpose:  shows end of game if user hasn't gotten to goal in time allotted
  Receive:  bool whether player has lost
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	public void timeLose(bool lose){
		
	}
}

