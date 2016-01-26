using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer instance = null;

	void Awake() {
		if (instance == null) {
			GameObject.DontDestroyOnLoad(gameObject);
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}
}
