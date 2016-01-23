using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void loadLevel(string name) {
		SceneManager.LoadScene(name);
	}

	public void quit() {
		Application.Quit();
	}
}
