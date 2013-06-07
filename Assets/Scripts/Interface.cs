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

// TODO: change font size/color of stuff *****
// TODO: maybe add functions canAfford or alreadyHave to disable buttons/display text in red or something???

public class Interface : MonoBehaviour {
	
	//need to instantiate.... want to get icons ON to the buttons!!
	public Texture employeeIcon; // GUITexture??
	public Texture coffeeCupIcon;
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	Clock clock;
	
	
	// TODO: change font size/color *****
	
	// Note: for private variable booleans, use an "IsX" naming convention
	// especially with visibility
	
	
	// TODO: need to fix something about these windows so only 1 open at a time *******
	// either GUI Selection Grid or GUI Begin/End group?
	private bool buyMenuIsVisible = false;
	private bool adMenuIsVisible = false; //advertisementDisplay = false;
	private bool empMenuIsVisible = false;
	private bool infoWindowIsVisible = false;
	
	
	// this is really hacky..... - lizz
		bool enableBuyButton1 = true;
		bool enableBuyButton2 = true;
		bool enableBuyButton3 = true;
		bool enableBuyButton4 = true;

	
	
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
	const int buyMenuW = 265; //200; //100;
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
	const int eodWindowY = 100;
	int eodWindowW = Screen.width - 400;
	int eodWindowH = Screen.height - 200;
	
	// --- Information Button ---
	int infoX = Screen.width - 190;
	const int infoY = 10;
	const int infoW = 60;
	const int infoH = 60;
	Texture2D informationIcon;
	
	// --- Information Window ---
	const int infoWindowX = 200; 
	const int infoWindowY = 100; 
	int infoWindowW = Screen.width - 400; 
	int infoWindowH = Screen.height - 200; 
	
	
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
		
		informationIcon = (Texture2D) Resources.Load ("information");
	
		//employeeIcon = (Texture) GameObject.FindGameObjectWithTag("employeeIcon").GetComponent<GUITexture>();
		//coffeeCupIcon = (Texture) GameObject.FindGameObjectWithTag("coffeeCupIcon").GetComponent<GUITexture>();
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		//Set drink cost of cafe
		cafe.moneyManager.setDrinkCost(costVal);
		
		if (cafe.hasMachine1 || !cafe.moneyManager.canAffordMachine(1)) enableBuyButton1 = false;
		if (cafe.hasMachine2 || !cafe.moneyManager.canAffordMachine(2)) enableBuyButton2 = false;
		if (cafe.hasMachine3 || !cafe.moneyManager.canAffordMachine(3)) enableBuyButton3 = false;
		if (cafe.hasMachine4 || !cafe.moneyManager.canAffordMachine(4)) enableBuyButton4 = false;
		
		// ----- Hacks for augmenting funds and popularity ----- //
		if(Input.GetKeyDown(KeyCode.M)) { cafe.moneyManager.funds += cafe.moneyManager.drinkCost; }
		
		if(Input.GetKeyDown (KeyCode.N)) { cafe.moneyManager.funds -= cafe.moneyManager.drinkCost; }
		
		if(Input.GetKeyDown(KeyCode.H)) { cafe.hypeLevel += 10; } //changed because P used for pause
		
