using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle 
{
    // Constructor

    // public Battle(){
        
    // }
    public Battle(int vik,int sm,int ship){
        this.nbrOfViking = vik;
        this.nbrOfShieldMaiden = sm;
        this.nbrOfShip = ship;
    }

    // Variables

    private int nbrOfViking;
    private int nbrOfShieldMaiden;
    private int nbrOfShip;

    // Getters and Setters

    public int NbrOfViking{get{return nbrOfViking;}}
    public int NbrOfShieldMaiden{get{return nbrOfShieldMaiden;}}
    public int NbrOfShip{get{return nbrOfShip;}}
}
