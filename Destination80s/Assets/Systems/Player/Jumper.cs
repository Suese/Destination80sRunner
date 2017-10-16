using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour {

	public string buttonName = "Jump";
	public float force = 100f;
	public AudioSource jumpSound;


	public Trigger groundTrigger;
	Rigidbody body;

	void Start () {
		body = GetComponent<Rigidbody>();

	}

	void Update () {
		if( groundTrigger.ContentCount > 0 && Input.GetButtonDown( buttonName ) ){
			body.AddForce( Vector3.up * force, ForceMode.Impulse );
			jumpSound.Play();
		}
	}
}
