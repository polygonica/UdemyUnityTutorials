using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool launched;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		launched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!launched) {
			this.transform.position = paddle.transform.position + paddleToBallVector; // lock the ball to the paddle
			if (Input.GetMouseButtonDown(0)) {
				print("mouse0");
				launched = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(paddleToBallVector.x, paddleToBallVector.y).normalized * 8;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 randomTweak = new Vector2(Random.Range(-0.2f, 0.2f),Random.Range(-0.2f, 0.2f));
		GetComponent<Rigidbody2D>().velocity += randomTweak;
		if (launched) {
			brick collidedBrick = collision.gameObject.GetComponent<brick>();
			if ((collidedBrick == null) || (collidedBrick.timesHit < collidedBrick.maxHits)) {
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
