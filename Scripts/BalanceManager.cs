using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceManager : Singleton<BalanceManager> {

	// Variables

	[SerializeField] GameManager gameManager;
	[SerializeField] JobsManager jobsManager;
	[SerializeField] WarManager warManager;
	[SerializeField] Slider warriorSlider;
	[SerializeField] Slider foodSlider;
	[SerializeField] Slider moralSlider;
	[SerializeField] Slider trustSlider;

	private int moral;
	private int trust;

	// Functions

	// void awake(){ Assert n'existe pas .... 
	// 	Assert
	// }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		updateSliders();
	}

	void updateSliders(){
		updateWarriorSlider();
		updateFoodSlider();
		updateMoral();
		updateTrust();
	}



	void updateWarriorSlider(){
		
		warriorSlider.value = gameManager.Resources.People.NbrTotalOfWarriors;
	}

	void updateFoodSlider(){
		int food = gameManager.Resources.Food;
		int foodConsomationForThirtyDaysForAllTheWarriors = ( gameManager.Resources.People.Vikings.FoodConsomationPerDay 
										+ gameManager.Resources.People.ShieldMaidens.FoodConsomationPerDay ) * 10 * gameManager.Resources.People.NbrTotalOfWarriors ;

		// si le joueur peut tenir 10 fois trentes jours, il est a 100 %
		// s'il ne peut tenir que 30 jours, il est a 0%
		float foodPercent = 
			((float)(food-foodConsomationForThirtyDaysForAllTheWarriors)
			/(float)(10*foodConsomationForThirtyDaysForAllTheWarriors-foodConsomationForThirtyDaysForAllTheWarriors))
			*100f;


		foodSlider.value = Mathf.Min(100f,foodPercent);
	}

	void updateMoral(){

	}

	void updateTrust(){

	}

}
