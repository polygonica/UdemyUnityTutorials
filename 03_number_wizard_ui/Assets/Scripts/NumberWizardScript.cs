using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizardScript : MonoBehaviour
{
	private int currentGuess = 500;
	private int maxnum = 1000;
	private int minnum = 1;
	private int _guessesLeft = 10;

	public Text guessText;

	// Use this for initialization
	void Start () {
		nextGuess();
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

	public void guessHigher() {
		minnum = min(currentGuess + 1, maxnum); // avoid raising the minnum above maxnum
		nextGuess();
	}

	public void guessLower() {
		maxnum = max(currentGuess - 1, minnum); // avoid lowering the maxnum below minnum
		nextGuess();
	}

	private void nextGuess() {
		if (--_guessesLeft < 0) SceneManager.LoadScene("Win");
		currentGuess = Random.Range(minnum, maxnum + 1); // min inclusive, max exclusive
		guessText.text = currentGuess.ToString();
	}
}
