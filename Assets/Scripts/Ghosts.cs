using UnityEngine;
using System.Collections;

public class Ghosts : MonoBehaviour {
	private float timer = 0.0f;
	private float frightenedTimer;
	private bool frightened=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (frightened) {
			frightenedTimer += Time.deltaTime;
			if (frightenedTimer > 6.0f) {
				frightened = false;
				Chase ();
				foreach (Transform child in transform){
					if (child.GetComponent<Blinky> ()) {
						
						child.GetComponent<Blinky> ().speed=child.GetComponent<Blinky> ().initialSpeed;

					} else if (child.GetComponent<Pinky> ()){
						child.GetComponent<Pinky> ().speed=child.GetComponent<Pinky> ().initialSpeed;
					} else if (child.GetComponent<Inky> ()){
						child.GetComponent<Inky> ().speed=child.GetComponent<Inky> ().initialSpeed;
					} else if (child.GetComponent<Clyde> ()){
						child.GetComponent<Clyde> ().speed=child.GetComponent<Clyde> ().initialSpeed;
					}
				}
			}
		}

		timer += Time.deltaTime;
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
		frightened = true;
		frightenedTimer = 0f;
		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetComponent<Blinky> ().frightened=true;
			} else if (child.GetComponent<Pinky> ()){
				child.GetComponent<Pinky> ().frightened=true;
			} else if (child.GetComponent<Inky> ()){
				child.GetComponent<Inky> ().frightened=true;
			} else if (child.GetComponent<Clyde> ()){
				child.GetComponent<Clyde> ().frightened=true;
			}
		}
	}

	public void Chase(){

		foreach (Transform child in transform){
			if (child.GetComponent<Blinky> ()) {
				child.GetComponent<Blinky> ().frightened=false;
				child.GetComponent<Blinky> ().scatter=false;
			} else if (child.GetComponent<Pinky> ()){
				child.GetComponent<Pinky> ().frightened=false;
				child.GetComponent<Pinky> ().scatter=false;
			} else if (child.GetComponent<Inky> ()){
				child.GetComponent<Inky> ().frightened=false;
				child.GetComponent<Inky> ().scatter=false;
			} else if (child.GetComponent<Clyde> ()){
				child.GetComponent<Clyde> ().frightened=false;
				child.GetComponent<Clyde> ().scatter=false;
			}
		}
	}
}
