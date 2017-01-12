using UnityEngine;
using System.Collections;

public class Ghosts : MonoBehaviour {

	public Material[] mats;
	public bool frightened=false;
	public int ghostsKilled;

	private float timer = 0.0f;
	private float frightenedTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 6.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 4.0f & frightenedTimer < 6.0f) {
				TurnWhite ();
			}
		}

		if (Time.timeScale == 0) {
			timer = timer;
		} else if (frightened) {
			timer = timer;
		} else {
			timer += Time.deltaTime;
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	
	}

	public void Scatter(){

		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetComponent<Blinky> ().scatter=true;
			} else if (child.GetComponent<Pinky> ()){
				child.GetComponent<Pinky> ().scatter=true;
			} else if (child.GetComponent<Inky> ()){
				child.GetComponent<Inky> ().scatter=true;
			} else if (child.GetComponent<Clyde> ()){
				child.GetComponent<Clyde> ().scatter=true;
			}
		}
	}

	public void Frightened(){
		ghostsKilled = 0;
		frightened = true;
		frightenedTimer = 0f;
		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetComponent<Blinky> ().frightened=true;
//				child.GetComponent<Blinky> ().speed = child.GetComponent<Blinky> ().speed * .5f;

			} else if (child.GetComponent<Pinky> ()){
				child.GetComponent<Pinky> ().frightened=true;
//				child.GetComponent<Pinky> ().speed = child.GetComponent<Pinky> ().speed * .5f;
			} else if (child.GetComponent<Inky> ()){
				child.GetComponent<Inky> ().frightened=true;
//				child.GetComponent<Inky> ().speed = child.GetComponent<Inky> ().speed * .5f;
			} else if (child.GetComponent<Clyde> ()){
				child.GetComponent<Clyde> ().frightened=true;
//				child.GetComponent<Clyde> ().speed = child.GetComponent<Clyde> ().speed * .5f;
			}
			child.GetChild(0).GetChild(0).GetComponent<Renderer> ().material = mats [0];
		}
	}

	void TurnWhite(){
		foreach (Transform child in transform) {
			child.GetChild(0).GetChild(0).GetComponent<Renderer> ().material = mats [1];
		}
	}

	public void Chase(){

		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetComponent<Blinky> ().frightened=false;
				child.GetComponent<Blinky> ().scatter=false;
//				child.GetComponent<Blinky> ().speed = child.GetComponent<Blinky> ().initialSpeed;

			} else if (child.GetComponent<Pinky> ()){
				child.GetComponent<Pinky> ().frightened=false;
				child.GetComponent<Pinky> ().scatter=false;
//				child.GetComponent<Pinky> ().speed = child.GetComponent<Pinky> ().initialSpeed;

			} else if (child.GetComponent<Inky> ()){
				child.GetComponent<Inky> ().frightened=false;
				child.GetComponent<Inky> ().scatter=false;
//				child.GetComponent<Inky> ().speed = child.GetComponent<Inky> ().initialSpeed;

			} else if (child.GetComponent<Clyde> ()){
				child.GetComponent<Clyde> ().frightened=false;
				child.GetComponent<Clyde> ().scatter=false;
//				child.GetComponent<Clyde> ().speed = child.GetComponent<Clyde> ().initialSpeed;
			}
		}
	}

	void TurnOriginalColor(){
		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetChild(0).GetChild(0).GetComponent<Renderer> ().material = child.GetComponent<Blinky> ().origMaterial;
			} else if (child.GetComponent<Pinky> ()){
				child.GetChild(0).GetChild(0).GetComponent<Renderer> ().material = child.GetComponent<Pinky> ().origMaterial;
			} else if (child.GetComponent<Inky> ()){
				child.GetChild(0).GetChild(0).GetComponent<Renderer> ().material = child.GetComponent<Inky> ().origMaterial;
			} else if (child.GetComponent<Clyde> ()){
				child.GetChild(0).GetChild(0).GetComponent<Renderer> ().material = child.GetComponent<Clyde> ().origMaterial;
			}
		}
	}

	void SetSpeed(float sp){
		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetComponent<Blinky> ().speed = sp+2.0f;
			} else if (child.GetComponent<Pinky> ()){
				child.GetComponent<Pinky> ().speed = sp;
			} else if (child.GetComponent<Inky> ()){
				child.GetComponent<Inky> ().speed = sp;
			} else if (child.GetComponent<Clyde> ()){
				child.GetComponent<Clyde> ().speed = sp;
			}
		}
	}

	void level1(){
		
		SetSpeed (6.5f);

		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 7.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 5.0f & frightenedTimer < 7.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level2(){
		SetSpeed (6.7f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 6.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 4.0f & frightenedTimer < 6.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level3(){
		SetSpeed (6.8f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 3.0f & frightenedTimer < 5.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level4(){
		SetSpeed (6.9f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 3.0f & frightenedTimer < 5.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level5(){
		SetSpeed (6.5f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 6.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 4.0f & frightenedTimer < 6.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level6(){
		SetSpeed (7.0f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 6.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 4.0f & frightenedTimer < 6.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level7(){
		SetSpeed (7.1f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 3.0f & frightenedTimer < 5.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level8(){
		SetSpeed (7.3f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 3.0f & frightenedTimer < 5.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level9(){
		SetSpeed (7.4f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 4.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 2.0f & frightenedTimer < 4.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level10(){
		SetSpeed (7.0f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 6.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 4.0f & frightenedTimer < 6.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level11(){
		SetSpeed (7.5f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 3.0f & frightenedTimer < 5.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level12(){
		SetSpeed (7.7f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 4.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 2.0f & frightenedTimer < 4.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 18f) {
			Scatter ();
		} else if (timer > 18f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 45f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level13(){
		SetSpeed (7.7f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 3.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 1.0f & frightenedTimer < 3.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 18f) {
			Scatter ();
		} else if (timer > 18f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 45f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level14(){
		SetSpeed (7.8f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 1.0f & frightenedTimer < 3.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level15(){
		SetSpeed (7.5f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 2.0f & frightenedTimer < 4.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level16(){
		SetSpeed (7.7f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 5.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 3.0f & frightenedTimer < 5.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level17(){
		SetSpeed (7.7f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 4.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 2.0f & frightenedTimer < 4.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level18(){
		SetSpeed (7.8f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 4.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 2.0f & frightenedTimer < 4.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level19(){
		SetSpeed (7.9f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 4.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 2.0f & frightenedTimer < 4.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level20(){
		SetSpeed (8.0f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 3.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 1.0f & frightenedTimer < 3.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level21_plus5s(){

		SetSpeed (6.5f);

		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 7.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 5.0f & frightenedTimer < 7.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else if (timer > 21f & timer < 41f) {
			Chase ();
		} else if (timer > 41f & timer < 48f) {
			Scatter ();
		} else if (timer > 48f & timer < 68f) {
			Chase ();
		} else if (timer > 68f & timer < 75f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

	void level22_plus(){
		SetSpeed (8.0f);
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 3.0f) {
				frightened = false;
				TurnOriginalColor ();
				Chase ();
			} else if (frightenedTimer > 1.0f & frightenedTimer < 3.0f) {
				TurnWhite ();
			}
		}

		if (timer > 0f & timer < 14f) {
			Chase ();
		} else if (timer > 14f & timer < 21f) {
			Scatter ();
		} else {
			Chase ();
		}
	}

}
