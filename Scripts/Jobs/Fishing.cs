using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Jobs {

	public Fishing() : base() {
	}
	
	public override void determineQuantity(GameManager gameManager){
		quantityOfProductBroughtBack = 0;
		quantityOfProductBroughtBack += nbrOfVikingAssigned * gameManager.Resources.People.Vikings.FoodGatheringEfficiency;
		quantityOfProductBroughtBack += nbrOfShieldMaidenAssigned * gameManager.Resources.People.ShieldMaidens.FoodGatheringEfficiency;
		quantityOfProductBroughtBack += nbrOfSlaveAssigned * gameManager.Resources.People.Slaves.FoodGatheringEfficiency;
	}
	public override void updateProduct(GameManager gameManager, int timeSpent){
		determineQuantity(gameManager);
		gameManager.Resources.Food += quantityOfProductBroughtBack * timeSpent;
		if (gameManager.Resources.Food > gameManager.Resources.MaxFood ) gameManager.Resources.Food = gameManager.Resources.MaxFood; 
	}
}
