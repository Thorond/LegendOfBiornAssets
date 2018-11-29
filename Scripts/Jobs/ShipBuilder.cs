using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipBuilder : Jobs {

	// Variables
	private bool workInProgress = false;
	private int nbrOfAssignedPeopleChosen = 0;
	private int remainingTimeForConstruction = 0;

	// Getters and Setters 
	public bool WorkInProgress{ get { return workInProgress;} set{workInProgress = value;}}
	public int NbrOfAssignedPeopleChosen{ get{return nbrOfAssignedPeopleChosen;} set{ nbrOfAssignedPeopleChosen = value;}}
	public int RemainingTimeForConstruction{get{return remainingTimeForConstruction;} set{ remainingTimeForConstruction = value;}}

	// Constructor
	public ShipBuilder() : base() {
	}
	
	// Functions 

	public override void determineQuantity(GameManager gameManager){
		quantityOfProductBroughtBack = 1;
	}

	public override void updateProduct(GameManager gameManager, int timeSpent){
		
	}

	public void assignWork(People people){
		if (nbrOfAssignedPeopleChosen > 0 ){
			addOrRemoveSeveralSlave(nbrOfAssignedPeopleChosen);
			workInProgress = true;
			people.NbrOfSlave -= nbrOfAssignedPeopleChosen;
			nbrOfAssignedPeopleChosen = 0;
			constructShip();
		}
	}
	public void closeAssignment(){
		if ( !workInProgress) nbrOfAssignedPeopleChosen = 0;
	}

	public void constructShip(){
		remainingTimeForConstruction = 4;
	}
	public void inConstruction(Ships ships, People people){
		if ( workInProgress) {
			if ( remainingTimeForConstruction <= 0 ){
				// rajouter un navire dans Ships, differencier en fonction du type
				ships.NbrOfShipType1 +=1;
				// rajouter le nombre de slave
				people.NbrOfSlave += nbrOfSlaveAssigned;
				nbrOfSlaveAssigned = 0;
				workInProgress = false;
			} else if ( remainingTimeForConstruction > 0 ){
				remainingTimeForConstruction -= 1;
			}
		} 
	}
}
