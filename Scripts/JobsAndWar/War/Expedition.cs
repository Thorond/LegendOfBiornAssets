using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expedition {
    // Constructor

    // public Expedition(){
        
    // }
    public Expedition(int vik,int sm,int ship,int spaceForMen, int spaceForLoots, City city, ConstantsAndEnums.possibleAttacks attackChosen){
		this.expeditionStatus = ConstantsAndEnums.expeditionStatus.inMovement;
        this.battleStatus = ConstantsAndEnums.battleStatus.onGoing;
        this.nbrOfViking = vik;
        this.nbrOfShieldMaiden = sm;
        this.nbrOfShip = ship;
        this.spaceForMen = spaceForMen;
        this.spaceForLoots = spaceForLoots;
        this.city = city;
        this.attackChosen = attackChosen;
        this.durationOfMission = city.ApproximatedTripAndBattleTime;
        this.nbrOfRemainingViking = 0;
        this.nbrOfRemainingSM = 0;
        this.goldBroughtBack = 0;
        this.woodBroughtBack = 0;
        this.ironBroughtBack = 0;
        this.slaveBroughtBack = 0;
    }

    // Variables
    
	private ConstantsAndEnums.expeditionStatus expeditionStatus;
    private ConstantsAndEnums.battleStatus battleStatus;
    private int nbrOfViking;
    private int nbrOfShieldMaiden;
    private int nbrOfShip;
    private int spaceForMen;
    private int spaceForLoots;
    private City city;
    private ConstantsAndEnums.possibleAttacks attackChosen;

    private int durationOfMission;

    private int nbrOfRemainingViking;
    private int nbrOfRemainingSM;
    private int goldBroughtBack;
    private int woodBroughtBack;
    private int ironBroughtBack;
    private int slaveBroughtBack;

    // Getters and Setters

    public ConstantsAndEnums.expeditionStatus ExpeditionStatus{get{return expeditionStatus;}set{expeditionStatus = value;}}
    public ConstantsAndEnums.battleStatus BattleStatus{get{return battleStatus;}set{battleStatus = value;}}
    public int NbrOfViking{get{return nbrOfViking;}set{nbrOfViking = value;}}
    public int NbrOfShieldMaiden{get{return nbrOfShieldMaiden;}set{nbrOfShieldMaiden = value;}}
    public int NbrOfShip{get{return nbrOfShip;}}
    public int SpaceForMen{get{return spaceForMen;}set{spaceForMen = value;}}
    public int SpaceForLoots{get{return spaceForLoots;}set{spaceForLoots = value;}}
    public City City{get{return city;}}
    public ConstantsAndEnums.possibleAttacks AttackChosen{get{return attackChosen;}}
    public int DurationOfMission{get{return durationOfMission;}set{durationOfMission = value;}}

    public int NbrOfRemainingViking{get{return nbrOfRemainingViking;}set{nbrOfRemainingViking = value;}}
    public int NbrOfRemainingSM{get{return nbrOfRemainingSM;}set{nbrOfRemainingSM = value;}}
    public int GoldBroughtBack{get{return goldBroughtBack;}set{goldBroughtBack = value;}}
    public int WoodBroughtBack{get{return woodBroughtBack;}set{woodBroughtBack = value;}}
    public int IronBroughtBack{get{return ironBroughtBack;}set{ironBroughtBack = value;}}
    public int SlaveBroughtBack{get{return slaveBroughtBack;}set{slaveBroughtBack = value;}}

    // Functions

    
	public void missionUpdate(){
		if ( expeditionStatus == ConstantsAndEnums.expeditionStatus.inMovement ) {
            if ( durationOfMission > 0 ){
				durationOfMission -= 1;
			}
			if ( durationOfMission <= 0 ){
				// dérouler la bataille, appeler battle
                if ( battleStatus != ConstantsAndEnums.battleStatus.returning ) {
                    Battle.battleCourse(this);
                }
				expeditionStatus = ConstantsAndEnums.expeditionStatus.battleOver;
			} 
		} 
	}
}
