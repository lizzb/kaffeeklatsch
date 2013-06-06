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
	Clock clock;
	
	// TODO: change font size/color of stuff *****
	
	
	// Note: for private variable booleans, use an "IsX" naming convention
	// especially with visibility
	
	
	// TODO: need to fix something about these windows so only 1 open at a time *******
	// either GUI Selection Grid or GUI Begin/End group?
	private bool buyMenuIsVisible = false;
	private bool adMenuIsVisible = false; //advertisementDisplay = false;
	private bool empMenuIsVisible = false;
	

	
	
	// ----- Constants for placement of interface elements ----- //
	
	const int leftPaddingX = 10;
	const int firstButtonY = 150;
	const int vertSpaceBtwButtons = 50;
	
	
	const int windowPaddingX = 5;
	
	// --- Display of current funds ---
	// Near upper left hand corner
	const int fundsX = leftPaddingX;
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
	const int popX = leftPaddingX;
	const int popY = 50; //125;
	const int popW = 185;
	const int popH = 75;
	
	
	// --- Display of current day and time ---
	// Near upper right hand corner
	int dateX = Screen.width - 120;
	const int dateY = 10;
	const int dateW = 110;
	const int dateH = 65;
	
	// --- Display of Price Setter Input ---
	int priceX = Screen.width - 120;
	const int priceY = 100;
	const int priceW = 110;
	const int priceH = 50;
	
	
	// TODO: not sure if will add pictures to the buttons.....**
	
	// * ----- Display of buy/shop upgrade button ----- * //
	const int buyButtonX = leftPaddingX;
	const int buyButtonY = firstButtonY; //150;
	const int buyButtonW = 120;
	const int buyButtonH = 30;
	
	// --- Display of buy/shop upgrade menu ---
	
	const int buyMenuX = buyButtonW + 25; //.......fixing of buttons/menus TODO
	const int buyMenuY = buyButtonY; 
	const int buyMenuW = 200; //100;
	const int buyMenuH = 150; //100;
	
	
	// * ----- Display of advertisement/marketing button ----- * //
	const int adButtonX = leftPaddingX;
	const int adButtonY = firstButtonY + 1*vertSpaceBtwButtons; //200; //100;
	const int adButtonW = 120;
	const int adButtonH = 30;
	
	// --- Display of advertisement/marketing menu ---
	
	const int adMenuX = adButtonW + 25; //adButtonX;
	const int adMenuY = adButtonY; //adButtonY+50;
	const int adMenuW = 130;
	const int adMenuH = 100;
	
	
	// * ----- Display of employees button ----- * //
	const int empButtonX = leftPaddingX;
	const int empButtonY = firstButtonY + 2*vertSpaceBtwButtons; //250;
	const int empButtonW = 120;
	const int empButtonH = 30;
	
	// --- Display of employees menu ---
	
	const int empMenuX = empButtonW + 25; 
	const int empMenuY = empButtonY; 
	const int empMenuW = 135; //100
	const int empMenuH = 80; //100
	
	// ---End of Day Report Window --
	const int eodWindowX = 200;
	const int eodWindowY = 50;
	int eodWindowW = Screen.width - 400;
	int eodWindowH = Screen.height - 100;
	
	
	// drinkssoldtoday
	// revenue today
	
	int costVal = GameConstants.initialDrinkCost;
		
	//
	// Use this for initialization
	//
	void Start () {
		
		// use built-in tag because i'm too lazy to make my own tag
		//GameObject room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		cafe = GameObject.FindGameObjectWithTag("GameController").GetComponent<CoffeeShop>();
		
		clock = this.GetComponent<Clock>();
	
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
		//Set drink cost of cafe
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
		displayAdButton();
		displayEmployeeButton();
		
		// Input for changing costs
		displayPriceSetter();
		
		if(clock.ReachedEOD()){
			displayEODReport();
		}
				
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
		GUI.Box(new Rect(dateX,dateY,dateW,dateH), "Day: " + clock.days);
		
		//GUI.Label(new Rect (dateX+10,dateY+20,dateW,dateH), clock.displayTime2());
		
		GUI.Label(new Rect (dateX+10,dateY+20,dateW,dateH), clock.getTimeOfDay()); //"Hour" + ":" + "Min" + "PM"); //........
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


	
/*---------------------------------------------------------------------------
  Name   :  displayAdButton  // displayAdvertisements
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void displayAdButton()
	{
		// If user clicks on Advertisement button, display ad Menu
		if(GUI.Button(new Rect(adButtonX,adButtonY,adButtonW,adButtonH),new GUIContent("Advertisements")))
		{
			adMenuIsVisible = !adMenuIsVisible;
		}
		
		// Display Ad Menu
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
		int buttonWidth = 120;
		int h = 20;
		
		// If user clicks on flyers, buy a flyer
		if(GUI.Button(new Rect(x,y,buttonWidth,h),"$" + GameConstants.adType1Cost + " " + GameConstants.adType1Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.Flyer,GameConstants.adType1Cost);
		}
		// If user clicks on Intenet Ads, buy internet ads
		else if(GUI.Button(new Rect(x,y+lineHeight,buttonWidth,h),"$" + GameConstants.adType2Cost + " " + GameConstants.adType2Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.TelevisionAd,GameConstants.adType2Cost);
		}
		//If user clicks on billboard, buy billboard
		else if(GUI.Button(new Rect(x, y+2*lineHeight,buttonWidth,h),"$" + GameConstants.adType3Cost + " " + GameConstants.adType3Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.Billboard,GameConstants.adType3Cost);
		}
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	

	
/*---------------------------------------------------------------------------
  Name   :  displayBuyButton
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void displayBuyButton()
	{
		// Toggle whether the Buy/Shop Upgrades button has been pressed
		if(GUI.Button(new Rect(buyButtonX,buyButtonY,buyButtonW,buyButtonH),new GUIContent("Shop Upgrades")))
		{
			buyMenuIsVisible = !buyMenuIsVisible;
		}
		
		// Display buy/shop upgrade menu if button is pressed
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
		//int x = windowPaddingX; //5;
		int y = 10;
		int lineHeight = 30;
		int w = buyMenuW - 2*windowPaddingX; //90;
		int h = 20;
		
		// Purchase Level 1 Coffee Machine
		if(GUI.Button(new Rect(windowPaddingX,y,w,h),
			GameConstants.coffeeMachine1Name + ": $" + GameConstants.coffeeMachine1Cost ))
		{
			// TODO: this function should actually take parameters, but haven't written yet
			// not sure if i like setup of advertisement call
			//cafe.buyCoffeeMachine(1); //cafe.buyAdvertisement(new Advertisement(AdvertisementType.Flyer));
			//cafe.addCoffeeMachine(1);
			cafe.buyCoffeeMachine(1);
			//cafe.buyCoffeeMachine(new CoffeeMachine(1));
		}
		// Purchase Level 2 Coffee Machine
		else if(GUI.Button(new Rect(windowPaddingX,y+lineHeight,w,h),
			GameConstants.coffeeMachine2Name + ": $" + GameConstants.coffeeMachine2Cost ))
		{
			cafe.buyCoffeeMachine(2);
			//cafe.buyCoffeeMachine(new CoffeeMachine(2)); //cafe.buyCoffeeMachine(2);
		}
		// Purchase Level 3 Coffee Machine
		else if(GUI.Button(new Rect(windowPaddingX, y+2*lineHeight,w,h),
			GameConstants.coffeeMachine3Name + ": $" + GameConstants.coffeeMachine3Cost ))
		{
			cafe.buyCoffeeMachine(3);
			//cafe.buyCoffeeMachine(new CoffeeMachine(3)); //cafe.buyCoffeeMachine(3);
		}
		// Purchase Level 4 Coffee Machine
		else if(GUI.Button(new Rect(windowPaddingX, y+3*lineHeight,w,h),
			GameConstants.coffeeMachine4Name + ": $" + GameConstants.coffeeMachine4Cost ))
		{
			cafe.buyCoffeeMachine(4);
			//cafe.buyCoffeeMachine(new CoffeeMachine(4)); //cafe.buyCoffeeMachine(4);
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayEmployeeButton
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void displayEmployeeButton()
	{
		// Toggle whether employee(s) button has been pressed
		if(GUI.Button(new Rect(empButtonX,empButtonY,empButtonW,empButtonH),"Employees: " + cafe.empManager.employees.Count))
		{
			empMenuIsVisible = !empMenuIsVisible;
		}
		
		// Display employees menu if button is pressed
		if(empMenuIsVisible)
		{
			GUI.Window(0,new Rect(empMenuX,empMenuY,empMenuW,empMenuH),empWindow,"");
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  empWindow
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	void empWindow(int WindowId)
	{
		//int x = windowPaddingX; = 5;
		int y = 10;
		int lineHeight = 30;
		int w = empMenuW - 2*windowPaddingX; // 10; //125;
		int h = 20;
		
		// COMMENT MEE..............
		if(GUI.Button(new Rect(windowPaddingX,y,w,h),"Hire an employee"))
		{
			cafe.empManager.hireEmployee();
		}
		// COMMENT MEE..............
		else if(GUI.Button(new Rect(windowPaddingX,y+lineHeight,w,h),"Fire an employee"))
		{
			cafe.empManager.fireEmployee();
		}
		// COMMENT MEE..............
		//else if(GUI.Button(new Rect(x, y+2*lineHeight,w,h),"Billboard"))
		//{
		//	cafe.buyAdvertisement(new Advertisement(AdvertisementType.Billboard));
		//}
	}	
	
/*---------------------------------------------------------------------------
  Name   :  displayPriceSetter
  Purpose:  displays text input to change price of drink
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/	
	void displayPriceSetter()
	{
		//Box to display current price
		GUI.Box (new Rect (priceX,priceY,priceW,priceH),"Price: $" + costVal);
		//When slider changes value, updates cost of drinks
		costVal = (int) GUI.HorizontalSlider (new Rect (priceX,priceY + 20,priceW,priceH - 20), (float)costVal, 0.0f, GameConstants.maximumDrinkCost);
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  displayEODReport
  Purpose:  displays end of day report
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void displayEODReport(){
		GUI.Window(3,new Rect(eodWindowX,eodWindowY,eodWindowW,eodWindowH),EODWindow,"End of Day Report");
	}
	
/*---------------------------------------------------------------------------
  Name   :  EODWindow
  Purpose:  displays end of day report
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void EODWindow(int windowID){
		int y = 20;
		int w = eodWindowW - windowPaddingX * 2;
		int h = 20;
		GUI.Label (new Rect(windowPaddingX,y,w,h),"Revenue: " + cafe.dailyRevenue);
		GUI.Label (new Rect(windowPaddingX,y + h,w,h),"Number of Drinks Sold: " + cafe.dailyNumDrinksSold);
		GUI.Label (new Rect(windowPaddingX,y + h * 2,w,h),"Daily Costs: " + cafe.calculateDailyCosts());
		GUI.Label (new Rect(windowPaddingX,y + h * 3,w,h),"Rent: " + cafe.rent);
		GUI.Label (new Rect(windowPaddingX,y + h * 4,w,h),"Employee Wages: " + cafe.calculateDailyTotalEmployeesWagesTotal());
		if(GUI.Button(new Rect(windowPaddingX, y + h * 6,w,h),"Advance Day")){ //If click on advance day button
			clock.advanceDay(); //Advances day
		}
	}
	

}
