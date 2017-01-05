using UnityEngine;
using System.Collections;

public class Blinky : MonoBehaviour {
	private NavMeshAgent agent;
	public Transform goal;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
//		agent.destination = goal.position;
	}
}
