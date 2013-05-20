using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CharacterMenu : MonoBehaviour {
	
	public float WIDTH;
	public string menuTitle;
	public string[] menuItems;
	private Vector2 clickLocation;
	private float HEIGHT;
	
	CharacterMenu(string[] items)
	{
		menuItems = items;
	}
	
	// Use this for initialization
	void Start ()
	{
		HEIGHT = 30*this.menuItems.Length + 30;
		clickLocation = new Vector2(-WIDTH, -HEIGHT);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetMouseButtonUp(0) && !MoveCamera.isMoving)
		{
			if(!clickInside())
			{
				if(clickLocation.x == -WIDTH && clickLocation.y == -HEIGHT && this.gameObject == clickedObject())
					clickLocation = Input.mousePosition;
				else
					clickLocation = new Vector2(-WIDTH, -HEIGHT);
			}
		}
		MoveCamera.isMoving = false;
	}
	
	void OnGUI()
	{
		float horizontalShift = HorizontalShift()? -WIDTH : 0;
		float verticalShift = VerticalShift()? -HEIGHT : 0;
		GUI.Box(new Rect(clickLocation.x+horizontalShift, Screen.height-clickLocation.y+verticalShift, WIDTH, HEIGHT), menuTitle);
		
		for(int i = 0; i < menuItems.Length; i++)
		{
			if(GUI.Button(new Rect(clickLocation.x+horizontalShift+10,Screen.height-clickLocation.y+verticalShift+30*i+30,WIDTH-20,20), menuItems[i]))
				print ("Button " + menuItems[i] + " Pressed");
		}
	}
	
	bool clickInside()
	{
		if(Input.mousePosition.x > clickLocation.x && Input.mousePosition.x < clickLocation.x+WIDTH && Screen.height-Input.mousePosition.y > Screen.height-clickLocation.y && Screen.height-Input.mousePosition.y < Screen.height-clickLocation.y+HEIGHT)
			return true;
		return false;
	}
	
	GameObject clickedObject()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
			return hit.transform.gameObject;
		else
			return null;
	}
	
	bool HorizontalShift()
	{
		return clickLocation.x+WIDTH > Screen.width;
	}
	
	bool VerticalShift()
	{
		return HEIGHT-clickLocation.y > 0;
	}
}
