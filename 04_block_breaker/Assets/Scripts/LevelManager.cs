using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void loadLevel(string name) {
		SceneManager.LoadScene(name);
		brick.breakableCount = 0;
	}

	public void loadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void quit() {
		Application.Quit();
	}
}
