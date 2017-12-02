using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {


	public int hitsToBreak;

	private int timesHit = 0;
	private SpriteRenderer sprR;

	void Awake() {
		sprR = GetComponent<SpriteRenderer> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		timesHit++;
		int hitsLeft = hitsToBreak - timesHit;
		switch (hitsLeft) {
		case 0:
			GameManager.Instance.IncrementScoreAndCheckForGW ();
			Destroy (gameObject);
			break;
		case 1:
			sprR.color = Color.green;
			break;
		case 2:
			sprR.color = Color.yellow;
			break;
		default: 
			break;
		}
	}


}
