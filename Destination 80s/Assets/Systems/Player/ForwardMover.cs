using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMover : MonoBehaviour {

	public float speed = 1f;
	Rigidbody body;

	void Start () {
		body = GetComponent<Rigidbody>();

	}
	void FixedUpdate(){
		body.AddForce( Vector3.forward * speed,ForceMode.Force );
	}

	
}
