using UnityEngine;
using System.Collections;

public class Edibles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool RoundOver(){
		if (transform.childCount == 0) {
			return true;
		} else {
			return false;
		}
	}
}
