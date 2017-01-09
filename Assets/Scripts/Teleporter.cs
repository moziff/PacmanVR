using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.GetComponent<Blinky> ()) {
			print (col.GetComponent<Blinky> ().speed);
			col.GetComponent<Blinky> ().speed = col.GetComponent<Blinky> ().speed * .5f;
			print (col.GetComponent<Blinky> ().speed);
		} else if (col.GetComponent<Pinky> ()){
			col.GetComponent<Pinky> ().speed = col.GetComponent<Pinky> ().speed * .5f;
		} else if (col.GetComponent<Inky> ()){
			col.GetComponent<Inky> ().speed = col.GetComponent<Inky> ().speed * .5f;
		} else if (col.GetComponent<Clyde> ()){
			col.GetComponent<Clyde> ().speed = col.GetComponent<Clyde> ().speed * .5f;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.GetComponent<Blinky> ()) {
			
			col.GetComponent<Blinky> ().speed = col.GetComponent<Blinky> ().speed * 2;
			print (col.GetComponent<Blinky> ().speed);
		} else if (col.GetComponent<Pinky> ()){
			col.GetComponent<Pinky> ().speed = col.GetComponent<Pinky> ().speed * 2;
		} else if (col.GetComponent<Inky> ()){
			col.GetComponent<Inky> ().speed = col.GetComponent<Inky> ().speed * 2;
		} else if (col.GetComponent<Clyde> ()){
			col.GetComponent<Clyde> ().speed = col.GetComponent<Clyde> ().speed * 2;
		}
	}
}
