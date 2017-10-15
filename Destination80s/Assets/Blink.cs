using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

	public float delay;
	public GameObject blinkingObject;

	void Start () {
		nextTime = Time.time + delay;

	}


	float nextTime;
	void FixedUpdate () {
		if( Time.time >= nextTime ){
			blinkingObject.SetActive( !blinkingObject.activeSelf );
			nextTime += delay;
		}
	}
}
