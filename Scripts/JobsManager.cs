using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JobsManager : JobsAndWarManager {

	// Constructor 
	public JobsManager() : base() {
		myHuntingBuilding = new Hunting();
		myFishingBuilding = new Fishing();
		myShipBuilderBuilding = new ShipBuilder();
		myMineralBuilding = new MineralGathering();
		myWoodBuilding = new WoodGathering();
		myBarrack = new Barrack();
		nameJob = "";
	}

	// Variables

	[SerializeField] GameObject jobPanel;
	[SerializeField] GameObject shipUI;
	[SerializeField] GameObject slaveUI;
	[SerializeField] GameObject barrackUI;
	[SerializeField] GameObject infoPanelSpacesShip;
	[SerializeField] GameObject infoPanelStrengthViking;
	[SerializeField] GameObject infoPanelStrengthSM;
	private Btn woodOrIronBtnPressed;

	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;
	private MineralGathering myMineralBuilding;
	private WoodGathering myWoodBuilding;
	private Barrack myBarrack;

	private string nameJob;
	


	// Getters and Setters
	public Btn WoodOrIronBtnPressed{get{return woodOrIronBtnPressed;}}

	public Hunting MyHuntingBuilding { get{return myHuntingBuilding;}}
	public Fishing MyFishingBuilding { get{return myFishingBuilding;}}
	public ShipBuilder MyShipBuilderBuilding { get{return myShipBuilderBuilding;}}
	public MineralGathering MyMineralBuilding { get{return myMineralBuilding;}}
	public WoodGathering MyWoodBuilding { get{return myWoodBuilding;}}
	public Barrack MyBarrack { get{return myBarrack;}}



	// Use this for initialization
	void Start () {
		setAllJobPanelInactive();
	}
	
	// Update is called once per frame
	void Update () {
	}


	// Functions 
	public void selectedWoodOrIron(Btn btnSelected){
		woodOrIronBtnPressed = btnSelected;
	}
	public override void selectedShipType(Btn btnSelected){
		whichShipSelected = btnSelected;
		if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship1Btn.ToString()){
			myShipBuilderBuilding.TypeOfShipConstruct = ConstantsAndEnums.shipType.type1;
		} 
		// else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship2Btn.ToString()){
		// 	myShipBuilderBuilding.TypeOfShipConstruct = ConstantsAndEnums.shipType.type2;
		// } else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship3Btn.ToString()){
		// 	myShipBuilderBuilding.TypeOfShipConstruct = ConstantsAndEnums.shipType.type3;
		// } 
	}

	public override void jobOrCitySettingCreation(){
		
		setAllJobPanelInactive();
		myShipBuilderBuilding.closeAssignment();
		if ( jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.huntingBtn.ToString() 
			|| jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.rawMaterialBtn.ToString()
			|| jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.shipBuilderBtn.ToString() 
			|| jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.barrackBtn.ToString()  ){

			GameObject btnToActivate;
			jobPanel.SetActive(true); // Afficher le panel des métiers
			slaveUI.SetActive(true);
			if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.huntingBtn.ToString()){ // afficher le panel de la chasse des matières premières
				nameJob = "Hunting";
			}
			if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.rawMaterialBtn.ToString()){ // afficher le panel du travail des matières premières
				btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.woodBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
				btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.ironBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);

				nameJob = "Raw Material";
			}
			if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.shipBuilderBtn.ToString()){ // Afficher le panel de la construction de navires
				applyBtn.SetActive(true);
				// ship1Btn.SetActive(true);
				// ship2Btn.SetActive(true);
				// ship3Btn.SetActive(true);
				shipUI.SetActive(true);

				nameJob = "Ship Builder";
			}
			if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.barrackBtn.ToString()){ // Afficher le panel pour l'entrainement des guerriers
				applyBtn.SetActive(true);
				slaveUI.SetActive(false);
				barrackUI.SetActive(true);

				nameJob = "Barrack";
			}
		} else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.harbor.ToString()){
			panelMap.SetActive(true);

			nameJob = "Harbor";
		}

		textManager.nameJobDisplay(nameJob);

	}

	public override void peopleAssignement( ){
		huntingAssignement();
		rawMaterialAssignement();
		shipBuildingAssignement();
		barrackAssignement();
	}

	// jobAssignement : fonction génératrice
	public void jobAssignement(Jobs myJobBuilding){
		if ( upOrDownBtnPressed.tag == ConstantsAndEnums.tagUpOrDown.upSlave.ToString() && gameManager.Resources.People.NbrOfSlave > 0 ){
			myJobBuilding.assignAnotherSlave();
			gameManager.Resources.People.NbrOfSlave -= 1;
		}
		else if ( upOrDownBtnPressed.tag == ConstantsAndEnums.tagUpOrDown.downSlave.ToString() && myJobBuilding.NbrOfSlaveAssigned > 0 ){
			myJobBuilding.removeASlave();
			gameManager.Resources.People.NbrOfSlave += 1;
		} else if ( upOrDownBtnPressed.tag == ConstantsAndEnums.tagUpOrDown.upViking.ToString() && gameManager.Resources.People.NbrOfVikings > 0 ){
			myJobBuilding.assignAnotherViking();
			gameManager.Resources.People.NbrOfVikings -= 1;
		}
		else if ( upOrDownBtnPressed.tag == ConstantsAndEnums.tagUpOrDown.downViking.ToString() && myJobBuilding.NbrOfVikingAssigned > 0 ){
			myJobBuilding.removeAViking();
			gameManager.Resources.People.NbrOfVikings += 1;
		} else if ( upOrDownBtnPressed.tag == ConstantsAndEnums.tagUpOrDown.upShieldMaiden.ToString() && gameManager.Resources.People.NbrOfShieldMaidens > 0 ){
			myJobBuilding.assignAnotherShieldMaiden();
			gameManager.Resources.People.NbrOfShieldMaidens -= 1;
		}
		else if ( upOrDownBtnPressed.tag == ConstantsAndEnums.tagUpOrDown.downShieldMaiden.ToString() && myJobBuilding.NbrOfShieldMaidenAssigned > 0 ){
			myJobBuilding.removeAShieldMaiden();
			gameManager.Resources.People.NbrOfShieldMaidens += 1;
		}
		
	}

	public void huntingAssignement(){
		if ( jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.huntingBtn.ToString() ){
			jobAssignement(myHuntingBuilding);
		}
	}

	public void rawMaterialAssignement(){
		if ( jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.rawMaterialBtn.ToString() ){
			if (woodOrIronBtnPressed){
				if ( woodOrIronBtnPressed.tag == ConstantsAndEnums.tagPanelJobs.woodBtn.ToString()){
					jobAssignement(myWoodBuilding);
				} else {
					jobAssignement(myMineralBuilding);
				}
			} else{
				jobAssignement(myWoodBuilding);
			}
		}
	}

	public void shipBuildingAssignement(){
		if ( jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.shipBuilderBtn.ToString() ){
			// attribution des vikings
			if (gameManager.Resources.People.NbrOfVikings > myShipBuilderBuilding.NbrOfAssignedVikingChosen ){
				if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upViking.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
					myShipBuilderBuilding.NbrOfAssignedVikingChosen += 1;
				}
			} 
			if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downViking.ToString()) && !myShipBuilderBuilding.WorkInProgress){
				if ( myShipBuilderBuilding.NbrOfAssignedVikingChosen > 0) myShipBuilderBuilding.NbrOfAssignedVikingChosen -= 1;
			}
			// attribution des shieldmaidens
			if (gameManager.Resources.People.NbrOfShieldMaidens > myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen ){
				if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upShieldMaiden.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
					myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen += 1;
				}
			} 
			if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downShieldMaiden.ToString()) && !myShipBuilderBuilding.WorkInProgress){
				if ( myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen > 0) myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen -= 1;
			}
			// attribution des esclaves
			if (gameManager.Resources.People.NbrOfSlave > myShipBuilderBuilding.NbrOfAssignedSlaveChosen ){
				if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upSlave.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
					myShipBuilderBuilding.NbrOfAssignedSlaveChosen += 1;
				}
			} 
			if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downSlave.ToString()) && !myShipBuilderBuilding.WorkInProgress){
				if ( myShipBuilderBuilding.NbrOfAssignedSlaveChosen > 0) myShipBuilderBuilding.NbrOfAssignedSlaveChosen -= 1;
			} 

			// application des travailleurs pour les trois types de navires
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagShipType.applyBtn.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
				int valeur = gameManager.Resources.Ships.ShipType1.NbrOfLaborNeeded ;
				// if (myShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type2){
				// 	//valeur = gameManager.Resources.Ships.ShipType2.NbrOfLaborNeeded ;
				// } else if (myShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type3){
				// 	//valeur = gameManager.Resources.Ships.ShipType3.NbrOfLaborNeeded ;
				// }
				myShipBuilderBuilding.assignWork(gameManager,textManager,valeur);
			} else if (myShipBuilderBuilding.WorkInProgress){
				textManager.errorTextDisplay("A construction is already in progress !");
			}

			// mise à jour de la valeur effective de la force de main d'oeuvre avec les choix de travailleurs
			myShipBuilderBuilding.TotalLaborValue = myShipBuilderBuilding.NbrOfAssignedVikingChosen * gameManager.Resources.People.Vikings.ShipConstructionEffeciency
							+ myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen * gameManager.Resources.People.ShieldMaidens.ShipConstructionEffeciency
							+ myShipBuilderBuilding.NbrOfAssignedSlaveChosen * gameManager.Resources.People.Slaves.ShipConstructionEffeciency;
		}
	}

	public void barrackAssignement(){
		if ( jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.barrackBtn.ToString() ){
			// attribution des vikings
			
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upViking.ToString())  ){
				myBarrack.NbrOfVikingToTrainChosen += 1;
			}
			
			if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downViking.ToString()) ){
				if ( myBarrack.NbrOfVikingToTrainChosen > 0) myBarrack.NbrOfVikingToTrainChosen -= 1;
			}
			// attribution des shieldmaidens
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upShieldMaiden.ToString())){
				myBarrack.NbrOFSMToTrainChosen += 1;
			}
			
			if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downShieldMaiden.ToString()) ){
				if ( myBarrack.NbrOFSMToTrainChosen > 0) myBarrack.NbrOFSMToTrainChosen -= 1;
			}

			// mettre en route les entrainements
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagShipType.applyBtn.ToString())  ){				
				myBarrack.assignWork(gameManager,textManager);
			}


			myBarrack.goldNeedCalculation();
			myBarrack.nbrOfTeachersSMNeededCalculation();
		}
	}


	
	public void setAllJobPanelInactive(){
		jobPanel.SetActive(false);
		applyBtn.SetActive(false);
		ship1Btn.SetActive(false);
		ship2Btn.SetActive(false);
		ship3Btn.SetActive(false);
		shipUI.SetActive(false);
		barrackUI.SetActive(false);
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			foreach( ConstantsAndEnums.tagPanelJobs tagou in Enum.GetValues(typeof(ConstantsAndEnums.tagPanelJobs)))
				if ( go.tag.Equals(tagou.ToString())) go.SetActive(false);
		} ;
	}

	

	
	public void infoDisplayShipOpen(){
		infoPanelSpacesShip.SetActive(true);
	}
	public void infoDisplayShipClose(){
		infoPanelSpacesShip.SetActive(false);
	}
	public void infoDisplayStrengthVikingOpen(){
		infoPanelStrengthViking.SetActive(true);
	}
	public void infoDisplayStrengthVikingClose(){
		infoPanelStrengthViking.SetActive(false);
	}
	public void infoDisplayStrengthSMOpen(){
		infoPanelStrengthSM.SetActive(true);
	}
	public void infoDisplayStrengthSMClose(){
		infoPanelStrengthSM.SetActive(false);
	}
}
