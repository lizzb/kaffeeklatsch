/*
 * CustomerFactory
 * 
 * This class is responsible for creating customers based 
 * on the popularity of the coffee shop.
 * 
 * Notes: 
 */

using UnityEngine;
using System.Collections;

public class CustomerFactory : MonoBehaviour {
	
	// Number of calls to Update() before the next customer is spawned
	int spawnRate = 50;  // adjust this #
	
	// The last time that a customer was spawned
	int lastSpawnTime = 0;
	
	//
	// Use this for initialization
	//
	void Start () {
	
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
	
	}
	
/*---------------------------------------------------------------------------
  Name   :  updateSpawnRate
  Purpose:  Update the rate at which customers are generated based on
  			the popularity of the coffee shop
  Receive:  ...
  Return :  ...
---------------------------------------------------------------------------*/
	void updateSpawnRate()
	{
		
	}
}
