﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City 
{

    //Constructor
    public City(String name, int nbS, ConstantsAndEnums.dificultyInGame cityDif,int time, Loot l)
    {
        nameOfCity = name;
        nbSoldats = nbS;
        cityDificulty = cityDif;
        underAttack = false;
        approximatedTripAndBattleTime = time;
        loot = l;
        openToAttack = true;
        nbrOfDayUntillAvailable = 0;
    }

    // Variables  

    private String nameOfCity;
    private int nbSoldats;
    private ConstantsAndEnums.dificultyInGame cityDificulty;
    private bool underAttack;
    private int approximatedTripAndBattleTime;
    private Loot loot;

    private bool openToAttack;
    private int nbrOfDayUntillAvailable;



    //Getters and Setters
    public String NameOfCity
    {
        get
        {
            return nameOfCity;
        }
        set
        {
            nameOfCity = value;
        }
    }

    public int NbSoldats
    {
        get
        {
            return nbSoldats;
        }
        set
        {
            nbSoldats = value;
        }
    }

    public ConstantsAndEnums.dificultyInGame DificultyCity
    {
        get
        {
            return cityDificulty;
        }
        set
        {
            cityDificulty = value;
        }
    }

    public bool UnderAttack{get{return underAttack;}set{underAttack = value;}}
    public int ApproximatedTripAndBattleTime{get{return approximatedTripAndBattleTime;}set{approximatedTripAndBattleTime = value;}}
    public Loot LootDetail
    {
        get
        {
            return loot;
        }
        set
        {
            loot = value;
        }
    }
    public bool OpenToAttack{get{return openToAttack;}set{openToAttack = value;}}
    public int NbrOfDayUntillAvailable{get{return nbrOfDayUntillAvailable;}set{nbrOfDayUntillAvailable = value;}}


    // Functions 

    
	public void updateCity(int timeE){
		if ( ! openToAttack ) {
            if ( nbrOfDayUntillAvailable > 0 ){
				nbrOfDayUntillAvailable -= timeE;
			}
			if ( nbrOfDayUntillAvailable <= 0 ){
				
				openToAttack = true;
			} 
		} 
	}


}
