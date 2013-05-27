/*
 * Interface ---> I realize this is an awful class name, don't judge me
 * 
 * TODO: finish description
 * 
 * This class is responsible for displaying all GUI components in the game on screen
 * 
 * Notes: 
 */

using UnityEngine;
using System;
using System.Collections;


public class Interface : MonoBehaviour {
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	GameObject room;
	
	// TODO: change font size/color of stuff *****
	
	
	// ----- Constants for placement of interface elements ----- //
	
	// --- Display of current funds ---
	// Near upper left hand corner
	const int fundsX = 10;
	const int fundsY = 10;
	const int fundsW = 185;
	const int fundsH = 30; //50;
	
	// --- Display of cafe's popularity ---
	// Popularity consists of customer satisfaction + hype from ads
	// When displaying, the hype level and satisfaction should be 2 diff colors
	// in a status bar labeled "popularity"
	
	// The established/long-term customer satisfaction rating of this coffee shop
	// The current "hype" level for this coffee shop
	// (boosts to popularity due to advertising)
	const int popX = 10;
	const int popY = 50; //125;
	const int popW = 185;
	const int popH = 75;
	
	
	// --- Display of current day and time ---
	// Near upper right hand corner
	int dateX = Screen.width - 110;
	const int dateY = 10;
	const int dateW = 100;
	const int dateH = 65;
	
	//Display of Price Setter Input
	int priceX = Screen.width - 110;
	const int priceY = 100;
	const int priceW = 100;
	const int priceH = 50;
	
	
	// TODO: not sure if will add pictures to the buttons.....
	
	// --- Display of buy/shop upgrade button ---
	const int buyButtonX = 10;
	const int buyButtonY = 150;
	const int buyButtonW = 120;
	const int buyButtonH = 30;
	
	// --- Display of buy/shop upgrade menu ---
	
	const int buyMenuX = buyButtonW + 25; 
	const int buyMenuY = buyButtonY; 
	const int buyMenuW = 100;
	const int buyMenuH = 100;
	
	
	
	
	
	// --- Display of advertisement/marketing button ---
	const int adButtonX = 10;
	const int adButtonY = 200; //100;
	const int adButtonW = 120;
	const int adButtonH = 30;
	
	// --- Display of advertisement/marketing menu ---
	
	const int adMenuX = adButtonW + 25; //adButtonX;
	const int adMenuY = adButtonY; //adButtonY+50;
	const int adMenuW = 100;
	const int adMenuH = 100;
	
	// drinkssoldtoday
	// revenue today
	
	int costVal = GameConstants.initialDrinkCost;
	

		
	//
	// Use this for initialization
	//
	void Start () {
		
		// use built-in tag because i'm too lazy to make my own tag
		room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		cafe = room.GetComponent<CoffeeShop>();
		
		//if (cafe == null) print ("NO CAFE!");
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
		cafe.setDrinkCost(costVal);
	
	}
	
