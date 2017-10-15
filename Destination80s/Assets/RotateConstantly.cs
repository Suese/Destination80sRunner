using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantly : MonoBehaviour {

	public float speed = 1.0f;
	float r = 0;
	void Update () {
		r += Time.deltaTime * speed;
		if( r >= 360 ){
			r -= 360;
		}
		transform.localRotation = Quaternion.Euler( 0, r, 0 );
	}
}
