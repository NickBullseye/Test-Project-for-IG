using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {

	public static GlobalManager Instance;
	public enum Controls {
		mouse,
		auto
		}
	public Controls selectedControls;

	void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
			selectedControls = Controls.mouse;
		} else if (Instance != null) {
			Destroy (gameObject);
		}
	}


}
