﻿using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour {

	private ScoreKeeper sk;
	// Use this for initialization
	void Start () {
		sk = FindObjectOfType<ScoreKeeper> ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.GetComponent<Biscuit> ()) {
			sk.IncrementScore (col.gameObject.GetComponent<Biscuit> ().value);
//			GetComponent<Movement>().speed=.9*GetComponent<Movement>().speed
			Destroy (col.gameObject);
		} else if (col.gameObject.GetComponent<PowerPellet> ()) {
			col.gameObject.GetComponent<PowerPellet> ().SuperPower ();
			sk.IncrementScore (col.gameObject.GetComponent<PowerPellet> ().value);
			Destroy (col.gameObject);
		}
	}
}
