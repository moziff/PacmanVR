using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		print ("triggered");
		col.transform.position = new Vector3 (-col.transform.position.x, col.transform.position.y, col.transform.position.z);
	}
}
