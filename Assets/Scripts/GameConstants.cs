/*
 * GameConstants
 * 
 * The purpose of this class is to establish global variable names/values
 * so that all tinkering with variables can be done from one location.
 * 
 */

using System;

//namespace AssemblyCSharp
// must be in same namespace for other classes to see these constants
//{
	public static class GameConstants
	{
		// static classes cannot have instance constructors
		/*	public GameConstants () { }*/
	
	public enum Drinks { PlainCoffee, Tea, Latte, IcedCoffee }
	
	//
	// ---------- GAME START / initialization ----------
	//
	
	// The initial cusotmer satisfaction level
	// for a brand new coffee shop
	public const int initialSatisfactionRating = 50;
	
	// Initial hype level for new coffee shop
	// Increased hype for a few days for being "new"
	public const int initialHypeLevel = 15; 
	
	
	// Amount of money that player receives upon start of game
	// Different intial funds => different difficulty levels
	public const int startingFundsEasy = 5000;
	public const int startingFundsMedium = 2500;
	public const int startingFundsHard = 500;
	
	
	//
	// ---------- GAME OBJECTS / variables ----------
	//
	
	// Names of different coffee machine models
	public const string coffeeMachine1Name = "Basic Pot 1";
	public const string coffeeMachine2Name = "Nice 2";
	public const string coffeeMachine3Name = "Triple Espresso Awesome 3";
	
	// Cost to purchase different coffee machine models
	public const int coffeeMachine1Cost = 50;
	public const int coffeeMachine2Cost = 175;
	public const int coffeeMachine3Cost = 350;
	
	
	//
	// ---------- EMPLOYEES ----------
	//
	
	// Pay rate (salary? wage?) for employees of different skill levels
	// TODO: probably will need to be adjusted! ***
	public const int wageNovice = 50;
	public const int wageAverage = 100;
	public const int wageExpert = 150;
	
	
	
	//
	// ---------- CUSTOMERS ----------
	//
	
	// potentially different patience levels?
	// different drink options? types of patrons?
	// looks/models?
	
	}

/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	

//}

