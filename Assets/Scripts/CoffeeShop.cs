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
	
	// Manages employees.... more later ****
	public EmployeeManager empManager;
	
	//CoffeMakers
	public CoffeeMachine coffeeMachine;
	
	//CoffeeMachine coffeeMakerLevel1;
	//CoffeeMachine coffeeMakerLevel2;
	//CoffeeMachine coffeeMakerLevel3;
	//CoffeeMachine coffeeMakerLevel4;
	
	
	// TODO ???
	// Not sure if we should have a "MoneyManager" class...
	//
	
	// TODO: make sure you can't purchase things that will make you go into debt
	// however, paying your employees at end of day CAN make you go into debt
	
	
	
	// Common good practice is to have private member variables and public getters/setters
	// However, this doesn't seem to be the way that Unity deals with variables like these
	// so hackyness yay
	//int funds = 0;
	//public int getFunds() { return funds; }
	
	// The overall current funds of this coffee shop
	public int funds;
	
	// The established/long-term customer satisfaction rating of this coffee shop
	public int satisfactionRating;
	
	// The current "hype" level for this coffee shop
	// (boosts to popularity due to advertising)
	public int hypeLevel;
	
	// The popularity of this coffee shop
	// Consists of customer satisfaction + hype from ads
	public int popularity;
	
	// The daily rent for this coffee shop
	// .....not sure if we'll get to implementing functionality requiring this
	public int rent; 

	
	// TODO: Figure out how to determine how long "hype" lasts for,
	// especially if multiple marketing campaigns are put in place
	
	
	// List (expandable) of drinks that this coffee shop is capable of making
	// Based on the machinery they have and/or the recipes they offer
	// drinksMenu []
	
	//Initial Cost of Drink
	public int drinkCost = GameConstants.initialDrinkCost; 
	
	//
	// Daily statistics - implement later if time
	// 
	
	// Money earned during 1 simulation day
	public int dailyRevenue = 0;
	
	// Number of drinks sold during 1 simulation day
	public int dailyNumDrinksSold = 0;
	
	
	// List for history of revenue
	// List for history of number of drinks sold
	// List for history of costs at EOD
	// List of history of satisfaction ratings at EOD
	
	//Variables to simulate drink making, will probably go away with employees
	private float time = 0;
	
	//
	// Use this for initialization
	//
	void Start () {
		
		// possibly feed in difficulty level --> different initial funds?
		
		rent = GameConstants.startingRent;
		
		// Initialize all starting variables
		funds = GameConstants.startingFundsEasy;
		satisfactionRating = GameConstants.initialSatisfactionRating;
		hypeLevel = GameConstants.initialHypeLevel;
		popularity = satisfactionRating + hypeLevel;
		
		empManager = GameObject.FindGameObjectWithTag("GameController").AddComponent<EmployeeManager>(); //(this);
		coffeeMachine = GameObject.FindGameObjectWithTag("GameController").AddComponent<CoffeeMachine>(); //Coffee Machine
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
		// Detect if customer is ready to buy drink
		takeCustomerOrder();
		
		// updatePopularity();
		// update satisfaction and update hype called elsewhere
		popularity = satisfactionRating + hypeLevel;
		
		// --- Hacks for augmenting funds and popularity --- //
		if(Input.GetKeyDown(KeyCode.M)) { funds += drinkCost; }
		
		if(Input.GetKeyDown (KeyCode.N)) { funds -= drinkCost; }
		
		if(Input.GetKeyDown(KeyCode.P)) { hypeLevel += 10; }
		
		if(Input.GetKeyDown(KeyCode.O)){ hypeLevel -= 10; }
		
		//Take 3 seconds to make drink
		if(coffeeMachine.inUse)
		{
			time += Time.deltaTime;
			//print (time);
			if(time > GameConstants.timeToMakeCoffee)
			{
				sellDrinkToCustomer(); //Sell drink to customer
				time = 0;
			}
		}
		
	}

	
	
// shop.updateCustomerSatisfaction(calculateSatisfactionLevel());	
/*---------------------------------------------------------------------------
  Name   :  updateSatisfaction
  Purpose:  
  Receive:  satisfaction rating from a customer
  Return :  void
---------------------------------------------------------------------------*/
	public void updateCustomerSatisfaction(int custSatisfaction)
	{
		satisfactionRating += custSatisfaction;
	}

