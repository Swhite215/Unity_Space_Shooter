using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource audio;

	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireDelta = 0.5f;
	public float nextFire = 0.5f;
	private float myTime = 0.0f;

	public Boundary boundary;

	void Start() 
	{
		rb = GetComponent<Rigidbody> ();
		audio = GetComponent<AudioSource> ();

	}

	void Update() 
	{
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton ("Fire1") && myTime > nextFire) 
		{
			nextFire = myTime + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			nextFire = nextFire - myTime;
			myTime = 0.0f;

			audio.Play ();
		}
	}

	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

		rb.velocity = movement;

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x,boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}


}
