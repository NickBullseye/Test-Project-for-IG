using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {


	public int hitsToBreak;

	private int timesHit = 0;

	void OnCollisionEnter2D(Collision2D coll) {
		timesHit++;
	}


}
