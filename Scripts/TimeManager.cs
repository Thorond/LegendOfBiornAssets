﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : Singleton<TimeManager> {
	
	// Variables

	private int TIME_OF_A_DAY_IN_SECONDS = 30; // a mettre dans un fichier constants
	[SerializeField] private GameManager gameManager;
	[SerializeField] private JobsManager jobsManager;
	[SerializeField] private WarManager warManager;
	private DateTime inGameDate;
	private int timeInYear;
	private int timeInDay;
	private int timeChoice;
	private int timeElapsed;
	private bool oneDayHavePassed = false;

	private DateTime resourceFrequency;

	private enum tagTime{ addTime, removeTime, applyTime }

	// Getters and Setters

	public int TimeElapsed { get {return timeElapsed;} set{ timeElapsed = value;}}
	public int TimeInYear { get {return timeInYear;} set{ timeInYear = value;}}
	public int TimeInDay { get {return timeInDay;} set{ timeInDay = value;}}
	public int TimeChoice{ get {return timeChoice;} set{ timeChoice = value;}}
	public bool OneDayHavePassed{ get {return oneDayHavePassed;} set{ oneDayHavePassed = value;}}

	// Use this for initialization
	void Start () {
		inGameDate = DateTime.Now;
		timeInYear = 803;
		timeInDay = 0;
		timeChoice = 0;
		updateTime();

		resourceFrequency = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		updateTime();
		updateJobsAndWar();
	}

	// Functions 
	
	void updateTime(){
		if ( DateTime.Now.Subtract(inGameDate).Seconds >= TIME_OF_A_DAY_IN_SECONDS ){
			timeInDay +=1;
			oneDayHavePassed = true;
			if (timeInDay == 365 ) {
				timeInDay = 0;
				timeInYear += 1;
			}
			inGameDate = DateTime.Now;
		}
	}

	void updateTimeElapsed(){
		timeInDay += timeElapsed;
		if ( timeInDay >= 365 ){
			timeInYear += timeInDay / 365;
			timeInDay = timeInDay%365;
		}
	}

	public void timeManagement(Btn btnSelected){
		if ( btnSelected ){
			if ( btnSelected.tag.Equals(tagTime.removeTime.ToString()) ){
				if (timeChoice > 0) timeChoice -= 1;
			} else if ( btnSelected.tag.Equals(tagTime.addTime.ToString())){
				timeChoice += 1;
			} else if ( btnSelected.tag.Equals(tagTime.applyTime.ToString())){
				timeElapsed = timeChoice;
				updateTimeElapsed();
				inGameDate = DateTime.Now;
				resourceFrequency = DateTime.Now;
				timeChoice = 0;
			}
		}
	}
	
	void updateJobsAndWar(){
		if ( timeElapsed > 0 ){
			updateJobs(timeElapsed * 3);
			jobsManager.MyShipBuilderBuilding.RemainingTimeForConstruction -= timeElapsed;
			jobsManager.MyShipBuilderBuilding.inConstruction(gameManager.Resources.Ships, gameManager.Resources.People );
			updateExplorations(timeElapsed);
			updateStatusOfCities(timeElapsed);
			updateBarrackTrainings(timeElapsed);
			timeElapsed = 0;
		} else {
			if ( DateTime.Now.Subtract(resourceFrequency).Seconds > TIME_OF_A_DAY_IN_SECONDS / 3 ){
				updateJobs(1);
				resourceFrequency = DateTime.Now;
			} 
			else if (DateTime.Now.Subtract(resourceFrequency).Seconds > TIME_OF_A_DAY_IN_SECONDS){ 
				updateExplorations(1);
				updateStatusOfCities(1);
				updateBarrackTrainings(1);
				jobsManager.MyShipBuilderBuilding.inConstruction(gameManager.Resources.Ships, gameManager.Resources.People);
			}
		}
		if ( oneDayHavePassed){
			jobsManager.MyShipBuilderBuilding.inConstruction(gameManager.Resources.Ships, gameManager.Resources.People ); 
			updateExplorations(1);
			updateStatusOfCities(1);
			updateBarrackTrainings(1);
			oneDayHavePassed = false;
		}
	}

	void updateJob(Jobs job, int time){
		job.updateProduct(gameManager,time);
	}
	void updateJobs(int time){
		updateJob(jobsManager.MyHuntingBuilding,time);
		// updateJob(jobsManager.MyFishingBuilding,time);
		updateJob(jobsManager.MyWoodBuilding,time);
		updateJob(jobsManager.MyMineralBuilding,time);
	}

	// fonction qui devrait etre directement dans warManager comme celle faites apres coup dans barrack
	void updateExplorations(int timeE){
		foreach (Expedition expedition in warManager.MyExpedition.Expeditions ) {
			if (expedition != null){
				expedition.missionUpdate(timeE);
			}
		}
	}

	// de meme, fonction qui devrait etre dans warManager ou worldCities
	void updateStatusOfCities(int timeE){
		foreach ( City city in warManager.WorldCities.Cities){
			city.updateCity(timeE);
		}
	}
	
	void updateBarrackTrainings(int timeE){
		jobsManager.MyBarrack.updateTrainings(timeE,gameManager);
	}

}
