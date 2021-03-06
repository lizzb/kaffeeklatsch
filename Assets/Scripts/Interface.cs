/*
 * Interface ---> I realize this is an awful class name, don't judge me please
 * 
 * 
 * This class is responsible for displaying all GUI game components on screen,
 * including the funds, time, day, speed, buy buttons w/ functionality, price, etc.
 * 
 * Notes: 
 * 	// TODO: change font size/color *****
* 	
* 	// Note: the functions to buy coffee machines and decorations take in a number,
	// which indicates the level 1-4 of the object, e.g.:
	//cafe.buyCoffeeMachine(1); 
	// Buying an advertisement is done differently, e.g.:
	//cafe.buyAdvertisement(new Advertisement(AdvertisementType.Flyer));
	// not sure which is better form/practice or more maintainable/readable
			
 */

using UnityEngine;
using System;
using System.Collections;

// TODO: change font size/color of stuff *****
// TODO: maybe add functions canAfford or alreadyHave to disable buttons/display text in red or something???

public class Interface : MonoBehaviour {
	
	// need to instantiate.... want to get icons ON to the buttons!!
	// ... but then gave up
	//public Texture employeeIcon; // GUITexture??
	//public Texture coffeeCupIcon;
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	Clock clock;
	
	

	
	// Note: for private variable booleans, use an "IsX" naming convention
	// especially with visibility
	
	
	// TODO: need BETTER fix so only open 1 window/menu at a time (but this works) ***
	// either GUI Selection Grid or GUI Begin/End group?
	private bool buyMenuIsVisible = false;
	private bool adMenuIsVisible = false;
	private bool decorMenuIsVisible = false;
	private bool infoWindowIsVisible = true;
	//private bool empMenuIsVisible = false;
	
	
	// this might be really hacky, but i couldn't figure out a better way to
	// enable/disable buttons elegantly
	bool enableBuyButton1 = true;
	bool enableBuyButton2 = true;
	bool enableBuyButton3 = true;
	bool enableBuyButton4 = true;

	bool enableDecoButton1 = true;
	bool enableDecoButton2 = true;
	bool enableDecoButton3 = true;
	bool enableDecoButton4 = true;
	
	
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
	// ---> never got to that level of display, just numbers indented, sadly
	
	// The established/long-term customer satisfaction rating of this coffee shop
	// The current "hype" level for this coffee shop
	// (boosts to popularity due to advertising)
	const int popX = leftPaddingX;
	const int popY = 50; //125;
	const int popW = 185;
	const int popH = 75;
	
	
	// --- Display of current day and time ---
	// Near upper right hand corner
	int dateX = Screen.width - 120;  // can't do const if getting value from Screen
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
	
	
	// * ----- Display of decorations button ----- * //
	const int decorButtonX = leftPaddingX;
	const int decorButtonY = firstButtonY + 2*vertSpaceBtwButtons; //250;
	const int decorButtonW = 120;
	const int decorButtonH = 30;
	
	// --- Display of decorations menu ---
	
	const int decorMenuX = decorButtonW + 25; 
	const int decorMenuY = decorButtonY; 
	const int decorMenuW = 265; // same as buy menu 
	const int decorMenuH = 150; // same as buy menu
	
	
	// at last minute replaced employee button/menu location with decorations
	// didn't get to worthwhile employee hiring/firing functionality
	// QUICK FIX: USING EMP MENU STUFF FOR DECORATIONS
	/*
	// * ----- Display of employees button ----- * //
	const int empButtonX = leftPaddingX;
	const int empButtonY = firstButtonY + 2*vertSpaceBtwButtons; //250;
	const int empButtonW = 120;
	const int empButtonH = 30;
	
	// --- Display of employees menu ---
	
	const int empMenuX = empButtonW + 25; 
	const int empMenuY = empButtonY; 
	const int empMenuW = 265; //135; //100
	const int empMenuH = 150; //80; //100
	*/
	

	
	// ---End of Day Report Window --
	const int eodWindowX = 200;
	const int eodWindowY = 100;
	int eodWindowW = Screen.width - 400;
	int eodWindowH = Screen.height - 200;
	
	// --- Information Button ---
	int infoX = Screen.width - 190;
	const int infoY = 10;
	const int infoW = 35; //60;
	const int infoH = 35; // 60;
	Texture2D informationIcon;
	
