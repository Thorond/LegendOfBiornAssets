using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipType1 {

	// Variables 
	private int nbrOfLaborNeeded;
	private int nbrOfMenNeededForNavigation;
	private int totalCapacityOfMen;
	private int totalCapacityOfLoot;
	private int nbrOfWoodNeededForConstruction;
	private int nbrOfIronNeededForConstruction;

	// Getters and Setters

	public int NbrOfLaborNeeded{ get { return nbrOfLaborNeeded; }}
	public int NbrOfMenNeededForNavigation{ get { return nbrOfMenNeededForNavigation; }}
	public int TotalCapacityOfMen{ get { return totalCapacityOfMen; }}
	public int TotalCapacityOfLoot{ get { return totalCapacityOfLoot; }}
	public int NbrOfWoodNeededForConstruction{ get { return nbrOfWoodNeededForConstruction; }}
	public int NbrOfIronNeededForConstruction{ get { return nbrOfIronNeededForConstruction; }}

	// Constructor

	public ShipType1(){
		nbrOfLaborNeeded = 15;
		nbrOfMenNeededForNavigation = 5;
		totalCapacityOfMen = 10;
		totalCapacityOfLoot = 20;
		nbrOfWoodNeededForConstruction = 20;
		nbrOfIronNeededForConstruction = 5;
	}
}
