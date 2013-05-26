using UnityEngine;
using System.Collections;

// I realize this is an awful class name, don't judge me

public class Interface : MonoBehaviour {
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	GameObject room;
	
	
	
	
	// Constants for placement of interface elements
	
	// --- Display of current funds ---
	// Near upper left hand corner
	const int fundsX = 10;
	const int fundsY = 10;
	const int fundsW = 100;
	const int fundsH = 75;
		
	// --- Display of current day and time ---
	// Near upper right hand corner
	int dateX = Screen.width - 110;
	const int dateY = 10;
	const int dateW = 100;
	const int dateH = 100;
	
		
	//
	// Use this for initialization
	//
	void Start () {
		
		//print ("yeay start");
		
		// use built-in tag because i'm too lazy to make my own tag
		room = GameObject.FindGameObjectWithTag("GameController");
		
		//Transform t = room.GetComponent<Transform>();
		//print (t.position.x);
		
		// Grabs the CoffeeShop class (only once!)
		cafe = room.GetComponent<CoffeeShop>();
		
		//if (cafe == null) print ("NO CAFE!");
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
	
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

		displayCurrentFunds();
		displayCurrentDayTime();
		displayAdvertisements();
		
		/*		
		// Near upper right hand corner
		const int dateX = Screen.width - 200;
		
		GUI.Box(new Rect(x - 20,10,200,100), "Parent Menu");
		
		GUI.Label (new Rect (x-10,40,120,20), "Parent fear: " + imp.currentFearLevel);
		GUI.Label (new Rect (x-10,65,120,20), "Motivation: " + imp.currentMotivationLevel);
		GUI.Label (new Rect (x-10,90,120,20), "Parent panic: " + imp.currentPanicLevel);
		GUI.Label (new Rect (x-10,115,120,20), "Parent play: " + imp.currentPlayLevel);
		GUI.Label (new Rect (x-10,140,120,20), "Emotion: " + imp.currentEmotion);

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
		GUI.Box(new Rect(fundsX,fundsY,fundsW,fundsH), "Current Funds: ");
		
		GUI.Label(new Rect (fundsX+10,fundsY+25,fundsW,fundsH), "$" + cafe.funds);
		
		// TODO: change font size/color
	}
	
/*---------------------------------------------------------------------------
  Name   :  displayCurrentDayTime
  Purpose:  Display the current day and time of day
  Receive:  null
  Return :  void
---------------------------------------------------------------------------*/	
	void displayCurrentDayTime()
	{
		// (0,Screen.height - 50,100,50), "Bottom-left");
		GUI.Box(new Rect(dateX,dateY,dateW,dateH), "Day: X" /*+ day in game */ );
		
		GUI.Label(new Rect (dateX+50,dateY+20,dateW,dateH), "Hour" + ":" + "Min" + "PM"); //........
	}
	
	private bool advertisementDisplay = false;
	void displayAdvertisements(){
		if(GUI.Button(new Rect(10,100,120,30),new GUIContent("Advertisements"))){
			advertisementDisplay = !advertisementDisplay;
		}
		if(advertisementDisplay){
			GUI.Window(0,new Rect(10,150,100,100),advertisementWindow,"");
		}
	}
	
	void advertisementWindow(int WindowId){
		if(GUI.Button(new Rect(5,10,90,20),"Flyers")){
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.Flyer));
		} else if(GUI.Button(new Rect(5,40,90,20),"Internet Ads")){
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.InternetAd));
		} else if(GUI.Button(new Rect(5, 70,90,20),"Billboard")){
			cafe.buyAdvertisement(new Advertisement(AdvertisementType.Billboard));
		}
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	
	
}
