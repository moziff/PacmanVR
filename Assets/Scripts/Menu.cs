using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	private float trueTime;
	// Use this for initialization
	void Start () {
		trueTime = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Pause(){
		Time.timeScale = 0.0f;
	}
	public void Unpause(){
		Time.timeScale = trueTime;
	}
}
