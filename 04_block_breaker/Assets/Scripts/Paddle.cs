using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	private float unitWidth = 0.0f;

	// Use this for initialization
	void Start () {
		unitWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			this.transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x/100f,
															  unitWidth/2,
															  (Screen.width/100f) - (unitWidth/2)),
												  this.transform.position.y,
												  this.transform.position.z);
		} else {
			this.transform.position = new Vector3(GameObject.FindObjectOfType<ball>().transform.position.x,
												  this.transform.position.y,
												  this.transform.position.z);
		}
	}
}
