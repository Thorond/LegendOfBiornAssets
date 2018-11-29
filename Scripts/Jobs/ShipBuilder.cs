using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipBuilder : Jobs {

	// Variables
	private bool workInProgress = false;
	private int nbrOfAssignedVikingChosen = 0;
	private int nbrOfAssignedShieldMaidenChosen = 0;
	private int nbrOfAssignedSlaveChosen = 0;
	private int remainingTimeForConstruction = 0;

	// Getters and Setters 
	public bool WorkInProgress{ get { return workInProgress;} set{workInProgress = value;}}
	public int NbrOfAssignedVikingChosen{ get{return nbrOfAssignedVikingChosen;} set{ nbrOfAssignedVikingChosen = value;}}
	public int NbrOfAssignedShieldMaidenChosen{ get{return nbrOfAssignedShieldMaidenChosen;} set{ nbrOfAssignedShieldMaidenChosen = value;}}
	public int NbrOfAssignedSlaveChosen{ get{return nbrOfAssignedSlaveChosen;} set{ nbrOfAssignedSlaveChosen = value;}}
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

	public void assignWork(GameManager gameManager){
		if (nbrOfAssignedVikingChosen > 0 || nbrOfAssignedShieldMaidenChosen > 0 || nbrOfAssignedSlaveChosen > 0 ){
			addOrRemoveSeveralViking(nbrOfAssignedVikingChosen);
			addOrRemoveSeveralShieldMaiden(nbrOfAssignedShieldMaidenChosen);
			addOrRemoveSeveralSlave(nbrOfAssignedSlaveChosen);
			gameManager.Resources.People.NbrOfVikings -= nbrOfAssignedVikingChosen;
			gameManager.Resources.People.NbrOfShieldMaidens -= nbrOfAssignedShieldMaidenChosen;
			gameManager.Resources.People.NbrOfSlave -= nbrOfAssignedSlaveChosen;
			nbrOfAssignedVikingChosen = 0;
			nbrOfAssignedShieldMaidenChosen = 0;
			nbrOfAssignedSlaveChosen = 0;
			constructShip(gameManager);
			workInProgress = true;
		}
	}
	public void closeAssignment(){
		if ( !workInProgress) {
			nbrOfAssignedVikingChosen = 0;
			nbrOfAssignedShieldMaidenChosen = 0;
			nbrOfAssignedSlaveChosen = 0;
		}
	}

	public void constructShip(GameManager gameManager){
		// TODO
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
