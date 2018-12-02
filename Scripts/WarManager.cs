using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarManager : JobsAndWarManager {
	
	// Constructor 
	public WarManager() : base() {
		// mettre les villes ici?
		worldCities = new WorldCity();
	}

	// Variables

	
    [SerializeField] GameObject panelDetails;

	private WorldCity worldCities;

	private City currentCity;

	
    [SerializeField] private Text cityName;
    [SerializeField] private Text nbSoldats;
    [SerializeField] private Text dificulty;
    [SerializeField] private Text gold;
    [SerializeField] private Text wood;
    [SerializeField] private Text iron;
    [SerializeField] private Text slaves;
	
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
	}

    // a mettre dans text Manager
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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
