using UnityEngine;
using System.Collections;

public class brick : MonoBehaviour {
	public static int breakableCount = 0;

	public int maxHits;
	public Sprite[] hitSprites;
	public GameObject smokeGameObject;

	public int timesHit { get; private set; }

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (this.tag == "breakable") breakableCount++;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (this.tag == "breakable") HandleHits();
	}

	void HandleHits() {
		if (++timesHit < maxHits) {
			LoadNextSprite();
		} else {
			AudioSource.PlayClipAtPoint(gameObject.GetComponent<AudioSource>().clip, transform.position);
			GameObject newSmoke = Instantiate(smokeGameObject, transform.position, Quaternion.identity) as GameObject;
			if (newSmoke != null) newSmoke.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			if (this.tag == "breakable") breakableCount--;
			if (breakableCount <= 0) levelManager.loadNextLevel();
			Destroy(gameObject);
		}
	}

	void LoadNextSprite() {
		if (hitSprites[timesHit - 1]) this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
	}
}
