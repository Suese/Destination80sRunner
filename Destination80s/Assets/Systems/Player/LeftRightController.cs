using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LeftRightController : MonoBehaviour {

	public float force = 1f;
	public string axisName;
	Rigidbody body;
	void Start () {
		body = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		float horizontal = Input.GetAxis( axisName );
		//body.AddForce( Vector3.right * force * horizontal, ForceMode.VelocityChange );
		body.MovePosition( body.position + Vector3.right * force * horizontal );
	}
}
