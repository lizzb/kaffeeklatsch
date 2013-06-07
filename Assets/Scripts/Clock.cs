
// Code modified from a past project of lizz's - cubezicles
// https://cubezicles.googlecode.com/svn/trunk/Cubezicles/Cubezicles/Clock.cs
using UnityEngine;
using System;//.Collections;

// promising: http://catlikecoding.com/unity/tutorials/clock/

public class Clock : MonoBehaviour
{
	CoffeeShop cafe;
	
	private const string timeFormat = "Day {0:d: hh:mm tt}";
	
	// The current time
	//public long time { get; set; }
	
	// The number of days played in the game
	public int days { get; set; }
	//public TimeSpan time; //public Time time;
	public float time;
	
	// The hours (in 24 hour format) that the work day begins and ends
	int startWork = 8; // 8am
	int goHomeTime = 17; // 5pm
	int endWork = 18; // 6pm
	
	public float deltaTime;
	
	// Time.timeScale;
	// Unity variable for controlling speed of time
	// The scale at which the time is passing. This can be used for slow motion effects.
	// timeScale = 1.0 : time passing as fast as realtime
	// timeScale = 0.5 : time passing 2x slower than realtime
	// timeScale = 0 : game is paused if all your functions are frame rate independent
	
	// Except for realtimeSinceStartup,
	// timeScale affects all the time and delta time measuring variables of the Time class.
	// If you lower timeScale it is recommended to also lower Time.fixedDeltaTime by the same amount.
	
	// http://rezzable.com/blogs/foolish-frost/unity-tutorial-scripting-pausing-and-time-control
	// You can change this variable, and all time variables will follow the new time scale.  All except "Time.realtimeSinceStartup". 
	// This float will ALWAYS be the real time since the program started.
	
	// Different time speeds
	// Using constants because enums can't be floats, only ints or bytes(?)
	const float Paused = 0.0f;
	const float SpeedPlay = 1.0f;
	const float SpeedFF = 2.0f;
	const float SpeedFFF = 4.0f;
	
	public float CurrTimeSpeed = SpeedPlay;
	public float oldSpeed = Paused;
	
	// ------------ Use this for initialization ------------ //
	void Start ()
	{
		
		// Used this in XNA (MSDN), TimeSpan represents a time interval
		// equivalent in Unity is .... actually maybe can use it, since c#?
		
		// Initialize TimeSpan with.......???
		//time = new TimeSpan (startWork, 1, 0);
		time = Time.time;
		days = 1; // or 0???
		
		
		cafe = GameObject.FindGameObjectWithTag("GameController").GetComponent<CoffeeShop>();
	}
	
	// ------------ Update is called once per frame ------------ //
	void Update ()
	{


		// 1 = normal speed
		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			oldSpeed = CurrTimeSpeed;
			CurrTimeSpeed = SpeedPlay;
			Time.timeScale = SpeedPlay; //TimeSpeed.SpeedPlay;
		}
		
