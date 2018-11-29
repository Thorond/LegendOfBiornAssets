using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralGathering : Jobs {

	// Variables

	public MineralGathering() : base() {
	}
	
	public override void determineQuantity(GameManager gameManager){
		quantityOfProductBroughtBack = 0;
		quantityOfProductBroughtBack += this.nbrOfVikingAssigned * gameManager.Resources.People.Vikings.IronGatheringEfficiency;
		quantityOfProductBroughtBack += this.nbrOfShieldMaidenAssigned * gameManager.Resources.People.ShieldMaidens.IronGatheringEfficiency;
		quantityOfProductBroughtBack += this.nbrOfSlaveAssigned * gameManager.Resources.People.Slaves.IronGatheringEfficiency;
	}
	public override void updateProduct(GameManager gameManager, int timeSpent){
		determineQuantity(gameManager);
		gameManager.Resources.Iron += quantityOfProductBroughtBack * timeSpent;
		if (gameManager.Resources.Iron > gameManager.Resources.MaxIron ) gameManager.Resources.Iron = gameManager.Resources.MaxIron; 
	}
}
