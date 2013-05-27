/*
 * Customer
 * 
 * TODO finish description
 * 
 * A customer comes to the coffee store with a specific drink to purchase in mind...
 * different patience levels.... calculate satisfaction when they leave...
 * 
 * Notes: 
 */
using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour
{
	// ADD OBJECT LABELS
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	
	// The time a customer arrived at the store (or got in line...??)
	float arrivalTime = 0;
	
	// The time a customer paid money to cashier for a drink 
	int transactionTime = 0;
	
	// The level of patience of this particular customer
	int patienceLevel = 50; 
	
	
	// TODO ???
	// should there be a different patience level for waiting in line
	// vs waiting to pick up drink?
	
	
	// ---> dont really think this makes sense to be a customer variable???
	// Whether this customer's drink is ready for pickup
	bool drinkIsReady = false;
	
	// Whether this customer has paid for a drink yet
	bool paidForDrink = false;
	
	
	// Dominant customer thought/opinion/emotion to display in thought bubble 
	enum Opinions { neutral=0, priceGood, priceBad, qualityGood, qualityBad,
							waitGood, waitBad, envGood, envBad };
	
	// This customer's opinion
	int custOp = (int)Opinions.neutral;
	
	// Different actions customers can be doing
	public enum Actions { neutral, walkingIn, inLine, walkingOut };
	
	// This customer's current action
	public int custAction = (int) Actions.neutral;
	
	//All public variables on scale [0,10] with 0 being 'better'
	public int cleanFreak;
	public int impatience;
	public int moneyGrubber;
	
	private int linePosition; // if linePosition==0 then customer is the first in line. This updates automatically
	private int customerSpeed; // Determines how slow/fast a customer walks. The higher the faster.
	
	public float timeInShop; // Used to store how many seconds the customer will stay in the shop.
								//The customer will leave if(time==0)

	//
	// Use this for initialization
	//
	void Start ()
	{

		
		// use built-in tag because i'm too lazy to make my own tag
		GameObject room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		cafe = room.GetComponent<CoffeeShop>();
		
		// ----- start lizz's thoughts -----
		
		// Set arrivalTime to current time
		//arrivalTime = current time
		arrivalTime = Time.time;
		
		// ----- end lizz's thoughts, start federico's code -----
		
		System.Random random = new System.Random();
		cleanFreak = random.Next(0, 11);
		impatience = random.Next(0, 10);
		moneyGrubber = random.Next(0, 11);
		linePosition = GameObject.FindObjectsOfType(this.GetType()).Length - 1;
		customerSpeed = 10;
		timeInShop = (10-impatience)*2;
	}
	

	//
	// Update is called once per frame
	//
	void Update ()
	{
		
		// ----- start lizz's thoughts -----
		
		// If still not served (and/or have order taken?)
		// decrease patienceLevel
		
		//if (!drinkIsReady)
		
		// Customer walks out of the line and leaves the shop if timeInShop < 0.	
		// If the time a customer has been waiting in line (modify this *****)
		// exceeds their patience limit, they leave unhappily
		// leaveCafe(true, false);

		

		// If the time a customer has been waiting in total (for a drink)
		// exceeds their patience limit, they won't leave, since they have 
		// already paid money - but this will negatively impact satisfaction
		
		
		// leaveCafe(false, true);
		
		
		// TODO ???
		// does getting rang up fast, but waiting for drink for long time,
		// have diff impact than waiting for both for a long time?
		
		
		// If a customer successfully receives their drink
		// without exceeding their patience limit, they leave the cafe	
		
		
		// ----- end lizz's thoughts, start federico's code -----
		
		bool leftEarly = false; // longline
		bool longWait = false; // wait for drink
		
		timeInShop -= Time.deltaTime;
		
		// Customer walks from door to its line position
		if(transform.position.x == 5)
		{
			custAction = (int) Actions.walkingIn;
			transform.Translate(0f, 0f, customerSpeed*Time.deltaTime);
		}

		// Customer gets in line
		if(transform.position.z > 10 && transform.position.x < 13-1.5*linePosition)
		{
			transform.Translate(customerSpeed*Time.deltaTime, 0f, 0f);
		}
		else if(transform.position.x >= 13-1.5*linePosition && custAction != (int) Actions.walkingOut)
		{
			custAction = (int) Actions.inLine;
		}
		
		// Customer walks out of the line and leaves the shop if timeInShop < 0.	
		// If the time a customer has been waiting in line (modify this *****)
		// exceeds their patience limit, they leave unhappily
		// leaveCafe(true, false);
		if(timeInShop < 0 || custAction == (int) Actions.walkingOut)
		{
			custAction = (int) Actions.walkingOut;
			leftEarly = true; // leave early, negative impact on satisfaction
			leaveCafe();
		}
		
		// Checks if the customer is far enough from the shop after leaving it and destroys its object.
		if(transform.position.x < 6 && transform.position.z < -1 && (timeInShop < 0 || custAction == (int) Actions.walkingOut))
		{
			int customerRemoved = this.linePosition;
			Customer[] customers = (Customer[]) GameObject.FindObjectsOfType(this.GetType());
			
			// Loops through each of the current customers and if they were behind the customer who left,
			// their linePosition is decreased, so they move forward in line.
			foreach(Customer customer in customers)
			{
				if(customer.linePosition > customerRemoved)
					customer.linePosition--;
			}
			
			cafe.updateCustomerSatisfaction(calculateSatisfactionLevel(leftEarly, longWait));
			Destroy(this.gameObject);
		}
	}

	
	
/*---------------------------------------------------------------------------
  Name   :  calculateLineWaitingTime
  Purpose:  Determine number of minutes the customer has been waiting in line
  Receive:  none, uses member variables
  Return :  int - minutes the customer has been waiting in line
---------------------------------------------------------------------------*/	
	int calculateLineWaitingTime ()
	{
		
		return 0; // transactionTime - arrivalTime
	}

	
/*---------------------------------------------------------------------------
  Name   :  calculateTotalWaitingTime
  Purpose:  x
  Receive:  x
  Return :  int - minutes the customer has been waiting total
  			(time in line + time waiting for drink)
---------------------------------------------------------------------------*/	
	int calculateTotalWaitingTime ()
	{
		
		return 0; // current time - arrivalTime? 
	}
	

/*---------------------------------------------------------------------------
  Name   :  getOpinion
  Purpose:  ...
  Receive:  ...
  Return :  the current dominant opinion of this Customer
---------------------------------------------------------------------------*/	
	int getOpinion ()
	{
		
		// Neutral is the default state of a customer, and
		// does not display a thought bubble
		return (int) Opinions.neutral;
	}	
	
	
	
/*---------------------------------------------------------------------------
  Name   :  calculateSatisfactionLevel
  Purpose:  Calculate and return a customer's satisfaction with their
  			experience at the coffee shop upon their departure
  Receive:  none, uses member variables
  			--> could potentially take in variables like longLine, longWait
  			--> could potentially take in variables like leftearly = true
  			or a multiplier that leaveCafe generates based on leave conditions
  Return :  int satisfaction level - to use for other coffee shop functions 
---------------------------------------------------------------------------*/
	int calculateSatisfactionLevel (bool leftEarly, bool longWait)
	{
		int satisfaction = GameConstants.defaultSatisfactionLevel;
		
		if (leftEarly) satisfaction = satisfaction * -1;
		
		// A customer's satisfaction with their experience at the coffee shop
		// depends on many factors:
		
		// waiting time / patience
		// ambiance (alleviates negative impact of waiting time or bad drinks)
		// quality of drink
		// price of drink
		
		// TODO!! **** ACTUALLY calculate this stuff
		// maybe dont need to feed longwait and stuff as bools in other function
		
		return satisfaction;
	}
	

/*---------------------------------------------------------------------------
  Name   :  leaveCafe
  Purpose:  Customer leaves the cafe and calls appropriate functions
  			to affect the coffee shop's variables ... ??
  Receive:  --> could potentially take in variables like longLine, longWait
  Return :  
---------------------------------------------------------------------------*/	
	public void leaveCafe ()
	{
		// Animation to leave cafe....comment me later!! ****
		if(transform.position.z < 1 && transform.position.x >= 6)
			transform.Translate(-customerSpeed*Time.deltaTime, 0f, 0f);
		else if(transform.position.x < 6)
			transform.Translate(0f, 0f, -customerSpeed*Time.deltaTime);
		else
			transform.Translate(0f, 0f, -customerSpeed*Time.deltaTime);
		
		print ("leaving");
		// shop.updateSatisfaction(calculateSatisfactionLevel());
		//cafe.updateCustomerSatisfaction(calculateSatisfactionLevel());
	}	
	

/*---------------------------------------------------------------------------
  Name   :  moveForwardInLine
  Purpose:  ...
  Receive:  ...
  Return :  ...
---------------------------------------------------------------------------*/	
	
/*---------------------------------------------------------------------------
  Name   :  isFrontOfLine
  Purpose:  Determines if customer is in front of line
  Receive:  uses internal variables
  Return :  true if customer is front of line, false otherwise
---------------------------------------------------------------------------*/	
	
	public bool isFrontOfLine(){
		if(custAction == (int) Actions.inLine && linePosition == 0 && paidForDrink == false){
			return true;
		}
		return false;
	}

	public void setPaidForDrink(bool val){
		paidForDrink = val;
	}
}