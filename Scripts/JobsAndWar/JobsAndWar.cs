using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JobsAndWar  {


	// Variables
	protected int nbrOfVikingAssigned;
	protected int nbrOfShieldMaidenAssigned;

	protected int quantityOfProductBroughtBack;

	
	// Constructor
	public JobsAndWar(){
		nbrOfVikingAssigned = 0;
		nbrOfShieldMaidenAssigned = 0;
		quantityOfProductBroughtBack = 0;
	}



	// Functions
	public void assignAnotherViking(){
		nbrOfVikingAssigned += 1;
	}
	public void removeAViking(){
		nbrOfVikingAssigned -= 1;
	}
	public void addOrRemoveSeveralViking(int nbr){
		nbrOfVikingAssigned = nbr;
	}
	public void assignAnotherShieldMaiden(){
		nbrOfShieldMaidenAssigned += 1;
	}
	public void removeAShieldMaiden(){
		nbrOfShieldMaidenAssigned -= 1;
	}
	public void addOrRemoveSeveralShieldMaiden(int nbr){
		nbrOfShieldMaidenAssigned = nbr;
	}

	// public abstract void determineQuantity(GameManager gameManager);

	// public abstract void updateProduct(GameManager gameManager, int timeSpent);


	// Getters and Setters
	public int NbrOfVikingAssigned{
		get{
			return nbrOfVikingAssigned;
		}
		set{
			nbrOfVikingAssigned = value;
		}
	}
	public int NbrOfShieldMaidenAssigned{
		get{
			return nbrOfShieldMaidenAssigned;
		}
		set{
			nbrOfShieldMaidenAssigned = value;
		}
	}
}
