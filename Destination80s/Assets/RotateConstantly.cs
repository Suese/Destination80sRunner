using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateConstantly : MonoBehaviour {

	public enum Axis{
		x,y,z
	}
	public float speed = 1.0f;
	public Axis axis = Axis.y;
	float r = 0;
	void Update () {
		r += Time.deltaTime * speed;
		if( r >= 360 ){
			r -= 360;
		}
		switch( axis ){
			case Axis.x:
				transform.localRotation = Quaternion.Euler( r, 0, 0 );
			break;
			case Axis.y:
				transform.localRotation = Quaternion.Euler( 0, r, 0 );
			break;
			case Axis.z:
				transform.localRotation = Quaternion.Euler( 0, 0, r );
			break;
		}
	}
}
