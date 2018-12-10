using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantsAndEnums {

	// Global

	public enum people{Viking,ShieldMaiden,Slave}

	// JobsManager	
	public enum tagBtnJob{ huntingBtn, fishingBtn,shipBuilderBtn,rawMaterialBtn,harbor}
	public enum tagPanelJobs{mapPanel,woodBtn,ironBtn}
	public enum tagShipType{ship1Btn,ship2Btn,ship3Btn,applyBtn}
	public enum tagUpOrDown{upViking,downViking,upShieldMaiden,downShieldMaiden,upSlave,downSlave,upShip,downShip}

	// ShipBuilding
	
	public enum shipType{type1,type2,type3}

	// War
	public enum battleDisplayBtn{battleDisplay1,battleDisplay2,battleDisplay3,battleDisplay4,battleDisplay5}
	public enum possibleAttacks{explore,plunder,raze}
	public enum expeditionStatus{inMovement,battleOver,over}
	public enum battleStatus{won,lost,onGoing}

	// Cities 

    public enum tagBtnCity{LindisfarneBtn, DublinBtn, YorkBtn, NovgorodBtn, KiovBtn, ConstantinopleBtn, BagdadBtn,
        ParisBtn, BordeauxBtn, LunaBtn, LisbonneBtn}
		
    public enum dificultyInGame{easy, medium, hard}
}
