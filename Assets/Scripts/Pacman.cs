using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour {
	private AudioSource source;
	private ScoreKeeper sk;
	private Ghosts ghosts;
	// Use this for initialization
	void Start () {
		sk = FindObjectOfType<ScoreKeeper> ();
		source = GetComponent<AudioSource> ();
		ghosts = FindObjectOfType<Ghosts> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.GetComponent<Biscuit> ()) {
			source.Play ();
			sk.IncrementScore (col.gameObject.GetComponent<Biscuit> ().value);
//			GetComponent<Movement>().speed=.9*GetComponent<Movement>().speed
			Destroy (col.gameObject);

		} else if (col.gameObject.GetComponent<PowerPellet> ()) {
			ghosts.Frightened ();
			col.gameObject.GetComponent<PowerPellet> ().SuperPower ();
			sk.IncrementScore (col.gameObject.GetComponent<PowerPellet> ().value);
			Destroy (col.gameObject);

			//DEATH
		} else if (col.gameObject.GetComponent<Ghost>()& ghosts.frightened){
			col.transform.GetChild (0).GetChild (0).gameObject.SetActive (false);
			if (col.gameObject.GetComponent<Blinky> ()) {
				col.gameObject.GetComponent<Blinky> ().deathSequence ();
			} else if (col.gameObject.GetComponent<Pinky> ()){
				col.gameObject.GetComponent<Pinky> ().deathSequence ();
			} else if (col.gameObject.GetComponent<Inky> ()){
				col.gameObject.GetComponent<Inky> ().deathSequence ();
			} else if (col.gameObject.GetComponent<Clyde> ()){
				col.gameObject.GetComponent<Clyde> ().deathSequence ();
			}
			if (ghosts.ghostsKilled == 0) {
				sk.IncrementScore (200);
				ghosts.ghostsKilled++;
			} else if (ghosts.ghostsKilled == 1) {
				sk.IncrementScore (400);
				ghosts.ghostsKilled++;
			} else if (ghosts.ghostsKilled == 2) {
				sk.IncrementScore (800);
				ghosts.ghostsKilled++;
			} else if (ghosts.ghostsKilled == 3) {
				sk.IncrementScore (1600);
				ghosts.ghostsKilled++;
			}
		}
	}
}
