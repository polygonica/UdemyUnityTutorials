using UnityEngine;
using System.Collections;

public class NumberWizardScript : MonoBehaviour
{
	private int currentGuess = 500;
	private int maxnum = 1000;
	private int minnum = 1;
	private bool ready = false;

	// Use this for initialization
	void Start () {
		print("Welcome to Number Wizard");
		print("Pick a number in your head but don't tell me!");

		print("The highest number you can pick is " + maxnum);
		print("The lowest number you can pick is " + minnum);

		print("Is the number higher or lower than " + currentGuess + "?");
		print("Up = higher, down = lower, return = equal");
	}

	int min(int a, int b) {
		if (a <= b) {
			return a;
		} else {
			return b;
		}
	}

	int max(int a, int b) {
		if (a >= b) {
			return a;
		} else {
			return b;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			minnum = min(currentGuess + 1, maxnum); // min to avoid collapsing the range
			ready = true;
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			maxnum = max(currentGuess - 1, minnum); // max to avoid collapsing the range
			ready = true;
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print("I won!");
		}

		if (ready == true) {
			currentGuess = ((maxnum + minnum) / 2);
			print("Is the number higher or lower than " + currentGuess + "?");
			ready = false;
		}
	}
}
