using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour {

	public UnityEvent onWin;
	public UnityEvent onLose;
	GameObject player;
	private static Game _instance;

	public static Game Instance{
		get{
			if( _instance == null ){
				GameObject o = new GameObject ("Game Singleton");
				_instance = o.AddComponent<Game>();
				GameObject.DontDestroyOnLoad( _instance );
			}
			return _instance;
		}

	}

	void Awake(){
		if ( _instance == null ){
			_instance = this;
		} else {
			Destroy(gameObject);
		}


	}
	void Start(){
		player = GameObject.FindGameObjectWithTag( "Player" );
	}



	public void DoWin(){
		player.SetActive( false );
		onWin.Invoke();
	}

	public void DoLose(){
		onLose.Invoke();
		
	}
}