	// UnityGUI controls make use of a special function called OnGUI().
	// The OnGUI() function gets called every frame as long as the
	// containing script is enabled - just like the Update() function.
	void OnGUI () {
		
		// Notes:
		// Rect: x, y, width, height
		// top left: 0,0,100,50
		// top right: Screen.width - 100,0,100,50
		// bottom left: (0,Screen.height - 50,100,50)
		// bottom right: (Screen.width - 100,Screen.height - 50,100,50)
		
		// y: 40, 65, 90,115, 140 --> i.e. 25 is nice line height for labels

		displayCurrentFunds();
		displayPopularity();
		displayCurrentDayTime();
		
		// ----- Buttons, Buy Menus, etc. ----- //
		displayBuyButton();
		displayAdvertisements();
		
		//Input for changing costs
		displayPriceSetter();
		
		/*		
		GUI.Label (new Rect (x-10,40,120,20), "Drinks sold today: " + imp.currentFearLevel);
		GUI.Label (new Rect (x-10,65,120,20), "Revenue for today: " + imp.currentMotivationLevel);
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}*/
		
	}

/*---------------------------------------------------------------------------
  Name   :  displayCurrentFunds
  Purpose:  Display the current amount of money that the player has on screen
  Receive:  null
  Return :  void
---------------------------------------------------------------------------*/	
	void displayCurrentFunds()
	{
		// Make a background box ...near the top left screen corner
		//GUI.Box(new Rect(10,10,100,75), "Current Funds: ");
		//GUI.Box(new Rect(fundsX,fundsY,fundsW,fundsH), "Current Funds: ");
		
		// Since label is inside box, make sure position is relative to position of box
		//GUI.Label(new Rect (fundsX+10,fundsY+25,fundsW,fundsH), "$" + cafe.funds);
		
		// TODO: change font size/color *****
		
		GUI.Box(new Rect(fundsX,fundsY,fundsW,fundsH), "Current Funds: $"+ cafe.funds);
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayCurrentDayTime
  Purpose:  Display the current day and time of day
  Receive:  null
  Return :  void
---------------------------------------------------------------------------*/	
	void displayCurrentDayTime()
	{
		GUI.Box(new Rect(dateX,dateY,dateW,dateH), "Day: X" /*+ day in game */ );
		
		GUI.Label(new Rect (dateX+10,dateY+20,dateW,dateH), "Hour" + ":" + "Min" + "PM"); //........
	}
	

/*---------------------------------------------------------------------------
  Name   :  displayPopularity
  Purpose:  Display the popularity of this coffee shop
  			TODO: in meter form.....???? ***
  Receive:  null
  Return :  void
---------------------------------------------------------------------------*/
	void displayPopularity()
	{
		int lineHeight = 20;
		int y = popY+5;
		//GUI.Box(new Rect(popX,popY,popW,popH), "Popularity: " + cafe.popularity);
		
		GUI.Box(new Rect(popX,popY,popW,popH), "");
		GUI.Label(new Rect(popX+12,y,popW,popH), "Popularity: " + cafe.popularity);
		GUI.Label(new Rect (popX+25,y+lineHeight,popW,popH), "Customer Satisfaction: " + cafe.satisfactionRating); 
		GUI.Label(new Rect (popX+25,y+2*lineHeight,popW,popH), "Hype: " + cafe.hypeLevel); 
		
		// pretty sure i can type text and use \n for line breaks... will figure out later ***
		// seems silly to be making rects inside a box
	}
	
	

	// Note: for private variable booleans, use an "IsX" naming convention
	// especially with visibility
	
	private bool adMenuIsVisible = false; //advertisementDisplay = false;
	
	private bool buyMenuIsVisible = false;
	
	private bool priceMenuIsVisible = false;
	
/*---------------------------------------------------------------------------
  Name   :  displayAdvertisements
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void displayAdvertisements()
	{
		// COMMENT MEE..............
		if(GUI.Button(new Rect(adButtonX,adButtonY,adButtonW,adButtonH),new GUIContent("Advertisements")))
		{
			adMenuIsVisible = !adMenuIsVisible;
		}
		
		// COMMENT MEE..............
		if(adMenuIsVisible)
		{
			GUI.Window(0,new Rect(adMenuX,adMenuY,adMenuW,adMenuH),advertisementWindow,"");
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  advertisementWindow
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void advertisementWindow(int WindowId)
	{
		int x = 5;
		int y = 10;
		int lineHeight = 30;
		int w = 90;
		int h = 20;
		
		// COMMENT MEE..............
		if(GUI.Button(new Rect(x,y,w,h),"Flyers"))
		{
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.Flyer));
		}
		// COMMENT MEE..............
		else if(GUI.Button(new Rect(x,y+lineHeight,w,h),"Internet Ads"))
		{
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.InternetAd));
		}
		// COMMENT MEE..............
		else if(GUI.Button(new Rect(x, y+2*lineHeight,w,h),"Billboard"))
		{
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.Billboard));
		}
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	

	// just copy/pasted below from KG's code
	// will fix later - wanted to get it in for layout purposes
	
/*---------------------------------------------------------------------------
  Name   :  displayBuyButton
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void displayBuyButton()
	{
		// COMMENT MEE..............
		if(GUI.Button(new Rect(buyButtonX,buyButtonY,buyButtonW,buyButtonH),new GUIContent("Shop Upgrades")))
		{
			buyMenuIsVisible = !buyMenuIsVisible;
		}
		
		// COMMENT MEE..............
		if(buyMenuIsVisible)
		{
			GUI.Window(0,new Rect(buyMenuX,buyMenuY,buyMenuW,buyMenuH),buyWindow,"");
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  buyWindow
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void buyWindow(int WindowId)
	{
		int x = 5;
		int y = 10;
		int lineHeight = 30;
		int w = 90;
		int h = 20;
		
		// COMMENT MEE..............
		if(GUI.Button(new Rect(x,y,w,h),"Flyers"))
		{
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.Flyer));
		}
		// COMMENT MEE..............
		else if(GUI.Button(new Rect(x,y+lineHeight,w,h),"Internet Ads"))
		{
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.InternetAd));
		}
		// COMMENT MEE..............
		else if(GUI.Button(new Rect(x, y+2*lineHeight,w,h),"Billboard"))
		{
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.Billboard));
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayPriceSetter
  Purpose:  displays text input to change price of drink
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/	
	void displayPriceSetter(){
		GUI.Box (new Rect (priceX,priceY,priceW,priceH),"Price: $" + costVal);
		float sliderValue = GUI.HorizontalSlider (new Rect (priceX,priceY + 20,priceW,priceH - 20), (float)costVal, 0.0f, 10.0f);
		costVal = (int) sliderValue;
	}
}
