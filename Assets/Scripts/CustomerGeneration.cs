/*
 * CustomerGeneration
 * 
 * This class is responsible for creating customers based 
 * on the popularity of the coffee shop.
 * 
 * Notes: 
 */

using UnityEngine;
using System;
using System.Collections; // pretty sure this is redundant, since you already have System included

public class CustomerGeneration : MonoBehaviour {
	
	// time ranges from [0, 1] and resets to 0 once it reaches 1. Used to regulate customer spawn once a second passes.
	private float time;
	
	// Probability [0, 100] that a customer will spawn each second.
	public int probOfCustomerSpawn;
	
	CoffeeShop coffeeShop;
	
	
	//
	// Use this for initialization
	//
	void Start ()
	{
		// use built-in tag because i'm too lazy to make my own tag
		//GameObject room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		//cafe = room.GetComponent<CoffeeShop>();
		coffeeShop = (CoffeeShop) GameObject.FindObjectOfType(typeof(CoffeeShop));
		
		// comment meeeeeeeee
		time = 0;
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		// Updates probOfCustomerSpawn according to shop's popularity
		//CoffeeShop coffeeShop = (CoffeeShop) GameObject.FindObjectOfType(typeof(CoffeeShop));
		probOfCustomerSpawn = coffeeShop.popularity/4;
		
		time += Time.deltaTime;
		if(time > 1.0f)
		{
			if(P(probOfCustomerSpawn) && GameObject.FindObjectsOfType(typeof(Customer)).Length < 6)
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

/*
// old CustomerFactory - unnecessary now, but perhaps better naming scheme? dunno

using UnityEngine;
using System.Collections;

public class CustomerFactory : MonoBehaviour {
	
	// Number of calls to Update() before the next customer is spawned
	int spawnRate = 50;  // adjust this #
	
	// The last time that a customer was spawned
	int lastSpawnTime = 0;
	
	
/*---------------------------------------------------------------------------
  Name   :  updateSpawnRate
  Purpose:  Update the rate at which customers are generated based on
  			the popularity of the coffee shop
  Receive:  ...
  Return :  ...
---------------------------------------------------------------------------*
	void updateSpawnRate()
	{
		
	}
}

//
// THIS FILE WILL PROBABLY BE COMBINED WITH CUSTOMERFACTORY ***
//

*/
