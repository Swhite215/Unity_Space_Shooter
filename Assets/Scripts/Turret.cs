using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform ship;
	private Rigidbody rb;
	private Vector3 sight;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		sight = new Vector3 (ship.position.x, ship.position.y, ship.position.z);
		//rb.transform.LookAt (2 * ship.position - rb.transform.position);
		rb.transform.LookAt(sight, Vector3.left);
	}
}
