using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jobs : JobsAndWar  {


	// Variables
	protected int nbrOfSlaveAssigned;

	
	// Constructor
	public Jobs() : base() {
		nbrOfSlaveAssigned = 0;
	}



	// Functions
	public void assignAnotherSlave(){
		nbrOfSlaveAssigned += 1;
	}
	public void removeASlave(){
		nbrOfSlaveAssigned -= 1;
	}
	public void addOrRemoveSeveralSlave(int nbr){
		nbrOfSlaveAssigned = nbr;
	}

	public abstract void determineQuantity(GameManager gameManager);

	public abstract void updateProduct(GameManager gameManager, int timeSpent);


	// Getters and Setters
	public int NbrOfSlaveAssigned{
		get{
			return nbrOfSlaveAssigned;
		}
		set{
			nbrOfSlaveAssigned = value;
		}
	}
}
