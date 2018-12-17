using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : Inhabitant {

	public Viking() : base() {
		this.foodGatheringEfficiency = 5;
		this.woodGatheringEfficiency = 6;
		this.ironGatheringEfficiency = 4;
		this.shipConstructionEffeciency = 3;
		this.battleEfficiency = 10;
		this.foodConsomationPerDay = 2;
	}
}
