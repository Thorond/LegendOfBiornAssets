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

	// Text d'erreur

	[SerializeField] private Text errorText;

	private IEnumerator coroutineErrorText;


	// infos standard

	[SerializeField] private Text nameOfPeople;
	[SerializeField] private Text displayOfNbrOfPeople;
	[SerializeField] private Text displayOfResources;


	// Pour les jobs
	[SerializeField] private Text nameJob;
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

		// pour la caserne

	[SerializeField] private Text displayOfNbrOfTeacherNeeded;
	[SerializeField] private Text displayOfNbrOfGoldNeed;

		// pour les entrainements
	[SerializeField] private Text[] timeRemainingTraining;
	[SerializeField] private Text[] nbrVikingInTraining;
	[SerializeField] private Text[] nbrSMInTraining;
	

	// Pour les batailles 
	[SerializeField] private Text foodNeeded;
	[SerializeField] private Text displayOfForceOfAViking;
	[SerializeField] private Text displayOfForceOfAShieldMaiden;
	[SerializeField] private Text displayOfTheSpacesWarriorOfAShip;
	[SerializeField] private Text displayOfTheSpacesLootOfAShip;
	[SerializeField] private Text displayOfNbrOfVikingChosenForWar;
	[SerializeField] private Text displayOfNbrOfShieldMaidenChosenForWar;
	[SerializeField] private Text displayOfNbrOfShipChosenForWar;
	[SerializeField] private Text displayOfShipTypeChosenForWar;
	[SerializeField] private Text displayOfSpacesAvailable;
	[SerializeField] private Text displayOfTotalFighterForce;

	// pour les villes 

	
    [SerializeField] private Text cityName;
    [SerializeField] private Text nbSoldats;
    [SerializeField] private Text difficultyCityDisplay;
    [SerializeField] private Text gold;
    [SerializeField] private Text wood;
    [SerializeField] private Text iron;
    [SerializeField] private Text slaves;

	
	// Pour le timeManager
	[SerializeField] private Text timeElapsedText;


	// Pour warManager
	[SerializeField] private Sprite easyDifficulty;
	[SerializeField] private Sprite mediumDifficulty;
	[SerializeField] private Sprite hardDifficulty;
	[SerializeField] private Sprite exploreAttack;
	[SerializeField] private Sprite plunderAttack;
	[SerializeField] private Sprite razeAttack;


	[SerializeField] private Image[] typeOfAttack;
	[SerializeField] private Text[] cityAttacked;
	[SerializeField] private Text[] RemainingTime;
	[SerializeField] private Image[] difficultyCityImageDisplay;

	// Pour expedtion

	[SerializeField] private Text cityNameCurrentExpedition;
	[SerializeField] private Text nbrOfVikingStart;
	[SerializeField] private Text nbrOfSMStart;
	[SerializeField] private Text expeditionStatus;
	[SerializeField] private Text battleStatus;
	[SerializeField] private Text nbrOfVikingEnd;
	[SerializeField] private Text nbrOfSMEnd;
	[SerializeField] private Text goldGained;
	[SerializeField] private Text woodGained;
	[SerializeField] private Text ironGained;
	[SerializeField] private Text slaveGained;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
		battleGeneralPanelDisplay();
		
	}


	// ********** FUNCTIONS **********

	public void errorTextDisplay(string errorMessage){
		errorText.text = errorMessage;
		coroutineErrorText = TextEffects.FadeTextToZeroAlpha(2f, errorText);
		StartCoroutine(coroutineErrorText);
		
	}


	public void textDisplay(){
		peopleAndNbrOfPeopleAndResourcesTextDisplay(); // affichage des personnes disponibles et des ressources
		workerTextDisplay(); // affichage du nombre de travailleurs pour chaque travail
		shipsTextDisplay(); // affichage du nombre de navires de chaque types
		barrackTextDisplay(); // affichage des donnees pour l'entrainement de guerriers
		trainingDisplay(); // affichage des entrainements en cours
		choiceOfWorkerForShipBuildingTextDisplay(); // Affichage du choix IG du joueur pour la construction de navires
		efficiencyOfPeopleTextDisplay(); // Affichage de l'efficacité de chaque personnes (Viking ou ShieldMaiden ou Slave) en fonction du travail demandé

		choiceOfFighterForWarTextDisplay(); // affiche le choix des navires et des guerriers à envoyer en bataille
		forceOfPeopleTextDisplay(); // affiche la force de chaque catégorie de guerriers

		timeElapsedTextDisplay(); // Affichage du temps écoulés 
	}

	// Pour les jobs
	public void nameJobDisplay(string name){
		nameJob.text = name;
	}
	void choiceOfWorkerForShipBuildingTextDisplay(){
		displayOfNbrOfVikingChosen.text = jobsManager.MyShipBuilderBuilding.NbrOfAssignedVikingChosen.ToString();
		displayOfNbrOfShieldMaidenChosen.text = jobsManager.MyShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen.ToString();
		displayOfNbrOSlaveChosen.text = jobsManager.MyShipBuilderBuilding.NbrOfAssignedSlaveChosen.ToString();

		if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type1){
			displayOfShipTypeChosen.text = "Type of ship to construct : type 1" ;
			displayOfLaborNeeded.text = "Workforce needed : " + gameManager.Resources.Ships.ShipType1.NbrOfLaborNeeded.ToString()
										+ "\nWood needed : " + gameManager.Resources.Ships.ShipType1.NbrOfWoodNeededForConstruction.ToString()
										+ "\nIron needed : " + gameManager.Resources.Ships.ShipType1.NbrOfIronNeededForConstruction.ToString();
		} 
		// else if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type2){
		// 	displayOfShipTypeChosen.text = "Type of ship to construct : type 2" ;
		// 	// displayOfLaborNeeded.text = gameManager.Resources.Ships.ShipType2.NbrOfLaborNeeded.ToString() ;
		// } else if (jobsManager.MyShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type3){
		// 	displayOfShipTypeChosen.text = "Type of ship to construct : type 3" ;
		// 	// displayOfLaborNeeded.text = gameManager.Resources.Ships.ShipType3.NbrOfLaborNeeded.ToString() ;
		// }
		
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
			
			// on profite des gameObject text de l'efficacité pour l'affichage du nombre de viking et de sm selectionnes pour l'entrainement
			else if (jobsManager.JobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.barrackBtn.ToString()){
				displayOfEfficiencyOfAViking.text = jobsManager.MyBarrack.NbrOfVikingToTrainChosen.ToString();
				displayOfEfficiencyOfAShieldMaiden.text = jobsManager.MyBarrack.NbrOFSMToTrainChosen.ToString();
				displayOfEfficiencyOfASlave.text = "";
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
	void barrackTextDisplay(){
		displayOfNbrOfTeacherNeeded.text = "ShieldMaidens needed : " + jobsManager.MyBarrack.NbrOfTeachersSMNeeded.ToString();
		displayOfNbrOfGoldNeed.text = "Gold needed : " + jobsManager.MyBarrack.GoldNeeded.ToString();
	}
	
		// pour les entrainements
	void trainingDisplay(){
		int iteration = 0;
		foreach (Training training in jobsManager.MyBarrack.Trainings ) {
			if (training != null){
				if ( training.InTraining ){

					timeRemainingTraining[iteration].text = training.TimeRemainingForTraining.ToString();
					nbrVikingInTraining[iteration].text = "Viking : " + training.NbrOfVikingToTrain.ToString();
					nbrSMInTraining[iteration].text = "SM : " + training.NbrOFSMToTrain.ToString();

				} else {
					timeRemainingTraining[iteration].text = "";
					nbrVikingInTraining[iteration].text = "";
					nbrSMInTraining[iteration].text = "";
				}
			} else {
					timeRemainingTraining[iteration].text = "";
					nbrVikingInTraining[iteration].text = "";
					nbrSMInTraining[iteration].text = "";
			}
			iteration +=1;
		}
	}

	// Pour les batailles
	void choiceOfFighterForWarTextDisplay(){
		foodNeeded.text = warManager.MyExpedition.NbrOfFoodNeeded.ToString();
		displayOfNbrOfVikingChosenForWar.text = warManager.MyExpedition.NbrOfAssignedVikingChosen.ToString();
		displayOfNbrOfShieldMaidenChosenForWar.text = warManager.MyExpedition.NbrOfAssignedShieldMaidenChosen.ToString();
		displayOfNbrOfShipChosenForWar.text = warManager.MyExpedition.NbrOfAssignedShipChosen.ToString();
		
		displayOfSpacesAvailable.text = "Space available : " + warManager.MyExpedition.NbrOfSpacesAvailable.ToString()
									+ "\n\nSpace available for loots : " 
									+ (warManager.MyExpedition.NbrOfAssignedShipChosen * gameManager.Resources.Ships.ShipType1.TotalCapacityOfLoot).ToString();
		displayOfTotalFighterForce.text = "Fighter force selected : " + warManager.MyExpedition.TotalForceValue.ToString();
	}
	void forceOfPeopleTextDisplay(){
			
	
		displayOfForceOfAViking.text = "Strength of a viking : " + gameManager.Resources.People.Vikings.BattleEfficiency.ToString();
		displayOfForceOfAShieldMaiden.text = "Strength of a SM : " +  gameManager.Resources.People.ShieldMaidens.BattleEfficiency.ToString();
		displayOfTheSpacesWarriorOfAShip.text = "Space for warriors : " +  gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen.ToString();
		displayOfTheSpacesLootOfAShip.text = "Space for loots : " + gameManager.Resources.Ships.ShipType1.TotalCapacityOfLoot.ToString(); 
			
	}

	// Pour les villes 

	void CityDetailsCreation()
    {
        cityName.text = warManager.CurrentCity.NameOfCity;
        nbSoldats.text = warManager.CurrentCity.NbSoldats.ToString();
        difficultyCityDisplay.text = warManager.CurrentCity.DificultyCity.ToString();
        gold.text = warManager.CurrentCity.LootDetail.Gold.ToString();
        wood.text = warManager.CurrentCity.LootDetail.Wood.ToString();
        iron.text = warManager.CurrentCity.LootDetail.Iron.ToString();
        slaves.text = warManager.CurrentCity.LootDetail.Slaves.ToString();
    }

	// Pour le timeManager

	void timeElapsedTextDisplay(){
		timeElapsedText.text = "Year " + timeManager.TimeInYear.ToString() + " - Day " + timeManager.TimeInDay.ToString()
			+ "\nDays to skip : " + timeManager.TimeChoice.ToString();
	}

	// Pour warManager

	public void battleGeneralPanelDisplay(){
		int iteration = 0;
		foreach (Expedition expedition in warManager.MyExpedition.Expeditions ) {
			if (expedition != null){
				if ( expedition.ExpeditionStatus != ConstantsAndEnums.expeditionStatus.over){

					if ( expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.explore ){
						typeOfAttack[iteration].sprite = exploreAttack;
					} else if ( expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.plunder ){
						typeOfAttack[iteration].sprite = plunderAttack;
					} else if ( expedition.AttackChosen == ConstantsAndEnums.possibleAttacks.raze ){
						typeOfAttack[iteration].sprite = razeAttack;
					}
					typeOfAttack[iteration].color = new Color(255,255,255,255);

					cityAttacked[iteration].text = expedition.City.NameOfCity;
					if ( expedition.ExpeditionStatus == ConstantsAndEnums.expeditionStatus.inMovement){
						RemainingTime[iteration].text = expedition.DurationOfMission.ToString();
					} else {
						RemainingTime[iteration].text = "Finished";
					}

					if ( expedition.City.DificultyCity == ConstantsAndEnums.dificultyInGame.easy ){
						difficultyCityImageDisplay[iteration].sprite = easyDifficulty;
					} else if ( expedition.City.DificultyCity == ConstantsAndEnums.dificultyInGame.medium ){
						difficultyCityImageDisplay[iteration].sprite = mediumDifficulty;
					} else if ( expedition.City.DificultyCity == ConstantsAndEnums.dificultyInGame.hard ){
						difficultyCityImageDisplay[iteration].sprite = hardDifficulty;
					}
					difficultyCityImageDisplay[iteration].color = new Color(255,255,255,255);
				} else {
					hideImagesAndTextsForBattlePanel(iteration);
				}
			} else {
				hideImagesAndTextsForBattlePanel(iteration);
			}
			iteration +=1;
		}
	}

	void hideImagesAndTextsForBattlePanel(int iteration){
		typeOfAttack[iteration].color = new Color(0,0,0,0);
		cityAttacked[iteration].text = "";
		RemainingTime[iteration].text = "";
		difficultyCityImageDisplay[iteration].color = new Color(0,0,0,0);
	}

	// pour les expeditions

	public void detailsExpedition(){
		
		if (  warManager.BattleDisplayChosen != 0) {
			Expedition currentExpedition = warManager.MyExpedition.Expeditions[warManager.BattleDisplayChosen -1];
			
			if ( currentExpedition != null ){
				if (  currentExpedition.ExpeditionStatus != ConstantsAndEnums.expeditionStatus.over){
					cityNameCurrentExpedition.text = currentExpedition.City.NameOfCity.ToString();
					nbrOfVikingStart.text = "Vikings sent : " + currentExpedition.NbrOfViking.ToString();
					nbrOfSMStart.text = "SM sent : " + currentExpedition.NbrOfShieldMaiden.ToString();	
					expeditionStatus.text = "State : " + currentExpedition.ExpeditionStatus.ToString();
					battleStatus.text = "Result : " + currentExpedition.BattleStatus.ToString();
					if ( currentExpedition.ExpeditionStatus == ConstantsAndEnums.expeditionStatus.battleOver ){

						nbrOfVikingEnd.text = "Remaining vkings : " + currentExpedition.NbrOfRemainingViking.ToString();
						nbrOfSMEnd.text = "Remaining SM : " + currentExpedition.NbrOfRemainingSM.ToString();
						goldGained.text = "Gold gained : " + currentExpedition.GoldBroughtBack.ToString();
						woodGained.text = "Wood gained : " + currentExpedition.WoodBroughtBack.ToString();
						ironGained.text = "Iron gained : " + currentExpedition.IronBroughtBack.ToString();
						slaveGained.text = "Slave gained : " + currentExpedition.SlaveBroughtBack.ToString();
						
					} else {

						nbrOfVikingEnd.text = "-";
						nbrOfSMEnd.text = "-";
						goldGained.text = "-";
						woodGained.text = "-";
						ironGained.text = "-";
						slaveGained.text = "-";
					}
				}
			}
		
		}
	}

}
