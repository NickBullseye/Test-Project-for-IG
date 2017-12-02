using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseZone : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ball") {
			if (GameManager.Instance.amountOfBallsLive > 1) {
				GameManager.Instance.amountOfBallsLive--;
				Destroy (other.gameObject);
			} else {
				if (GameManager.Instance.BallDropped ()) {
					other.GetComponent<Ball> ().ResetBall ();
				}
			}
		}
	}

}
