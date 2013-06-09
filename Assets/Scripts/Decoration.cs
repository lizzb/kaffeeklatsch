/*
 * Decoration
 * 
 * Base class for decorations that a player can purchase and put in their shop.
 * There are a fixed number of fixed slots for decorations.
 *  
 * 
 * Notes: based on coffeemachine class
 */

using UnityEngine;
using System.Collections;

public class Decoration : MonoBehaviour {

	
	
	
	public GameObject decorationModel1;
	public GameObject decorationModel2;
	public GameObject decorationModel3;
	public GameObject decorationModel4;
	
	
	// The name of the coffee machine, to display in the buy menu
	
	string objectName = ""; // except this doesnt actually get used....called from gameconstants

	// The cost of this decoration --> ideally use constants defined in another file
	int cost = 0;

	// The boost to ambiance this decoration gives
	// Customers will .... be willing to wait longer if better ambiance? .... TODO define
	public enum AmbianceRating { low = 1, med = 2, high = 3, highest = 4 }
	
	public static AmbianceRating ambianceBoost = AmbianceRating.low;




	// ---------- Use this for initialization ---------- //
	void Start ()
	{	
		// don't feel like this should be attached...
		//gameObject.AddComponent<EndGame>(); //End Game conditions
	}
	

	// ---------- Update is called once per frame ---------- //
	void Update ()
	{
		// rather than creating and worrying about activating/rendering, only create when bought
	}
	
	
	static Vector3 coffeePhotosRot = new Vector3(0, 180, 0);
	static Vector3 coffeePhotosPos = new Vector3(10.18452f, 5.521872f, 15.86662f);
	static Vector3 coffeePhotosScale = new Vector3(230, 230, 230);

	static Vector3 standingLampRot = new Vector3(0,0,0);
	static Vector3 standingLampPos = new Vector3(4.829332f, 2.980975f, 14.69177f);
	static Vector3 standingLampScale = new Vector3(3, 3, 3);
	
	static Vector3 bambooPotRot = new Vector3(0,0,0);
	static Vector3 bambooPotPos = new Vector3(15.38791f, 3.926149f, 14.91631f);
	static Vector3 bambooPotScale = new Vector3(100, 100, 100);
	
	static Vector3 modernPaintingRot = new Vector3(0, 90, 0);
	static Vector3 modernPaintingPos = new Vector3(19.91141f, 5.222107f, 2.940214f);
	static Vector3 modernPaintingScale = new Vector3(225, 225, 225); 

	

	Vector3 decoration1Rot = coffeePhotosRot;
	Vector3 decoration1Pos = coffeePhotosPos;
	Vector3 decoration1Scale = coffeePhotosScale;
	
	Vector3 decoration2Rot = standingLampRot;
	Vector3 decoration2Pos = standingLampPos;
	Vector3 decoration2Scale = standingLampScale;
	
	Vector3 decoration3Rot = bambooPotRot;
	Vector3 decoration3Pos = bambooPotPos;
	Vector3 decoration3Scale =bambooPotScale;
	
	Vector3 decoration4Rot = modernPaintingRot;
	Vector3 decoration4Pos = modernPaintingPos;
	Vector3 decoration4Scale = modernPaintingScale;
	
	string decoration1ModelPrefabName ="coffeePictures";
	string decoration2ModelPrefabName ="circularStandingLamp";
	string decoration3ModelPrefabName ="bambooPot";
	string decoration4ModelPrefabName = "modernPanelPainting";
	
	// Sort of like a fake constructor??
	public bool createDecorationType (int decorationLevel)
	{
		
		switch (decorationLevel)
		{
			case 1:
				//coffeeMachineModel1 = //GameObject.FindGameObjectWithTag("decoration1"); //(GameObject)Instantiate(Resources.Load("CoffeeMachine1")); //, coffeeMachine1Pos, Quaternion.identity);
				decorationModel1 = (GameObject)Instantiate(Resources.Load(decoration1ModelPrefabName));
				decorationModel1.transform.localScale = decoration1Scale;	
				decorationModel1.transform.position = decoration1Pos;
				decorationModel1.transform.Rotate(decoration1Rot);
			
				objectName = GameConstants.decoration1Name;	
				cost = GameConstants.decoration1Cost;
				ambianceBoost = ambianceBoost > AmbianceRating.low ? ambianceBoost : AmbianceRating.low;
				return true;
			
			case 2:
				decorationModel2 = (GameObject)Instantiate(Resources.Load(decoration2ModelPrefabName));
				decorationModel2.transform.localScale = decoration2Scale;	
				decorationModel2.transform.position = decoration2Pos;
				decorationModel2.transform.Rotate(decoration2Rot);
			
				objectName = GameConstants.decoration2Name;	
				cost = GameConstants.decoration2Cost;
				ambianceBoost = ambianceBoost > AmbianceRating.med ? ambianceBoost : AmbianceRating.med;
				return true;
				
			case 3:
				decorationModel3 = (GameObject)Instantiate(Resources.Load(decoration3ModelPrefabName));
				decorationModel3.transform.localScale = decoration3Scale;	
				decorationModel3.transform.position = decoration3Pos;
				decorationModel3.transform.Rotate(decoration3Rot);
			
				objectName = GameConstants.decoration3Name;	
				cost = GameConstants.decoration3Cost;
				ambianceBoost = ambianceBoost > AmbianceRating.high ? ambianceBoost : AmbianceRating.high;
				return true;
			
			case 4:
				decorationModel4 = (GameObject)Instantiate(Resources.Load(decoration4ModelPrefabName));
				decorationModel4.transform.localScale = decoration4Scale;	
				decorationModel4.transform.position = decoration4Pos;
				decorationModel4.transform.Rotate(decoration4Rot);
			
				objectName = GameConstants.decoration4Name;	
				cost = GameConstants.decoration4Cost;
				ambianceBoost = AmbianceRating.highest;
				return true;
			
			default: 
				return false;
		}
		

	}
	
	void OnGUI()
	{
		
	}
	
	
/*---------------------------------------------------------------------------
  Name   :  
  Purpose:  
  Receive:  
  Return :  
---------------------------------------------------------------------------*/
	
	public int getCost () { return cost; }

}
