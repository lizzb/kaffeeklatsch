/*
 * CoffeeMachine
 * 
 * Base class for coffee machines that a player can purchase and put in their shop.
 * There are a fixed number of fixed slots for coffee machines.
 *  
 * 
 * Notes: 
 * removed: If a player upgrades one, it replaces the existing one. 
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

	//Clock
	Clock clock;
	
	public GameObject coffeeMachineModel1;
	public GameObject coffeeMachineModel2;
	public GameObject coffeeMachineModel3;
	public GameObject coffeeMachineModel4;
	
	// Whether this coffee machine has been purchased - was going to be used for rendering
	//public bool isPurchased = false;
	
	// The name of the coffee machine, to display in the buy menu
	string objectName = "";

	// The cost of this coffee machine --> ideally use constants defined in another file
	int cost = 0;

	// The quality of the drinks produced by this machine
	// Customers will pay more for higher quality drinks
	//qualityRating...coffeeQuality
	public enum QualityRating { low = 1, med = 2, high = 3, highest = 4 }
	
	public QualityRating drinkQuality = QualityRating.low;


	// Whether or not this machine is in use
	public bool inUse = false;

	// If machine is in use, time that current drink was started
	int drinkStartTime = 0;
	
	public bool drinkIsReady = false;
	


	
	// PROGRESS BAR SHOULD BE ITS OWN CLASS THAT ATTACHES ABOVE AN OBJECT, LIKE THOUGHT BUBBLES
	// TODO *** actually nah
	
	// --- Progress Bars --- //
	int barX = 0;
	const int barY = 0;
	const int barW = 10;
	const int barH = 80;
	float progress = 0;
	Texture2D progressBarFull;
	
	GameObject progressBarFill;
	GUITexture progressBarFillTexture;
	ObjectLabel progressBarFillObjectLabel;
	

	// ---------- Use this for initialization ---------- //
	void Start ()
	{		
		clock = GameObject.Find("GUI").GetComponent<Clock>();
		//gameObject.SetActive(false);
		
		gameObject.AddComponent<EndGame>(); //End Game conditions
		
		// Setting up progress Bar object
		progressBarFull = new Texture2D(barW,barH); // Progress bar while full
		progressBarFill = new GameObject("ProgressBarFill"); // Create new game object
		progressBarFillTexture = progressBarFill.AddComponent<GUITexture>(); // Add Texture
		progressBarFillTexture.texture = progressBarFull; // Set texture as progress bar full texture
		progressBarFill.transform.localScale = Vector3.zero; // Set scale to 0 so it doesn't become huge
		progressBarFillObjectLabel = progressBarFill.AddComponent<ObjectLabel>(); //Add Object label
		progressBarFillObjectLabel.target = this.transform;
	}
	

	// ---------- Update is called once per frame ---------- //
	void Update ()
	{
		
		// rather than creating and worrying about activating/rendering, only create when bought
		//SetActive(false);
		//renderer.enabled = false;
		
		
		// only draw the machine if it has been purchased
		//if (isPurchased)
		//{
			//gameObject.SetActive(true);
			//renderer.enabled = true;
		//}
	}
	
				// not sure if this posiiton was effecting the next 4 positions...
	//public Vector3 CoffeeMachinesPos = new Vector3(2.615282f, 5.342656f, 7.862321f);
	
	
	//new Vector3(16.13379f, -3.482452f, 6.18842f);
	// coffeeMakerLevel1		tag: coffeeMaker1
	Vector3 coffeeMachine1Rot = new Vector3(0, 180, 0);

	Vector3 coffeeMachine1Pos = new Vector3(18.96623f, 1.854218f, 13.51166f);//(18.96623f, 1.854218f, 13.51166f);
	Vector3 coffeeMachine1Scale = new Vector3(250, 250, 250);
	
	Vector3 coffeeMachine2Pos = new Vector3(19.81675f, 1.848863f, 17.21671f); //(19.81675f, 1.906335f, 17.21671f); //(19.81675f, 1.906335f, 17.21671f); //(25.96623f, 1.854218f, 13.51166f); //(0.01065969f, -0.002764772f, 0.03486542f); //(17.22975f, -3.470431f, 9.385904f);
	Vector3 coffeeMachine2Rot = new Vector3(0, 0, 0);
	Vector3 coffeeMachine2Scale = new Vector3(225, 225, 225);
	
	Vector3 coffeeMachine3Pos = new Vector3(17.08269f, 1.744937f, 9.790641f); //14.50232f, -3.636328f, 1.99104f);
	// coffeeMakerLevel3		tag: coffeeMaker3
	Vector3 coffeeMachine3Rot = new Vector3(0, 0, 0);
	Vector3 coffeeMachine3Scale = new Vector3(200, 200, 200);
	
	Vector3 coffeeMachine4Pos = new Vector3(9.193657f, 1.906335f, 19.72051f); //18.11771f); //(9.193657f, 1.906335f, 18.11771f); //(6.751243f, -3.515523f, 11.89497f);
	Vector3 coffeeMachine4Rot = new Vector3(0, 270, 0);
	Vector3 coffeeMachine4Scale = new Vector3(225, 225, 225);
	
	//private later
	//public void addCoffeeMachine(int machineLevelNum)
	//{
		/*switch (machineLevelNum)
		{
			case 1:
				coffeeMachineModel1 = (GameObject)Instantiate(Resources.Load("CoffeeMachine1")); //, coffeeMachine1Pos, Quaternion.identity);
				coffeeMachineModel1.transform.localScale = coffeeMachine1Scale;	
				coffeeMachineModel1.transform.position = coffeeMachine1Pos; //new Vector3(16.13379f, -3.482452f, 6.18842f);	
				coffeeMachineModel1.transform.Rotate(coffeeMachine1Rot);	
			break;
		case 2:
				coffeeMachineModel2 = (GameObject)Instantiate(Resources.Load("CoffeeMachine2"));
				coffeeMachineModel2.transform.localScale = coffeeMachine2Scale;	
				coffeeMachineModel2.transform.position = coffeeMachine2Pos; 
				coffeeMachineModel2.transform.Rotate(coffeeMachine2Rot);	
				//print ("position3");
				//print (coffeeMachineModel2.transform.localPosition);
				//print (coffeeMachineModel2.transform.position);
				
			break;
		case 3:
				coffeeMachineModel3 = (GameObject)Instantiate(Resources.Load("CoffeeMachine3")); //, coffeeMachine1Pos, Quaternion.identity);
				coffeeMachineModel3.transform.localScale = coffeeMachine3Scale;	
				coffeeMachineModel3.transform.position = coffeeMachine3Pos; //new Vector3(16.13379f, -3.482452f, 6.18842f);	
				coffeeMachineModel3.transform.Rotate(coffeeMachine3Rot);
			break;
		case 4:
				coffeeMachineModel4 = (GameObject)Instantiate(Resources.Load("CoffeeMachine4")); //, coffeeMachine1Pos, Quaternion.identity);
				coffeeMachineModel4.transform.localScale = coffeeMachine4Scale;	
				coffeeMachineModel4.transform.position = coffeeMachine4Pos; //new Vector3(16.13379f, -3.482452f, 6.18842f);	
				coffeeMachineModel4.transform.Rotate(coffeeMachine4Rot);
			break;
		default:
			break;
		}*/
		
		//coffeeMachine = GameObject.FindGameObjectWithTag("GameController").AddComponent<CoffeeMachine>(); //Coffee Machine
		//coffeeMachine.setCoffeeMachineType(machineLevelNum);
		
		/*Instantiate(Resources.Load("CoffeeMachine1"), new Vector3(16.13379f, -3.482452f, 6.18842f), Quaternion.identity);
		coffeeMakerLevel1 = GameObject.FindGameObjectWithTag("coffeeMaker1").AddComponent<CoffeeMachine>(); //(this);
		*/
		//coffeeMakerLevel1 = (CoffeeMachine) Instantiate(Resources.Load("coffeeMachineLevel1"), new Vector3(16.13379f, -3.482452f, 6.18842f), Quaternion.identity);
		//Instantiate(coffeeMachineLevel1, new Vector3(16.13379, -3.482452, 6.18842), Quaternion.identity);
		//Instantiate(Resources.Load("Customer"), new Vector3(5, 1, 0), Quaternion.identity);
		
				// try 3 based on atlas sneezed code
		/*
		coffeeMachineModel = (GameObject)Instantiate(CoffeeMachine1, new Vector3(16.13379f, -3.482452f, 6.18842f), Quaternion.identity);
		cm1script = coffeeMachine.AddComponent<CoffeeMachine>();
		coffeeMachine = coffeeMachineModel.AddComponent<CoffeeMachine>();*/
		//coffeeMachine = transform.position = new Vector3(xPosition, 40.0f, 0.0f);
		
		
		
		//return true;
	//}
	
	// Sort of like a fake constructor??
	public bool createCoffeeMachineType (int machineLevel) //public CoffeeMachine (int machineLevel) //(CoffeeMachineType machineType)
	{
		
		switch (machineLevel) //switch (machineType)
		{
			case 1:
				objectName = GameConstants.coffeeMachine1Name;	
				cost = GameConstants.coffeeMachine1Cost;
				drinkQuality = QualityRating.low;
			
				coffeeMachineModel1 = GameObject.FindGameObjectWithTag("coffeeMaker1"); //(GameObject)Instantiate(Resources.Load("CoffeeMachine1")); //, coffeeMachine1Pos, Quaternion.identity);
				coffeeMachineModel1.transform.localScale = coffeeMachine1Scale;	
				coffeeMachineModel1.transform.position = coffeeMachine1Pos; //new Vector3(16.13379f, -3.482452f, 6.18842f);	
				coffeeMachineModel1.transform.Rotate(coffeeMachine1Rot);
				return true;
			//break;
			case 2:
				objectName = GameConstants.coffeeMachine2Name;	
				cost = GameConstants.coffeeMachine2Cost;
				drinkQuality = QualityRating.med;
			
				coffeeMachineModel2 = GameObject.FindGameObjectWithTag("coffeeMaker2"); //(GameObject)Instantiate(Resources.Load("CoffeeMachine2"));
				coffeeMachineModel2.transform.localScale = coffeeMachine2Scale;	
				coffeeMachineModel2.transform.position = coffeeMachine2Pos; 
				coffeeMachineModel2.transform.Rotate(coffeeMachine2Rot);
				return true;
			//break;
			case 3:
				objectName = GameConstants.coffeeMachine3Name;	
				cost = GameConstants.coffeeMachine3Cost;
				drinkQuality = QualityRating.high;
			
				coffeeMachineModel3 = GameObject.FindGameObjectWithTag("coffeeMaker3"); //(GameObject)Instantiate(Resources.Load("CoffeeMachine3"));
				coffeeMachineModel3.transform.localScale = coffeeMachine3Scale;	
				coffeeMachineModel3.transform.position = coffeeMachine3Pos;
				//new Vector3(16.13379f, -3.482452f, 6.18842f);	
				coffeeMachineModel3.transform.Rotate(coffeeMachine3Rot);
				return true;
			//break;
			case 4:
				objectName = GameConstants.coffeeMachine4Name;	
				cost = GameConstants.coffeeMachine4Cost;
				drinkQuality = QualityRating.highest;
			
				coffeeMachineModel4 = GameObject.FindGameObjectWithTag("coffeeMaker4"); //(GameObject)Instantiate(Resources.Load("CoffeeMachine4"));
				coffeeMachineModel4.transform.localScale = coffeeMachine4Scale;	
				coffeeMachineModel4.transform.position = coffeeMachine4Pos;
				//new Vector3(16.13379f, -3.482452f, 6.18842f);	
				coffeeMachineModel4.transform.Rotate(coffeeMachine4Rot);
				return true;
			//break;
			
			default: // case 1
				//objectName = GameConstants.coffeeMachine1Name;	
				//cost = GameConstants.coffeeMachine1Cost;
				//drinkQuality = QualityRating.low;
				return false;
			//break;
		}
		

	}
	
	void OnGUI()
	{
		// If making drink
		if(inUse)
		{
			drawProgressBar(); 			// display progress bar
			progress += clock.deltaTime; //Time.deltaTime; // Increment progress
		}
		else
		{	
			progress = 0f; // Otherwise set progress to 0
		}
	}
	
	
	
	//................. not sure if i like this......................
	
	public int calculateDrinkSpeed()
	{
		return 5 - (int)drinkQuality;
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
		progressBarFillTexture.pixelInset = new Rect(barX,barY,barW,barH * (calculateDrinkSpeed() * 2 - progress) / (calculateDrinkSpeed() * 2)); 
	}
	
	
	public int getCost () { return cost; }

}
	
	/*
	public AdvertisementType getType () { return type; }

	public int getCost () { return cost; }

	public int getHype () { return hypeFactor; }
	*/


	
	//public CoffeeMachine coffeeMachine; //cm1script;
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

	
	void OnGUI()
	{
		// If making drink
		if(inUse)
		{
			drawProgressBar(); 			// display progress bar
			progress += clock.deltaTime; //Time.deltaTime; // Increment progress
		}
		else
		{
			progress = 0f; // Otherwise set progress to 0
		}
	}
*/