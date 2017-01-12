using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Blinky : MonoBehaviour {
//	private NavMeshAgent agent;
	public Transform goal;
	public float speed=6.8f;
	public float initialSpeed;
	public float frightenedSpeed;
	public Transform scatterGoal;
	public Material origMaterial;
	public bool death = false;

	private Waypoint wp;
	private Vector3 nextPoint;
	private Rigidbody rb;
	private float remainingDistance;
	private float dirNum;
	private float frontNum;
	private bool start = false;


	private Vector3 trueGoal;

	public bool scatter=false;
	public bool frightened=false;
	// Use this for initialization
	void Start () {
		origMaterial = transform.GetChild(0).GetChild(0).GetComponent<Renderer> ().material;
		rb = GetComponent<Rigidbody> ();

		wp = FindObjectOfType<Waypoint> ().GetComponent<Waypoint> ();
		initialSpeed = speed;
		frightenedSpeed = .5f * speed;
		scatter = false;
		nextPoint = wp.waypoints_list [66];

//		print(wp.waypoints_list.IndexOf(wp.waypoints_list [0]));
		transform.LookAt (nextPoint);
//		transform.position += transform.forward * Time.deltaTime * speed;
//		MoveTo (wp.waypoints_list [0]);
	}
	
	// Update is called once per frame
	void Update () {
		print (speed);
		if (death) {
			deathSequence ();
		}

		if (frightened) {
			print ("frightened");
			speed = frightenedSpeed;
		} else {
			speed = initialSpeed;
		}

		remainingDistance =Vector3.Distance(transform.position, nextPoint);
		if (remainingDistance < 0.5f & (transform.position.x < -50f || transform.position.x > 50f)) {
			transform.position = new Vector3 (-transform.position.x, transform.position.y, transform.position.z);
			MoveTo (nextPoint);

		} else if (remainingDistance < 0.5f) {
//			agent.destination = nextPoint;
			MoveTo (nextPoint);

		} else {
			transform.position += transform.forward * Time.deltaTime * speed;
		}

	}

	void MoveTo(Vector3 vec){
		if (scatter) {
			trueGoal = scatterGoal.position;
		} else {
			trueGoal = goal.position;
		}
//		print (wp.waypoints_list.Contains (vec));
		int pos = wp.waypoints_list.IndexOf (vec);

//		print (vec);
//		print (pos);
		List<float> distances = new List<float> ();
		foreach (Vector3 position in wp.waypoints_dict[pos]) {
//			print (position);

			Vector3 heading = position - vec;
//			dirNum = AngleDir(transform.forward, heading, transform.up);
			dirNum = Vector3.Dot(transform.right.normalized, heading.normalized);
			frontNum = Vector3.Dot(transform.forward.normalized, heading.normalized);
//			print (dirNum);
//			print (frontNum);
			if (dirNum > 0.5f || dirNum <-0.5f || frontNum > 0.5f) {
				var distance = Vector3.Distance (position, trueGoal);
//				print (distance);
				distances.Add (distance);
			} else {
//				print("added 10000");
				distances.Add (100000f);
			}

		}
//		print (distances.IndexOf (distances.Min ()));
		List<Vector3> nextList = wp.waypoints_dict [pos];

		if (frightened) {
			int num = Random.Range (0, nextList.Count ()-1);
			nextPoint = nextList[num];
		} else {
			nextPoint = nextList [distances.IndexOf (distances.Min ())];
		}	

		remainingDistance =Vector3.Distance(transform.position, nextPoint);

		transform.LookAt (nextPoint);
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp.normalized, up.normalized);

		if (dir > 0f) {
			return 1f;
		} else if (dir < 0f) {
			return -1f;
		} else {
			return 0f;
		}
	}

	public void FrightenedGhost(){
		speed = speed * .5f;
	}


	IEnumerator DeathFuntion(){
		nextPoint = wp.waypoints_list [66];

		yield return new WaitForSeconds (1);

		MoveTo (nextPoint);
		start = true;
	}

	public void deathSequence(){
		death = true;
		if (Vector3.Distance (transform.position, wp.waypoints_list [67]) < .3f) {
			death = false;
			transform.position = wp.waypoints_list [67];
			transform.GetChild (0).GetChild (0).gameObject.SetActive (true);
			nextPoint = wp.waypoints_list [66];
			StartCoroutine (DeathFuntion());
		} else {
			transform.LookAt (wp.waypoints_list [67]);
			transform.position += transform.forward * Time.deltaTime * speed;
		}

	}
}
