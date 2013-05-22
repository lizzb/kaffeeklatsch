using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// UnityGUI controls make use of a special function called OnGUI().
	// The OnGUI() function gets called every frame as long as the
	// containing script is enabled - just like the Update() function.
	void OnGUI () {
		
		
		// top left: 0,0,100,50
		// top right: Screen.width - 100,0,100,50
		// bottom left: (0,Screen.height - 50,100,50)
		// bottom right: (Screen.width - 100,Screen.height - 50,100,50)
		
		
		// Rect: x, y, width, height
		
		GUI.Box(new Rect(0, 0,100,50), "Funds: ");
		
		//GUI.Label (new Rect (20,40,120,20), "Child fear: ");
		
	}
}
