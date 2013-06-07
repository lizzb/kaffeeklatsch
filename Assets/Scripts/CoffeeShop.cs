/*
 * CoffeeShop
 * 
 * TODO finish description
 * 
 * This class is the main... keeps track of inventory/funds, employees...
 * 
 * Notes: 
 * Out of scope due to time:
 * 	// List (expandable) of drinks that this coffee shop is capable of making
	// Based on the machinery they have and/or the recipes they offer
	// drinksMenu []
	
	// Would like to trigger animation to show money earned displayed, floating up
 */

using UnityEngine;
using System.Collections;

public class CoffeeShop : MonoBehaviour {
	
	// Clock
	Clock clock;
	
	// Manages employees.... more later ****
	public EmployeeManager empManager;

	// Manages all money stuff for this coffee shop
	public MoneyManager moneyManager;
	
	// CoffeeMachines
	public CoffeeMachine coffeeMachine; // reevaluate later
	
	// Scripts associated with the coffee machine models
	// i.e. where all the functionality actually is
	public CoffeeMachine coffeeM1; 
	public CoffeeMachine coffeeM2; 
	public CoffeeMachine coffeeM3; 
	public CoffeeMachine coffeeM4; 


	
	// List of Advertisements bought
	public ArrayList advertisements;
	
	
	// --------------- POPULARITY variables --------------- //

	
	// The established/long-term customer satisfaction rating of this coffee shop
	public int satisfactionRating;
	
	// The current "hype" level for this coffee shop
	// (boosts to popularity due to advertising)
	public int hypeLevel;
	
