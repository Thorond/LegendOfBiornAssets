using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	// Variables
	private Resource resources;

	[SerializeField] private Text nameOfPeople;
	[SerializeField] private Text displayOfNbrOfPeople;
	[SerializeField] private Text displayOfResources;

	// Getters and Setters


	public Resource Resources{
		get{
			return resources;
		}
	}
	

	// Use this for initialization
	void Start () {
		resources = new Resource();

		textDisplay();
		Debug.Log("Jeu lancé.");
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
	}


	// Functions 
	
	void textDisplay(){
		nameOfPeople.text = resources.People.nameOfPeopleDisplay();
		displayOfNbrOfPeople.text = resources.People.textDisplay();
		displayOfResources.text = resources.textDisplay();
	}

	
}
