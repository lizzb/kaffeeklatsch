using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {
	
	CoffeeShop cafe;
	
	// TODO ???Not sure if we should have a "MoneyManager" class...
	
	// TODO: make sure you can't purchase things that will make you go into debt
	// however, paying your employees at end of day CAN make you go into debt
	// then you lose
	
	
	// Common good practice is to have private member variables and public getters/setters
	// However, this doesn't seem to be the way that Unity deals with variables like these
	// so hackyness yay
	//int funds = 0;
	//public int getFunds() { return funds; }
	
	// The overall current funds of this coffee shop
	public int funds;
	
	
	// ----- Daily statistics ----- //
	
	// Money earned during 1 simulation day
	public int dailyRevenue = 0;
	
	// Number of drinks sold during 1 simulation day
	public int dailyNumDrinksSold = 0;
	
	
	// List for history of revenue
	// List for history of number of drinks sold
	// List for history of costs at EOD
	// List of history of satisfaction ratings at EOD
	
	
	// The daily rent for this coffee shop
	// Didn't get to implementing functionality where this is very meaningful
	public int rent; 
	
	// Initial Cost of Drink
	public int drinkCost = GameConstants.initialDrinkCost; 
	
	public void setDrinkCost(int cost) { drinkCost = cost; }
	
	// Use this for initialization
	void Start ()
	{
		// Grabs the CoffeeShop class (only once!)
		cafe = GameObject.FindGameObjectWithTag("GameController").GetComponent<CoffeeShop>();
		
		// possibly feed in difficulty level --> different initial funds?
		rent = GameConstants.startingRent;
		funds = GameConstants.startingFundsEasy;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
/*---------------------------------------------------------------------------
  Name   :  sellDrink (drinkTransaction?? sellDrink? transaction??)
  Purpose:  Take money from a customer (add to cafe funds)
  Receive:  the drink ordered by a customer
  Return :  true if the sale was successful
  			always true for now, since this class/functionality
  			strictly deals with money and stats
---------------------------------------------------------------------------*/
	public bool sellDrink (GameConstants.Drinks drink) //(Customer c, GameConstants.Drinks drink)
	{
		
		/* Out of scope:
		// possibly determine if we have the ingredients necessary?
		
		// determine the price of the drink requested
		// not sure yet best way to do this
		// also if drink is just an enum then possibly easier
		*/
		
		// Add drink sale to daily revenue tracker and daily drink/customer count
		dailyRevenue += drinkCost;
		dailyNumDrinksSold++;
		
		// increase shop funds by price of drink requested
		funds += drinkCost;
		
		
		// for now, all transactions assumed to be successful
		return true;
	}
	
/*---------------------------------------------------------------------------
  Name   :  calculateDailyCosts
  Purpose:  Calculate the costs for one day of simulation
  			(doesn't acutally remove them from store funds!)
  Receive:  none, uses internal variables
  Return :  costs for the day
---------------------------------------------------------------------------*/	
	public int calculateDailyCosts()
	{
		int totalDailyCosts = 0;
		
		// Include rent
		totalDailyCosts += rent;
		
		// Calculate sum of paying all employees for this day
		totalDailyCosts += calculateDailyTotalEmployeesWagesTotal();
		
		// Prices of ingredients/stock?
		
		return totalDailyCosts;
		//return GameConstants.startingRent + GameConstants.wageNovice;
	}

/*---------------------------------------------------------------------------
  Name   :  calculateDailyEmployeesWagesTotal
  Purpose:  To calculate the wages of all employees
  Receive:  All internal variables
  Return :  the cost of paying wages to all employees for a particular day
---------------------------------------------------------------------------*/
	public int calculateDailyTotalEmployeesWagesTotal() // might make an employeemanager class for keeping track of this stuff...
	{
		int total = 0;
		foreach(Employee e in cafe.empManager.employees)
		{
			total += e.getPayrate();
		}
		// For each employee in the list of employees
		// determine what their daily pay rate is
		// sum it all up
		// and return it
		// (another function actually takes it from shop funds)
		return total;
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  EODreport (displayEODReport somewhere else....?)
  Purpose:  Produce an end-of-day report and update coffee shop variables
  Receive:  none, uses internal variables
  Return :  void
---------------------------------------------------------------------------*/	
	public void EODreport()
	{
		// don't need to add revenue to funds,
		// since they are added at time of sale
		
		// Display costs spent on employee wages
		// Display costs spent on rent
		
		// deduct daily costs
		funds -= calculateDailyCosts();
		
		// Update cafe popularity (both satisfaction and hype)
		// ...
		
		//Reset counters
		dailyRevenue = 0;
		dailyNumDrinksSold = 0;
	}
	
	public int getMachineCost(int coffeeMachineLevel)
	{
		int cost = 0;
		switch (coffeeMachineLevel)
		{
			case 1:
				cost = GameConstants.coffeeMachine1Cost;
				break;
			case 2:
				cost = GameConstants.coffeeMachine2Cost;
				break;
			case 3:
				cost = GameConstants.coffeeMachine3Cost;
				break;
			case 4:
				cost = GameConstants.coffeeMachine4Cost;
				break;
			default:
				cost = -1;
				break;
				//return false;
			//break;
		}
		return cost;
	}
	
	
public bool canAffordMachine(int coffeeMachineLevel)
	{
		int cost = getMachineCost(coffeeMachineLevel);
		
		// cost might return false, so be careful
		// change to -1
		if (cost != -1)
			return (funds >= cost); 
		return false;
	}
	
public void buyCoffeeMachine(int coffeeMachineLevel)
	{
		funds -= getMachineCost(coffeeMachineLevel); // cost; //coffeeMach.getCost(); // Decrease funds
		switch (coffeeMachineLevel)
		{
			case 1: cafe.hasMachine1 = true; break;
			case 2: cafe.hasMachine2 = true; break;
			case 3: cafe.hasMachine3 = true; break;
			case 4: cafe.hasMachine4 = true; break;
			default:
				break;
		}
		
	}
	
	
public int getDecorationCost(int decorationLevel)
	{
		int cost = 0;
		switch (decorationLevel)
		{
			case 1:
				cost = GameConstants.decoration1Cost;
				break;
			case 2:
				cost = GameConstants.decoration2Cost;
				break;
			case 3:
				cost = GameConstants.decoration3Cost;
				break;
			case 4:
				cost = GameConstants.decoration4Cost;
				break;
			default:
				cost = -1;
				break;
				//return false;
			//break;
		}
		return cost;
	}
	
	
public bool canAffordDecoration(int decorationLevel)
	{
		int cost = getDecorationCost(decorationLevel);
		
		// cost might return false, so be careful
		// change to -1
		if (cost != -1)
			return (funds >= cost); 
		return false;
	}
	
public void buyDecoration(int decorationLevel)
	{
		funds -= getDecorationCost(decorationLevel); // Decrease funds
		switch (decorationLevel)
		{
			case 1: cafe.hasDecoration1 = true; break;
			case 2: cafe.hasDecoration2 = true; break;
			case 3: cafe.hasDecoration3 = true; break;
			case 4: cafe.hasDecoration4 = true; break;
			default:
				break;
		}
		
	}
}
