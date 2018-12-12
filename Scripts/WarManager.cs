using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarManager : JobsAndWarManager {
	
	// Constructor 
	public WarManager() : base() {
		worldCities = new WorldCity();
		myExpedition = new ExpeditionManager();
	}

	// Variables

	
    [SerializeField] GameObject panelDetails;
    [SerializeField] GameObject battlesPanel;
    [SerializeField] protected GameObject reportPanel;
    [SerializeField] Btn exploreBtn;
    [SerializeField] Btn plunderBtn;
    [SerializeField] Btn razeBtn;
	private WorldCity worldCities;
	private City currentCity;
	private ExpeditionManager myExpedition;
	private Btn whichAttackSelected;

	private int battleDisplayChosen = 0;

	
	// Getters and Setters

	public WorldCity WorldCities{get{return worldCities;}}
	public ExpeditionManager MyExpedition { get{return myExpedition;}}
	public City CurrentCity { get{return currentCity;}}
	public int BattleDisplayChosen { get{return battleDisplayChosen;}}

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Functions

	public override void selectedShipType(Btn btnSelected){
		whichShipSelected = btnSelected;
		if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship1Btn.ToString()){
			myExpedition.TypeOfShipSelected = ConstantsAndEnums.shipType.type1;
		} 
		// else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship2Btn.ToString()){
		// 	myExpedition.TypeOfShipSelected = ConstantsAndEnums.shipType.type2;
		// } else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship3Btn.ToString()){
		// 	myExpedition.TypeOfShipSelected = ConstantsAndEnums.shipType.type3;
		// } 
	}

	public void selectedTypeOfAttack(Btn btnSelected){
		whichAttackSelected = btnSelected;
		if (whichAttackSelected.tag == ConstantsAndEnums.possibleAttacks.explore.ToString()){
			myExpedition.TypeOfAttackSelected = ConstantsAndEnums.possibleAttacks.explore;
		} else if (whichAttackSelected.tag == ConstantsAndEnums.possibleAttacks.plunder.ToString()){
			myExpedition.TypeOfAttackSelected = ConstantsAndEnums.possibleAttacks.plunder;
		} else if (whichAttackSelected.tag == ConstantsAndEnums.possibleAttacks.raze.ToString()){
			myExpedition.TypeOfAttackSelected = ConstantsAndEnums.possibleAttacks.raze;
		} 
		highlightAttackBtnSelected();
	}

	void highlightAttackBtnSelected(){
		if ( myExpedition.TypeOfAttackSelected == ConstantsAndEnums.possibleAttacks.explore ){
			exploreBtn.GetComponent<Image>().color = new Color(255,255,255,255) ;
			plunderBtn.GetComponent<Image>().color = new Color(0,0,0,255) ;
			razeBtn.GetComponent<Image>().color = new Color(0,0,0,255) ;
		} else if ( myExpedition.TypeOfAttackSelected == ConstantsAndEnums.possibleAttacks.plunder ){
			exploreBtn.GetComponent<Image>().color = new Color(0,0,0,255) ;
			plunderBtn.GetComponent<Image>().color = new Color(255,255,255,255) ;
			razeBtn.GetComponent<Image>().color = new Color(0,0,0,255) ;
		} else if ( myExpedition.TypeOfAttackSelected == ConstantsAndEnums.possibleAttacks.raze ){
			exploreBtn.GetComponent<Image>().color = new Color(0,0,0,255) ;
			plunderBtn.GetComponent<Image>().color = new Color(0,0,0,255) ;
			razeBtn.GetComponent<Image>().color = new Color(255,255,255,255) ;
		}
	}

    public override void jobOrCitySettingCreation()
    {
        if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.LindisfarneBtn.ToString())
        {

            currentCity = worldCities.Lindisfarne;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.DublinBtn.ToString())
        {
            currentCity = worldCities.Dublin;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.YorkBtn.ToString())
        {
            currentCity = worldCities.York;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.NovgorodBtn.ToString())
        {
            currentCity = worldCities.Novgorod;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.KiovBtn.ToString())
        {
            currentCity = worldCities.Kiov;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.ConstantinopleBtn.ToString())
        {
            currentCity = worldCities.Constantinople;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.BagdadBtn.ToString())
        {
            currentCity = worldCities.Bagdad;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.ParisBtn.ToString())
        {
            currentCity = worldCities.Paris;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.BordeauxBtn.ToString())
        {
            currentCity = worldCities.Bordeaux;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.LunaBtn.ToString())
        {
            currentCity = worldCities.Luna;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.LisbonneBtn.ToString())
        {
            currentCity = worldCities.Lisbonne;
        }

    }

	public override void peopleAssignement( ){
		attackAssignement();
	}

	public void attackAssignement(){
		// attribution des vikings
		if (gameManager.Resources.People.NbrOfVikings > myExpedition.NbrOfAssignedVikingChosen && myExpedition.NbrOfSpacesAvailable > 0 ){
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upViking.ToString())  ){
				myExpedition.NbrOfAssignedVikingChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downViking.ToString()) ){
			if ( myExpedition.NbrOfAssignedVikingChosen > 0) myExpedition.NbrOfAssignedVikingChosen -= 1;
		}
		// attribution des shieldmaidens
		if (gameManager.Resources.People.NbrOfShieldMaidens > myExpedition.NbrOfAssignedShieldMaidenChosen && myExpedition.NbrOfSpacesAvailable > 0 ){
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upShieldMaiden.ToString())  ){
				myExpedition.NbrOfAssignedShieldMaidenChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downShieldMaiden.ToString()) ){
			if ( myExpedition.NbrOfAssignedShieldMaidenChosen > 0) myExpedition.NbrOfAssignedShieldMaidenChosen -= 1;
		}
		// attribution des navires
		// !!!!! différencier en fonctiond du type 
		if (gameManager.Resources.Ships.NbrOfShipType1 > myExpedition.NbrOfAssignedShipChosen ){
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upShip.ToString()) ){
				myExpedition.NbrOfAssignedShipChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downShip.ToString()) ){
			if ( myExpedition.NbrOfAssignedShipChosen > 0 
				&& (myExpedition.NbrOfAssignedShieldMaidenChosen+myExpedition.NbrOfAssignedVikingChosen) // a faire pour les dfft types
				    <= myExpedition.NbrOfAssignedShipChosen * gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen - gameManager.Resources.Ships.ShipType1.TotalCapacityOfMen) 
					myExpedition.NbrOfAssignedShipChosen -= 1;
		} 

		// application des travailleurs pour les trois types de navires
		if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagShipType.applyBtn.ToString()) ){
			myExpedition.assignWork(gameManager,textManager, currentCity);
		}

		myExpedition.nbrOfFoodNeedCalcultation(gameManager,currentCity);
		myExpedition.nbrOfSpacesAvailableCalculation(gameManager);
		myExpedition.totalForceValueCalculation(gameManager);
	}

    public void AfficherDetails()
    {
		if ( ! currentCity.OpenToAttack ){
			textManager.errorTextDisplay("The city is not open to battle - at least not untill " + currentCity.NbrOfDayUntillAvailable + " days !");
		} else {
        	panelDetails.SetActive(true);
		}
    }

    public void RetourMap()
    {
        panelDetails.SetActive(false);
    }

    public void BackAccueil()
    {
        panelCity.SetActive(true);
		panelMap.SetActive(false);
		battlesPanel.SetActive(false);
    }

	public void BattleBtnFunction(){
        panelCity.SetActive(true);
		panelMap.SetActive(false);
        panelDetails.SetActive(false);
		battlesPanel.SetActive(true);
	}

	
	public void openDetailPanel(Btn btn){

		if ( btn.tag == ConstantsAndEnums.battleDisplayBtn.battleDisplay1.ToString() ) battleDisplayChosen = 1;
		else if ( btn.tag == ConstantsAndEnums.battleDisplayBtn.battleDisplay2.ToString() ) battleDisplayChosen = 2;
		else if ( btn.tag == ConstantsAndEnums.battleDisplayBtn.battleDisplay3.ToString() ) battleDisplayChosen = 3;
		else if ( btn.tag == ConstantsAndEnums.battleDisplayBtn.battleDisplay4.ToString() ) battleDisplayChosen = 4;
		else if ( btn.tag == ConstantsAndEnums.battleDisplayBtn.battleDisplay5.ToString() ) battleDisplayChosen = 5;
		
		Expedition currentExpedition = myExpedition.Expeditions[battleDisplayChosen -1];
		if ( currentExpedition != null ){
			if (  currentExpedition.ExpeditionStatus != ConstantsAndEnums.expeditionStatus.over){
				
				reportPanel.SetActive(true);
			} else {
				battleDisplayChosen = 0;
			}
		} else {
			battleDisplayChosen = 0;
		}	
	}
	
	public void returningFromExpedition(){
		
		Expedition currentExpedition = myExpedition.Expeditions[battleDisplayChosen -1];
		if ( currentExpedition != null ){
			if (  currentExpedition.ExpeditionStatus == ConstantsAndEnums.expeditionStatus.inMovement 
					&& currentExpedition.BattleStatus != ConstantsAndEnums.battleStatus.returning ){
				
				currentExpedition.BattleStatus = ConstantsAndEnums.battleStatus.returning;
				currentExpedition.DurationOfMission = currentExpedition.City.ApproximatedTripAndBattleTime - currentExpedition.DurationOfMission;
			}
		}
	}

	public void backBattlesBoard(){
		reportPanel.SetActive(false);
		Expedition expeTemp = myExpedition.Expeditions[battleDisplayChosen -1];
		if ( expeTemp.ExpeditionStatus == ConstantsAndEnums.expeditionStatus.battleOver){
			myExpedition.closeExpedition(gameManager,expeTemp);
		}
	}


}
