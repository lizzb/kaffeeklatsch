//
// THIS FILE WILL PROBABLY BE COMBINED WITH CUSTOMERFACTORY ***
//


using UnityEngine;
using System;
using System.Collections; // pretty sure this is redundant, since you already have System included

public class CustomerGeneration : MonoBehaviour {
	
	// DESCRIBE MEEEE.......
	private float time;
	
	// DESCRIBE MEEEE.......
	public int probOfCustomerSpawn;
	
	
	//
	// Use this for initialization
	//
	void Start ()
	{
		time = 0;
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		time += Time.deltaTime;
		if(time > 1.0f)
		{
			if(P(probOfCustomerSpawn) && GameObject.FindObjectsOfType(typeof(Customer)).Length < 4)
			{
				Instantiate(Resources.Load("Customer"), new Vector3(5, 1, 0), Quaternion.identity);
			}
			time--;
		}
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  P ... rename this to something more descriptive please
  Purpose:  ...
  Receive:  ...
  Return :  ...
---------------------------------------------------------------------------*/	
	//There is an a% chance that P(a) will return true
	bool P(int a)
	{
		System.Random random = new System.Random();
		int x = random.Next(0, 100);
		return x<a;
	}
}