        // 2 = fast forward (speed x2)
		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			oldSpeed = CurrTimeSpeed;
			CurrTimeSpeed = SpeedFF;
			Time.timeScale = SpeedFF; //TimeSpeed.SpeedFF;
		}
		
        // 3 = super fast forward (speed x4)
		else if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			oldSpeed = CurrTimeSpeed;
			CurrTimeSpeed = SpeedFFF;
			Time.timeScale = SpeedFFF; //TimeSpeed.SpeedFFF;
		}
		
        // 0, space, or P = pause or unpause
		else if (Input.GetKeyDown (KeyCode.Alpha0) || Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown(KeyCode.Space))
		{
			// If currently paused, return to last time speed
			if (CurrTimeSpeed == Paused)
			{
				CurrTimeSpeed = oldSpeed;
				oldSpeed = Paused;
				Time.timeScale = CurrTimeSpeed;
			}
			// If currently not paused, pause
			else
			{
				pause ();
			}
			
			// pretty sure this isnt being called right....
			//PauseUnpause();
		}

		// Update game time
		// Elapsed game time since the last update.
		//gameTime.ElapsedGameTime.Ticks * (int)CurrTimeSpeed); //timeSpeed;
		
		
		//time += Time.deltaTime; //new TimeSpan ((long)(Time.deltaTime * Time.timeScale));	
		deltaTime = Time.deltaTime * Time.timeScale;
		time += deltaTime;
		//print (time.ToString());	
		
		
		
			
		//Time.deltaTime
		//The time in seconds it took to complete the last frame (Read Only).
		//Use this function to make your game frame rate independent.
		//If you add or subtract to a value every frame chances are you should multiply with Time.deltaTime.
		// When you multiply with Time.deltaTime you essentially express:
		// I want to move this object 10 meters per second instead of 10 meters per frame.
		//When called from inside MonoBehaviour's FixedUpdate, returns the fixed framerate delta time.
		//Note that you should not rely on Time.deltaTime from inside OnGUI
		// since OnGUI can be called multiple times per frame and deltaTime would hold the same value each call,
		// until next frame where it would be updated again.
		
		
		
		//Tell all the employees to go home and give them an hour to walk to the door
		/* if (time.Hours > goHomeTime)
        {
            game1.EmployeeManager.EmpGoHomeAlready();
        } */

		// End of the Day Stuff
		/* if (time.Hours >= endWork)
        {
            if (CurrTimeSpeed != TimeSpeed.Paused)
                game1.MoneyManager.reported = false;
            time = new TimeSpan(startWork, 0, 0);
            days++;
            oldSpeed = CurrTimeSpeed;
            CurrTimeSpeed = TimeSpeed.Paused;
        } */ 
		
		// ****** TODO this isn't working
		// End of day stuff
		if (ReachedEOD())
		{
			// Pause game, display some stuff
			//oldSpeed = CurrTimeSpeed; 
			//Time.timeScale = Paused; 
			//CurrTimeSpeed = Paused;
			pause ();
		}
	}

	/// <summary>
	/// Get the time of day (to display in the user interface)
	/// </summary>
	/// <returns>time in string format</returns>
	public string getTimeOfDay()
	{
		// OLD way for XNA code... probably much better
		//private const string timeFormat = "Day {0:d: hh:mm tt}"; (declared at top)
		//var dt = new DateTime ().Add (time).AddDays (days - 1);
		//return string.Format (timeFormat, dt);
		
		// Janky hacky-ish way.... - lizz
		
		string ampmString = "AM";
		int hrs = startWork + (int)time / 60;
		if (hrs >= 12)
		{
			ampmString = "PM";
			if (hrs > 12) hrs = hrs % 12;
		}
		string hrString = hrs.ToString();
		
		int min = (int)time % 60;
		string minString = min.ToString();
		if (min<10) minString = "0"+minString;
		
		return "Time: " + hrString + ":" + minString + " " + ampmString;
	}

	/// <summary>
	/// Determine if we reached the end of the work day.
	/// </summary>
	/// <returns>true if end of day reached</returns>
	public bool ReachedEOD ()
	{
		return (startWork + (int)time / 60) >= endWork;
		//return time.Hours == endWork && time.Minutes == 0; //startWork && time.Minutes == 0;
	}
	
	
	//Advances a day forward
	public void advanceDay()
	{
		days++;
		CurrTimeSpeed = SpeedPlay; //oldSpeed; 
		Time.timeScale = SpeedPlay; //oldSpeed; 
		time = 0;
		cafe.EODreport();
	}
	
	public void pause()
	{
		oldSpeed = CurrTimeSpeed;
		CurrTimeSpeed = Paused;
		Time.timeScale = Paused; //TimeSpeed.Pause;
	}
	
	public void play(){
		oldSpeed = CurrTimeSpeed;
		CurrTimeSpeed = SpeedPlay;
		Time.timeScale = SpeedPlay;
	}


	// todo:  move calling end of day display/update to Game1... should be handled there
	/* public override void Draw(GameTime gameTime)
        {
            if (ReachedEOD())
            {
                game1.MoneyManager.DisplayEODReport();
                game1.MoneyManager.reported = true;
                game1.MoneyManager.dailyExpenses = 0;
            }

            base.Draw(gameTime);
        }
       */

    
}
