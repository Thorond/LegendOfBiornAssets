﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : Singleton<TextManager> {



	// Variables 
	[SerializeField] private GameManager gameManager;
	[SerializeField] private TimeManager timeManager;
	[SerializeField] private JobsManager jobsManager;
	[SerializeField] private WarManager warManager;

	// Les différents Texts

	[SerializeField] private Text nameOfPeople;
	[SerializeField] private Text displayOfNbrOfPeople;
	[SerializeField] private Text displayOfResources;


	// Pour les jobs
	[SerializeField] private Text displayOfNbrOfHunter;
	// [SerializeField] private Text displayOfNbrOfFisherMen;
	[SerializeField] private Text displayOfNbrOfShipBuilder;
	[SerializeField] private Text displayOfNbrOfShip;
	[SerializeField] private Text displayOfWoodWorkers;
	[SerializeField] private Text displayOfIronWorkers;
	[SerializeField] private Text displayOfEfficiencyOfAViking;
	[SerializeField] private Text displayOfEfficiencyOfAShieldMaiden;
	[SerializeField] private Text displayOfEfficiencyOfASlave;
	[SerializeField] private Text displayOfNbrOfVikingChosen;
	[SerializeField] private Text displayOfNbrOfShieldMaidenChosen;
	[SerializeField] private Text displayOfNbrOSlaveChosen;
	[SerializeField] private Text displayOfShipTypeChosen;
	[SerializeField] private Text displayOfLaborNeeded;
	[SerializeField] private Text displayOfLaborChosen;

	// Pour les batailles 
	[SerializeField] private Text displayOfForceOfAViking;
	[SerializeField] private Text displayOfForceOfAShieldMaiden;
	[SerializeField] private Text displayOfTheSpacesOfAShip;
	[SerializeField] private Text displayOfNbrOfVikingChosenForWar;
	[SerializeField] private Text displayOfNbrOfShieldMaidenChosenForWar;
	[SerializeField] private Text displayOfNbrOfShipChosenForWar;
	[SerializeField] private Text displayOfShipTypeChosenForWar;
	[SerializeField] private Text displayOfSpacesAvailable;


	
	// Pour le timeManager
	[SerializeField] private Text timeElapsedText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		textDisplay();
	}


	// ********** FUNCTIONS **********

	public void textDisplay(){
		peopleAndNbrOfPeopleAndResourcesTextDisplay(); // affichage des personnes disponibles et des ressources
		workerTextDisplay(); // affichage du nombre de travailleurs pour chaque travail
		shipsTextDisplay(); // affichage du nombre de navires de chaque types
		choiceOfWorkerForShipBuildingTextDisplay(); // Affichage du choix IG du joueur pour la construction de navires
		efficiencyOfPeopleTextDisplay(); // Affichage de l'efficacité de chaque personnes (Viking ou ShieldMaiden ou Slave) en fonction du travail demandé

		choiceOfFighterForWarTextDisplay();
		forceOfPeopleTextDisplay();

		timeElapsedTextDisplay(); // Affichage du temps écoulés 
	}

	// Pour les jobs
	void choiceOfWorkerForShipBuildingTextDisplay(){
		displayOfNbrOfVikingChosen.text = jobsManager.MyShipBuilderBuilding.NbrOfAssignedVikingChosen.ToString();
		displayOfNbrOfShieldMaidenChosen.text = jobsManager.MyShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen.ToString();
		displayOfNbrOSlaveChosen.text = jobsManager.MyShipBuilderBuilding.NbrOfAssignedSlaveChosen.ToString();

		if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type1){
			displayOfShipTypeChosen.text = "Type of ship to construct : type 1" ;
			displayOfLaborNeeded.text = "Workforce needed : " + gameManager.Resources.Ships.ShipType1.NbrOfLaborNeeded.ToString()
										+ "\nWood needed : " + gameManager.Resources.Ships.ShipType1.NbrOfWoodNeededForConstruction.ToString()
										+ "\nIron needed : " + gameManager.Resources.Ships.ShipType1.NbrOfIronNeededForConstruction.ToString();
		} else if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type2){
			displayOfShipTypeChosen.text = "Type of ship to construct : type 2" ;
			// displayOfLaborNeeded.text = gameManager.Resources.Ships.ShipType2.NbrOfLaborNeeded.ToString() ;
		} else if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type3){
			displayOfShipTypeChosen.text = "Type of ship to construct : type 3" ;
			// displayOfLaborNeeded.text = gameManager.Resources.Ships.ShipType3.NbrOfLaborNeeded.ToString() ;
		}
		
		displayOfLaborChosen.text = "Workforce selected : " + jobsManager.MyShipBuilderBuilding.TotalLaborValue.ToString();
	}

	void peopleAndNbrOfPeopleAndResourcesTextDisplay(){
		nameOfPeople.text = gameManager.Resources.People.nameOfPeopleDisplay();
		displayOfNbrOfPeople.text = gameManager.Resources.People.textDisplay();
		displayOfResources.text = gameManager.Resources.textDisplay();
	}

	void workerTextDisplay(){
		displayOfNbrOfHunter.text = "Hunting : \n" + jobsManager.MyHuntingBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + jobsManager.MyHuntingBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + jobsManager.MyHuntingBuilding.NbrOfSlaveAssigned.ToString();
		// displayOfNbrOfFisherMen.text = "Fishing : \n" + jobsManager.MyFishingBuilding.NbrOfVikingAssigned.ToString()
		// 		+ "\n"  + jobsManager.MyFishingBuilding.NbrOfShieldMaidenAssigned.ToString()
		// 		+ "\n"  + jobsManager.MyFishingBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfShipBuilder.text = "Ships Workers : \n" + jobsManager.MyShipBuilderBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + jobsManager.MyShipBuilderBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + jobsManager.MyShipBuilderBuilding.NbrOfSlaveAssigned.ToString();
		displayOfWoodWorkers.text = "Wood Workers : \n" + jobsManager.MyWoodBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + jobsManager.MyWoodBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + jobsManager.MyWoodBuilding.NbrOfSlaveAssigned.ToString();
		displayOfIronWorkers.text = "Iron Workers : \n" + jobsManager.MyMineralBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + jobsManager.MyMineralBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + jobsManager.MyMineralBuilding.NbrOfSlaveAssigned.ToString();
	}
	void efficiencyOfPeopleTextDisplay(){
		if (jobsManager.JobsOrCityBtnPressed){
			if ( jobsManager.JobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.huntingBtn.ToString()  ){
				displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.FoodGatheringEfficiency.ToString();
				displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.FoodGatheringEfficiency.ToString();
				displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.FoodGatheringEfficiency.ToString();
			}

			else if ( jobsManager.JobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.rawMaterialBtn.ToString()  ){
				if (jobsManager.WoodOrIronBtnPressed){
					if (jobsManager.WoodOrIronBtnPressed.tag == ConstantsAndEnums.tagPanelJobs.ironBtn.ToString()){
						displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.IronGatheringEfficiency.ToString();
						displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.IronGatheringEfficiency.ToString();
						displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.IronGatheringEfficiency.ToString();
					}
					else {
						displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.WoodGatheringEfficiency.ToString();
						displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.WoodGatheringEfficiency.ToString();
						displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.WoodGatheringEfficiency.ToString();
					}
				}
				else {
					displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.WoodGatheringEfficiency.ToString();
					displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.WoodGatheringEfficiency.ToString();
					displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.WoodGatheringEfficiency.ToString();
				}
			}
			
			else if (jobsManager.JobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.shipBuilderBtn.ToString()){
				displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.ShipConstructionEffeciency.ToString();
				displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.ShipConstructionEffeciency.ToString();
				displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.ShipConstructionEffeciency.ToString();
			}
			
		} else{
			displayOfEfficiencyOfAViking.text = "";
			displayOfEfficiencyOfAShieldMaiden.text = "";
			displayOfEfficiencyOfASlave.text = "";
		}
	}
	void shipsTextDisplay(){
		displayOfNbrOfShip.text = "Ships  \n Type 1 : " + gameManager.Resources.Ships.NbrOfShipType1.ToString();
	}
		
	// Pour les batailles
	void choiceOfFighterForWarTextDisplay(){
		displayOfNbrOfVikingChosenForWar.text = warManager.MyExpedition.NbrOfAssignedVikingChosen.ToString();
		displayOfNbrOfShieldMaidenChosenForWar.text = warManager.MyExpedition.NbrOfAssignedShieldMaidenChosen.ToString();
		displayOfNbrOfShipChosenForWar.text = warManager.MyExpedition.NbrOfAssignedShipChosen.ToString();

		// if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type1){
		// 	displayOfShipTypeChosen.text = "Type of ship to construct : type 1" ;
		// 	displayOfLaborNeeded.text = "Workforce needed : " + gameManager.Resources.Ships.ShipType1.NbrOfLaborNeeded.ToString()
		// 								+ "\nWood needed : " + gameManager.Resources.Ships.ShipType1.NbrOfWoodNeededForConstruction.ToString()
		// 								+ "\nIron needed : " + gameManager.Resources.Ships.ShipType1.NbrOfIronNeededForConstruction.ToString();
		// } else if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type2){
		// 	displayOfShipTypeChosen.text = "Type of ship to construct : type 2" ;
		// 	// displayOfLaborNeeded.text = gameManager.Resources.Ships.ShipType2.NbrOfLaborNeeded.ToString() ;
		// } else if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type3){
		// 	displayOfShipTypeChosen.text = "Type of ship to construct : type 3" ;
		// 	// displayOfLaborNeeded.text = gameManager.Resources.Ships.ShipType3.NbrOfLaborNeeded.ToString() ;
		// }
		
		displayOfSpacesAvailable.text = warManager.MyExpedition.NbrOfSpacesAvailable.ToString();
		// displayOfLaborChosen.text = "Workforce selected : " + jobsManager.MyShipBuilderBuilding.TotalLaborValue.ToString();
	}
	void forceOfPeopleTextDisplay(){
			
	
		displayOfForceOfAViking.text = "Force d'un viking : " + gameManager.Resources.People.Vikings.BattleEfficiency.ToString();
		displayOfForceOfAShieldMaiden.text = "Force d'une SM : " +  gameManager.Resources.People.ShieldMaidens.BattleEfficiency.ToString();
		displayOfTheSpacesOfAShip.text = "Espace dans un navire : " +  gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen.ToString(); // a faire pour les trois types
		
			
	}

	// Pour le timeManager

	void timeElapsedTextDisplay(){
		timeElapsedText.text = "Year " + timeManager.TimeInYear.ToString() + " - Day " + timeManager.TimeInDay.ToString()
			+ "\n How many days do you want to skip : " + timeManager.TimeChoice.ToString();
	}


}