	// The popularity of this coffee shop
	// Consists of customer satisfaction + hype from ads
	public int popularity;


	
	// Variables to simulate drink making, will probably go away with employees
	private float time = 0;
	
	

	
	//
	// Use this for initialization
	//
	void Start ()
	{
		empManager = GameObject.FindGameObjectWithTag("GameController").AddComponent<EmployeeManager>(); //(this);
		moneyManager = GameObject.FindGameObjectWithTag("GameController").AddComponent<MoneyManager>(); //(this);


		// Initialize all starting variables
		satisfactionRating = GameConstants.initialSatisfactionRating;
		hypeLevel = GameConstants.initialHypeLevel;
		popularity = satisfactionRating + hypeLevel;
		
		advertisements = new ArrayList();
		
		clock = GameObject.Find("GUI").GetComponent<Clock>();
		

		
		// original hack by KG for one machine
		//coffeeMachine = GameObject.FindGameObjectWithTag("GameController").AddComponent<CoffeeMachine>(); //Coffee Machine
		
		// By default, Instantiate makes an object, so cast to GameObject
		//coffeeMachineModel1 = (GameObject)Instantiate(Resources.Load("CoffeeMachine1"), new Vector3(16.13379f, -3.482452f, 6.18842f), Quaternion.identity);
		//cm1script =//coffeeMachine = GameObject.FindGameObjectWithTag("GameController").AddComponent<CoffeeMachine>(); //Coffee Machine
		
		
		// TODO: ***
		// need to figure out a better way to update
		// which coffee machine will be used for dirnk making...
		addCoffeeMachine(1);
		coffeeMachine = coffeeM1; 
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		// FIX THIS ******
		// lizz's bad attempt to get the best coffee machine to be the one used by default
		if (coffeeM2 != null) coffeeMachine = coffeeM2; 
		if (coffeeM3 != null) coffeeMachine = coffeeM3; 
		if (coffeeM4 != null) coffeeMachine = coffeeM4; 
		
		// Detect if customer is ready to buy drink
		takeCustomerOrder();
		
		// updatePopularity();
		// update satisfaction and update hype called elsewhere
		popularity = satisfactionRating + hypeLevel;
		
		updateHypeLength();
		
		//Take 3 seconds to make drink
		if(coffeeMachine!= null && coffeeMachine.inUse)
		{
			time += clock.deltaTime;
			
			if(time > coffeeMachine.calculateDrinkSpeed())
			{
				customerTransaction(); //sellDrinkToCustomer(); //Sell drink to customer
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
	
	
		// TODO: Figure out how to determine how long "hype" lasts for,
	// especially if multiple marketing campaigns are put in place
	
/*---------------------------------------------------------------------------
  Name   :  updateHypeLength
  Purpose:  update length of hype for advertisements at the end of day
  Receive:  nothing
  Return :  void
---------------------------------------------------------------------------*/
	void updateHypeLength()
	{
		ArrayList deleteAds = new ArrayList();
		
		foreach(Advertisement ad in advertisements)
		{
			if(ad.hypeEnd)
			{ //If hypelength
				hypeLevel -= ad.getHype(); //Decrease hype level
				deleteAds.Add(ad); //Add it to delete list
			}
		}
		
		// Need delete list so that you don't delete while looping through list
		foreach(Advertisement ad in deleteAds)
		{
			advertisements.Remove(ad); //delete from advertisement list
			Destroy (ad);
		}
	}
	
	
	

	

/*---------------------------------------------------------------------------
  Name   :  EODreport (displayEODReport somewhere else....?)
  Purpose:  Produce an end-of-day report and update coffee shop variables
  Receive:  none, uses internal variables
  Return :  void
---------------------------------------------------------------------------*/	
	public void EODreport()
	{
		moneyManager.EODreport();
	}
	
	


public bool customerWaitingAtRegister()
	{
		// Check all of customers in coffee shop
		// to determine if someone is at front of line
		foreach(Customer c in GameObject.FindObjectsOfType(typeof(Customer)))
		{
			if(c.isFrontOfLine()) return true;
		}
		
		return false;
		
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
				Employee e = empManager.findAvailableEmployee(); // Find next available employee
				if(e != null)
				{
					coffeeMachine.inUse = true;
					e.setAction(Employee.Actions.MakingDrink); // Set employee to making drink
				}
			}
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  customerTransaction <-- sellDrinkToCustomer
  Purpose:  Selling a drink to customer in front of line
  Receive:  Nothing, use internal variables
  Return :  void
---------------------------------------------------------------------------*/	
	public void customerTransaction() //sellDrinkToCustomer()
	{
		// Check all of customers in coffee shop
		// to determine if someone is at front of line
		// if so, then take their order
		foreach(Customer c in GameObject.FindObjectsOfType(typeof(Customer)))
		{
			if(c.isFrontOfLine()) // If customer is in front of line
			{ 
				// Out of scope:
				// An employee must be at the cash register to take the order
				// Find working employee
				Employee e = empManager.findWorkingEmployee(); 
				if(e != null)
				{
					// Out of scope:
					// Determine what drink the customer wants
					// Determine if we have the ingredients (possibly equipment?) to make drink
					
					// Assume all customers have funds required to buy their desired drink
					// and WILL buy a drink, regardless if they think it is overpriced
					
					//sellDrink (c,GameConstants.Drinks.PlainCoffee); // Sell drink to customer
					
					// for now, customers only order one thing
					moneyManager.sellDrink(GameConstants.Drinks.PlainCoffee);
					
					
					
					// Out of Scope:
					// Set the time of transaction for this customer to current time
					// c.transactionTime = now
					// then have the customer wait for their coffee at end of counter
					// Instead...
					
					c.setPaidForDrink(true);
					// Set customer action to leaving shop
					c.custAction = Customer.Actions.walkingOut; 
					
					coffeeMachine.inUse = false; // Stop incrementing drink
					
					e.setAction(Employee.Actions.Nothing); //set employee to doing nothing
				}
			}
		}
	}

	
	// TODO: ???
	// not sure if next 2 functions are better in a "employeemanager" class
	// or here... or within employees?
	
	

	
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
  Name   :  buyObject
  Purpose:  
  Receive:  
  Return :  true if purchase was successful, false otherwise
---------------------------------------------------------------------------*/	

	
/*---------------------------------------------------------------------------
  Name   :  buyAdvertisement
  Purpose:  Buying advertisement to shop in order to increase hype
  Receive:  The Advertisement to be purchased
  Return :  Return true if shop has enough money to buy, false if not enough
---------------------------------------------------------------------------*/	
	public bool buyAdvertisement(Advertisement.AdvertisementType adType,int cost)
	{
		if(moneyManager.funds > cost) //If advertisement costs less than available funds
		{
			Advertisement ad = gameObject.AddComponent<Advertisement>();
			ad.setType(adType);
			advertisements.Add(ad);
			moneyManager.funds -= ad.getCost(); //Decrease funds
			updateHype(ad.getHype()); //hypeLevel += ad.getHype(); //Increase hype
			return true;
		}
		return false;
	}

/*---------------------------------------------------------------------------
  Name   :  buyCoffeeMachine
  Purpose:  Buy and add a new coffee machine to the shop
  Receive:  Coffee Machine Level / (enum??? not sure???) to buy
  Return :  true if purchase was successful,
  			false if machine not bought (insufficient funds or reach limit)
---------------------------------------------------------------------------*/	
	public bool buyCoffeeMachine(int coffeeMachineLevel)
	//(CoffeeMachine coffeeMac, int coffeeMachineLevel) //(CoffeeMachine coffeeMach) //
	{
		// check if player does not already ahve this object!!
		//if they have the object, don't allow to buy another one - return false and notify user?
		// otherwise, move onto next if statement
		
		
		
		
		// Player can afford to buy selected item
		if(moneyManager.canAffordMachine(coffeeMachineLevel)) //funds >= cost) //coffeeMach.getCost()) 
		{
			moneyManager.buyCoffeeMachine(coffeeMachineLevel); //funds -= cost; //coffeeMach.getCost(); // Decrease funds
			//coffeeMach.isPurchased = true;
			addCoffeeMachine (coffeeMachineLevel);
			return true;
		}
		
		// insufficient funds - NOTIFY USER TODO *****
		else
		{
			
			return false;
		}
		
		
		
	}
	
	
	
/*---------------------------------------------------------------------------
  Name   :  
  Purpose:  
  Receive:  
  Return :  
---------------------------------------------------------------------------*/	
	private void addCoffeeMachine(int machineLevelNum)
	{
		// 4 diff prefabs, with scripts arleady attached, and unique tags
		/*
		 * Prefab names:						Tag
		 * CoffeeMachine1						coffeeMaker1
		 * CoffeeMachine2						coffeeMaker2
		 * CoffeeMachine3 						coffeeMaker3
		 * CoffeeMachine4						coffeeMaker4
		 */
		
		switch (machineLevelNum)
		{
		case 1: 
			//coffeeMachineModel1 = (GameObject)
			Instantiate(Resources.Load("CoffeeMachine1"));
			//coffeeM1 = (CoffeeMachine) GameObject.FindGameObjectWithTag("coffeeMaker1");
			//if (coffeeM1 != null) coffeeM1.createCoffeeMachineType(machineLevelNum);
			if (GameObject.FindGameObjectWithTag("coffeeMaker1").GetComponent<CoffeeMachine>() != null)
			{
				coffeeM1 = (CoffeeMachine) GameObject.FindGameObjectWithTag("coffeeMaker1").GetComponent<CoffeeMachine>();
				coffeeM1.createCoffeeMachineType(machineLevelNum);
			}
			break;
		case 2: 
			Instantiate(Resources.Load("CoffeeMachine2"));
			if (GameObject.FindGameObjectWithTag("coffeeMaker2").GetComponent<CoffeeMachine>() != null)
			{
				coffeeM2 = (CoffeeMachine) GameObject.FindGameObjectWithTag("coffeeMaker2").GetComponent<CoffeeMachine>();
				coffeeM2.createCoffeeMachineType(machineLevelNum);
			}
			break;
		case 3: 
			Instantiate(Resources.Load("CoffeeMachine3"));
			if (GameObject.FindGameObjectWithTag("coffeeMaker3").GetComponent<CoffeeMachine>() != null)
			{
				coffeeM3 = (CoffeeMachine) GameObject.FindGameObjectWithTag("coffeeMaker3").GetComponent<CoffeeMachine>();
				coffeeM3.createCoffeeMachineType(machineLevelNum);
			}
			break;
		case 4: 
			Instantiate(Resources.Load("CoffeeMachine4"));
			if (GameObject.FindGameObjectWithTag("coffeeMaker4").GetComponent<CoffeeMachine>() != null)
			{
				coffeeM4 = (CoffeeMachine) GameObject.FindGameObjectWithTag("coffeeMaker4").GetComponent<CoffeeMachine>();
				coffeeM4.createCoffeeMachineType(machineLevelNum);
			}
			break;
		}		
	}

}
