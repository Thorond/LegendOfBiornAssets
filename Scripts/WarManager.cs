using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarManager : JobsAndWarManager {
	
	// Constructor 
	public WarManager() : base() {
		worldCities = new WorldCity();
		myExpedition = new Expedition();
	}

	// Variables

	
    [SerializeField] GameObject panelDetails;
	private WorldCity worldCities;
	private City currentCity;
	private Expedition myExpedition;

	
    [SerializeField] private Text cityName;
    [SerializeField] private Text nbSoldats;
    [SerializeField] private Text dificulty;
    [SerializeField] private Text gold;
    [SerializeField] private Text wood;
    [SerializeField] private Text iron;
    [SerializeField] private Text slaves;

	// Getters and Setters

	public Expedition MyExpedition { get{return myExpedition;}}

	
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
		} else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship2Btn.ToString()){
			myExpedition.TypeOfShipSelected = ConstantsAndEnums.shipType.type2;
		} else if (whichShipSelected.tag == ConstantsAndEnums.tagShipType.ship3Btn.ToString()){
			myExpedition.TypeOfShipSelected = ConstantsAndEnums.shipType.type3;
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
			myExpedition.assignWork(gameManager);
		}


		myExpedition.nbrOfSpacesAvailableCalculation(gameManager);
		myExpedition.totalForceValueCalculation(gameManager);
	}

    // a mettre dans text Manager
	// *****
    public void CityDetailsCreation()
    {
        cityName.text = currentCity.NameOfCity;
        nbSoldats.text = currentCity.NbSoldats.ToString();
        dificulty.text = currentCity.DificultyCity.ToString();
        gold.text = currentCity.LootDetail.Gold.ToString();
        wood.text = currentCity.LootDetail.Wood.ToString();
        iron.text = currentCity.LootDetail.Iron.ToString();
        slaves.text = currentCity.LootDetail.Slaves.ToString();
    }
	// *****

    public void AfficherDetails()
    {
        panelDetails.SetActive(true);
    }

    public void RetourMap()
    {
        panelDetails.SetActive(false);
    }

    public void BackAccueil()
    {
        panelCity.SetActive(true);
		panelMap.SetActive(false);
    }


}
