using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expedition : JobsAndWar {

	// Constructor 

	public Expedition() : base() {
		nbrOfShipAssigned = 0;
		typeOfShipSelected = ConstantsAndEnums.shipType.type1; // encore le même problème
		nbrOfAssignedVikingChosen = 0;
		nbrOfAssignedShieldMaidenChosen = 0;
		nbrOfAssignedShipChosen = 0;
		nbrOfSpacesAvailable = 0;
		totalLaborValue = 0;
	}

	// Variables

	protected int nbrOfShipAssigned;

	// mettre une variable des différents batailles en cours ici 

	private ConstantsAndEnums.shipType typeOfShipSelected;
	private int nbrOfAssignedVikingChosen;
	private int nbrOfAssignedShieldMaidenChosen;
	private int nbrOfAssignedShipChosen;
	private int nbrOfSpacesAvailable;
	private int totalLaborValue;


	// Getters and Setters

	public int NbrOfShipAssigned{get{return nbrOfShipAssigned;}set{nbrOfShipAssigned = value;}}
	public ConstantsAndEnums.shipType TypeOfShipSelected{ get{return typeOfShipSelected;} set{ typeOfShipSelected = value;}}
	public int NbrOfAssignedVikingChosen{ get{return nbrOfAssignedVikingChosen;} set{ nbrOfAssignedVikingChosen = value;}}
	public int NbrOfAssignedShieldMaidenChosen{ get{return nbrOfAssignedShieldMaidenChosen;} set{ nbrOfAssignedShieldMaidenChosen = value;}}
	public int NbrOfAssignedShipChosen{ get{return nbrOfAssignedShipChosen;} set{ nbrOfAssignedShipChosen = value;}}
	public int NbrOfSpacesAvailable{ get{return nbrOfSpacesAvailable;} set{ nbrOfSpacesAvailable = value;}}
	public int TotalLaborValue{ get{return totalLaborValue;} set{ totalLaborValue = value;}}

	// Functions 

	public void assignAnotherShip(){
		nbrOfShipAssigned += 1;
	}
	public void removeAShip(){
		nbrOfShipAssigned -= 1;
	}
	public void addOrRemoveSeveralShip(int nbr){
		nbrOfShipAssigned = nbr;
	}

	public void nbrOfSpacesAvailableCalculation(GameManager gameManager){
		if (nbrOfAssignedShipChosen > 0 ){
			nbrOfSpacesAvailable = nbrOfAssignedShipChosen * gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen 
							- ( nbrOfAssignedVikingChosen + nbrOfAssignedShieldMaidenChosen);
		}
	}

}
