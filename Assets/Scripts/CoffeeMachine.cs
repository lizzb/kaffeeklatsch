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
	public bool inUse = false;

// If machine is in use, time that current drink was started
	int drinkStartTime = 0;
	
	
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
	
	// --- Progress Bars
	int barX = 0;
	const int barY = 0;
	const int barW = 10;
	const int barH = 50;
	float progress = 0;
	Texture2D progressBarFull;
	
	GameObject progressBarFill;
	GUITexture progressBarFillTexture;
	
	//
	// Use this for initialization
	//
	void Start ()
	{		
		//Setting up progress Bar object
		progressBarFull = new Texture2D(barW,barH); //Progress bar while full
		progressBarFill = new GameObject("ProgressBarFill"); //Create new game object
		progressBarFillTexture = progressBarFill.AddComponent<GUITexture>(); //Add Texture
		progressBarFillTexture.texture = progressBarFull; //Set texture as progress bar full texture
		progressBarFill.transform.localScale = Vector3.zero; //Set scale to 0 so it doesn't become huge
		ObjectLabel progressBarFillObjectLabel = progressBarFill.AddComponent<ObjectLabel>(); //Add Object label
		progressBarFillObjectLabel.target = GameObject.Find("coffeeMachineL").transform; //Bind label to coffemachine
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
	
	}
	
	void OnGUI()
	{
		//If making drink
		if(inUse){
			drawProgressBar(); //display progress bar
			progress += Time.deltaTime; //Increment progress
		} else{
			progress = 0f; //Otherwise set progress to 0
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  drawProgressBar
  Purpose:  draws progress bar to display while making drink
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void drawProgressBar(){
		progressBarFillTexture.pixelInset = new Rect(barX,barY,barW,barH * (6.0f - progress) / 6.0f); //Based on progress, alter height
	}

}
