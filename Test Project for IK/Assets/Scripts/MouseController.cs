using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
	
	[SerializeField]	float minX;
	[SerializeField]	float maxX;


	void Update () {
		Vector2 playerPos = new Vector2 (0f, this.transform.position.y);
		float mousePos = Input.mousePosition.x / Screen.width * 16;
		playerPos.x = Mathf.Clamp (mousePos, minX, maxX);
		this.transform.position = playerPos;
	}
}
