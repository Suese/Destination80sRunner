using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

	[System.Serializable]
	public class LevelReference{
		public string sceneName;
//		public Spin sign;
		public GameObject sign;

	}
	public LevelReference[] levels;
	public string axisName = "Vertical";
	public string selectButton = "Start";
	public float delayAfterSelect = 3;
	public float verticalDistance = 3;
	public int selectionID = 0;
	public AudioSource selectSound;
	public AudioSource changeSelectionSound;

	Vector3 startPosition;
	void Start(){
		startPosition = transform.localPosition;
	}
	bool itemSelected = false;

	public float y = 0;
	bool holdingDown = false;
	bool holdingUp = false;
	void Update () {
		if( itemSelected ){
			return;
		}
		float vertical = Input.GetAxis( axisName );
		bool up = false;
		bool down = false;
		y = vertical;
		if( vertical > 0.5f ){
			up = true;
		} else if( vertical < -0.5f ){
			down = true;
		}

		if( up == false ){
			holdingUp = false;
		}
		if( down == false ){
			holdingDown = false;
		}

		if( up && !holdingUp){
			selectionID--;
			changeSelectionSound.Play();
			if( selectionID < 0 ){
				selectionID = levels.Length - 1;
			}
			holdingUp = true;
		}
		if( down && !holdingDown ){
			selectionID++;
			changeSelectionSound.Play();
			if( selectionID >= levels.Length ){
				selectionID = 0;
			}
			holdingDown = true;
		}

		transform.localPosition = startPosition + (Vector3.down * verticalDistance * selectionID);

		if( Input.GetButton( selectButton ) ){
			StartCoroutine( SelectLevel( selectionID ) );
		}
	}

	IEnumerator SelectLevel(int selectionID ){
		selectSound.Play();
		itemSelected = true;
		float endTime = Time.time + delayAfterSelect;
		LevelReference level = levels[selectionID];
		string nextScene = level.sceneName;
		GameObject o = level.sign;
		RotateConstantly rotator = o.GetComponent<RotateConstantly>();
		Blink blink = o.GetComponent<Blink>();
		Animator anim = o.GetComponent<Animator>();

		if( rotator != null ){
			rotator.enabled = true;
		}
		if( blink != null ){
			blink.enabled = true;
		}
		if( anim != null ){
			anim.SetTrigger( "Selected" );
		}

		yield return new WaitForSeconds (delayAfterSelect);
		UnityEngine.SceneManagement.SceneManager.LoadScene( nextScene );


	}
}
