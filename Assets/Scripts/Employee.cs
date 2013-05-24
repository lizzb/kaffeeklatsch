/*
 * Employee
 * 
 * TODO finish employee description
 * 
 * In this game, employees are pretty much drones that work for your cafe
 * and never have to take breaks :)
 * 
 * Notes: 
 */
using UnityEngine;
using System.Collections;

public class Employee : MonoBehaviour {
	
	string name = "";
	
	// Pay rate per hour... or day... not sure yet
	int payRate = 0; 
	
	// Whether this employee is currently busy or not
	bool isBusy = false;
	
	enum Actions { Nothing=0, Cashier, MakingDrink }
	
	// The current action of this employee
	int currentAction = (int)Actions.Nothing;
	
	
	// Skill --> higher quality drinks, but also requires higher pay
	// but not sure we'll get to this implementation
	enum Skill {beginner, average, expert}
	
	// The current skill level of this employee
	// possibly increases over time, based on how many drinks they make/orders they take?
	int skillLevel = (int)Skill.beginner;
	
	//
	// Use this for initialization
	//
	void Start () {
		
		// Give them a name
	
	}
	
	//
	// Update is called once per frame
	//
	void Update () {
		
		// If no one is at the cash register, man the cash register
		// move there function
		// isBusy = true;
		// currentAction = Actions.Cashier,
	
	}
}
