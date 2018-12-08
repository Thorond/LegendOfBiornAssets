using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City 
{

    private String nameOfCity;
    private int nbSoldats;
    private ConstantsAndEnums.dificultyInGame cityDificulty;
    private bool underAttack;

    private int approximatedTripAndBattleTime;
    private Loot loot;


    //Constructor
    public City(String name, int nbS, ConstantsAndEnums.dificultyInGame cityDif,int time, Loot l)
    {
        nameOfCity = name;
        nbSoldats = nbS;
        cityDificulty = cityDif;
        underAttack = false;
        approximatedTripAndBattleTime = time;
        loot = l;
    }

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

}
