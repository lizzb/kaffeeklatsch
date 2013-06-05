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
using System;

	/*
public enum CoffeeMachineType
{
	Flyer,
	TelevisionAd,
	Billboard
}
	
	private AdvertisementType type;
	private int cost;
	private int hypeFactor;
		*/
public class CoffeeMachine : MonoBehaviour
{
		// not sure if this posiiton was effecting the next 4 positions...
		//public Vector3 CoffeeMachinesPos = new Vector3(2.615282f, 5.342656f, 7.862321f);
	
	//public Vector3 coffeeMachine1Pos = new Vector3(16.13379f, -3.482452f, 6.18842f);
	// coffeeMakerLevel1		tag: coffeeMaker1
	// coffeeMachine1Rot = new Vector3(0, 270, 0);
	// coffeeMachine1Scale = new Vector3(225, 225, 225);
	
	//public Vector3 coffeeMachine2Pos = new Vector3(17.22975f, -3.470431f, 9.385904f);
	// coffeeMachine2Rot = new Vector3(0, 0, 0);
	// coffeeMachine2Scale = new Vector3(225, 225, 225);
	
	//public Vector3 coffeeMachine3Pos = new Vector3(14.50232f, -3.636328f, 1.99104f);
	// coffeeMakerLevel3		tag: coffeeMaker3
	// coffeeMachine3Scale = new Vector3(200, 200, 200);
	
	//public Vector3 coffeeMachine4Pos = new Vector3(6.751243f, -3.515523f, 11.89497f);
	// coffeeMachine4Rot = new Vector3(0, 270, 0);
	// coffeeMachine4Scale = new Vector3(225, 225, 225);
	
	
	
	// Whether this coffee machine has been purchased
	public bool isPurchased = false;
	
	// The name of the coffee machine, to display in the buy menu
	string objectName = "";

	// The cost of this coffee machine --> ideally use constants defined in another file
	int cost = 0;

	// The quality of the drinks produced by this machine
	// Customers will pay more for higher quality drinks
	//qualityRating...coffeeQuality
	enum QualityRating { low = 1, med = 2, high = 3, highest = 4 }
	
	QualityRating drinkQuality = QualityRating.low;


	// Whether or not this machine is in use
	public bool inUse = false;

	// If machine is in use, time that current drink was started
	int drinkStartTime = 0;
	
	public bool drinkIsReady = false;
	

	public CoffeeMachine (int machineLevel) //(CoffeeMachineType machineType)
	{
		
		switch (machineLevel) //switch (machineType)
		{
			case 1:
				objectName = GameConstants.coffeeMachine1Name;	
				cost = GameConstants.coffeeMachine1Cost;
				drinkQuality = QualityRating.low;
			break;
			case 2:
				objectName = GameConstants.coffeeMachine2Name;	
				cost = GameConstants.coffeeMachine2Cost;
				drinkQuality = QualityRating.med;
			break;
			case 3:
				objectName = GameConstants.coffeeMachine3Name;	
				cost = GameConstants.coffeeMachine3Cost;
				drinkQuality = QualityRating.high;
			break;
			case 4:
				objectName = GameConstants.coffeeMachine4Name;	
				cost = GameConstants.coffeeMachine4Cost;
				drinkQuality = QualityRating.highest;
			break;
			default: // case 1
				objectName = GameConstants.coffeeMachine1Name;	
				cost = GameConstants.coffeeMachine1Cost;
				drinkQuality = QualityRating.low;
			break;
		}
		
		//SetActive(false);
		//renderer.enabled = false;
	}
	
	// PROGRESS BAR SHOULD BE ITS OWN CLASS THAT ATTACHES ABOVE AN OBJECT, LIKE THOUGHT BUBBLES
	// TODO *** actually nah
	
	// --- Progress Bars --- //
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
		//gameObject.SetActive(false);
		
		// Setting up progress Bar object
		progressBarFull = new Texture2D(barW,barH); // Progress bar while full
		progressBarFill = new GameObject("ProgressBarFill"); // Create new game object
		progressBarFillTexture = progressBarFill.AddComponent<GUITexture>(); // Add Texture
		progressBarFillTexture.texture = progressBarFull; // Set texture as progress bar full texture
		progressBarFill.transform.localScale = Vector3.zero; // Set scale to 0 so it doesn't become huge
		ObjectLabel progressBarFillObjectLabel = progressBarFill.AddComponent<ObjectLabel>(); //Add Object label
		progressBarFillObjectLabel.target = GameObject.Find("coffeeMachineL").transform; //Bind label to coffeemachine
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		// only draw the machine if it has been purchased
		//if (isPurchased)
		//{
			//gameObject.SetActive(true);
			//renderer.enabled = true;
		//}
	}
	
	void OnGUI()
	{

		
		// If making drink
		if(inUse)
		{
			drawProgressBar(); 			// display progress bar
			progress += Time.deltaTime; // Increment progress
		}
		else
		{
			progress = 0f; // Otherwise set progress to 0
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  drawProgressBar
  Purpose:  draws progress bar to display while making drink
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void drawProgressBar()
	{
		// Based on progress, alter height
		progressBarFillTexture.pixelInset = new Rect(barX,barY,barW,barH * (6.0f - progress) / 6.0f); 
	}
	
	
	public int getCost () { return cost; }

}
	
	/*
	public AdvertisementType getType () { return type; }

	public int getCost () { return cost; }

	public int getHype () { return hypeFactor; }
	*/
//}

// old implementation - lizz
// going off of KGs for simplicity for now
// even though theres probs a better way

/*using UnityEngine;
using System.Collections;

public class CoffeeMachine : MonoBehaviour
{
	// Whether this coffee machine has been purchased
	public bool isPurchased = false;
	
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
*
	
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
		// Setting up progress Bar object
		progressBarFull = new Texture2D(barW,barH); //Progress bar while full
		progressBarFill = new GameObject("ProgressBarFill"); //Create new game object
		progressBarFillTexture = progressBarFill.AddComponent<GUITexture>(); //Add Texture
		progressBarFillTexture.texture = progressBarFull; //Set texture as progress bar full texture
		progressBarFill.transform.localScale = Vector3.zero; //Set scale to 0 so it doesn't become huge
		ObjectLabel progressBarFillObjectLabel = progressBarFill.AddComponent<ObjectLabel>(); //Add Object label
		progressBarFillObjectLabel.target = GameObject.Find("coffeeMachineL").transform; //Bind label to coffeemachine
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
	
	}
	
	void OnGUI()
	{
		// If making drink
		if(inUse)
		{
			drawProgressBar(); 			// display progress bar
			progress += Time.deltaTime; // Increment progress
		}
		else
		{
			progress = 0f; // Otherwise set progress to 0
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  drawProgressBar
  Purpose:  draws progress bar to display while making drink
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*
	void drawProgressBar()
	{
		// Based on progress, alter height
		progressBarFillTexture.pixelInset = new Rect(barX,barY,barW,barH * (6.0f - progress) / 6.0f); 
	}

}
*/