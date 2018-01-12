using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShots : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		if (gameControllerObject == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}

	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			Instantiate (explosion, transform.position, transform.rotation);
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

			gameController.GameOver ();

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
			


	}
}
