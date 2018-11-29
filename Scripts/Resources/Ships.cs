using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ships {

	// Variables

	private ShipType1 shipType1;
	private int nbrOfShipType1;

	// Getters and Setters

	public ShipType1 ShipType1{ get{return shipType1;}}
	public int NbrOfShipType1{ get { return nbrOfShipType1;} set { nbrOfShipType1 = value;}}


	// Constructor 
	public Ships(){
		shipType1 = new ShipType1();
		nbrOfShipType1 = 5;
	}


	// Functions 


}
