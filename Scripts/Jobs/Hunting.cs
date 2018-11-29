using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : Jobs {

	// Variables

	public Hunting() : base() {
	}
	
	public override void determineQuantity(GameManager gameManager){
		quantityOfProductBroughtBack = 0;
		quantityOfProductBroughtBack += this.nbrOfVikingAssigned * gameManager.Resources.People.Vikings.FoodGatheringEfficiency;
		quantityOfProductBroughtBack += this.nbrOfShieldMaidenAssigned * gameManager.Resources.People.ShieldMaidens.FoodGatheringEfficiency;
		quantityOfProductBroughtBack += this.nbrOfSlaveAssigned * gameManager.Resources.People.Slaves.FoodGatheringEfficiency;
	}
	public override void updateProduct(GameManager gameManager, int timeSpent){
		determineQuantity(gameManager);
		gameManager.Resources.Food += quantityOfProductBroughtBack * timeSpent;
		if (gameManager.Resources.Food > gameManager.Resources.MaxFood ) gameManager.Resources.Food = gameManager.Resources.MaxFood; 
	}

}
