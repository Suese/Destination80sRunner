using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangesScene : MonoBehaviour {

	public string buttonName = "Start";
	public string sceneName = "LevelSelect";

	void Update () {
		if( Input.GetButton( buttonName ) ){
			UnityEngine.SceneManagement.SceneManager.LoadScene( sceneName );
		}
	}
}
