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


    public override void jobOrCitySettingCreation()
    {
        if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.LindisfarneBtn.ToString())
        {
            currentCity = worldCities.Lindisfarne;
            Debug.Log("Dans Lindisfarne");
            Debug.Log("Nom de la ville : " + worldCities.Lindisfarne.NameOfCity);
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.DublinBtn.ToString())
        {
            Debug.Log("Dans Dublin");
            currentCity = worldCities.Dublin;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.YorkBtn.ToString())
        {
            Debug.Log("Dans York");
            currentCity = worldCities.York;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.NovgorodBtn.ToString())
        {
            Debug.Log("Dans Novgorod");
            currentCity = worldCities.Novgorod;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.KiovBtn.ToString())
        {
            Debug.Log("Dans Kiov");
            currentCity = worldCities.Kiov;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.ConstantinopleBtn.ToString())
        {
            Debug.Log("Dans Constantinople");
            currentCity = worldCities.Constantinople;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.BagdadBtn.ToString())
        {
            Debug.Log("Dans Bagdad");
            currentCity = worldCities.Bagdad;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.ParisBtn.ToString())
        {
            Debug.Log("Dans Paris");
            currentCity = worldCities.Paris;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.BordeauxBtn.ToString())
        {
            Debug.Log("Dans Bordeaux");
            currentCity = worldCities.Bordeaux;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.LunaBtn.ToString())
        {
            Debug.Log("Dans Luna");
            currentCity = worldCities.Luna;
        }
        else if (jobsOrCityBtnPressed.tag == ConstantsAndEnums.tagBtnCity.LisbonneBtn.ToString())
        {
            Debug.Log("Dans Lisbonne");
            currentCity = worldCities.Lisbonne;
        }
    }

	
	public override void peopleAssignement( ){
		attackAssignement();
	}

	public void attackAssignement(){
		// attribution des vikings
		if (gameManager.Resources.People.NbrOfVikings > myExpedition.NbrOfAssignedVikingChosen ){
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upViking.ToString())  ){
				myExpedition.NbrOfAssignedVikingChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downViking.ToString()) ){
			if ( myExpedition.NbrOfAssignedVikingChosen > 0) myExpedition.NbrOfAssignedVikingChosen -= 1;
		}
		// attribution des shieldmaidens
		if (gameManager.Resources.People.NbrOfShieldMaidens > myExpedition.NbrOfAssignedShieldMaidenChosen ){
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upShieldMaiden.ToString())  ){
				myExpedition.NbrOfAssignedShieldMaidenChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downShieldMaiden.ToString()) ){
			if ( myExpedition.NbrOfAssignedShieldMaidenChosen > 0) myExpedition.NbrOfAssignedShieldMaidenChosen -= 1;
		}
		// attribution des navires
		// !!!!! différencier en fonctiond u type 
		if (gameManager.Resources.Ships.NbrOfShipType1 > myExpedition.NbrOfAssignedShipChosen ){
			if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.upShip.ToString()) ){
				myExpedition.NbrOfAssignedShipChosen += 1;
			}
		} 
		if (upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagUpOrDown.downShip.ToString()) ){
			if ( myExpedition.NbrOfAssignedShipChosen > 0) myExpedition.NbrOfAssignedShipChosen -= 1;
		} 

		// application des travailleurs pour les trois types de navires
		// if ( upOrDownBtnPressed.tag.Equals(ConstantsAndEnums.tagPanelJobs.applyBtn.ToString()) ){
		// 	int valeur = gameManager.Resources.Ships.ShipType1.NbrOfLaborNeeded ;
		// 	if (myShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type2){
		// 		//valeur = gameManager.Resources.Ships.ShipType2.NbrOfLaborNeeded ;
		// 	} else if (myShipBuilderBuilding.TypeOfShipConstruct == ConstantsAndEnums.shipType.type3){
		// 		//valeur = gameManager.Resources.Ships.ShipType3.NbrOfLaborNeeded ;
		// 	}
		// 	myShipBuilderBuilding.assignWork(gameManager,valeur);
		// }

		// mise à jour de la valeur effective de la force de main d'oeuvre avec les choix de travailleurs
		// myShipBuilderBuilding.TotalLaborValue = myShipBuilderBuilding.NbrOfAssignedVikingChosen * gameManager.Resources.People.Vikings.ShipConstructionEffeciency
		// 				+ myShipBuilderBuilding.NbrOfAssignedShieldMaidenChosen * gameManager.Resources.People.ShieldMaidens.ShipConstructionEffeciency
		// 				+ myShipBuilderBuilding.NbrOfAssignedSlaveChosen * gameManager.Resources.People.Slaves.ShipConstructionEffeciency;
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
