using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People  {

	// Variables
	private Slaves slaves;
	private int nbrOfSlave;
	private Viking vikings;
	private int nbrOfVikings;
	private ShieldMaiden shieldMaidens;
	private int nbrOfShieldMaidens;

	private int nbrTotalOfWarriors;

	// Getters and Setters 

	public Slaves Slaves{get{return slaves;}}
	public Viking Vikings{get{return vikings;}}
	public ShieldMaiden ShieldMaidens{get{return shieldMaidens;}}
	public int NbrOfSlave{
		get{
			return nbrOfSlave;
		}
		set{
			nbrOfSlave = value;
		}
	}
	public int NbrOfVikings{
		get{
			return nbrOfVikings;
		}
		set{
			nbrOfVikings = value;
		}
	}
	public int NbrOfShieldMaidens{
		get{
			return nbrOfShieldMaidens;
		}
		set{
			nbrOfShieldMaidens = value;
		}
	}
	public int NbrTotalOfWarriors{
		get{
			return nbrTotalOfWarriors;
		}
		set{
			nbrTotalOfWarriors = value;
		}
	}


	// Constructor
	public People(){
		slaves = new Slaves();
		shieldMaidens = new ShieldMaiden();
		vikings = new Viking();
		nbrOfSlave = 5;
		nbrOfVikings = 20;
		nbrOfShieldMaidens = 10;
		nbrTotalOfWarriors = nbrOfVikings + nbrOfShieldMaidens;
	}

	// Functions
	public string nameOfPeopleDisplay(){
		return "\nVikings : " 
			+ "\nShield-maidens : " 
			+ "\nSlaves : " ;
	}
	public string textDisplay(){
		return "Available : \n" + nbrOfVikings.ToString()
			+ "\n " + nbrOfShieldMaidens.ToString()
			+ "\n" + nbrOfSlave.ToString() ;
	}

}
