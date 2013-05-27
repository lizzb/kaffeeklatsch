/*
 * EmployeeManager
 * 
 * TODO finish description
 * 
 * Responsible for delegating employees, keeping track of task queue, etc.
 * hiring, firing
 * 
 * Notes: 
 */

using UnityEngine;
using System.Collections;

public class EmployeeManager : MonoBehaviour {
	
	CoffeeShop cafe; // the cafe this employeemanager belongs to
	
	//public void EmployeeManager(CoffeeShop) {}
	
	// List of employees working at this coffee shop... public because i'm naughty
	public ArrayList employees;
	
	
	// Use this for initialization
	void Start () {
		
		employees = new ArrayList();
		
		// use built-in tag because i'm too lazy to make my own tag
		GameObject room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		cafe = room.GetComponent<CoffeeShop>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
/*---------------------------------------------------------------------------
  Name   :  hireEmployee
  Purpose:  Hire employee to shop
  Receive:  Employee to add
  Return :  false if employee was not hired (insufficient funds or reach limit)
---------------------------------------------------------------------------*/	
	public bool hireEmployee()
	{
		// use built-in tag because i'm too lazy to make my own tag
		//room = GameObject.FindGameObjectWithTag("GameController");
		
		// Grabs the CoffeeShop class (only once!)
		//cafe = room.GetComponent<CoffeeShop>();
		//cafe.empManager.hireEmployee(this);
		
		if (cafe.funds < GameConstants.employeeHiringCost) return false;
		Employee emp = new Employee();
		print("yay hire an employee!");
		employees.Add(emp);
		return true;
		
		// THIS ALL NEEDS TO BE FIXED *********
	}
}
