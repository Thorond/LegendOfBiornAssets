﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training {

	// Constructor

	public Training(int viking, int sm,int teacher, int time, bool intraining){
		this.nbrOfVikingToTrain = viking;
		this.nbrOFSMToTrain = sm;
		this.nbrOfTeachersSM = teacher;
		this.timeRemainingForTraining = time;
		this.inTraining = intraining;
	}


	// Variables

	private bool inTraining;
	private int nbrOfVikingToTrain;
	private int nbrOFSMToTrain;
	private int nbrOfTeachersSM;
	private int timeRemainingForTraining;

	// Getters and Setters

	public bool InTraining{get{return inTraining;}set{inTraining = value;}}
	public int NbrOfVikingToTrain{get{return nbrOfVikingToTrain;}set{nbrOfVikingToTrain = value;}}
	public int NbrOFSMToTrain{get{return nbrOFSMToTrain;}set{nbrOFSMToTrain = value;}}
	public int NbrOfTeachersSM{get{return nbrOfTeachersSM;}set{nbrOfTeachersSM = value;}}
	public int TimeRemainingForTraining{get{return timeRemainingForTraining;}set{timeRemainingForTraining = value;}}

	
	// Functions

	public int updateTraining(Resource ressources, int simultanouesTraining){
		if ( inTraining  ) {
            if ( timeRemainingForTraining > 0 ){
				timeRemainingForTraining -= 1;
			}
			if ( timeRemainingForTraining <= 0 ){
				
				updateWarriors(ressources);
				simultanouesTraining -= 1;
				inTraining = false;
			} 
		} 
		return simultanouesTraining;
	}

	void updateWarriors(Resource ressources){
		ressources.People.NbrOfVikings += this.nbrOfVikingToTrain;
		ressources.People.NbrOfShieldMaidens += this.nbrOFSMToTrain + this.nbrOfTeachersSM;
		ressources.People.NbrTotalOfWarriors += this.nbrOfVikingToTrain + this.nbrOFSMToTrain; // on met a jour le nbr total pour les barres d'équilibres
	}



}
