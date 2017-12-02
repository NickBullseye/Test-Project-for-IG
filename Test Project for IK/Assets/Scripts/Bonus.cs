using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

	public string bonusType;


	void Start() {
		Destroy (gameObject, 10f);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.GetComponent<MouseController> ().BonusPickedUp (bonusType);
			Destroy (gameObject);
		}
	}
}
