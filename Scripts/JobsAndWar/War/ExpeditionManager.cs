using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionManager : JobsAndWar {

	// Constructor 

	public ExpeditionManager() : base() {
		nbrOfShipAssigned = 0;
		typeOfShipSelected = ConstantsAndEnums.shipType.type1; // encore le même problème
		nbrOfAssignedVikingChosen = 0;
		nbrOfAssignedShieldMaidenChosen = 0;
		nbrOfAssignedShipChosen = 0;
		nbrOfSpacesAvailable = 0;
		totalForceValue = 0;

		nbrOfSimulatneousExpedition = 0;

		expeditions = new Expedition[5];
	}

	// Variables

	protected int nbrOfShipAssigned;

	// mettre une variable des différents batailles en cours ici 

	private ConstantsAndEnums.shipType typeOfShipSelected;
	private int nbrOfAssignedVikingChosen;
	private int nbrOfAssignedShieldMaidenChosen;
	private int nbrOfAssignedShipChosen;
	private int nbrOfSpacesAvailable;
	private int totalForceValue;

	private int NBR_MAX_OF_SIMULTANEOUS_EXPEDITION = 5;
	private int nbrOfSimulatneousExpedition;
	private Expedition[] expeditions;


	// Getters and Setters

	public int NbrOfShipAssigned{get{return nbrOfShipAssigned;}set{nbrOfShipAssigned = value;}}
	public ConstantsAndEnums.shipType TypeOfShipSelected{ get{return typeOfShipSelected;} set{ typeOfShipSelected = value;}}
	public int NbrOfAssignedVikingChosen{ get{return nbrOfAssignedVikingChosen;} set{ nbrOfAssignedVikingChosen = value;}}
	public int NbrOfAssignedShieldMaidenChosen{ get{return nbrOfAssignedShieldMaidenChosen;} set{ nbrOfAssignedShieldMaidenChosen = value;}}
	public int NbrOfAssignedShipChosen{ get{return nbrOfAssignedShipChosen;} set{ nbrOfAssignedShipChosen = value;}}
	public int NbrOfSpacesAvailable{ get{return nbrOfSpacesAvailable;} set{ nbrOfSpacesAvailable = value;}}
	public int TotalForceValue{ get{return totalForceValue;} set{ totalForceValue = value;}}

	public Expedition[] Expeditions{get{return expeditions;}}

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
		nbrOfSpacesAvailable = nbrOfAssignedShipChosen * gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen 
						- ( nbrOfAssignedVikingChosen + nbrOfAssignedShieldMaidenChosen);
		
	}
	public void totalForceValueCalculation(GameManager gameManager){
		totalForceValue = nbrOfAssignedVikingChosen * gameManager.Resources.People.Vikings.BattleEfficiency 
						+ nbrOfAssignedShieldMaidenChosen * gameManager.Resources.People.ShieldMaidens.BattleEfficiency ;
	}


	public void assignWork(GameManager gameManager, City currentCity){
		if (nbrOfAssignedVikingChosen > 0 || nbrOfAssignedShieldMaidenChosen > 0 ){
			if ( nbrOfSimulatneousExpedition < NBR_MAX_OF_SIMULTANEOUS_EXPEDITION ){
				Expedition expedition = new Expedition(nbrOfAssignedVikingChosen,nbrOfAssignedShieldMaidenChosen,nbrOfAssignedShipChosen,currentCity);
				expeditions[nbrOfSimulatneousExpedition] = expedition;
				nbrOfSimulatneousExpedition += 1;

				// mise a jour des donnees de jeu
				gameManager.Resources.People.NbrOfVikings -= nbrOfAssignedVikingChosen;
				gameManager.Resources.People.NbrOfShieldMaidens -= nbrOfAssignedShieldMaidenChosen;
				gameManager.Resources.Ships.NbrOfShipType1 -= nbrOfAssignedShipChosen;

				// réinitialisation des paramètres 
				nbrOfAssignedVikingChosen = 0;
				nbrOfAssignedShieldMaidenChosen = 0;
				nbrOfAssignedShipChosen = 0;

				nbrOfSpacesAvailableCalculation(gameManager);
				totalForceValueCalculation(gameManager);

			} else {
				// dire que le joueur à atteint le nombre max d'attaques simulténées
			}
			
		}
		else {
			// dire qu'il faut selectionner des guerriers
		}
	}
}