/*---------------------------------------------------------------------------
  Name   :  updateHype
  Purpose:  
  Receive:  hype level from an advertising campaign
  Return :  void
---------------------------------------------------------------------------*/
	public void updateHype(int hype)
	{
		hypeLevel += hype;
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
		foreach(Employee e in empManager.employees)
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
		hypeLevel = GameConstants.initialHypeLevel;
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
		
		// An employee must be at the cash register to take the order
		
		// possibly determine if we have the ingredients necessary?
		
		// determine the price of the drink requested
		// not sure yet best way to do this
		// also if drink is just an enum then possibly easier
		
		// Add drink sale to daily revenue tracker and daily drink/customer count
		dailyRevenue += drinkCost;
		dailyNumDrinksSold++;
		
		// increase shop funds by price of drink requested
		funds += drinkCost;
		
		
		// Set the time of transaction for this customer to current time
		// c.transactionTime = now
		
		
		// Would like to trigger animation to show money earned displayed, floating up
		
		c.setPaidForDrink(true);
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

	
/*---------------------------------------------------------------------------
  Name   :  buyAdvertisement
  Purpose:  Buying advertisement to shop in order to increase hype
  Receive:  The Advertisement to be purchased
  Return :  Return true if shop has enough money to buy, false if not enough
---------------------------------------------------------------------------*/	
	public bool buyAdvertisement(Advertisement ad)
	{
		if(funds > ad.getCost()) //If advertisement costs less than available funds
		{
			funds -= ad.getCost(); //Decrease funds
			updateHype(ad.getHype()); //hypeLevel += ad.getHype(); //Increase hype
			return true;
		}
		return false;
	}



	
	public void setDrinkCost(int cost) { drinkCost = cost; }
	
	
/*---------------------------------------------------------------------------
  Name   :  sellDrinkToCustomer
  Purpose:  Selling a drink to customer in front of line
  Receive:  Nothing, use internal variables
  Return :  void
---------------------------------------------------------------------------*/	
	public void sellDrinkToCustomer()
	{
		foreach(Customer c in GameObject.FindObjectsOfType(typeof(Customer)))
		{
			if(c.isFrontOfLine()) // If customer is in front of line
			{ 
				Employee e = empManager.findWorkingEmployee(); //Find working employee
				if(e != null)
				{
					sellDrink (c,GameConstants.Drinks.PlainCoffee); // Sell drink to customer
					c.custAction = Customer.Actions.walkingOut; // bug fix = 0 //3; // Set customer action to leaving shop...
					// *** not waiting for coffee???? TODO
					coffeeMachine.inUse = false; // Stop incrementing drink
					e.setAction(Employee.Actions.Nothing); //set employee to doing nothing
				}
			}
		}
	}

/*---------------------------------------------------------------------------
  Name   :  takeCustomerOrder
  Purpose:  Take customer order from front of line
  Receive:  Nothing, use internal variables
  Return :  void
---------------------------------------------------------------------------*/	
	public void takeCustomerOrder()
	{
		foreach(Customer c in GameObject.FindObjectsOfType(typeof(Customer)))
		{
			if(c.isFrontOfLine())
			{
				Employee e = empManager.findAvailableEmployee(); //Find next available employee
				if(e != null)
				{
					coffeeMachine.inUse = true;
					e.setAction(Employee.Actions.MakingDrink); //Set employee to making drink
				}
			}
		}
	}

/*---------------------------------------------------------------------------
  Name   :  buyCoffeeMachine
  Purpose:  Buy and add a new coffee machine to the shop
  Receive:  Coffee Machine Level / (enum??? not sure???) to buy
  Return :  true if purchase was successful,
  			false if machine not bought (insufficient funds or reach limit)
---------------------------------------------------------------------------*/	
	public bool buyCoffeeMachine(CoffeeMachine coffeeMach) //(int coffeeMachineLevel)
	{
		if(funds > coffeeMach.getCost()) //If advertisement costs less than available funds
		{
			funds -= coffeeMach.getCost(); // Decrease funds
			coffeeMach.isPurchased = true;
			return true;
		}
		
		// insufficient funds - NOTIFY USER
		return false;
		
	}
}
