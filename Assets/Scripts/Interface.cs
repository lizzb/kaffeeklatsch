using UnityEngine;
using System.Collections;

// I realize this is an awful name, don't judge me

public class Interface : MonoBehaviour {
	
	// Access to the coffee shop object
	CoffeeShop cafe;
	GameObject room;
	
	
	
	
	// Constant
	const int fundsX = 10;
	const int fundsY = 10;
	const int fundsW = 100;
	const int fundsH = 75;
		
		
	//
	// Use this for initialization
	//
	void Start () {
		
		//print ("yeay start");
		
		// use built-in tag because i'm too lazy to make my own tag
		room = GameObject.FindGameObjectWithTag("GameController");
		
		//Transform t = room.GetComponent<Transform>();
		//print (t.position.x);
		
		// Grabs the CoffeeShop class
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
		
		
		
		/*void OnGUI () {

		// Make a background box
		
		
		const int dateX = Screen.width - 200;
		
		GUI.Box(new Rect(x - 20,10,200,100), "Parent Menu");
		
		GUI.Label (new Rect (x-10,40,120,20), "Parent fear: " + imp.currentFearLevel);
		GUI.Label (new Rect (x-10,65,120,20), "Motivation: " + imp.currentMotivationLevel);
		GUI.Label (new Rect (x-10,90,120,20), "Parent panic: " + imp.currentPanicLevel);
		GUI.Label (new Rect (x-10,115,120,20), "Parent play: " + imp.currentPlayLevel);
		GUI.Label (new Rect (x-10,140,120,20), "Emotion: " + imp.currentEmotion);
		
		
		/*
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}

		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel(2);
		}*
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
		// Make a background box near the top left screen corner
		//GUI.Box(new Rect(10,10,100,75), "Current Funds: ");
		GUI.Box(new Rect(fundsX,fundsY,fundsW,fundsH), "Current Funds: ");
		
		GUI.Label(new Rect (fundsX+50,fundsY+10,fundsW,fundsH), "$" + cafe.funds);
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
		GUI.Box(new Rect(10,10,100,75), "Day: " /*+ day in game */ );
		
		GUI.Label(new Rect (50,20,100,50), "$" + cafe.funds);
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	
	
	
}
