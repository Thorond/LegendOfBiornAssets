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
	}

	// Variables
	private Btn woodOrIronBtnPressed;

	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;
	private MineralGathering myMineralBuilding;
	private WoodGathering myWoodBuilding;
	


	// Getters and Setters
	public Btn WoodOrIronBtnPressed{get{return woodOrIronBtnPressed;}}

	public Hunting MyHuntingBuilding { get{return myHuntingBuilding;}}
	public Fishing MyFishingBuilding { get{return myFishingBuilding;}}
	public ShipBuilder MyShipBuilderBuilding { get{return myShipBuilderBuilding;}}
	public MineralGathering MyMineralBuilding { get{return myMineralBuilding;}}
	public WoodGathering MyWoodBuilding { get{return myWoodBuilding;}}



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
		} else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship2Btn.ToString()){
			myShipBuilderBuilding.TypeOfShipConstruct = ConstantsAndEnums.shipType.type2;
		} else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship3Btn.ToString()){
			myShipBuilderBuilding.TypeOfShipConstruct = ConstantsAndEnums.shipType.type3;
		} 
	}

	public override void jobOrCitySettingCreation(){
		
		setAllJobPanelInactive();
		myShipBuilderBuilding.closeAssignment();
		if ( jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.huntingBtn.ToString() || jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.rawMaterialBtn.ToString()
			|| jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.shipBuilderBtn.ToString()  ){
			GameObject btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.jobPanel.ToString()); 
			if (btnToActivate) btnToActivate.SetActive(true); // Afficher le panel de la chasse
			if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.rawMaterialBtn.ToString()){ // afficher le panel du travail des matières premières
				btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.woodBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
				btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.ironBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
			}
			if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.shipBuilderBtn.ToString()){ // Afficher le panel de la construction de navires
				btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.applyBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
				ship1Btn.SetActive(true);
				ship2Btn.SetActive(true);
				ship3Btn.SetActive(true);
				btnToActivate = findGameObject(ConstantsAndEnums.tagPanelJobs.shipUI.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
			}
		} else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnJob.harbor.ToString()){
			panelCity.SetActive(false);
			panelMap.SetActive(true);
		}

	}

	public override void peopleAssignement( ){
		huntingAssignement();
		rawMaterialAssignement();
		shipBuildingAssignement();
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
		if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagPanelJobs.applyBtn.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
			int valeur = gameManager.Resources.Ships.ShipType1.NbrOfLaborNeeded ;
			if (myShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type2){
				//valeur = gameManager.Resources.Ships.ShipType2.NbrOfLaborNeeded ;
			} else if (myShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type3){
				//valeur = gameManager.Resources.Ships.ShipType3.NbrOfLaborNeeded ;
			}
			myShipBuilderBuilding.assignWork(gameManager,valeur);
		}

		// mise à jour de la valeur effective de la force de main d'oeuvre avec les choix de travailleurs
		myShipBuilderBuilding.TotalLaborValue = myShipBuilderBuilding.NbrOfAssignedVikingChosen * gameManager.Resources.People.Vikings.ShipConstructionEffeciency
						+ myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen * gameManager.Resources.People.ShieldMaidens.ShipConstructionEffeciency
						+ myShipBuilderBuilding.NbrOfAssignedSlaveChosen * gameManager.Resources.People.Slaves.ShipConstructionEffeciency;
	}


	
	public void setAllJobPanelInactive(){
		ship1Btn.SetActive(false);
		ship2Btn.SetActive(false);
		ship3Btn.SetActive(false);
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			foreach( ConstantsAndEnums.tagPanelJobs tagou in Enum.GetValues(typeof(ConstantsAndEnums.tagPanelJobs)))
				if ( go.tag.Equals(tagou.ToString())) go.SetActive(false);
		} ;
	}
}
