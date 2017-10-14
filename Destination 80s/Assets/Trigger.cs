using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Trigger : MonoBehaviour {


	public UnityEvent onTriggerEnter;
	public UnityEvent onTriggerExit;

	public int _contentCount;
	public int ContentCount{
		get{
			return _contentCount;
		}
	}

	void OnTriggerEnter(Collider  c ){
		_contentCount++;
		onTriggerEnter.Invoke();
	}
	void OnTriggerExit(Collider c){
		_contentCount--;
		onTriggerExit.Invoke();
	}
}
