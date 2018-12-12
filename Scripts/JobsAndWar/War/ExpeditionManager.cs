using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionManager : JobsAndWar {

	// Constructor 

	public ExpeditionManager() : base() {
		nbrOfShipAssigned = 0;
		typeOfShipSelected = ConstantsAndEnums.shipType.type1; // encore le même problème
		typeOfAttackSelected = ConstantsAndEnums.possibleAttacks.explore;
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

	private ConstantsAndEnums.shipType typeOfShipSelected;
	private ConstantsAndEnums.possibleAttacks typeOfAttackSelected;
	private int nbrOfFoodNeeded;
	private int nbrOfAssignedVikingChosen;
	private int nbrOfAssignedShieldMaidenChosen;
	private int nbrOfAssignedShipChosen;
	private int nbrOfSpacesAvailable;
	private int totalForceValue;

	// private int NBR_MAX_OF_SIMULTANEOUS_EXPEDITION = 5;
	private int nbrOfSimulatneousExpedition;
	private Expedition[] expeditions; // différentes batailles en cours


	// Getters and Setters

	public int NbrOfShipAssigned{get{return nbrOfShipAssigned;}set{nbrOfShipAssigned = value;}}
	public ConstantsAndEnums.shipType TypeOfShipSelected{ get{return typeOfShipSelected;} set{ typeOfShipSelected = value;}}
	public ConstantsAndEnums.possibleAttacks TypeOfAttackSelected{ get{return typeOfAttackSelected;} set{ typeOfAttackSelected = value;}}

	public int NbrOfFoodNeeded{ get{return nbrOfFoodNeeded;} set{ nbrOfFoodNeeded = value;}}
	public int NbrOfAssignedVikingChosen{ get{return nbrOfAssignedVikingChosen;} set{ nbrOfAssignedVikingChosen = value;}}
	public int NbrOfAssignedShieldMaidenChosen{ get{return nbrOfAssignedShieldMaidenChosen;} set{ nbrOfAssignedShieldMaidenChosen = value;}}
	public int NbrOfAssignedShipChosen{ get{return nbrOfAssignedShipChosen;} set{ nbrOfAssignedShipChosen = value;}}
	public int NbrOfSpacesAvailable{ get{return nbrOfSpacesAvailable;} set{ nbrOfSpacesAvailable = value;}}
	public int TotalForceValue{ get{return totalForceValue;} set{ totalForceValue = value;}}
	public int NbrOfSimulatneousExpedition{ get{return nbrOfSimulatneousExpedition;} set{ nbrOfSimulatneousExpedition = value;}}

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

	public void nbrOfFoodNeedCalcultation(GameManager gameManager, City currentCity){
		nbrOfFoodNeeded = ( nbrOfAssignedVikingChosen * gameManager.Resources.People.Vikings.FoodConsomationPerDay 
							+ nbrOfAssignedShieldMaidenChosen * gameManager.Resources.People.ShieldMaidens.FoodConsomationPerDay)
							* currentCity.ApproximatedTripAndBattleTime ;
	}


	public void assignWork(GameManager gameManager, TextManager textManager, City currentCity){
		if ( !currentCity.UnderAttack ){
			if (  nbrOfAssignedVikingChosen > 0 || nbrOfAssignedShieldMaidenChosen > 0 ){
				if (gameManager.Resources.Food > nbrOfFoodNeeded){
					int rank = 0;
					foreach (Expedition exp in expeditions){
						if ( exp == null || exp.ExpeditionStatus == ConstantsAndEnums.expeditionStatus.over ){
							currentCity.UnderAttack = true;
							Expedition expedition = new Expedition(nbrOfAssignedVikingChosen,nbrOfAssignedShieldMaidenChosen,nbrOfAssignedShipChosen,
																nbrOfAssignedShipChosen * gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen,
																nbrOfAssignedShipChosen * gameManager.Resources.Ships.ShipType1.TotalCapacityOfLoot,
																currentCity,TypeOfAttackSelected);
							expeditions[rank] = expedition;
							nbrOfSimulatneousExpedition +=1;

							// Enlever la ville des villes attaquables

							// mise a jour des donnees de jeu
							gameManager.Resources.People.NbrOfVikings -= nbrOfAssignedVikingChosen;
							gameManager.Resources.People.NbrOfShieldMaidens -= nbrOfAssignedShieldMaidenChosen;
							gameManager.Resources.Ships.NbrOfShipType1 -= nbrOfAssignedShipChosen;
							gameManager.Resources.Food -= nbrOfFoodNeeded;

							// réinitialisation des paramètres 
							nbrOfAssignedVikingChosen = 0;
							nbrOfAssignedShieldMaidenChosen = 0;
							nbrOfAssignedShipChosen = 0;
							nbrOfFoodNeeded = 0;

							nbrOfSpacesAvailableCalculation(gameManager);
							totalForceValueCalculation(gameManager);
							break;
						} else{
							rank+=1;
						}
					}
					if (rank == 5) {
						// dire que le joueur à atteint le nombre max d'attaques simutanees
						textManager.errorTextDisplay("You already have five ongoing missions !");
					}
				} else {
						// le joueur n'a pas assez de nourriture pour cette expediton
						textManager.errorTextDisplay("You don't have enough food !");
				}
				
			}
			else if ( nbrOfAssignedVikingChosen == 0 && nbrOfAssignedShieldMaidenChosen == 0 ){
				// dire qu'il faut selectionner des guerriers
				textManager.errorTextDisplay("You did not assigned any warrior !");
			}
			
		}
		else if ( currentCity.UnderAttack ){
			textManager.errorTextDisplay("The city is already under attack !");

		}
	}

	public void closeExpedition(GameManager gameManager, Expedition expeTemp){
	
		gameManager.Resources.People.NbrOfVikings += expeTemp.NbrOfRemainingViking;
		gameManager.Resources.People.NbrOfShieldMaidens += expeTemp.NbrOfRemainingSM;
		gameManager.Resources.People.NbrOfSlave += expeTemp.SlaveBroughtBack;
		gameManager.Resources.Ships.NbrOfShipType1 += expeTemp.NbrOfShip;
		gameManager.Resources.Gold += expeTemp.GoldBroughtBack;
		gameManager.Resources.Wood += expeTemp.WoodBroughtBack;
		gameManager.Resources.Iron += expeTemp.IronBroughtBack;

		expeTemp.City.UnderAttack = false;
		expeTemp.ExpeditionStatus = ConstantsAndEnums.expeditionStatus.over;
	}
}
