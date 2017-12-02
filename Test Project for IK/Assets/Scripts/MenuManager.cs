using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public static MenuManager Instance;

	void Awake() {
		if (Instance == null) {
			Instance = this;
		} else if (Instance != null) {
			Destroy (gameObject);
		}
	}

	public void Play() {
		GlobalManager.Instance.selectedControls = GlobalManager.Controls.mouse;
		SceneManager.LoadScene ("Level_1");
	}

	public void Test() {
		GlobalManager.Instance.selectedControls = GlobalManager.Controls.auto;
		SceneManager.LoadScene ("Level_1");
	}
}
