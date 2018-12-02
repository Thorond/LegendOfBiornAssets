using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipBuilder : Jobs {

	// Variables
	private bool workInProgress;
	private ConstantsAndEnums.shipType typeOfShipConstruct;
	private int nbrOfAssignedVikingChosen;
	private int nbrOfAssignedShieldMaidenChosen;
	private int nbrOfAssignedSlaveChosen;
	private int totalLaborValue;
	private int remainingTimeForConstruction;


	// Getters and Setters 
	public bool WorkInProgress{ get { return workInProgress;} set{workInProgress = value;}}
	public ConstantsAndEnums.shipType TypeOfShipConstruct{ get{return typeOfShipConstruct;} set{ typeOfShipConstruct = value;}}
	public int NbrOfAssignedVikingChosen{ get{return nbrOfAssignedVikingChosen;} set{ nbrOfAssignedVikingChosen = value;}}
	public int NbrOfAssignedShieldMaidenChosen{ get{return nbrOfAssignedShieldMaidenChosen;} set{ nbrOfAssignedShieldMaidenChosen = value;}}
	public int NbrOfAssignedSlaveChosen{ get{return nbrOfAssignedSlaveChosen;} set{ nbrOfAssignedSlaveChosen = value;}}
	public int TotalLaborValue{ get{return totalLaborValue;} set{ totalLaborValue = value;}}
	public int RemainingTimeForConstruction{get{return remainingTimeForConstruction;} set{ remainingTimeForConstruction = value;}}

	// Constructor
	public ShipBuilder() : base() {
		workInProgress = false;
		typeOfShipConstruct = ConstantsAndEnums.shipType.type1;
		nbrOfAssignedVikingChosen = 0;
		nbrOfAssignedShieldMaidenChosen = 0;
		nbrOfAssignedSlaveChosen = 0;
		totalLaborValue = 0;
		remainingTimeForConstruction = 0;
	}
	
	// Functions 

	public override void determineQuantity(GameManager gameManager){
		quantityOfProductBroughtBack = 1;
	}

	public override void updateProduct(GameManager gameManager, int timeSpent){
		
	}

	public void assignWork(GameManager gameManager, int laborValue ){
		if (nbrOfAssignedVikingChosen > 0 || nbrOfAssignedShieldMaidenChosen > 0 || nbrOfAssignedSlaveChosen > 0 ){
			if ( totalLaborValue >= laborValue ){
				if ( gameManager.Resources.Wood >= gameManager.Resources.Ships.ShipType1.NbrOfWoodNeededForConstruction ){
					if (gameManager.Resources.Iron >= gameManager.Resources.Ships.ShipType1.NbrOfIronNeededForConstruction){
						addOrRemoveSeveralViking(nbrOfAssignedVikingChosen);
						addOrRemoveSeveralShieldMaiden(nbrOfAssignedShieldMaidenChosen);
						addOrRemoveSeveralSlave(nbrOfAssignedSlaveChosen);
						gameManager.Resources.People.NbrOfVikings -= nbrOfAssignedVikingChosen;
						gameManager.Resources.People.NbrOfShieldMaidens -= nbrOfAssignedShieldMaidenChosen;
						gameManager.Resources.People.NbrOfSlave -= nbrOfAssignedSlaveChosen;
						nbrOfAssignedVikingChosen = 0;
						nbrOfAssignedShieldMaidenChosen = 0;
						nbrOfAssignedSlaveChosen = 0;
						gameManager.Resources.Wood -= gameManager.Resources.Ships.ShipType1.NbrOfWoodNeededForConstruction;
						gameManager.Resources.Iron -= gameManager.Resources.Ships.ShipType1.NbrOfIronNeededForConstruction;
						constructShip(gameManager);
						workInProgress = true;
					}else{
						// affichage d'erreur disant que le joueur n'a pas assez de métal
					}
				}else {
					// message d'erreur disant que le joueur n'a pas assez de bois
				}
				
			}
			else {
				//retourner un affichage d'erreur comme quoi le joueur n'a pas sélectionné assez de travailleurs 
			}
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
				if (this.typeOfShipConstruct == ConstantsAndEnums.shipType.type1) ships.NbrOfShipType1 +=1;
				// else if (this.typeOfShipConstruct == ConstantsAndEnums.shipType.type2) ships.NbrOfShipType2 +=1;
				// else if (this.typeOfShipConstruct == ConstantsAndEnums.shipType.type3) ships.NbrOfShipType3 +=1;

				people.NbrOfVikings += nbrOfVikingAssigned;
				people.NbrOfShieldMaidens += nbrOfShieldMaidenAssigned;
				people.NbrOfSlave += nbrOfSlaveAssigned;
				nbrOfVikingAssigned = 0;
				nbrOfShieldMaidenAssigned = 0;
				nbrOfSlaveAssigned = 0;
				workInProgress = false;
			} else if ( remainingTimeForConstruction > 0 ){
				remainingTimeForConstruction -= 1;
			}
		} 
	}
}
