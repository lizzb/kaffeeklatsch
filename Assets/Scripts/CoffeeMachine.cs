/*
 * CoffeeMachine
 * 
 * Base class for coffee machines that a player can purchase and put in their shop.
 * There are a fixed number of fixed slots for coffee machines.
 * If a player upgrades one, it replaces the existing one. 
 * 
 * Notes: 
 */
using UnityEngine;
using System.Collections;

public class CoffeeMachine : MonoBehaviour
{
	
	// The name of the coffee machine, to display in the buy menu
	string name = "";

// The cost of this coffee machine --> ideally use constants defined in another file
	int cost = 0;

// The quality of the drinks produced by this machine
// Customers will pay more for higher quality drinks
	enum qualityRating { low = 1, med = 2, high = 3, highest = 4 }


// Whether or not this machine is in use
	bool inUse = false;

// If machine is in use, time that current drink was started
	int drinkStartTime = 0;
	
	
	//
	// Use this for initialization
	//
	void Start ()
	{
	
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
	
	}
	
	





/*

// The rate at which (length of time?) that it takes to create a drink (specific to drinks???)

// If machine is in use, time remaining until current drink is completed
public int timeUntilFree(drink) {
		
	}


LATER:

// The list of drinks that can be made with this machine
list possibleDrinks[]

// Based on quality of machine, calculate the [suggested] price of a certain drink
int calculateSuggestedPrice(string drinkName)


instead of string drinkName, use enums across multiple files?
*/
}
