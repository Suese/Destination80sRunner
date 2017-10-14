using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Trigger))]
public class LevelEnd : MonoBehaviour {

	Trigger trigger;
	void Start () {
		trigger = GetComponent<Trigger>();
		trigger.onTriggerEnter.AddListener( OnTriggerEnter );
	}
	void OnTriggerEnter(){
//		Game.Instance.DoWin();
	}
	
}
