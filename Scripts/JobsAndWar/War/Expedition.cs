using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expedition {
    // Constructor

    // public Expedition(){
        
    // }
    public Expedition(int vik,int sm,int ship, City city, ConstantsAndEnums.possibleAttacks attackChosen){
		this.battleInProgress = true;
        this.nbrOfViking = vik;
        this.nbrOfShieldMaiden = sm;
        this.nbrOfShip = ship;
        this.city = city;
        this.attackChosen = attackChosen;
        this.durationOfMission = city.ApproximatedTripAndBattleTime;
    }

    // Variables

	private bool battleInProgress;
    private int nbrOfViking;
    private int nbrOfShieldMaiden;
    private int nbrOfShip;
    private City city;
    private ConstantsAndEnums.possibleAttacks attackChosen;

    private int durationOfMission;

    // Getters and Setters

    public bool BattleInProgress{get{return battleInProgress;}set{battleInProgress = value;}}
    public int NbrOfViking{get{return nbrOfViking;}set{nbrOfViking = value;}}
    public int NbrOfShieldMaiden{get{return nbrOfShieldMaiden;}set{nbrOfShieldMaiden = value;}}
    public int NbrOfShip{get{return nbrOfShip;}}
    public City City{get{return city;}}
    public ConstantsAndEnums.possibleAttacks AttackChosen{get{return attackChosen;}}
    public int DurationOfMission{get{return durationOfMission;}set{durationOfMission = value;}}

    // Functions

    
	public void missionUpdate(int timeE){
		if ( battleInProgress ) {
            if ( durationOfMission > 0 ){
				durationOfMission -= timeE;
			}
			if ( durationOfMission <= 0 ){
				// dérouler la bataille, appeler battle
                Battle.battleCourse(this);
				
				battleInProgress = false;
			} 
		} 
	}
}
