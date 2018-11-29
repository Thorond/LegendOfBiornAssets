using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City 
{

    private String nameOfCity;
    private int nbSoldats;
    private dificultyInGame cityDificulty;
    private Loot loot;

    public enum dificultyInGame
    {
        easy,
        medium,
        hard
    }

    //Constructor
    public City(String name, int nbS, dificultyInGame cityDif, Loot l)
    {
        nameOfCity = name;
        nbSoldats = nbS;
        cityDificulty = cityDif;
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

    public dificultyInGame DificultyCity
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
