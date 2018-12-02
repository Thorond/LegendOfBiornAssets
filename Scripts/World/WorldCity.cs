using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldCity : MonoBehaviour
{

    //City[] cities = new City[20];
    // private List<City> cities = new List<City>();

    private City Lindisfarne = new City("Lindisfarne", 20, City.dificultyInGame.easy, new Loot(100, 100, 100, 4));
    private City Dublin = new City("Dublin", 40, City.dificultyInGame.easy, new Loot(150, 50, 120, 2));
    private City York = new City("York", 5, City.dificultyInGame.easy, new Loot(50, 130, 80, 6));
    private City Novgorod = new City("Novgorod", 70, City.dificultyInGame.easy, new Loot(160, 40, 90, 5));
    private City Kiov = new City("Kiov", 10, City.dificultyInGame.easy, new Loot(60, 150, 150, 4));
    private City Constantinople = new City("Constantinople", 15, City.dificultyInGame.easy, new Loot(120, 120, 120, 3));
    private City Bagdad = new City("Bagdad", 30, City.dificultyInGame.easy, new Loot(40, 50, 200, 7));
    private City Paris = new City("Paris", 65, City.dificultyInGame.easy, new Loot(200, 50, 100, 5));
    private City Bordeaux = new City("Bordeaux", 50, City.dificultyInGame.easy, new Loot(160, 70, 100, 3));
    private City Luna = new City("Luna", 25, City.dificultyInGame.easy, new Loot(80, 120, 110, 4));
    private City Lisbonne = new City("Lisbonne", 55, City.dificultyInGame.easy, new Loot(180, 90, 90, 6));

    [SerializeField]
    GameObject panelDetails;
    [SerializeField]
    GameObject panelMap;
    //public GameObject btnPressed;

    [SerializeField]
    private Text cityName;
    [SerializeField]
    private Text nbSoldats;
    [SerializeField]
    private Text dificulty;
    [SerializeField]
    private Text gold;
    [SerializeField]
    private Text wood;
    [SerializeField]
    private Text iron;
    [SerializeField]
    private Text slaves;

    enum tagBtn
    {
        LindisfarneBtn,
        DublinBtn,
        YorkBtn,
        NovgorodBtn,
        KiovBtn,
        ConstantinopleBtn,
        BagdadBtn,
        ParisBtn,
        BordeauxBtn,
        LunaBtn,
        LisbonneBtn
    }

    City currentCity;

    public void SelectedCity(GameObject btnPressed)
    {
        if (btnPressed.tag == tagBtn.LindisfarneBtn.ToString())
        {
            currentCity = Lindisfarne;
            Debug.Log("Dans Lindisfarne");
            Debug.Log("Nom de la ville : " + Lindisfarne.NameOfCity);
        }
        else if (btnPressed.tag == tagBtn.DublinBtn.ToString())
        {
            Debug.Log("Dans Dublin");
            currentCity = Dublin;
        }
        else if (btnPressed.tag == tagBtn.YorkBtn.ToString())
        {
            Debug.Log("Dans York");
            currentCity = York;
        }
        else if (btnPressed.tag == tagBtn.NovgorodBtn.ToString())
        {
            Debug.Log("Dans Novgorod");
            currentCity = Novgorod;
        }
        else if (btnPressed.tag == tagBtn.KiovBtn.ToString())
        {
            Debug.Log("Dans Kiov");
            currentCity = Kiov;
        }
        else if (btnPressed.tag == tagBtn.ConstantinopleBtn.ToString())
        {
            Debug.Log("Dans Constantinople");
            currentCity = Constantinople;
        }
        else if (btnPressed.tag == tagBtn.BagdadBtn.ToString())
        {
            Debug.Log("Dans Bagdad");
            currentCity = Bagdad;
        }
        else if (btnPressed.tag == tagBtn.ParisBtn.ToString())
        {
            Debug.Log("Dans Paris");
            currentCity = Paris;
        }
        else if (btnPressed.tag == tagBtn.BordeauxBtn.ToString())
        {
            Debug.Log("Dans Bordeaux");
            currentCity = Bordeaux;
        }
        else if (btnPressed.tag == tagBtn.LunaBtn.ToString())
        {
            Debug.Log("Dans Luna");
            currentCity = Luna;
        }
        else if (btnPressed.tag == tagBtn.LisbonneBtn.ToString())
        {
            Debug.Log("Dans Lisbonne");
            currentCity = Lisbonne;
        }
    }

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
        panelMap.SetActive(false);
        GameObject btnToActivate = JobsManager.findGameObject(ConstantsAndEnums.tagPanel.ourCityPanel.ToString()); 
		if (btnToActivate) btnToActivate.SetActive(true); // Afficher le panel de la chasse
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
