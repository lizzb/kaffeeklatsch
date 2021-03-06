/*
 * EmployeeManager
 * 
 * TODO finish description
 * 
 * Responsible for hiring, firing, and delegating employees,
 * as well as keeping track of task queue, etc.
 * 
 * Notes: 
 */

using UnityEngine;
using System.Collections;

public class EmployeeManager : MonoBehaviour {
	
	private CoffeeShop cafe; // the cafe this employeemanager belongs to
	
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
		
		employees.Add(room.AddComponent<Employee>());
	
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
		// was in customer class...
		//cafe.empManager.hireEmployee(this);
		
		if (cafe.moneyManager.funds < GameConstants.employeeHiringCost)
		{
			// TODO: notify user through UI that funds are insufficient ***
			return false;
		}
		
		/*
		if (employees.length >= GameConstants.employeesLimit)
		{
			// TODO: notify user through UI that reached employee limit ****
			return false;
		}
		*/
		
		cafe.moneyManager.funds -= GameConstants.employeeHiringCost;
		employees.Add(gameObject.AddComponent<Employee>());
		return true;
		
		// THIS ALL NEEDS TO BE FIXED *********
	}
	
/*---------------------------------------------------------------------------
  Name   :  fireEmployee
  Purpose:  Fire a current employee
  Receive:  Employee to fire
  Return :  true if employee was fired successfully
  			(don't know if there's ever a false condition??)
---------------------------------------------------------------------------*/	
	public bool fireEmployee()
	{	
		
		// Your coffee shop must have at least 1 employee
		if (employees.Count <= 1)
		{
			// TODO: notify user they can't fired their only employee ****
			return false;
		}
		;
		employees.RemoveAt(employees.Count - 1);
		return true;
		
		// THIS ALL NEEDS TO BE FIXED *********
	}	

	
/*---------------------------------------------------------------------------
  Name   :  findAvailableEmployee
  Purpose:  find a employee who is availabl
  Receive:  nothing
  Return :  return employee who is available
---------------------------------------------------------------------------*/
	public Employee findAvailableEmployee()
	{
		// Iterate through employees
		foreach (Employee e in employees)
		{ 
			if(e.getAction() == Employee.Actions.Nothing)
			{ //If doing nothing (idle)
				return e; //return firstavailable employee
			}
		}
		return null;
	}
	
/*---------------------------------------------------------------------------
  Name   :  findWorkingEmployee
  Purpose:  find a employee who is currently working.... why?
  Receive:  Nothing
  Return :  return employee who is working
---------------------------------------------------------------------------*/
	public Employee findWorkingEmployee()
	{
		// Iterate through employees
		foreach (Employee e in employees)
		{ 
			if(e.getAction() == Employee.Actions.MakingDrink){ //If making drink
				return e; //return
			}
		}
		return null;
	}
	
	
		// TODO: ???
	// not sure if next 2 functions are better in a "employeemanager" class
	// or here... or within employees?
	
	

	
/*---------------------------------------------------------------------------
  Name   :  makeDrink
  Purpose:  Choose an employee to make specified drink
  			Assume customer will wait and pick up their correct drink
  Receive:  the drink ordered
  Return :  true if the drink was made successfully (?? void?)
---------------------------------------------------------------------------*/
	public bool makeDrink (GameConstants.Drinks drink)	
	{
		// Check if one of your employees is free
		
		// If not, add job to job queue for next free employee to take
		
		// TODO: ??? will this cause a problem if there are 2 people in line,
		// and only 1 employee, then they take all orders first and then make them all?
		// actually maybe not...
		
		// Not sure how to handle it from here....
		
		return true;
	}	
}
