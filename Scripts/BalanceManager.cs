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
	[SerializeField] GameObject infoPanelBalance;
	[SerializeField] GameObject infoPanelWarriorSlider;
	[SerializeField] GameObject infoPanelFoodSlider;
	[SerializeField] GameObject infoPanelMoralSlider;
	[SerializeField] GameObject infoPanelTrustSlider;

	private int foodConsomationForTenDaysForAllTheWarriors = 0;
	private float foodPercent = 0;
	private float moral = 50;
	private float trust = 50;

	// Getters and Setters

	public int FoodConsomationForTenDaysForAllTheWarriors{get{return foodConsomationForTenDaysForAllTheWarriors;}set{foodConsomationForTenDaysForAllTheWarriors = value;}}
	public float FoodPercent{get{return foodPercent;}set{foodPercent = value;}}
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
		isGameOver();
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
		foodConsomationForTenDaysForAllTheWarriors = ( gameManager.Resources.People.Vikings.FoodConsomationPerDay 
										+ gameManager.Resources.People.ShieldMaidens.FoodConsomationPerDay ) * 10 * gameManager.Resources.People.NbrTotalOfWarriors ;

		// si le joueur peut tenir 10 fois trentes jours, il est a 100 %
		// s'il ne peut tenir que 30 jours, il est a 0%
		foodPercent = 
			((float)(food-foodConsomationForTenDaysForAllTheWarriors)
			/(float)(10*foodConsomationForTenDaysForAllTheWarriors-foodConsomationForTenDaysForAllTheWarriors))
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

	public void infoDisplayOpen(){
		infoPanelBalance.SetActive(true);
	}
	public void infoDisplayClose(){
		infoPanelBalance.SetActive(false);
	}
	
	public void infoDisplayWarriorSliderOpen(){
		infoPanelWarriorSlider.SetActive(true);
	}
	public void infoDisplayWarriorSliderClose(){
		infoPanelWarriorSlider.SetActive(false);
	}
	public void infoDisplayFoodSliderOpen(){
		infoPanelFoodSlider.SetActive(true);
	}
	public void infoDisplayFoodSliderClose(){
		infoPanelFoodSlider.SetActive(false);
	}
	public void infoDisplayMoralSliderOpen(){
		infoPanelMoralSlider.SetActive(true);
	}
	public void infoDisplayMoralSliderClose(){
		infoPanelMoralSlider.SetActive(false);
	}
	public void infoDisplayTrustSliderOpen(){
		infoPanelTrustSlider.SetActive(true);
	}
	public void infoDisplayTrustSliderClose(){
		infoPanelTrustSlider.SetActive(false);
	}


	
	public void isGameOver(){
		if (!gameManager.GameOver){
			if ( moral <= 0 || trust <= 0 
				|| gameManager.Resources.People.NbrTotalOfWarriors <= 0
				|| foodPercent <= 0  ){
					gameManager.GameOver = true;
			}
		}
		
	}

}
