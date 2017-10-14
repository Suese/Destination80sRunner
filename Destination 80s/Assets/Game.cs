using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	GameObject player;
	private static Game _instance;

	public static Game Instance{
		get{
			if( _instance == null ){
				GameObject o = new GameObject ("Game Singleton");
				_instance = o.AddComponent<Game>();
				_instance.player = GameObject.FindGameObjectWithTag( "Player" );
				GameObject.DontDestroyOnLoad( _instance );
			}
			return _instance;
		}

	}
}
