using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle 
{
    // Constructor

    // public Battle(){
        
    // }
    public Battle(int vik,int sm,int ship, City city){
        this.nbrOfViking = vik;
        this.nbrOfShieldMaiden = sm;
        this.nbrOfShip = ship;
        this.city = city;
    }

    // Variables

    private int nbrOfViking;
    private int nbrOfShieldMaiden;
    private int nbrOfShip;
    private City city;

    // Getters and Setters

    public int NbrOfViking{get{return nbrOfViking;}}
    public int NbrOfShieldMaiden{get{return nbrOfShieldMaiden;}}
    public int NbrOfShip{get{return nbrOfShip;}}
}
