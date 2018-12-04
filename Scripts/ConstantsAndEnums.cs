using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantsAndEnums {

	// Global

	public enum people{Viking,ShieldMaiden,Slave}

	// JobsManager	
	public enum tagBtnJob{ huntingBtn, fishingBtn,shipBuilderBtn,rawMaterialBtn,harbor}
	public enum tagPanelJobs{jobPanel,mapPanel,woodBtn,ironBtn,shipUI}
	public enum tagShipType{ship1Btn,ship2Btn,ship3Btn,applyBtn}
	public enum tagUpOrDown{upViking,downViking,upShieldMaiden,downShieldMaiden,upSlave,downSlave,upShip,downShip}

	// ShipBuilding
	
	public enum shipType{type1,type2,type3}

	// War

	public enum possibleAttacks{explore,plunder,raze}

	// Cities 

    public enum tagBtnCity{LindisfarneBtn, DublinBtn, YorkBtn, NovgorodBtn, KiovBtn, ConstantinopleBtn, BagdadBtn,
        ParisBtn, BordeauxBtn, LunaBtn, LisbonneBtn}
		
    public enum dificultyInGame{easy, medium, hard}
}
