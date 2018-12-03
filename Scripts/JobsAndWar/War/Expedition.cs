using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expedition {
    // Constructor

    // public Expedition(){
        
    // }
    public Expedition(int vik,int sm,int ship, City city){
		this.battleInProgress = true;
        this.nbrOfViking = vik;
        this.nbrOfShieldMaiden = sm;
        this.nbrOfShip = ship;
        this.city = city;
        this.durationOfMission = city.ApproximatedTripAndBattleTime;
    }

    // Variables

	private bool battleInProgress;
    private int nbrOfViking;
    private int nbrOfShieldMaiden;
    private int nbrOfShip;
    private City city;

    private int durationOfMission;

    // Getters and Setters

    public bool BattleInProgress{get{return battleInProgress;}set{battleInProgress = value;}}
    public int NbrOfViking{get{return nbrOfViking;}set{nbrOfViking = value;}}
    public int NbrOfShieldMaiden{get{return nbrOfShieldMaiden;}set{nbrOfShieldMaiden = value;}}
    public int NbrOfShip{get{return nbrOfShip;}}
    public City City{get{return city;}}
    public int DurationOfMission{get{return durationOfMission;}}

    // Functions

    
	public void missionUpdate(){
		if ( battleInProgress ) {
			if ( durationOfMission <= 0 ){
				// dérouler la bataille, appeler battle
				
				battleInProgress = false;
			} else if ( durationOfMission > 0 ){
				durationOfMission -= 1;
			}
		} 
	}
}
