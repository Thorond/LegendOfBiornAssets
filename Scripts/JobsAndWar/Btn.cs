
using UnityEngine;

public class Btn : MonoBehaviour {

	[SerializeField] private GameObject jobsObject;
	// [SerializeField] private GameObject upBtn;

	public GameObject JobsObject{
		get{
			return jobsObject;
		}
	}

	// public GameObject UpBtn{
	// 	get{
	// 		return upBtn;
	// 	}
	// }
}
