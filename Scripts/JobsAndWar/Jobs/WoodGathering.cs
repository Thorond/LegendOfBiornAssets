using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGathering : Jobs {

	// Variables

	public WoodGathering() : base() {
	}
	
	public override void determineQuantity(GameManager gameManager){
		quantityOfProductBroughtBack = 0;
		quantityOfProductBroughtBack += this.nbrOfVikingAssigned * gameManager.Resources.People.Vikings.WoodGatheringEfficiency;
		quantityOfProductBroughtBack += this.nbrOfShieldMaidenAssigned * gameManager.Resources.People.ShieldMaidens.WoodGatheringEfficiency;
		quantityOfProductBroughtBack += this.nbrOfSlaveAssigned * gameManager.Resources.People.Slaves.WoodGatheringEfficiency;
	}
	public override void updateProduct(GameManager gameManager, int timeSpent){
		determineQuantity(gameManager);
		gameManager.Resources.Wood += quantityOfProductBroughtBack * timeSpent;
		if (gameManager.Resources.Wood > gameManager.Resources.MaxWood ) gameManager.Resources.Wood = gameManager.Resources.MaxWood; 
	}
}
