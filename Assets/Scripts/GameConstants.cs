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
	
	// not using drink list
	public enum Drinks { PlainCoffee = 1, Tea, Latte, IcedCoffee }
	
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
	public const int startingFundsEasy = 500;
	public const int startingFundsMedium = 250;
	public const int startingFundsHard = 50;
	
	//Initial Rent for Coffee Shop
	public const int startingRent = 50;
	
	//Initial Drink Cost for Coffee Shop
	public const int initialDrinkCost = 5;
	public const int maximumDrinkCost = 10;
	
	
	//
	// ---------- GAME OBJECTS / variables ----------
	//
	
	// Names of different coffee machine models
	public const string coffeeMachine1Name = "Basic Pot 1";
	public const string coffeeMachine2Name = "Nice 2";
	public const string coffeeMachine3Name = "Nicer maker 3";
	public const string coffeeMachine4Name = "Triple Orange Espresso Awesome 4";
	
	// Cost to purchase different coffee machine models
	public const int coffeeMachine1Cost = 50;
	public const int coffeeMachine2Cost = 175;
	public const int coffeeMachine3Cost = 350;
	public const int coffeeMachine4Cost = 500;
	
	
	public const float timeToMakeCoffee = 3.0f;
	
	
	// Names of different advertising/marketing campaigns
	public const string adType1Name = "Flyer";
	public const string adType2Name = "Television Ad";
	public const string adType3Name = "Billboard";
	
	
	// Cost to purchase different advertising/marketing campaigns
	public const int adType1Cost = 30;
	public const int adType2Cost = 60;
	public const int adType3Cost = 100;
	
	// Hype levels associated with different ad types
	public const int adType1Hype = 5;
	public const int adType2Hype = 15;
	public const int adType3Hype = 40;
	
	//Duration of hype
	public const int adType1Length = 1;
	public const int adType2Length = 2;
	public const int adType3Length = 3;
	
	
	
	
	//
	// ---------- EMPLOYEES ----------
	//
	
	public const int employeeHiringCost = 200;
	
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
	
	
	public const int defaultSatisfactionLevel = 5; // need to play with this TODO
	
	}

/*---------------------------------------------------------------------------
  Name   :  x
  Purpose:  x
  Receive:  x
  Return :  x
---------------------------------------------------------------------------*/	

//}

