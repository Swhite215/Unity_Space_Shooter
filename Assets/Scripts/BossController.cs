using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	private Rigidbody rb;
	public GameObject explosion;
	private Animator animator;
	public int hitPoints;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if (hitPoints == 10) {
			animator.SetInteger ("State", 2);
		} else if (hitPoints <= 0) 
		{
			Instantiate (explosion, rb.transform.position, rb.transform.rotation);
			Destroy(gameObject);

			gameController.GameOver ();
		}
	}

	void FixedUpdate() {
				
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Bolt") 
		{
			hitPoints = hitPoints - 1;

			Instantiate (explosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
		}

	}
}
