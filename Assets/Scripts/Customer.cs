/*
 * Customer
 * 
 * TODO finish description
 * 
 * A customer comes to the coffee store with a specific drink to purchase in mind...
 * different patience levels.... calculate satisfaction when they leave... and show dominating opinion
 * 
 * Notes: 
 */
using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour
{
	public bool isOutOfLine = false;
	
	public Texture2D thoughtBubble;
	GUIText opinionText;
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	
	// The time a customer arrived at the store (or got in line...??)
	float arrivalTime = 0;
	
	// The time a customer paid money to cashier for a drink 
	float transactionTime = 0; //int or float?
	
	// The level of patience of this particular customer
	int patienceLevel = 50; 
	
	public float timeInShop; // Used to store how many seconds the customer will stay in the shop.
							 // The customer will leave if(time==0)
	
	
	//All public variables on scale [0,10] with 0 being 'better'
	public int ambianceLover;
	public int impatience;
	public int moneyGrubber;
	public int drinkQuality; // Temporary while drink quality is implemented.
	
	// if linePosition==0 then customer is the first in line. This updates automatically.
	private int linePosition; 
		
	// Determines how slow/fast a customer walks. The higher the faster.
	private int customerSpeed; 
	// TODO ???? is there a reason why customer speed isnt a constant??
	
	
	
	// Whether this customer has paid for a drink yet
	bool paidForDrink = false;
	
// Sets paidfordrink (private variable) - pretty sure always set to true, for now
// called by coffeeshop
	public void setPaidForDrink(bool val) { paidForDrink = val; }
	
	// ---> dont really think this makes sense to be a customer variable???
	// Whether this customer's drink is ready for pickup
	bool drinkIsReady = false;
	
	// If the customer runs out of patience waiting in line,
	// they'll leave without ordering/paying for a drink (//longline)
	// VERY negative impact on satisfaction
	bool leftEarly = false;
	
	// The customer had the patience to wait in line, (//waitForDrink)
	// but had a long wait to pick up their drink (because they already paid, so...)
	// Negative impact on satisfaction
	bool longWait = false;
	
	
	// TODO ???
	// should there be different patience levels for waiting in line vs waiting to pick up drink?
	
	

	
	// Different actions a customer can be doing
	public enum Actions { neutral, walkingIn, inLine, payingForDrink, waitingForDrink, justLeftLine, justPaidForDrink, walkingOut };
	
	// This customer's current action
	public Actions custAction = Actions.neutral; // not sure if should be public...?
	
	//public int custAction = (int) Actions.neutral;
	// *** --> casting an enum back to an int completely defeats the purpose of enums
	
	
	// Dominant customer thought/opinion/emotion to display in thought bubble 
	public enum Opinions { neutral=0, priceGood, priceBad, qualityGood, qualityBad,
							waitGood, waitBad, envGood, envBad };
	
	// The dominating? opinion of this customer
	public Opinions custOp = Opinions.neutral; // not sure if should be public...?
	
	// This customer's opinion
	//int custOp = (int)Opinions.neutral;
	// again, this defeats the point of enums
	
	
	// The color of a customer once they receive their coffee
	Color gotCoffeeColor = new Color(0.65882f, 0.63137f, 1.0f); // Purple
	
	
	
	// ------------ Use this for initialization ------------ //
	void Start ()
	{
		
		// use built-in tag because i'm too lazy to make my own tag
		GameObject room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		cafe = room.GetComponent<CoffeeShop>();
		
		opinionText = this.GetComponent<GUIText>();
		//opinionText.transform.position = this.transform.position + Vector3.up;
		
		
		
		// Set arrivalTime to current time
		arrivalTime = Time.time;
		
		
		// Variables calculated Randomly
		System.Random random = new System.Random();
		ambianceLover = random.Next(0, 11);
		impatience = random.Next(0, 10);
		moneyGrubber = random.Next(0, 11);
		// Drink quality is calculated according to nicest machine currently in store.
		int coffeeMachineQuality = (int) ((CoffeeMachine) GameObject.FindObjectOfType(typeof(CoffeeMachine))).drinkQuality;
		int minDrinkQuality = 2*coffeeMachineQuality-12;
		print (minDrinkQuality);
		drinkQuality = random.Next(minDrinkQuality, 11);
		
		linePosition = GameObject.FindObjectsOfType(this.GetType()).Length - 1;
		customerSpeed = 10;
		resetTime();
		
		thoughtBubble = null;
	}
	
	void OnGUI()
	{
		
		opinionText.text = ""+ custOp.ToString(); //Time.time; //opinionText = custOp.ToString();
		
		// Sets a thought bubble for each customer
		float xPosition = Camera.main.WorldToScreenPoint(transform.position).x-10;
		float yPosition = Screen.height-Camera.main.WorldToScreenPoint(transform.position).y-75;
		GUI.Label(new Rect(xPosition, yPosition, 60, 60), thoughtBubble);
	} 

	// ------------ Update is called once per frame ------------ //
	void Update ()
	{
		// Units in world space to offset; 1 unit above object by default
		//opinionText.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + Vector3.up);
		
		// If still not served (and/or have order taken?)
		// decrease patienceLevel
		
		if(custAction == Actions.inLine)
		{
			timeInShop -= Time.deltaTime;
		}
		
		
		// Customer walks from door to its line position
		if(transform.position.x == 5)
		{
			custAction = Actions.walkingIn;
			transform.Translate(0f, 0f, customerSpeed*Time.deltaTime);
		}
		
		// USE CONSTANTS INSTEAD OF NUMBERS!!!! TODO what is 13?
		
		updateLinePositions(); // doesnt do anything right now
		
		// Customer gets in line
		if(transform.position.z > 10 && transform.position.x < 13-1.5*linePosition)
		{
			// Move forward in line?????................
			custAction = Actions.inLine;
			transform.Translate(customerSpeed*Time.deltaTime, 0f, 0f);
		}
		// Customer is at front of line waiting for drink.........???
		else if(transform.position.x >= 13-1.5*linePosition && custAction != Actions.walkingOut && linePosition == 0)
		{
			custAction = Actions.waitingForDrink;
		}
			
		
		checkLeavingCafe();
		
		//updateLinePositions();
		
		// Update the color of the customer
		// Default color gives indication of their remaining patience (from green --> red)
		// Purplish if they have received/paid for coffee...?????
		ColorCustomer();
		

		checkDestroyCustomer();
		
	}
	

	
public void updateLinePositions()
{
	/*// check that every line position is filled and in order	
	// ....?????
	// in start
	//linePosition = GameObject.FindObjectsOfType(this.GetType()).Length - 1;
	//int customerRemoved = this.linePosition;
		
	//ArrayList customers = GameObject.FindObjectsOfType(this.GetType());
	//foreach (Customer c in customers)
	//	{
	//		if (c.custAction != Actions.inLine) customers.Remove(c);
	//	}
	Customer[] customers = (Customer[]) GameObject.FindObjectsOfType(this.GetType());
		int numCustomersInLine = 0;
			
			// Loops through each of the current customers and if they were behind the customer who left,
			// their linePosition is decreased, so they move forward in line.
			foreach(Customer customer in customers)
			{
				if(customer.custAction == Actions.inLine || customer.custAction == Actions.waitingForDrink)
					numCustomersInLine++;
				//customer.linePosition = customers.Count - 1;
				//if(customer.linePosition > customerRemoved)
				//	customer.linePosition--;
			}	*/
}
	
	
void checkLeavingCafe()
{	
		// 
		// Conditions for customer leaving the shop
		//
		if (timeInShop < 0 || custAction == Actions.walkingOut) // || custAction == Actions.justLeftLine)
		{
			// If timeInShop < 0, customer walks out of the line and leaves the shop.
			custAction =  Actions.walkingOut; // Actions.justLeftLine;
			
			// Set thought bubble representing Opinion
			thoughtBubble = setOpinionImage(getOpinion()); 
			
			// If the time a customer has been waiting in line (modify this *****)
			// exceeds their patience limit, they leave unhappily without buying a drink
			if(!paidForDrink)
			{
				leftEarly = true; // leave early, VERY negative impact on satisfaction
				custOp = Opinions.waitBad;
			}
			
			// If a customer has already paid money for a drink,
			// but the time a customer has been waiting in total/(for a drink)
			// exceeds their patience limit, they won't instantly leave,
			// (since they have already paid money) but this will negatively impact satisfaction
			//if(t
				//if (!drinkIsReady)
				// decrease patience
				// leaveCafe(false, true);
			
			
			// If a customer successfully receives their drink
			// without exceeding their patience limit, they leave the cafe	
			// no variables need to be changed - calculateSatisfaction will do that internally
			
			// Trigger animation for leaving cafe
			leaveCafe();
		}
		
		//checkDestroyCustomer();
	}
	

void checkDestroyCustomer()
	{	
		// Checks if the customer is far enough from the shop after leaving it
		// if it is, destroys its object.
		if(transform.position.x < 6 && transform.position.z < -1 && (timeInShop < 0 || custAction == Actions.walkingOut))
		{
			
		// could start commenting out here if get getting out of line working earlier in code ********
			int customerRemoved = this.linePosition;
			Customer[] customers = (Customer[]) GameObject.FindObjectsOfType(this.GetType());
			
			// Loops through each of the current customers and if they were behind the customer who left,
			// their linePosition is decreased, so they move forward in line.
			foreach(Customer customer in customers)
			{
				if(customer.linePosition > customerRemoved)
					customer.linePosition--;
			}
			// could end commenting out here if get getting out of line working *********
			
			
			// Update the customer satisfaction rating of the coffee shop
			// Based on the satisfaction level of the customer that just left
			// Do it here (right before destroying customer)
			// so that it only happens ONCE
			cafe.updateCustomerSatisfaction(calculateSatisfactionLevel());
			
			Destroy(this.gameObject);
		}
		
		
		
	}
	
public void checkGetOutOfLine()
	{
		if (!isOutOfLine && transform.position.z <= 8 && (timeInShop < 0 || custAction == Actions.walkingOut))
		{
		// This customer is removed from the "line", but not destroyed from game yet
		int customerRemoved = this.linePosition;
		//othersMoveForwardInLine(customerRemoved);
		
		// Other customers move forward in line
		Customer[] customers = (Customer[]) GameObject.FindObjectsOfType(this.GetType());
		
		// Loops through each of the current customers and if they were behind the customer who left,
		// their linePosition is decreased, so they move forward in line.
		foreach(Customer customer in customers)
		{
			//if (customer != this)
			//	{
			//check if this is not the same customer??
			if(customer.linePosition > customerRemoved) customer.linePosition--;
			//	}
		}
		
		isOutOfLine = true;
		}
/*if(!isOutOfLine && transform.position.z == 8 && (timeInShop < 0 || custAction == Actions.walkingOut))
			{
				int customerRemoved = this.linePosition;
				Customer[] customers = (Customer[]) GameObject.FindObjectsOfType(this.GetType());
				
				// Loops through each of the current customers and if they were behind the customer who left,
				// their linePosition is decreased, so they move forward in line.
				foreach(Customer customer in customers)
				{
					if(customer.linePosition > customerRemoved) customer.linePosition--;
				}
				//isOutOfLine = true;
				//calledGetOutOfLine = true;
				//print (name + "  get out of line called: " + calledGetOutOfLine);
			}*/
	}	
	
/*---------------------------------------------------------------------------
  Name   :  resetTime
  Purpose:  Sets time to initial wait time ---> what is the PURPOSE of this??
  Receive:  None but timeInShop is a function of impatience 
  Return :  
---------------------------------------------------------------------------*/	
	public void resetTime()
	{
		transactionTime = Time.time; // not sure if doing this right... - lizz
		timeInShop = (10-impatience)*2;
	}	
	
/*---------------------------------------------------------------------------
  Name   :  calculateLineWaitingTime
  Purpose:  Determine time the customer has been waiting in line
  Receive:  none, uses member variables
  Return :  float - minutes(?) the customer has been waiting in line
---------------------------------------------------------------------------*/	
	float calculateLineWaitingTime ()
	{
		// could cause problems if function called at wrong time...???
		return transactionTime - arrivalTime; 
	}
	
			// TODO ???
		// does getting rang up fast, but waiting for drink for long time,
		// have diff impact than waiting for both for a long time?
	
/*---------------------------------------------------------------------------
  Name   :  calculateDrinkWaitingTime
  Purpose:  Determine time the customer has waited for a drink they paid for
  Receive:  none
  Return :  float - time the customer has been waiting for a drink they ordered
---------------------------------------------------------------------------*/	
	float calculateDrinkWaitingTime ()
	{
		// could cause problems if function called at wrong time...???
		return Time.time - transactionTime; 
	}
	
/*---------------------------------------------------------------------------
  Name   :  calculateTotalWaitingTime
  Purpose:  x
  Receive:  x
  Return :  int - minutes the customer has been waiting total
  			(time in line + time waiting for drink)
---------------------------------------------------------------------------*/	
	float calculateTotalWaitingTime ()
	{
		// used for generating shop stats?
		
		// could cause problems if function called at wrong time...???
		// Current time - arrivalTime // is this right?
		return Time.time - arrivalTime;
	}
	

/*---------------------------------------------------------------------------
  Name   :  getOpinion
  Purpose:  ...
  Receive:  ...
  Return :  the current dominant opinion of this Customer
---------------------------------------------------------------------------*/	
	public Opinions getOpinion ()
	{
		
		// Neutral is the default state of a customer, and
		// does not display a thought bubble
		
		// all other opinions/emotions display in a thought bubble
		int satisfaction = calculateSatisfactionLevel();
		if(satisfaction == 0)
			return Opinions.neutral;
		else
		{
			int x = calculatePatienceSatisfactionLevel();
			int y = calculateMoneySatisfactionLevel();
			int z = calculateQualitySatisfactionLevel();
			if(satisfaction > 0)
			{
				int max = Mathf.Max(Mathf.Max(x, y), z);
				return max == x? Opinions.waitGood : max == y? Opinions.priceGood : Opinions.qualityGood;
				
			}
			else
			{
				int min = Mathf.Min(Mathf.Min(x, y), z);
				return min == x? Opinions.waitBad : min == y? Opinions.priceBad : Opinions.qualityBad;
			}
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  setOpinionImage
  Purpose:  Selects which image the customer will have following it
  Receive:  Customer's opinion
  Return :  the image path according to the opinion of this Customer
---------------------------------------------------------------------------*/	
	
	public Texture2D setOpinionImage(Opinions opinion)
	{
		if(opinion == Opinions.qualityBad)
			return (Texture2D) Resources.Load("BadQuality");
		else if(opinion == Opinions.qualityGood)
			return (Texture2D) Resources.Load("GoodQuality");
		else if(opinion == Opinions.waitBad)
			return (Texture2D) Resources.Load("BadWait");
		else if(opinion == Opinions.waitGood)
			return (Texture2D) Resources.Load("GoodWait");
		else if(opinion == Opinions.priceBad)
			return (Texture2D) Resources.Load("BadMoney");
		else if(opinion == Opinions.priceGood)
			return (Texture2D) Resources.Load("GoodMoney");
		return (Texture2D) Resources.Load("Neutral");
	}
	
/*---------------------------------------------------------------------------
  Name   :  calculateSatisfactionLevel
  Purpose:  Calculate and return a customer's satisfaction with their
  			experience at the coffee shop upon their departure
  Receive:  Determines whether patience satisfaction level is calculated using
  			the time the customer has been in the shop or only using his
  			impatience level.
  Return :  int satisfaction level - to use for other coffee shop functions 
---------------------------------------------------------------------------*/
	int calculateSatisfactionLevel()
	{
		//int satisfaction = GameConstants.defaultSatisfactionLevel;
		
		// Generate multiplier/adjustment based on leave conditions
		
		// Customer walks out of the line and leaves the shop if timeInShop < 0.	
		// If the time a customer has been waiting in line (modify this *****)
		// exceeds their patience limit, they leave unhappily
		// leaveCafe(true);
						
		// A customer's satisfaction with their experience at the coffee shop
		// depends on many factors:
		
		// waiting time / patience
		// ambiance (alleviates negative impact of waiting time or bad drinks)
		// quality of drink
		// price of drink
		
		// All satisfaction sublevels below will be [-10, 10]
		
		int x = calculatePatienceSatisfactionLevel();
		int y = calculateMoneySatisfactionLevel();
		int z = calculateQualitySatisfactionLevel();
		//print("Waiting: " + x + ", Cash: " + y + ", Quality: " + z);
		
		int avg = (x+y+z)/3;
		// Returns Max(x,y,z) if average is positive, or Min(x,y,z) if average is negative
		return avg==0 ? 0 : avg > 0 ? Mathf.Max(Mathf.Max(x,y), z) : Mathf.Min(Mathf.Min(x, y), z);
	}
	
/*---------------------------------------------------------------------------
  Name   :  calculatePatienceSatisfactionLevel()
  Purpose:  Calculate and return a customer's patience satisfaction as
  			a of their impatience and time in shop.
  Receive:  
  Return :  int patience satisfaction level
---------------------------------------------------------------------------*/

	int calculatePatienceSatisfactionLevel()
	{
		// Linear function f:[0, 1] → [-10, 10] that maps a ratio of their current time in shop / initial time to a scale [-10, 10]
		return 20*((int) timeInShop)/((10-impatience)*2)-10;
	}

/*---------------------------------------------------------------------------
  Name   :  calculateMoneySatisfactionLevel()
  Purpose:  Calculate and return a customer's money satisfaction
  			as a function of their moneyGrubber value
  Receive:  
  Return :  int money satisfaction level
---------------------------------------------------------------------------*/
	
	int calculateMoneySatisfactionLevel()
	{
		return GameConstants.maximumDrinkCost-cafe.moneyManager.drinkCost-(GameConstants.maximumDrinkCost*moneyGrubber)/10;
	}
	
/*---------------------------------------------------------------------------
  Name   :  calculateQualitySatisfactionLevel()
  Purpose:  Calculate and return a customer's drink quality satisfaction.
  			Value is fixed according to generated quality value, which is
  			a function of the nicest coffee machine bought.
  Receive:  
  Return :  int quality satisfaction level
---------------------------------------------------------------------------*/
	
	int calculateQualitySatisfactionLevel()
	{
		
		return drinkQuality;
	}
	
/*---------------------------------------------------------------------------
  Name   :  isFrontOfLine
  Purpose:  Determines if customer is in front of line
  Receive:  uses internal variables
  Return :  true if customer is front of line, false otherwise
---------------------------------------------------------------------------*/	
	public bool isFrontOfLine()
	{
		if(custAction == Actions.waitingForDrink && linePosition == 0 && paidForDrink == false)
		{
			return true;
		}
		return false;
	}
	

	
	

	
/*---------------------------------------------------------------------------
  Name   :  ColorCustomer
  Purpose:  Colors the customer capsule according to how much time is left until they leave.
  			Yellow = just arrived; Red = leaving; Green = successfully received coffee
  Receive:  
  Return :  
---------------------------------------------------------------------------*/	
	void ColorCustomer()
	{
		float ratio = timeInShop/((10-impatience)*2);
		
		if(paidForDrink)
			renderer.material.color = gotCoffeeColor; //new Color(0.65882f, 0.63137f, 1.0f); // Purple
		else
			renderer.material.color = new Color(1-ratio, ratio, 0);
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  leaveCafe
  Purpose:  Animation for customer leaving the cafe
  Receive: 	null
  Return :	void
---------------------------------------------------------------------------*/	
	public void leaveCafe ()
	{
		//checkGetOutOfLine();
		//if(!isOutOfLine && transform.position.z < 8)
		//{
		//	isOutOfLine = true;
			//getOutOfLine();
		//}
		
		// Animation to leave cafe....comment me later!! ****
		if(transform.position.z < 1 && transform.position.x >= 6)
			transform.Translate(-customerSpeed*Time.deltaTime, 0f, 0f);
		else if(transform.position.x < 6)
			transform.Translate(0f, 0f, -customerSpeed*Time.deltaTime);
		else
			transform.Translate(0f, 0f, -customerSpeed*Time.deltaTime);
		
		// shop.updateSatisfaction(calculateSatisfactionLevel());
		//cafe.updateCustomerSatisfaction(calculateSatisfactionLevel());
	}	
	
	
	

	
}

/*---------------------------------------------------------------------------
  Name   :  ...
  Purpose:  ...
  Receive:  ...
  Return :  ...
---------------------------------------------------------------------------*/	
