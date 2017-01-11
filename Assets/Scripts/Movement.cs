using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed=8;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
//			print ("triggered");
			transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
		}
		if (transform.position.x < -50f || transform.position.x > 50f) {
			transform.position = new Vector3 (-transform.position.x, transform.position.y, transform.position.z);
		}

	}

	public void Move(){
		transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
	}
}
