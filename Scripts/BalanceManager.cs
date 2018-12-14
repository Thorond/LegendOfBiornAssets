using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceManager : Singleton<BalanceManager> {

	// Variables

	[SerializeField] GameManager gameManager;
	[SerializeField] JobsManager jobsManager;
	[SerializeField] WarManager warManager;
	[SerializeField] GameObject balancePanel;
	[SerializeField] Slider warriorSlider;
	[SerializeField] Slider foodSlider;
	[SerializeField] Slider moralSlider;
	[SerializeField] Slider trustSlider;

	private float moral = 50;
	private float trust = 50;

	// Getters and Setters

	public float Moral{get{return moral;}set{moral = value;}}
	public float Trust{get{return trust;}set{trust = value;}}

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
		updateMoralSlider();
		updateTrustSlider();
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

	public void updateMoralDayAfterDay(){
		if ( warManager.MyExpedition.NbrOfSimulatneousExpedition == 0 ) moral -= 0.5f; 
	}
	public void updateMoralWhenGoingAnExpedition(){ // and not returning obviously
		moral = Mathf.Min(100,moral + 15 );
	}

	void updateMoralSlider(){
		moralSlider.value = moral;
	}

	public void updateTrustAfterBattle(bool positif){
		if (positif){
			if (trust <=99 ) trust = Mathf.Min(100, trust + 5);
		} else {
			trust -= 10; // gameOver si en dessous de 0
		}
	}

	void updateTrustSlider(){
		trustSlider.value = trust;
	}

	public void openAndCloseBalancePanel(){
		if ( balancePanel.activeSelf ){
			balancePanel.SetActive(false);
		} else {
			balancePanel.SetActive(true);
		}
	}

}
