/*
 * CoffeeShop
 * 
 * TODO finish description
 * 
 * This class is the main... keeps track of inventory/funds, employees...
 * 
 * Notes: 
 */

using UnityEngine;
using System.Collections;

public class CoffeeShop : MonoBehaviour {
	
	// TODO ???
	// Not sure if we should have a "MoneyManager" class...
	//
	
	
	// The overall current funds of this coffee shop
	
	// This doesn't seem to be the way that Unity deals with getting variables
	// so hackyness yay
	//int funds = 0;
	//public int getFunds() { return funds; }
	
	public int funds = 0;
	
	// The popularity of this coffee shop
	// Consists of customer satisfaction + hype from ads
	int popularity = 0;
	
	// When displaying, the hype level and satisfaction should be 2 diff colors
	// in a status bar labeled "popularity"
	
	// The established/long-term customer satisfaction rating of this coffee shop
	int satisfactionRating = GameConstants.initialSatisfactionRating;
	
	// The current "hype" level for this coffee shop
	// (boosts to popularity due to advertising)
	int hypeLevel = GameConstants.initialHypeLevel;
	
	// TODO: Figure out how to determine how long "hype" lasts for,
	// especially if multiple marketing campaigns are put in place
	
	
	// List of employees working at this coffee shop
	// employees[]
	
	
	// List (expandable) of drinks that this coffee shop is capable of making
	// Based on the machinery they have and/or the recipes they offer
	// drinksMenu []
	
	
	//
	// Daily statistics - implement later if time
	// 
	
	// Money earned during 1 simulation day
	int dailyRevenue = 0;
	
	// Number of drinks sold during 1 simulation day
	int dailyNumDrinksSold = 0;
	
	
	// List for history of revenue
	// List for history of number of drinks sold
	// List for history of costs at EOD
	// List of history of satisfaction ratings at EOD
	
	//
	// Use this for initialization
	//
	
	// possibly feed in difficulty level --> different initial funds?
	void Start () {
		
		funds = GameConstants.startingFundsEasy;
		popularity = satisfactionRating + hypeLevel;
	
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
	
	}

	
/*---------------------------------------------------------------------------
  Name   :  calculateDailyCosts
  Purpose:  Calculate the costs for one day of simulation
  Receive:  none, uses internal variables
  Return :  costs for the day
---------------------------------------------------------------------------*/	
	int calculateDailyCosts()
	{
		// Include rent
		
		// Calculate sum of paying all employees
		
		// Prices of ingredients/stock?
		
		
		return 0;
	}

/*---------------------------------------------------------------------------
  Name   :  EODreport (displayEODReport somewhere else....?)
  Purpose:  Produce an end-of-day report and update coffee shop variables
  Receive:  none, uses internal variables
  Return :  void
---------------------------------------------------------------------------*/	
	void EODreport()
	{
		// don't need to add revenue to funds,
		// since they are added at time of sale
		
		// deduct daily costs
		funds -= calculateDailyCosts();
		
		// Update cafe popularity (both satisfaction and hype)
		// ...
	}
	
	
	
	
	
	// TODO: ???
	// not sure if next 2 functions are better in a "employeemanager" class
	// or here... or within employees?
	
	
/*---------------------------------------------------------------------------
  Name   :  sellDrink (drinkTransaction?? sellDrink? transaction??)
  Purpose:  Take money from a customer (add to cafe funds)
  Receive:  the customer that order, and the drink they ordered
  Return :  true if the sale was successful
---------------------------------------------------------------------------*/
	bool sellDrink (Customer c, GameConstants.Drinks drink)
	{
		
		// possibly determine if we have the ingredients necessary?
		
		// determine the price of the drink requested
		int drinkPrice = 1; //GameConstants.getPrice... have constant for prices? function?
		// not sure yet best way to do this
		// also if drink is just an enum then possibly easier
		
		
		// dailyRevenue += drinkPrice;
		// dailyNumDrinksSold++;
		
		// increase shop funds by price of drink requested
		funds += drinkPrice;
		
		
		// Set the time of transaction for this customer to current time
		// c.transactionTime = now
		
		
		// Would like to trigger animation to show money earned displayed, floating up
		
		
		// for now, all transactions assumed to be successful
		return true;
	}
	
/*---------------------------------------------------------------------------
  Name   :  makeDrink
  Purpose:  Choose an employee to make specified drink
  			Assume customer will wait and pick up their correct drink
  Receive:  the drink ordered
  Return :  true if the drink was made successfully (?? void?)
---------------------------------------------------------------------------*/
	bool makeDrink (GameConstants.Drinks drink)	
	{
		// Check if one of your employees is free
		
		// If not, add job to job queue for next free employee to take
		
		// TODO: ??? will this cause a problem if there are 2 people in line,
		// and only 1 employee, then they take all orders first and then make them all?
		// actually maybe not...
		
		// Not sure how to handle it from here....
		
		return true;
	}
	
}
