using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
	
	private bool isDown = false;
	private float mousePosition = 0.0f;
	public static bool isMoving = false;
	
	// Use this for initialization
	void Start ()
	{}
	
	// Update is called once per frame
	void Update ()
	{
		if(isDown)
		{
			this.transform.RotateAround(new Vector3(10f, 0f, 10f), new Vector3(0f, 1f, 0f), 0.1f*(Input.mousePosition.x-mousePosition));
			if(Input.mousePosition.x-mousePosition != 0)
				isMoving = true;
			mousePosition = Input.mousePosition.x;
		}
		if(Input.GetMouseButtonDown(0))
		{
			isDown = true;
			mousePosition = Input.mousePosition.x;
		}
		if(Input.GetMouseButtonUp(0))
			isDown = false;
	}
}