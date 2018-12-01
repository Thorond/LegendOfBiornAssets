using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	// Variables
	private Resource resources;

	// Getters and Setters


	public Resource Resources{
		get{
			return resources;
		}
	}
	

	// Use this for initialization
	void Start () {
		resources = new Resource();

		Debug.Log("Jeu lancé.");
	}
	
	// Update is called once per frame
	void Update () {
	}


	// Functions 
	

	
}
