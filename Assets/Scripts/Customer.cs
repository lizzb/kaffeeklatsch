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
	
	// The time a customer arrived at the store (or got in line...??)
	int arrivalTime = 0;
	
	// The time a customer paid money to cashier for a drink 
	int transactionTime = 0;
	
	// The level of patience of this particular customer
	int patienceLevel = 50; 
	
	
	// TODO ???
	// should there be a different patience level for waiting in line
	// vs waiting to pick up drink?
	
	
	// Whether this customer's drink is ready for pickup
	bool drinkIsReady = false;
	
	// Whether this customer has paid for a drink yet
	bool paidForDrink = false;
	
	
	// Dominant customer thought/opinion/emotion to display in thought bubble 
	enum Opinions { neutral=0, priceGood, priceBad, qualityGood, qualityBad,
							waitGood, waitBad, envGood, envBad }
	
	// This customer's opinion
	int custOp = (int)Opinions.neutral;
	
	
	//
	// Use this for initialization
	//
	void Start ()
	{
		// Set arrivalTime to current time
		//arrivalTime = current time
	
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		
		// If still not served (and/or have order taken?)
		// decrease patienceLevel
		
		//if (!drinkIsReady)
		
		
		// If the time a customer has been waiting in line
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
		return (int)Opinions.neutral;
	}	
	
	
	
/*---------------------------------------------------------------------------
  Name   :  calculateSatisfactionLevel
  Purpose:  Calculate and return a customer's satisfaction with their
  			experience at the coffee shop upon their departure
  Receive:  none, uses member variables
  			--> could potentially take in variables like leftearly = true
  			or a multiplier that leaveCafe generates based on leave conditions
  Return :  int satisfaction level - to use for other coffee shop functions 
---------------------------------------------------------------------------*/
	int calculateSatisfactionLevel ()
	{
		// A customer's satisfaction with their experience at the coffee shop
		// depends on many factors:
		
		// waiting time / patience
		// ambiance (alleviates negative impact of waiting time or bad drinks)
		// quality of drink
		// price of drink
		
		
		return 0;
	}
	

/*---------------------------------------------------------------------------
  Name   :  leaveCafe
  Purpose:  Customer leaves the cafe and calls appropriate functions
  			to affect the coffee shop's variables ... ??
  Receive:  --> could potentially take in variables like longLine, longWait
  Return :  
---------------------------------------------------------------------------*/	
	void leaveCafe (bool longLine, bool longWait)
	{

		// shop.updateSatisfaction(calculateSatisfactionLevel());
	}	
	
	
}
