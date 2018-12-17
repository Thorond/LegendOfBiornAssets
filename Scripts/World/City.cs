using System;
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

    
    public void upgradeCity(){
        if ( this.DificultyCity == ConstantsAndEnums.dificultyInGame.easy && UnityEngine.Random.Range(0,100) < 50 ){
            this.DificultyCity = ConstantsAndEnums.dificultyInGame.medium;
        }
        if ( this.DificultyCity == ConstantsAndEnums.dificultyInGame.medium &&  UnityEngine.Random.Range(0,100) < 20 ){
            this.DificultyCity = ConstantsAndEnums.dificultyInGame.hard;
        }

        if ( UnityEngine.Random.Range(0,100) < 70 ){
            increaseProporties(20f/100f);
        } else if ( UnityEngine.Random.Range(0,100) < 90 ){
            increaseProporties(25f/100f);
        } else {
            increaseProporties(30f/100f);
        }
    }
    void increaseProporties(float increaseRate){
        this.NbSoldats = this.NbSoldats + (int) (this.NbSoldats * increaseRate);
        this.loot.Gold = this.loot.Gold + (int) (this.loot.Gold * increaseRate);
        this.loot.Wood = this.loot.Wood + (int) (this.loot.Wood * increaseRate);
        this.loot.Iron = this.loot.Iron + (int) (this.loot.Iron * increaseRate);
        this.loot.Slaves = this.loot.Slaves + (int) (this.loot.Slaves * increaseRate);
    }


	public void updateCity(){
		if ( ! openToAttack ) {
            if ( nbrOfDayUntillAvailable > 0 ){
				nbrOfDayUntillAvailable -= 1;
			}
			if ( nbrOfDayUntillAvailable <= 0 ){
				
				openToAttack = true;
			} 
		} 
	}


}
