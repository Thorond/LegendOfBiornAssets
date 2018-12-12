using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {

	// Variables

	private int gold;
	private int maxGold;
	private int wood;
	private int maxWood;
	private int iron;
	private int maxIron;
	private int food;
	private int maxFood;

	private Ships ships;
	private People people;

	// Getters and Setters

	public int Gold{
		get{
			return gold;
		}
		set{
			gold = value;
		}
	}
	public int MaxGold{get{return maxGold;}}
	public int Wood{
		get{
			return wood;
		}
		set{
			wood = value;
		}
	}
	public int MaxWood{get{return maxWood;}}
	public int Iron{
		get{
			return iron;
		}
		set{
			iron = value;
		}
	}
	public int MaxIron{get{return maxIron;}}
	public int Food{
		get{return food;}
		set{food = value;}
	}
	public int MaxFood{get{return maxFood;}}

	public Ships Ships{
		get{return ships;}
		set{ships = value;} // ??
	}
	// public int ShipsNbrOfShipType1{ // Necessaire??
	// 	set{ships.NbrOfShipType1 = value;}
	// }

	public People People{
		get {
			return people;
		}
	}

	
	// Constructor

	public Resource(){
		gold = 500;
		maxGold = 2000;
		wood = 500;
		maxWood = 2000;
		iron = 100;
		maxIron = 500;
		food = 400;
		maxFood = 1600;
		ships = new Ships();
		people = new People();
	}
	

	// Functions

	public string textDisplay(){
		return "Gold : " + gold.ToString()
			+ "\nWood : " + wood.ToString()
			+ "\nIron : " + iron.ToString()
			+ "\nFood : " + food.ToString();
	}
}
