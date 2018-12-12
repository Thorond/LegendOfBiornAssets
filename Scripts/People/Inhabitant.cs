using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant  {


	// Variables 

	protected int foodGatheringEfficiency;
	protected int woodGatheringEfficiency;
	protected int ironGatheringEfficiency;
	protected int shipConstructionEffeciency;
	protected int battleEfficiency;

	protected int foodConsomationPerDay;

	// Getters and setters

	public int FoodGatheringEfficiency{get{return foodGatheringEfficiency;}set{foodGatheringEfficiency = value;}}
	public int WoodGatheringEfficiency{get{return woodGatheringEfficiency;}set{woodGatheringEfficiency = value;}}
	public int IronGatheringEfficiency{get{return ironGatheringEfficiency;}set{ironGatheringEfficiency = value;}}
	public int ShipConstructionEffeciency{get{return shipConstructionEffeciency;}set{shipConstructionEffeciency = value;}}
	public int BattleEfficiency{get{return battleEfficiency;}set{battleEfficiency = value;}}
	public int FoodConsomationPerDay{get{return foodConsomationPerDay;}set{foodConsomationPerDay = value;}}

	// Constructor
	public Inhabitant(){

	}
}
