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
		if(cafe.moneyManager.funds <= 0){
			isBankrupt = true;
		}
		if(clock.days == 6){
			if(cafe.moneyManager.funds >= GameConstants.moneyGoalWin){
				hasWon = true;
			} else{
				hasLost = true;
			}
		}
	}
	
	void OnGUI(){
		bankrupt(isBankrupt);
		timeWin (hasWon);
		timeLose (hasLost);
	}
	
	public void bankrupt(bool bankrupt){
		
	}
	
	public void timeWin(bool win){
		
	}
	
	public void timeLose(bool lose){
		
	}
}

