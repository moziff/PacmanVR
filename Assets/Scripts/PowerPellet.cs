using UnityEngine;
using System.Collections;

public class PowerPellet : MonoBehaviour {
	public GameObject insideWalls;
	public GameObject redPath;
	// Use this for initialization

	public int value =50; 

	void Start () {
		insideWalls = GameObject.Find("Inside");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SuperPower(){
		print ("wooho");
		var color = insideWalls.GetComponentInChildren<Renderer> ().material.color;
		color.a -= 0.1f;
		insideWalls.GetComponentInChildren<Renderer> ().material.SetColor("_Color", color);


//		foreach(GameObject child in insideWalls)
//		{
//			var color = child.GetComponent<Renderer>().material.color; 
//			
//		foreach(GameObject child in redPath)
//		{
//			child.transform.position = new Vector3 (child.transform.position.x, 0.5f, child.transform.position.z);
//		}
	}
}
