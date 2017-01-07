using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Blinky : MonoBehaviour {
//	private NavMeshAgent agent;
	public Transform goal;
	public float speed=7;

	private Waypoint wp;
	private Vector3 nextPoint;
	private Rigidbody rb;
	private float remainingDistance;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

		wp = FindObjectOfType<Waypoint> ().GetComponent<Waypoint> ();

//		agent = GetComponent<NavMeshAgent>();

		nextPoint = wp.waypoints_list [0];

//		print(wp.waypoints_list.IndexOf(wp.waypoints_list [0]));
		transform.LookAt (nextPoint);
//		transform.position += transform.forward * Time.deltaTime * speed;
//		MoveTo (wp.waypoints_list [0]);
	}
	
	// Update is called once per frame
	void Update () {
		remainingDistance =Vector3.Distance(transform.position, nextPoint);
		if (remainingDistance < 0.5f) {
//			agent.destination = nextPoint;
			MoveTo (nextPoint);
			transform.position += transform.forward * Time.deltaTime * speed;
		} else {
			transform.position += transform.forward * Time.deltaTime * speed;
		}

	}

	void MoveTo(Vector3 vec){
		
//		print (wp.waypoints_list.Contains (vec));
		int pos = wp.waypoints_list.IndexOf (vec);

//		print (vec);
//		print (pos);
		List<float> distances = new List<float> ();
		foreach (Vector3 position in wp.waypoints_dict[pos]) {
//			print (position);
			var distance = Vector3.Distance(position, goal.position);
			distances.Add (distance);
		}
//		print (distances.IndexOf (distances.Min ()));
		List<Vector3> nextList = wp.waypoints_dict [pos];

		nextPoint = nextList [distances.IndexOf (distances.Min ())];

		remainingDistance =Vector3.Distance(transform.position, nextPoint);

		transform.LookAt (nextPoint);

	}
}
