
// Code modified from a past project of lizz's - cubezicles
// https://cubezicles.googlecode.com/svn/trunk/Cubezicles/Cubezicles/Clock.cs
using UnityEngine;
using System;//.Collections;

// promising: http://catlikecoding.com/unity/tutorials/clock/

public class Clock : MonoBehaviour
{
	
	private const string timeFormat = "Day {0:d: hh:mm tt}";
	
	// The current time
	//public long time { get; set; }
	
	// The number of days played in the game
	public int days { get; set; }
	public TimeSpan time; //public Time time;
	public float time1;
	public float time2; 
	
	// The hours (in 24 hour format) that the work day begins and ends
	int startWork = 8;
	int goHomeTime = 17;
	int endWork = 18;
	
	// Unity variable for controlling speed of time
	// The scale at which the time is passing. This can be used for slow motion effects.
	// timeScale = 1.0 : time passing as fast as realtime
	// timeScale = 0.5 : time passing 2x slower than realtime
	// timeScale = 0 : game is paused if all your functions are frame rate independent
	
	// Except for realtimeSinceStartup,
	// timeScale affects all the time and delta time measuring variables of the Time class.

	// If you lower timeScale it is recommended to
	// also lower Time.fixedDeltaTime by the same amount.
	//Time.timeScale;
	
	// http://rezzable.com/blogs/foolish-frost/unity-tutorial-scripting-pausing-and-time-control
	//You can change this variable, and all time variables will follow the new time scale.  All except "Time.realtimeSinceStartup". 
	//	This float will ALWAYS be the real time since the program started.
	
	// Different time speeds...........
	
	const float Paused = 0.0f;
	const float SpeedPlay = 1.0f;
	const float SpeedFF = 2.0f;
	const float SpeedFFF = 3.0f;
	
	// enums can't be floats....
	/* public enum TimeSpeed
    {
        // The 60 is to convert from seconds to minutes
        /*Paused = 0,
        SpeedPlay = 1 * 4 * 60, // lizz likes 4 (5 pushing a little) as the multiplier... was at 10
        SpeedFF = 4 * 4 * 60,
        SpeedFFF = 16 * 4 * 60
        *
		Paused = 0,
		SpeedPlay = 1.0,
		SpeedFF = 2.0,
		SpeedFFF = 3.0
    }*/
	
	//public TimeSpeed CurrTimeSpeed = TimeSpeed.SpeedPlay;
	//public TimeSpeed oldSpeed = TimeSpeed.Paused;
	
	public float CurrTimeSpeed = SpeedPlay;
	public float oldSpeed = Paused;
	
	//public Time.timeScale CurrTimeSpeed = TimeSpeed.SpeedPlay;
	//public Time.timeScale oldSpeed = TimeSpeed.Paused;
	
	
	// Get the Game1 object stored by the base class
	//private Game1 game1 { get { return (Game1)Game; } }

	
	
	// ------------ Use this for initialization ------------ //
	void Start ()
	{
		
		// IN XNA (MSDN), TimeSpan represents a time interval
		// equivalent in Unity is .... actually maybe can use it, since c#?
		
		
		//public Clock(Game1 game): base(game)
		//{
		//    this.DrawOrder = (int)Game1.DisplayOrder.UI;
		// Give the player a starting lump sum of money
		time = new TimeSpan (startWork, 1, 0);
		time1 = Time.time;
		time2 = Time.time;
		days = 1;
		//}
	
	}
	
	// ------------ Update is called once per frame ------------ //
	void Update ()
	{
		//-- Keyboard user controls for game speed --//
		//KeyboardState keys = Keyboard.GetState();

		// 1 = normal speed
		//if (keys.IsKeyDown(Keys.D1)) CurrTimeSpeed = TimeSpeed.SpeedPlay;
		if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			oldSpeed = CurrTimeSpeed;
			CurrTimeSpeed = SpeedPlay;
			Time.timeScale = SpeedPlay; //TimeSpeed.SpeedPlay;
		}
		
        // 2 = fast forward (speed x2)
        //else if (keys.IsKeyDown(Keys.D2)) CurrTimeSpeed = TimeSpeed.SpeedFF;
		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			oldSpeed = CurrTimeSpeed;
			CurrTimeSpeed = SpeedFF;
			Time.timeScale = SpeedFF; //TimeSpeed.SpeedFF;
		}
		
        // 3 = super fast forward (speed x3)
        //else if (keys.IsKeyDown(Keys.D3)) CurrTimeSpeed = TimeSpeed.SpeedFFF;
		else if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			oldSpeed = CurrTimeSpeed;
			CurrTimeSpeed = SpeedFFF;
			Time.timeScale = SpeedFFF; //TimeSpeed.SpeedFFF;
		}
		
        // 0, space, or P = pause or unpause
		else if (Input.GetKeyDown (KeyCode.Alpha0) || Input.GetKeyDown (KeyCode.P))
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
				oldSpeed = CurrTimeSpeed;
				CurrTimeSpeed = Paused;
				Time.timeScale = Paused; //TimeSpeed.Pause;
			}
			
			// pretty sure this isnt being called right....
			//PauseUnpause();
		}
		/*else if ((keys.IsKeyDown(Keys.P) && game1.oldks.IsKeyUp(Keys.P))
            || (keys.IsKeyDown(Keys.OemTilde) && game1.oldks.IsKeyUp(Keys.OemTilde))
            || (keys.IsKeyDown(Keys.Space) && game1.oldks.IsKeyUp(Keys.Space)))
        {
            PauseUnpause();
        }*/
		
		// Update game time
		//time += Time.deltaTime; //new TimeSpan ((long)(Time.deltaTime * Time.timeScale));
		
		time1 += Time.time;
		time2 += Time.deltaTime * Time.timeScale;
		//print (time.ToString());	
		
		
		// Elapsed game time since the last update.
		//gameTime.ElapsedGameTime.Ticks * (int)CurrTimeSpeed); //timeSpeed;
			
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
		//base.Update(gameTime);
	}
        
	/*public void PauseUnpause ()
	{
		/*TimeSpeed
		float o = CurrTimeSpeed;
		CurrTimeSpeed = oldSpeed;
		oldSpeed = o;
	}*/

	public string getTimeOfDay()
	{
		// OLD way for XNA code... probably much better
		//private const string timeFormat = "Day {0:d: hh:mm tt}"; (declared at top)
		//var dt = new DateTime ().Add (time).AddDays (days - 1);
		//return string.Format (timeFormat, dt);
		
		// Janky hacky-ish way.... - lizz
		
		string hrString = "";
		string minString = "";
		string ampmString = "AM";
		int hrs = startWork + (int)time2 / 60;
		if (hrs >= 12)
		{
			ampmString = "PM";
			if (hrs > 12) hrs = hrs % 12;
		}
		
		hrString = hrs.ToString();
		
		int min = (int)time2 % 60;
		if (min<10)
		{
			minString = "0"+min.ToString();
		}
		else minString = min.ToString();
		
		return "Time: " + hrString + ":" + minString + " " + ampmString;
	}

	/// <summary>
	/// Determine if we reached the end of the work day.
	/// </summary>
	/// <returns>true if end of day reached</returns>
	public bool ReachedEOD ()
	{
		return time.Hours == startWork && time.Minutes == 0;
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
