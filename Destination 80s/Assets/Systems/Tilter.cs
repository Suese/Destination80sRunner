using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilter : MonoBehaviour {

	public string axisName = "Horizontal";
	public float degrees = 32;
	public float tiltSpeed = 0.01f;

	void Start(){
	}
	float destDegrees = 0;
	float currentDegrees = 0;
	void Update () {
		float horizontal = -Input.GetAxis( axisName );

		destDegrees = horizontal * degrees;
		currentDegrees = Mathf.Lerp( currentDegrees, destDegrees, tiltSpeed * Time.deltaTime );
		transform.localRotation = Quaternion.Euler( 0, 0,currentDegrees );

	}
}
