using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChanger : MonoBehaviour {

	public Material material;
	public Gradient gradient;
	public float speed;
	public string colorUniform;

	void Update () {
		material.SetColor( colorUniform, gradient.Evaluate( Mathf.Repeat(Time.time * speed,1) ) );
	}
}
