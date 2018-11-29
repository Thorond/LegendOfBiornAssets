﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slaves : Inhabitant {

	public Slaves() : base() {
		this.foodGatheringEfficiency = 4;
		this.woodGatheringEfficiency = 2;
		this.ironGatheringEfficiency = 1;
		this.shipConstructionEffeciency = 2;
		this.battleEfficiency = 0;
	}
}
