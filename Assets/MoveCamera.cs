using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(new Vector3(10F, 0F, 10F), new Vector3(0F, 1F, 0F), 0.1F);
		if(Input.GetMouseButtonDown(1))
			CameraControl ();
	}
	
	void CameraControl()
	{
		
	}
}