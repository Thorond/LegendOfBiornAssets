using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Barrack  {

	
	// Constructor 

	public Barrack()  {
		trainings = new Training[4];
		nbrOfSimulatneousTrainings = 0;
		nbrOfVikingToTrainChosen = 0;
		nbrOFSMToTrainChosen = 0;
		goldNeeded = 0;
		nbrOfTeachersSMNeeded = 0;
	}

	// Constants 
	
	private int TIME_FOR_ONE_TRAINING = 50;
	private int GOLD_NEEDED_FOR_ONE_STUDENT = 10;

	// Variables
	private Training[] trainings;
	private int nbrOfSimulatneousTrainings;

	private int nbrOfVikingToTrainChosen;
	private int nbrOFSMToTrainChosen;
	private int goldNeeded;
	private int nbrOfTeachersSMNeeded;

	// Getters and Setters

	public Training[] Trainings{get{return trainings;}}
	public int NbrOfSimulatneousTrainings{get{return nbrOfSimulatneousTrainings;}set{nbrOfSimulatneousTrainings = value;}}
	public int NbrOfVikingToTrainChosen{get{return nbrOfVikingToTrainChosen;}set{nbrOfVikingToTrainChosen = value;}}
	public int NbrOFSMToTrainChosen{get{return nbrOFSMToTrainChosen;}set{nbrOFSMToTrainChosen = value;}}
	public int GoldNeeded{get{return goldNeeded;}set{goldNeeded = value;}}
	public int NbrOfTeachersSMNeeded{get{return nbrOfTeachersSMNeeded;}set{nbrOfTeachersSMNeeded = value;}}

	// Functions

	public void goldNeedCalculation(){
		goldNeeded = GOLD_NEEDED_FOR_ONE_STUDENT * ( nbrOFSMToTrainChosen + nbrOfVikingToTrainChosen );
	}
	public void nbrOfTeachersSMNeededCalculation(){
		if ( nbrOFSMToTrainChosen + nbrOfVikingToTrainChosen  != 0)
			nbrOfTeachersSMNeeded = Mathf.Max( (int) ( ( nbrOFSMToTrainChosen + nbrOfVikingToTrainChosen ) / 2 ) , 1) ;
		else nbrOfTeachersSMNeeded = 0;
		
	}

	public void assignWork(GameManager gameManager, TextManager textManager){
		if (this.nbrOfSimulatneousTrainings >= 4 ){ // on ne peut pas faire plus de 4 entrainements à la fois
			textManager.errorTextDisplay("You can't start more trainings !");
		} else {

			if ( this.nbrOfVikingToTrainChosen + this.nbrOFSMToTrainChosen > 0 ){
				if ( this.nbrOfTeachersSMNeeded <= gameManager.Resources.People.NbrOfShieldMaidens ){
					if ( this.goldNeeded <= gameManager.Resources.Gold){

						int rank = 0;
						foreach (Training training in trainings){
							if ( training == null || training.InTraining == false ){

								Training newTraining = new Training(nbrOfVikingToTrainChosen,nbrOFSMToTrainChosen,
																	nbrOfTeachersSMNeeded,TIME_FOR_ONE_TRAINING,true);
								trainings[rank] = newTraining;
								nbrOfSimulatneousTrainings +=1;


								// mise a jour des donnees de jeu
								gameManager.Resources.People.NbrOfShieldMaidens -= nbrOfTeachersSMNeeded;
								gameManager.Resources.Gold -= goldNeeded;

								// réinitialisation des paramètres 
								nbrOfVikingToTrainChosen = 0;
								nbrOFSMToTrainChosen = 0;
								nbrOfTeachersSMNeeded = 0;
								goldNeeded = 0;

								nbrOfTeachersSMNeededCalculation();
								goldNeedCalculation();
								break;
							} else{
								rank+=1;
							}
						}

					} else{
						// pas assez d'or pour l'entrainement souhaite
						textManager.errorTextDisplay("You don't have enough gold for that training !");
					}

				} else{
					// pas assez de sm disponible pour l'entrainement souhaite
					textManager.errorTextDisplay("You don't have enough shieldmaiden for that training !");
				}

			} else {
				// aucun type de guerriers choisi
				textManager.errorTextDisplay("You need to select some training !");
			}
		}
		
	}

	public void updateTrainings(GameManager gameManager){
		foreach (Training training in trainings){
			if (training != null  ){
				this.nbrOfSimulatneousTrainings = training.updateTraining( gameManager.Resources, this.nbrOfSimulatneousTrainings);
			}
		}
	}

}
