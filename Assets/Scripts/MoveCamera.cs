using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	
	private bool isDown = false;
	private float mousePositionX = 0.0f;
	private float mousePositionY = 0.0f;
	public static bool isMoving = false;
	
	// Use this for initialization
	void Start ()
	{}
	
	// Update is called once per frame
	void Update ()
	{
		if(isDown && !mouseWithinSliderBox())
		{
			this.transform.RotateAround(new Vector3(10f, 0f, 10f), new Vector3(0f, 1f, 0f), 0.1f*(Input.mousePosition.x-mousePositionX));
			if(Input.mousePosition.x-mousePositionX != 0)
				isMoving = true;
			mousePositionX = Input.mousePosition.x;
			mousePositionY = Input.mousePosition.y;
		}
		if(Input.GetMouseButtonDown(0))
		{
			isDown = true;
			mousePositionX = Input.mousePosition.x;
			mousePositionY = Input.mousePosition.y;
		}
		if(Input.GetMouseButtonUp(0))
			isDown = false;
	}
	
	bool mouseWithinSliderBox(){
		if(mousePositionX > Screen.width - 10 || mousePositionX < Screen.width - 110){
			if(mousePositionY < 100 || mousePositionY > 150){
				return false;
			}
		}
		return true;
	}
}