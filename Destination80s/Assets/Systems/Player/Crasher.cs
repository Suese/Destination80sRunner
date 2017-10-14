using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Crasher : MonoBehaviour {
	public Trigger crashTrigger;
	public GameObject spawnWhat;
	public UnityEvent onCrash;
	public bool destroyMe = true;

	void Start(){
		crashTrigger.onTriggerEnter.AddListener(OnCrash);
	}
	void Destroy(){
		crashTrigger.onTriggerEnter.RemoveListener(OnCrash);
	}

	void OnCrash(){
		Instantiate( spawnWhat, transform.position, transform.rotation );
		if( destroyMe ){
			gameObject.SetActive( false );
		}
	}
}