		if(Input.GetKeyDown(KeyCode.G)){ cafe.hypeLevel -= 10; }
	}
	
	// UnityGUI controls make use of a special function called OnGUI().
	// The OnGUI() function gets called every frame as long as the
	// containing script is enabled - just like the Update() function.
	void OnGUI () {
		
		GUI.enabled = true;
		
		if (cafe.hasMachine1 || !cafe.moneyManager.canAffordMachine(1)) enableBuyButton1 = false;
		if (cafe.hasMachine2 || !cafe.moneyManager.canAffordMachine(2)) enableBuyButton2 = false;
		if (cafe.hasMachine3 || !cafe.moneyManager.canAffordMachine(3)) enableBuyButton3 = false;
		if (cafe.hasMachine4 || !cafe.moneyManager.canAffordMachine(4)) enableBuyButton4 = false;
		
		// Notes:
		// Rect: x, y, width, height
		// top left: 0,0,100,50
		// top right: Screen.width - 100,0,100,50
		// bottom left: (0,Screen.height - 50,100,50)
		// bottom right: (Screen.width - 100,Screen.height - 50,100,50)
		
		// y: 40, 65, 90,115, 140 --> i.e. 25 is nice line height for labels

		displayCurrentFunds();
		displayPopularity();
		displayCurrentDayTimeSpeed();
		
		// ----- Buttons, Buy Menus, etc. ----- //
		displayBuyButton();
		displayAdButton();
		
		//displayEmployeeButton();
		
		// Input for changing costs
		displayPriceSetter();
		
		if(clock.ReachedEOD())
		{
			displayEODReport();
		}
		
		// Information Icon
		displayInformationButton();
		

		
	
				
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
		
		
		GUI.Box(new Rect(fundsX,fundsY,fundsW,fundsH), "Current Funds: $"+ cafe.moneyManager.funds);
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayCurrentDayTime
  Purpose:  Display the current day and time of day
  Receive:  null
  Return :  void
---------------------------------------------------------------------------*/	
	void displayCurrentDayTimeSpeed()
	{
		GUI.Box(new Rect(dateX,dateY,dateW,dateH), "Day: " + clock.days);
		
		//GUI.Label(new Rect (dateX+10,dateY+20,dateW,dateH), clock.displayTime2());
		//"Hour" + ":" + "Min" + "PM"); //........
		GUI.Label(new Rect (dateX+10,dateY+20,dateW,dateH), clock.getTimeOfDay()); 
		
		
		char rightTriangleB = '\u25B6'; //'\u25B8';
		char rightTriangleW = '\u25B7';//'\u25B9';
		string pause = '\u2016'.ToString (); //"||"
		
		
		//string play = rightTriangleW.ToString();
		//string ff = rightTriangleW.ToString() + rightTriangleW.ToString();
		//string fff = rightTriangleW.ToString() + rightTriangleW.ToString() + rightTriangleB.ToString();
		
		/* version so that white = current speed, black otherwise */ 
		
		string play = rightTriangleB.ToString();
		string ff = rightTriangleB.ToString() + rightTriangleB.ToString();
		string fff = rightTriangleB.ToString() + rightTriangleB.ToString() + rightTriangleB.ToString();
		
		/*
		 * i should be making these public or making a getter but i'm lazy so... yeah
		 * 
		 * 	const float Paused = 0.0f;
	const float SpeedPlay = 1.0f;
	const float SpeedFF = 2.0f;
	const float SpeedFFF = 4.0f;
	
	public float CurrTimeSpeed = SpeedPlay;
	public float oldSpeed = Paused;
		 * 
		 * */
		
		if (clock.CurrTimeSpeed == 0.0f) { /* don't know how to turn white?? only displays white*/ }
		else if (clock.CurrTimeSpeed == 1.0f) { play = rightTriangleW.ToString(); }
		else if (clock.CurrTimeSpeed == 2.0f) { ff = rightTriangleW.ToString() + rightTriangleW.ToString(); }
		else if (clock.CurrTimeSpeed == 4.0f) { fff = rightTriangleW.ToString() + rightTriangleW.ToString() + rightTriangleW.ToString(); }
		
		// unity didn't want to compile a float switch statement...
		/*
		switch (clock.CurrTimeSpeed)
		{
		case 0.0f:
			break;
		case 1.0f:
			play = rightTriangleW.ToString();
			break;
		case 2.0f:
			ff = rightTriangleW.ToString() + rightTriangleW.ToString();
			break;
		case 4.0f:
			fff = rightTriangleW.ToString() + rightTriangleW.ToString() + rightTriangleW.ToString();
			break;
		//default:
		//	break;
		}
		*/
		string timeSpeedString = pause +"   "+ play +"   "+ ff +"   "+ fff;
		
		GUI.Label (new Rect (dateX+10,dateY+40,dateW,dateH), timeSpeedString);
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
		
		// Display Ad Menu menu if button is pressed
		if(adMenuIsVisible)
		{
			// Button was pressed presumably because player wants to 
			// display this menu, so disable others
			if (buyMenuIsVisible) buyMenuIsVisible = false;
			if (empMenuIsVisible) empMenuIsVisible = false;
			
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
		if(GUI.Button(new Rect(x,y,buttonWidth,h),"$" + GameConstants.adType1Cost + ": " + GameConstants.adType1Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.Flyer,GameConstants.adType1Cost);
		}
		// If user clicks on Intenet Ads, buy internet ads
		else if(GUI.Button(new Rect(x,y+lineHeight,buttonWidth,h),"$" + GameConstants.adType2Cost + ": " + GameConstants.adType2Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.TelevisionAd,GameConstants.adType2Cost);
		}
		//If user clicks on billboard, buy billboard
		else if(GUI.Button(new Rect(x, y+2*lineHeight,buttonWidth,h),"$" + GameConstants.adType3Cost + ": " + GameConstants.adType3Name))
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
		if(GUI.Button(new Rect(buyButtonX,buyButtonY,buyButtonW,buyButtonH), new GUIContent("Shop Upgrades"))) //coffeeCupIcon))
		{
			buyMenuIsVisible = !buyMenuIsVisible;
		}
		
		// Display buy/shop upgrade menu if button is pressed
		if(buyMenuIsVisible)
		{
			// Button was pressed presumably because player wants to 
			// display this menu, so disable others
			if (adMenuIsVisible) adMenuIsVisible = false;
			if (empMenuIsVisible) empMenuIsVisible = false;
			
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
		GUI.enabled = true;
		//int x = windowPaddingX; //5;
		int y = 10;
		int lineHeight = 30;
		int w = buyMenuW - 2*windowPaddingX; //90;
		int h = 20;
		
		//fix SO DON'T ENABLE BUTTONS WHEN object already purchased
		
		//GUI.Button btn1 = GUI.Button(new Rect(windowPaddingX,y,w,h),
		//	"$" + GameConstants.coffeeMachine1Cost + ":  " + GameConstants.coffeeMachine1Name );
		
		
		// Enable/disable button depending on whether we've bought this item already
		//if (cafe.hasMachine1 || !cafe.moneyManager.canAffordMachine(1)) GUI.enabled = false;
		///else GUI.enabled = true;
		
		//if (enableBuyButton1) GUI.enabled = true;
		//else GUI.enabled = false;
		
		GUI.enabled = enableBuyButton1;
		// Purchase Level 1 Coffee Machine 
		if(GUI.Button(new Rect(windowPaddingX,y,w,h),
			"$" + GameConstants.coffeeMachine1Cost + ":  " + GameConstants.coffeeMachine1Name ))
		{
			// TODO: this function should actually take parameters, but haven't written yet
			// not sure if i like setup of advertisement call
			//cafe.buyCoffeeMachine(1); //cafe.buyAdvertisement(new Advertisement(AdvertisementType.Flyer));
			cafe.buyCoffeeMachine(1);
			//buyMenuIsVisible = false;
			
		}
		
		// Enable/disable button depending on whether we've bought this item already
		// or if the player cannot afford it
		//if (cafe.hasMachine2 || !cafe.moneyManager.canAffordMachine(2)) GUI.enabled = false;
		//else GUI.enabled = true;
		GUI.enabled = enableBuyButton2;
		// Purchase Level 2 Coffee Machine
		//else
		if(GUI.Button(new Rect(windowPaddingX,y+lineHeight,w,h),
			"$" + GameConstants.coffeeMachine2Cost + ":  " + GameConstants.coffeeMachine2Name))
		{
			cafe.buyCoffeeMachine(2);
			//buyMenuIsVisible = false;
		}
		
	
		// Enable/disable button depending on whether we've bought this item already
		// or if the player cannot afford it
		//if (cafe.hasMachine3 || cafe.moneyManager.canAffordMachine(3) == false) GUI.enabled = false;
		//else GUI.enabled = true;
		GUI.enabled = enableBuyButton3;
		// Purchase Level 3 Coffee Machine
		//else 
		if(GUI.Button(new Rect(windowPaddingX, y+2*lineHeight,w,h),
			"$" + GameConstants.coffeeMachine3Cost + ":  " + GameConstants.coffeeMachine3Name))
		{
			cafe.buyCoffeeMachine(3);
			//buyMenuIsVisible = false;
		}
		
		// Enable/disable button depending on whether we've bought this item already
		// or if the player cannot afford it
		//if (cafe.hasMachine4 || !cafe.moneyManager.canAffordMachine(4)) GUI.enabled = false;
		//else GUI.enabled = true;
		GUI.enabled = enableBuyButton4;
		// Purchase Level 4 Coffee Machine
		//else 
		if(GUI.Button(new Rect(windowPaddingX, y+3*lineHeight,w,h),
			"$" + GameConstants.coffeeMachine4Cost + ":  " + GameConstants.coffeeMachine4Name))
		{
			cafe.buyCoffeeMachine(4);
			//buyMenuIsVisible = false;
		}
		
		GUI.enabled = true;
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
			// Button was pressed presumably because player wants to 
			// display this menu, so disable others
			if (adMenuIsVisible) adMenuIsVisible = false;
			if (empMenuIsVisible) empMenuIsVisible = false;
			
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
	}	
	
/*---------------------------------------------------------------------------
  Name   :  displayPriceSetter
  Purpose:  displays text input to change price of drink
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/	
	void displayPriceSetter()
	{
		// Box to display current price
		GUI.Box (new Rect (priceX,priceY,priceW,priceH),"Price: $" + costVal);
		
		// When slider changes value, updates cost of drinks
		costVal = (int) GUI.HorizontalSlider (new Rect (priceX,priceY + 20,priceW,priceH - 20),
			(float)costVal, 0.0f, GameConstants.maximumDrinkCost);
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  displayEODReport
  Purpose:  displays end of day report
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void displayEODReport()
	{
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
		
		GUI.Label (new Rect(windowPaddingX,y,w,h),"Revenue: " + cafe.moneyManager.dailyRevenue);
		GUI.Label (new Rect(windowPaddingX,y + h,w,h),"     Number of Drinks Sold: " + cafe.moneyManager.dailyNumDrinksSold);
		GUI.Label (new Rect(windowPaddingX,y + h * 2,w,h),"Daily Costs: " + cafe.moneyManager.calculateDailyCosts());
		GUI.Label (new Rect(windowPaddingX,y + h * 3,w,h),"     Rent: " + cafe.moneyManager.rent);
		GUI.Label (new Rect(windowPaddingX,y + h * 4,w,h),"     Employee Wages: " + cafe.moneyManager.calculateDailyTotalEmployeesWagesTotal());
		
		// If click on advance day button
		if(GUI.Button(new Rect(windowPaddingX, eodWindowH - y * 2,w,h),"Advance Day"))
		{ 
			clock.advanceDay(); //Advances day
		}
	}
	
	void displayInformationButton(){
		if(GUI.Button(new Rect(infoX,infoY,infoW,infoH),informationIcon)){
			infoWindowIsVisible = !infoWindowIsVisible;
		}
		
		if(infoWindowIsVisible){
			GUI.Window (0,new Rect(infoWindowX,infoWindowY,infoWindowW,infoWindowH),infoWindow,"kaffeeklatsch Instructions");
		} else{
		}
	}
	
	void infoWindow(int windowID){
		int y = 20;
		int w = eodWindowW - windowPaddingX * 2;
		int h = 20;
		GUI.Label(new Rect(windowPaddingX,y,w,h * 2),"Welcome to kaffeeklatsch, a coffee shop simulation game. You are the owner of this coffeeshop,\nwith the dream of making the most money as quicky as possible.");
		
	}

}
