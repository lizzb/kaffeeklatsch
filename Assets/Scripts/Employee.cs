/*
 * Employee
 * 
 * In this game, employees are pretty much drones that work for your cafe
 * and never have to take breaks :)
 * 
 * Notes: 
 * Items that ended up out of scope due to time:
 * 		Skill levels
 * 		Animations/movements
 * 		Different pay rates
 * 		Different personality/skill characteristics/abilities
 */
using UnityEngine;
using System.Collections;

public class Employee : MonoBehaviour {
	
	CoffeeShop cafe;

	//string name = "";
	
	// Pay rate per hour... or day... not sure yet
	// should ideally be per hour, that way,
	// if you hire in the middle of the day, they don't get paid for a whole day's work
	int payRate; 
	
	// Whether this employee is currently busy or not
	// Ideally should work with the currentAction variable
	bool isBusy = false;
	
	public enum Actions { Nothing=0, Cashier, MakingDrink }
	
	// The current action of this employee
	Actions currentAction = Actions.Nothing;
	
	
	// Skill --> higher quality drinks, but also requires higher pay
	// but not sure we'll get to this implementation
	//enum Skill {novice, average, expert}
	
	// The current skill level of this employee
	// possibly increases over time, based on how many drinks they make/orders they take?
	//int skillLevel = (int)Skill.novice;
	
	//
	// Use this for initialization
	//
	void Start () {
		//name = "Janie";
		
		payRate = GameConstants.wageNovice;
		
		// THIS NEEDS TO BE FIXED TO BE HANDLED BY EMPLOYEEMANAGER
		// use built-in tag because i'm too lazy to make my own tag
		//GameObject room = GameObject.FindGameObjectWithTag("GameController");
	
	}
	
	//
	// Update is called once per frame
	//
	void Update ()
	{
		
		// If no one is at the cash register, man the cash register
		// move there function
		// isBusy = true;
		// currentAction = Actions.Cashier,
	
	}
	
	
	
	// Public getters and setters for selected member variables
	
	// Get pay rate (per day)
	public int getPayrate() { return payRate; }
	
	public Actions getAction() { return currentAction; }
	
	public void setAction(Actions a) { currentAction = a; }
	
}
