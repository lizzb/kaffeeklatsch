//
// THIS FILE WILL PROBABLY BE COMBINED WITH CUSTOMERFACTORY ***
//


using UnityEngine;
using System;
using System.Collections; // pretty sure this is redundant, since you already have System included

public class CustomerGeneration : MonoBehaviour {
	
	// time ranges from [0, 1] and resets to 0 once it reaches 1. Used to regulate customer spawn once a second passes.
	private float time;
	
	// Probability [0, 100] that a customer will spawn each second.
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
  Purpose:  There is an a% chance that P(a) will return true
  Receive:  An integer a [0, 100]
  Return :  bool - pseudorandomly generated. a% chance that it's true.
---------------------------------------------------------------------------*/	
	bool P(int a)
	{
		System.Random random = new System.Random();
		int x = random.Next(0, 100);
		return x<a;
	}
}
