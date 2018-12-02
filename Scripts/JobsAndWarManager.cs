using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class JobsAndWarManager : Singleton<JobsAndWarManager> {


	// Constructor 
	public JobsAndWarManager() {
	}

	// Variables
	[SerializeField] protected GameManager gameManager;
    [SerializeField] protected GameObject panelCity;
    [SerializeField] protected GameObject panelMap;

	[SerializeField] protected GameObject ship1Btn;
	[SerializeField] protected GameObject ship2Btn;
	[SerializeField] protected GameObject ship3Btn;
	protected Btn jobsOrCityBtnPressed;
	protected Btn upOrDownBtnPressed;
	protected Btn whichShipSelected;
	

	// Getters and Setters
	public Btn JobsOrCityBtnPressed{get{return jobsOrCityBtnPressed;}}
	public Btn UpOrDownBtnPressed{get{return upOrDownBtnPressed;}}
	public Btn WhichShipSelected{get{return whichShipSelected;}}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Functions 
	public void selectedJobOrCity(Btn jobSelected){
		jobsOrCityBtnPressed = jobSelected;
	}
	public void selectedUpOrDown(Btn btnSelected){
		upOrDownBtnPressed = btnSelected;
	}
	public virtual void selectedShipType(Btn btnSelected){
		whichShipSelected = btnSelected;
	}

	public abstract void jobOrCitySettingCreation();

	public abstract void peopleAssignement( );



	// Static functions 
	
	
	public static GameObject findGameObject(string tagou){
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			if ( go.tag.Equals(tagou)) return go;
		} ;
		return null;
	}
}
