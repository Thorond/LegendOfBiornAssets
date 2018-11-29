using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobsManager : Singleton<JobsManager> {

	// Variables
	private Btn jobsBtnPressed;
	private Btn upOrDownBtnPressed;
	private Btn woodOrIronBtnPressed;

	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;
	private MineralGathering myMineralBuilding;
	private WoodGathering myWoodBuilding;

	
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Text displayOfNbrOfHunter;
	[SerializeField] private Text displayOfNbrOfFisherMen;
	[SerializeField] private Text displayOfNbrOfShipBuilder;
	[SerializeField] private Text displayOfNbrOfShip;
	[SerializeField] private Text displayOfWoodWorkers;
	[SerializeField] private Text displayOfIronWorkers;
	[SerializeField] private Text displayOfEfficiencyOfAViking;
	[SerializeField] private Text displayOfEfficiencyOfAShieldMaiden;
	[SerializeField] private Text displayOfEfficiencyOfASlave;

	private enum tagBtnJob{
		huntingBtn,
		fishingBtn,
		shipBuilderBtn,
		rawMaterialBtn
	}
	private enum tagPanel{
		jobPanel,
		woodBtn,
		ironBtn,
		applyBtn
	}

	private enum tagUpOrDown{
		upViking,
		downViking,
		upShieldMaiden,
		downShieldMaiden,
		upSlave,
		downSlave
	}

	// Getters and Setters

	public Hunting MyHuntingBuilding { get{return myHuntingBuilding;}}
	public Fishing MyFishingBuilding { get{return myFishingBuilding;}}
	public ShipBuilder MyShipBuilderBuilding { get{return myShipBuilderBuilding;}}
	public MineralGathering MyMineralBuilding { get{return myMineralBuilding;}}
	public WoodGathering MyWoodBuilding { get{return myWoodBuilding;}}


	// Use this for initialization
	void Start () {

		myHuntingBuilding = new Hunting();
		myFishingBuilding = new Fishing();
		myShipBuilderBuilding = new ShipBuilder();
		myMineralBuilding = new MineralGathering();
		myWoodBuilding = new WoodGathering();

		textDisplay();

		setAllJobPanelInactive();
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
	}


	// Functions 
	public void selectedJob(Btn jobSelected){
		jobsBtnPressed = jobSelected;
	}
	public void selectedUpOrDown(Btn btnSelected){
		upOrDownBtnPressed = btnSelected;
	}
	public void selectedWoodOrIron(Btn btnSelected){
		woodOrIronBtnPressed = btnSelected;
	}

	public void jobSettingCreation(){
		
		setAllJobPanelInactive();
		myShipBuilderBuilding.closeAssignment();
		if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString() || jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString()
			|| jobsBtnPressed.tag == tagBtnJob.shipBuilderBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagPanel.jobPanel.ToString()); 
			if (btnToActivate) btnToActivate.SetActive(true); // Afficher le panel de la chasse
			if (jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString()){ // afficher le panel du travail des matières premières
				btnToActivate = findGameObject(tagPanel.woodBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
				btnToActivate = findGameObject(tagPanel.ironBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
			}
			if (jobsBtnPressed.tag == tagBtnJob.shipBuilderBtn.ToString()){ // Afficher le panel de la construction de navires
				btnToActivate = findGameObject(tagPanel.applyBtn.ToString()); 
				if (btnToActivate) btnToActivate.SetActive(true);
			}
		}

	}

	public void peopleAssignement( ){
		huntingAssignement();
		rawMaterialAssignement();
		shipBuildingAssignement();
	}

	public void jobAssignement(Jobs myJobBuilding){
		if ( upOrDownBtnPressed.tag == tagUpOrDown.upSlave.ToString() && gameManager.Resources.People.NbrOfSlave > 0 ){
			myJobBuilding.assignAnotherSlave();
			gameManager.Resources.People.NbrOfSlave -= 1;
		}
		else if ( upOrDownBtnPressed.tag == tagUpOrDown.downSlave.ToString() && myJobBuilding.NbrOfSlaveAssigned > 0 ){
			myJobBuilding.removeASlave();
			gameManager.Resources.People.NbrOfSlave += 1;
		} else if ( upOrDownBtnPressed.tag == tagUpOrDown.upViking.ToString() && gameManager.Resources.People.NbrOfVikings > 0 ){
			myJobBuilding.assignAnotherViking();
			gameManager.Resources.People.NbrOfVikings -= 1;
		}
		else if ( upOrDownBtnPressed.tag == tagUpOrDown.downViking.ToString() && myJobBuilding.NbrOfVikingAssigned > 0 ){
			myJobBuilding.removeAViking();
			gameManager.Resources.People.NbrOfVikings += 1;
		} else if ( upOrDownBtnPressed.tag == tagUpOrDown.upShieldMaiden.ToString() && gameManager.Resources.People.NbrOfShieldMaidens > 0 ){
			myJobBuilding.assignAnotherShieldMaiden();
			gameManager.Resources.People.NbrOfShieldMaidens -= 1;
		}
		else if ( upOrDownBtnPressed.tag == tagUpOrDown.downShieldMaiden.ToString() && myJobBuilding.NbrOfShieldMaidenAssigned > 0 ){
			myJobBuilding.removeAShieldMaiden();
			gameManager.Resources.People.NbrOfShieldMaidens += 1;
		}
		
	}

	public void huntingAssignement(){
		if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString() ){
			jobAssignement(myHuntingBuilding);
		}
	}

	public void rawMaterialAssignement(){
		if ( jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString() ){
			if (woodOrIronBtnPressed){
				if ( woodOrIronBtnPressed.tag == tagPanel.woodBtn.ToString()){
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
			if ( upOrDownBtnPressed.tag.Equals(tagUpOrDown.upViking.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
				myShipBuilderBuilding.NbrOfAssignedVikingChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(tagUpOrDown.downViking.ToString()) && !myShipBuilderBuilding.WorkInProgress){
			if ( myShipBuilderBuilding.NbrOfAssignedVikingChosen > 0) myShipBuilderBuilding.NbrOfAssignedVikingChosen -= 1;
		}
		// attribution des shieldmaidens
		if (gameManager.Resources.People.NbrOfShieldMaidens > myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen ){
			if ( upOrDownBtnPressed.tag.Equals(tagUpOrDown.upShieldMaiden.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
				myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(tagUpOrDown.downShieldMaiden.ToString()) && !myShipBuilderBuilding.WorkInProgress){
			if ( myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen > 0) myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen -= 1;
		}
		// attribution des esclaves
		if (gameManager.Resources.People.NbrOfSlave > myShipBuilderBuilding.NbrOfAssignedSlaveChosen ){
			if ( upOrDownBtnPressed.tag.Equals(tagUpOrDown.upSlave.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
				myShipBuilderBuilding.NbrOfAssignedSlaveChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(tagUpOrDown.downSlave.ToString()) && !myShipBuilderBuilding.WorkInProgress){
			if ( myShipBuilderBuilding.NbrOfAssignedSlaveChosen > 0) myShipBuilderBuilding.NbrOfAssignedSlaveChosen -= 1;
		} 
		// application pour les troics types
		if ( upOrDownBtnPressed.tag.Equals(tagPanel.applyBtn.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
			myShipBuilderBuilding.assignWork(gameManager);
		}
	}

	public void textDisplay(){
		displayOfNbrOfHunter.text = "Hunting : \n" + myHuntingBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + myHuntingBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + myHuntingBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfFisherMen.text = "Fishing : \n" + myFishingBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + myFishingBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + myFishingBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfShipBuilder.text = "Ships Workers : \n" + myShipBuilderBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + myShipBuilderBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + myShipBuilderBuilding.NbrOfSlaveAssigned.ToString();
		displayOfWoodWorkers.text = "Wood Workers : \n" + myWoodBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + myWoodBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + myWoodBuilding.NbrOfSlaveAssigned.ToString();
		displayOfIronWorkers.text = "Iron Workers : \n" + myMineralBuilding.NbrOfVikingAssigned.ToString()
				+ "\n"  + myMineralBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n"  + myMineralBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfShip.text = "Ships  \n Type 1 : " + gameManager.Resources.Ships.NbrOfShipType1.ToString();


		// Affichage de l'efficacité de chaque personnes (Viking ou ShieldMaiden ou Slave) en fonction du travail demandé
		if (jobsBtnPressed){
			if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString()  ){
				displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.FoodGatheringEfficiency.ToString();
				displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.FoodGatheringEfficiency.ToString();
				displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.FoodGatheringEfficiency.ToString();
			}

			else if ( jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString()  ){
				if (woodOrIronBtnPressed){
					if (woodOrIronBtnPressed.tag == tagPanel.ironBtn.ToString()){
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
			
			// on met à profit ces variables pour compter le nombre de travailleurs que le joueur veut mettre dans la construction du navire
			else if (jobsBtnPressed.tag == tagBtnJob.shipBuilderBtn.ToString()){
				displayOfEfficiencyOfAViking.text = myShipBuilderBuilding.NbrOfAssignedVikingChosen.ToString();
				displayOfEfficiencyOfAShieldMaiden.text = myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen.ToString();
				displayOfEfficiencyOfASlave.text = myShipBuilderBuilding.NbrOfAssignedSlaveChosen.ToString();
			}
			
		} else{
			displayOfEfficiencyOfAViking.text = "";
			displayOfEfficiencyOfAShieldMaiden.text = "";
			displayOfEfficiencyOfASlave.text = "";
		}
	}

	public void setAllJobPanelInactive(){
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			foreach( tagPanel tagou in Enum.GetValues(typeof(tagPanel)))
				if ( go.tag.Equals(tagou.ToString())) go.SetActive(false);
		} ;
	}
	public GameObject findGameObject(string tagou){
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			if ( go.tag.Equals(tagou)) return go;
		} ;
		return null;
	}
	
}