	// --- Information Window ---
	const int infoWindowX = 200; 
	const int infoWindowY = 100; 
	int infoWindowW = Screen.width - 400; 
	int infoWindowH = Screen.height - 200; 
	
	
	// drinkssoldtoday
	// revenue today
	int costVal = GameConstants.initialDrinkCost;
		

	// ---------- Use this for initialization ---------- //
	void Start () {
		
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
		GUI.enabled = true;
		
		// Set cafe's cost of a drink (set with a slider in the interface)
		cafe.moneyManager.setDrinkCost(costVal);
		
		// this wasn't working for some reason... wonder why??
		
		// FOR SOME REASON DISABLES EVERYTHING, EVEN IF CAN AFFORD
		// BUT IF I DONT INCLUDE CAN AFFORD IN ENABLE STATEMENTS, PLAYER CAN BUY AND GO BANKRUPT
		// --- ended up fixing this buy doing a check inside each button, seems redundant
		//if (cafe.hasMachine1 || !cafe.moneyManager.canAffordMachine(1)) enableBuyButton1 = false;
		//if (cafe.hasMachine2 || !cafe.moneyManager.canAffordMachine(2)) enableBuyButton2 = false;
		//if (cafe.hasMachine3 || !cafe.moneyManager.canAffordMachine(3)) enableBuyButton3 = false;
		//if (cafe.hasMachine4 || !cafe.moneyManager.canAffordMachine(4)) enableBuyButton4 = false;
		
		//
		// Only enable buttons to buy objects if player does not already own them
		// If the player does not have enough money, button is not disabled,
		// but will not take any action (i.e. deduct money or crash or notify user)
		//
		
		if (cafe.hasMachine1) enableBuyButton1 = false;
		if (cafe.hasMachine2) enableBuyButton2 = false;
		if (cafe.hasMachine3) enableBuyButton3 = false;
		if (cafe.hasMachine4) enableBuyButton4 = false;
		
		if (cafe.hasDecoration1) enableDecoButton1 = false;
		if (cafe.hasDecoration2) enableDecoButton2 = false;
		if (cafe.hasDecoration3) enableDecoButton3 = false;
		if (cafe.hasDecoration4) enableDecoButton4 = false;
		

		// ----- Hacks for augmenting funds and popularity ----- //
		// M = more money, N = less money, H = more hype, G = less hype
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
		
		// Checking these variables in both update and OnGUI
		// because not sure which one will get called more
		
		if (cafe.hasMachine1) enableBuyButton1 = false;
		if (cafe.hasMachine2) enableBuyButton2 = false;
		if (cafe.hasMachine3) enableBuyButton3 = false;
		if (cafe.hasMachine4) enableBuyButton4 = false;
		
		if (cafe.hasDecoration1) enableDecoButton1 = false;
		if (cafe.hasDecoration2) enableDecoButton2 = false;
		if (cafe.hasDecoration3) enableDecoButton3 = false;
		if (cafe.hasDecoration4) enableDecoButton4 = false;
		
		
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
		
		displayDecorButton();
		
		// displayEmployeeButton(); // replaced with decorations
		
		// Input for changing costs
		displayPriceSetter();
		
		if(clock.ReachedEOD())
		{
			displayEODReport();
		}
		
		// Information Icon
		displayInformationButton();

	}

/*---------------------------------------------------------------------------
  Name   :  displayCurrentFunds
  Purpose:  Display the current amount of money that the player has on screen
  Receive:  null
  Return :  void
---------------------------------------------------------------------------*/	
	void displayCurrentFunds()
	{		
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
		
		//"Hour" + ":" + "Min" + "PM"); //........
		GUI.Label(new Rect (dateX+10,dateY+20,dateW,dateH), clock.getTimeOfDay()); 
		
		/*
		// THESE LABELS SHOULD BE REVERSED !!!!!!!
		ie u25b6 is black, u25b7 is white
		and vert lines actually black,
		but for now just don't display unless game paused (then selected --> drawn white)
		
		BUT THE logic is messing me up and i'm trying to finish this fast
		or it might have to do with font color....???
		*/
		
		// note: these unicode characters display in different sizes on mac os vs. windows
		// (much bigger triangles on windows)
		char rightTriangleW = '\u25B6'; //'\u25B8';
		char rightTriangleB = '\u25B7';//'\u25B9';
		
		char doubleVerticalLinesW = '\u2016'; // black unicode but font renders them white....?
		
		string pause = " "; // = '\u2016'.ToString(); //"||"
		string play;
		string ff;
		string fff;
		
		bool selectedSpeedColorWhite = true; // true for white, false for black
		
		if(selectedSpeedColorWhite)
		{
			// version so that white = current speed, black otherwise 
			play = rightTriangleB.ToString();
			ff = rightTriangleB.ToString() + rightTriangleB.ToString();
			fff = rightTriangleB.ToString() + rightTriangleB.ToString() + rightTriangleB.ToString();
			
			if (clock.CurrTimeSpeed == 0.0f) { pause = doubleVerticalLinesW.ToString(); }
			if (clock.CurrTimeSpeed == 1.0f) { play = rightTriangleW.ToString(); }
			if (clock.CurrTimeSpeed == 2.0f) { ff = rightTriangleW.ToString() + rightTriangleW.ToString(); }
			if (clock.CurrTimeSpeed == 4.0f) { fff = rightTriangleW.ToString() + rightTriangleW.ToString() + rightTriangleW.ToString(); }
		}
		else
		{
			// version so that black = current speed, white otherwise 
			// better visibility of controls, but little more confusing, esp with pause not turning black
			play = rightTriangleW.ToString();
			ff = rightTriangleW.ToString() + rightTriangleW.ToString();
			fff = rightTriangleW.ToString() + rightTriangleW.ToString() + rightTriangleB.ToString();
			
			if (clock.CurrTimeSpeed == 0.0f) {  }
			else if (clock.CurrTimeSpeed == 1.0f) { play = rightTriangleB.ToString(); }
			else if (clock.CurrTimeSpeed == 2.0f) { ff = rightTriangleB.ToString() + rightTriangleB.ToString(); }
			else if (clock.CurrTimeSpeed == 4.0f) { fff = rightTriangleB.ToString() + rightTriangleB.ToString() + rightTriangleB.ToString(); }
		
		}
		
		
		/*
		 * i should be making these public or making a getter but i'm lazy so... yeah
		 * 
		 * from clock:
		 * 	const float Paused = 0.0f;
			const float SpeedPlay = 1.0f;
			const float SpeedFF = 2.0f;
			const float SpeedFFF = 4.0f;
	
			public float CurrTimeSpeed = SpeedPlay;
			public float oldSpeed = Paused;
		 * 
		 * */
		
		//if (clock.CurrTimeSpeed == 0.0f) { /* don't know how to turn white?? only displays white*/ }
		//else if (clock.CurrTimeSpeed == 1.0f) { play = rightTriangleW.ToString(); }
		//else if (clock.CurrTimeSpeed == 2.0f) { ff = rightTriangleW.ToString() + rightTriangleW.ToString(); }
		//else if (clock.CurrTimeSpeed == 4.0f) { fff = rightTriangleW.ToString() + rightTriangleW.ToString() + rightTriangleW.ToString(); }
		
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
		
		GUI.Box(new Rect(popX,popY,popW,popH), ""); //"Popularity: " + cafe.popularity);
		GUI.Label(new Rect(popX+12,y,popW,popH), "Popularity: " + cafe.popularity);
		GUI.Label(new Rect (popX+25,y+lineHeight,popW,popH),
			"Customer Satisfaction: " + cafe.satisfactionRating); 
		GUI.Label(new Rect (popX+25,y+2*lineHeight,popW,popH), "Hype: " + cafe.hypeLevel); 
		
		// pretty sure i can type text and use \n for line breaks... will figure out later ***
		// seems silly to be making rects inside a box
	}


	
/*---------------------------------------------------------------------------
  Name   :  displayAdButton 
  			// displayAdvertisements - changed name to match naming scheme
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
			if (decorMenuIsVisible) decorMenuIsVisible = false;
			
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
		if(GUI.Button(new Rect(x,y,buttonWidth,h),
			"$" + GameConstants.adType1Cost + ": " + GameConstants.adType1Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.Flyer,GameConstants.adType1Cost);
		}
		// If user clicks on Intenet Ads, buy internet ads
		else if(GUI.Button(new Rect(x,y+lineHeight,buttonWidth,h),
			"$" + GameConstants.adType2Cost + ": " + GameConstants.adType2Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.TelevisionAd,GameConstants.adType2Cost);
		}
		//If user clicks on billboard, buy billboard
		else if(GUI.Button(new Rect(x, y+2*lineHeight,buttonWidth,h),
			"$" + GameConstants.adType3Cost + ": " + GameConstants.adType3Name))
		{
			cafe.buyAdvertisement(Advertisement.AdvertisementType.Billboard,GameConstants.adType3Cost);
		}
	}
	

	
/*---------------------------------------------------------------------------
  Name   :  displayBuyButton
  Purpose:  Display button that brings up menu to show buyable coffee machines
  Receive:  none
  Return :  void
---------------------------------------------------------------------------*/	
	void displayBuyButton()
	{
		// Toggle whether the Buy/Shop Upgrades button has been pressed
		if(GUI.Button(new Rect(buyButtonX,buyButtonY,buyButtonW,buyButtonH), new GUIContent("Coffee Machines"))) //coffeeCupIcon)) // shop upgrades
		{
			buyMenuIsVisible = !buyMenuIsVisible;
		}
		
		// Display buy/shop upgrade menu if button is pressed
		if(buyMenuIsVisible)
		{
			// Button was pressed presumably because player wants to 
			// display this menu, so disable others
			if (adMenuIsVisible) adMenuIsVisible = false;
			if (decorMenuIsVisible) decorMenuIsVisible = false;
			
			GUI.Window(0,new Rect(buyMenuX,buyMenuY,buyMenuW,buyMenuH),buyWindow,"");
		}
	}
	
/*---------------------------------------------------------------------------
  Name   :  buyWindow
  Purpose:  Display buttons that allows user to purchase new coffee machines
  Receive:  none
  Return :  void
---------------------------------------------------------------------------*/	
	void buyWindow(int WindowId)
	{
		// Make sure to enable the GUI, just in case another function didn't reset it
		GUI.enabled = true;
		
		//int x = windowPaddingX; //5;
		int y = 10;
		int lineHeight = 30;
		int w = buyMenuW - 2*windowPaddingX; //90;
		int h = 20;
		
		// I guess you can't grab and save GUI.Button objects...???
		//GUI.Button btn1 = GUI.Button(new Rect(windowPaddingX,y,w,h),
		//	"$" + GameConstants.coffeeMachine1Cost + ":  " + GameConstants.coffeeMachine1Name );

		
		// Enable/disable button depending on whether we've bought this item already
		// or if the player cannot afford it
		// --> actually, you enable/disable the GUI entirely for some reason, this is
		// what i found on forums...
		
		//if (enableBuyButton1) GUI.enabled = true;
		//else GUI.enabled = false;
		
		// simpler, more concise than previous 2 statements
		GUI.enabled = enableBuyButton1; 
		
		// Purchase Level 1 Coffee Machine Button
		if(GUI.Button(new Rect(windowPaddingX,y,w,h),
			"$" + GameConstants.coffeeMachine1Cost + ":  " + GameConstants.coffeeMachine1Name ))
		{
			
			if(cafe.moneyManager.canAffordMachine(1))
			{
				cafe.buyCoffeeMachine(1);
			}
			// sadly couldn't get this to work??
			/*else
			{
				GUI.Label (new Rect(windowPaddingX,y+lineHeight/2,w,h),"Insufficient funds!");
			}*/
			
			// Considered closing the window automatically when something was purchased,
			// (also in case that would've helped with updating UI, somehow)
			// but decided against it
			
			//buyMenuIsVisible = false;
		}
		
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableBuyButton2;
		
		// Purchase Level 2 Coffee Machine Button
		if(GUI.Button(new Rect(windowPaddingX,y+lineHeight,w,h),
			"$" + GameConstants.coffeeMachine2Cost + ":  " + GameConstants.coffeeMachine2Name))
		{	
			
			if(cafe.moneyManager.canAffordMachine(2))
			{
				cafe.buyCoffeeMachine(2);
			}
		}
		
	
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableBuyButton3;
		
		// Purchase Level 3 Coffee Machine Button
		if(GUI.Button(new Rect(windowPaddingX, y+2*lineHeight,w,h),
			"$" + GameConstants.coffeeMachine3Cost + ":  " + GameConstants.coffeeMachine3Name))
		{
			
			if(cafe.moneyManager.canAffordMachine(3))
			{
				cafe.buyCoffeeMachine(3);
			}
		}
		
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableBuyButton4;
		
		// Purchase Level 4 Coffee Machine Button
		if(GUI.Button(new Rect(windowPaddingX, y+3*lineHeight,w,h),
			"$" + GameConstants.coffeeMachine4Cost + ":  " + GameConstants.coffeeMachine4Name))
		{
			//if(cafe.moneyManager.canAffordMachine(4)) cafe.buyCoffeeMachine(4);
			//buyMenuIsVisible = false;
			
			if(cafe.moneyManager.canAffordMachine(4))
			{
				cafe.buyCoffeeMachine(4);
			}
		}
		
		
		// Make sure to enable the GUI again!!!
		GUI.enabled = true;
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayDecorButton
  Purpose:  Display button that brings up menu to show buyable decorations
  Receive:  none
  Return :  void
---------------------------------------------------------------------------*/	
	void displayDecorButton()
	{
		// leftovers from displayEmployeeButton
		// Toggle whether employee(s) button has been pressed
		//if(GUI.Button(new Rect(empButtonX,empButtonY,empButtonW,empButtonH),"Employees: " + cafe.empManager.employees.Count))
		
		if(GUI.Button(new Rect(decorButtonX,decorButtonY,decorButtonW,decorButtonH),"Shop Decorations"))
		{
			decorMenuIsVisible = !decorMenuIsVisible;
		}
		
		// Display employees menu if button is pressed
		if(decorMenuIsVisible)
		{
			// Button was pressed presumably because player wants to 
			// display this menu, so disable others
			if (adMenuIsVisible) adMenuIsVisible = false;
			if (buyMenuIsVisible) buyMenuIsVisible = false;
			
			GUI.Window(0,new Rect(decorMenuX,decorMenuY,decorMenuW,decorMenuH),decorWindow,"");
		}
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  decorWindow
  Purpose:  Display buttons that allows user to purchase new decorations
  Receive:  none
  Return :  void
---------------------------------------------------------------------------*/	
	void decorWindow(int WindowId)
	{
		/*
		 * leftovers from empWindow
		//int x = windowPaddingX; = 5;
		int y = 10;
		int lineHeight = 30;
		int w = empMenuW - 2*windowPaddingX; // 10; //125;
		int h = 20;
		*/
		/*
		if(GUI.Button(new Rect(windowPaddingX,y,w,h),"Hire an employee"))
		{
			cafe.empManager.hireEmployee();
		}
		else if(GUI.Button(new Rect(windowPaddingX,y+lineHeight,w,h),"Fire an employee"))
		{
			cafe.empManager.fireEmployee();
		}
		*/
		
		GUI.enabled = true;
		
		//int x = windowPaddingX; //5;
		int y = 10;
		int lineHeight = 30;
		int w = decorMenuW - 2*windowPaddingX; //90;
		int h = 20;
		
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableDecoButton1;
		
		// Purchase Level 1 Decoration Button
		if(GUI.Button(new Rect(windowPaddingX,y,w,h),
			"$" + GameConstants.decoration1Cost + ":  " + GameConstants.decoration1Name ))
		{
			if(cafe.moneyManager.canAffordDecoration(1))
			{
				cafe.buyDecoration(1);
			}
		}
		
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableDecoButton2;
		
		// Purchase Level 2 Decoration Button
		if(GUI.Button(new Rect(windowPaddingX,y+lineHeight,w,h),
			"$" + GameConstants.decoration2Cost + ":  " + GameConstants.decoration2Name ))
		{
			if(cafe.moneyManager.canAffordDecoration(2))
			{
				cafe.buyDecoration(2);
			}
		}
		
	
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableDecoButton3;
		
		// Purchase Level 3 Decoration Button
		if(GUI.Button(new Rect(windowPaddingX, y+2*lineHeight,w,h),
			"$" + GameConstants.decoration3Cost + ":  " + GameConstants.decoration3Name ))
		{
			if(cafe.moneyManager.canAffordDecoration(3))
			{
				cafe.buyDecoration(3);
			}
		}
		
		// Enable/disable button depending on whether we've bought this item already
		GUI.enabled = enableDecoButton4;
		
		// Purchase Level 4 Decoration Button
		if(GUI.Button(new Rect(windowPaddingX, y+3*lineHeight,w,h),
			"$" + GameConstants.decoration4Cost + ":  " + GameConstants.decoration4Name ))
		{
			if(cafe.moneyManager.canAffordDecoration(4))
			{
				cafe.buyDecoration(4);
			}
		}
		
		GUI.enabled = true;	
			
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
		costVal = (int) GUI.HorizontalSlider
			(new Rect (priceX,priceY + 20,priceW,priceH - 20),
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
		GUI.Window(3,new Rect(eodWindowX,eodWindowY,eodWindowW,eodWindowH),
			EODWindow,"End of Day Report");
	}
	
/*---------------------------------------------------------------------------
  Name   :  EODWindow
  Purpose:  displays end of day report
  Receive:  nothing, just ui 
  Return :  nothing, just ui
---------------------------------------------------------------------------*/
	void EODWindow(int windowID)
	{
		int y = 20;
		int w = eodWindowW - windowPaddingX * 2;
		int h = 20;
		
		GUI.Label (new Rect(windowPaddingX,y,w,h),
			"Revenue: " + cafe.moneyManager.dailyRevenue);
		GUI.Label (new Rect(windowPaddingX,y + h,w,h),
			"     Number of Drinks Sold: " + cafe.moneyManager.dailyNumDrinksSold);
		GUI.Label (new Rect(windowPaddingX,y + h * 2,w,h),
			"Daily Costs: " + cafe.moneyManager.calculateDailyCosts());
		GUI.Label (new Rect(windowPaddingX,y + h * 3,w,h),
			"     Rent: " + cafe.moneyManager.rent);
		GUI.Label (new Rect(windowPaddingX,y + h * 4,w,h),
			"     Employee Wages: " + cafe.moneyManager.calculateDailyTotalEmployeesWagesTotal());
		
		// If click on advance day button
		if(GUI.Button(new Rect(windowPaddingX, eodWindowH - y * 2,w,h),"Advance Day"))
		{ 
			clock.advanceDay(); //Advances day
		}
	}
	
	void displayInformationButton()
	{
		if(GUI.Button(new Rect(infoX,infoY,infoW,infoH),informationIcon))
		{
			infoWindowIsVisible = true;
		}
		
		if(infoWindowIsVisible)
		{
			clock.pause ();
			GUI.Window (0,new Rect(infoWindowX,infoWindowY,infoWindowW,infoWindowH),infoWindow,"kaffeeklatsch Instructions");
		}
	}
	
	void infoWindow(int windowID)
	{
		int y = 20;
		int w = eodWindowW - windowPaddingX * 2;
		int h = 20;
		GUI.Label(new Rect(windowPaddingX,y,w,h * 2),"Welcome to kaffeeklatsch, a coffee shop simulation game. You are the owner of this coffeeshop,with the dream of making the most money as quicky as possible.");
		GUI.Label (new Rect(windowPaddingX,y + h * 2, w, h),"Your goal is to make $" + GameConstants.moneyGoalWin + " by day " + GameConstants.maxNumberOfDays + ".");
		GUI.Label (new Rect(windowPaddingX,y + h * 3,w,h * 2),"You can change the speed of the game by pressing 1, 2 or 3. You can pause the game by pressing 'p'");
		GUI.Label (new Rect(windowPaddingX,y + h * 5,w, h),"Buying Coffee Machines will increase your drink quality and decrease the time it takes to make coffee.");
		GUI.Label (new Rect(windowPaddingX,y + h * 6,w, h),"Buying Advertisements will increase your hype for a certain period of time.");
		GUI.Label (new Rect(windowPaddingX,y + h * 7,w, h),"Buying Decorations will improve your shop and increase customer patience.");
		GUI.Label (new Rect(windowPaddingX,y + h * 8,w, h * 2),"You can adjust the price of coffee anytime using the slider on the left, but it will impact your customer satisfaction.");
		
		if(GUI.Button(new Rect(windowPaddingX,y + h * 10, w, h),"Close"))
		{
			infoWindowIsVisible = false;
			clock.play();
		}
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
}
