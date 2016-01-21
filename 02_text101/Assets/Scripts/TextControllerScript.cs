using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControllerScript : MonoBehaviour {
	public Text text;
	public FiniteStateMachine stateMachine;

	// Use this for initialization
	private void Start() {
		State stateOne = new State("There was a dark cell. Press C to go to the corner");
		State stateTwo = new State("There was a dark corner of a dark cell. Press B to go to go back");
		stateOne.nextStates.Add(KeyCode.C, stateTwo);
		stateTwo.nextStates.Add(KeyCode.B, stateOne);
		stateMachine = new FiniteStateMachine(stateOne);
		stateMachine.states.Add(stateTwo);
		text.text = stateMachine.currentState.description;
	}

	// Update is called once per frame
	private void Update() {
		foreach (KeyCode key in stateMachine.currentState.nextStates.Keys) {
			if (Input.GetKeyDown(key)) {
				stateMachine.currentState.nextStates.TryGetValue(key, out stateMachine.currentState);
				text.text = stateMachine.currentState.description;
				break;
			}
		}
	}
}

public class FiniteStateMachine {
	public List<State> states;
	public State initialState;
	public State currentState;

	public FiniteStateMachine(State initialState) {
		states = new List<State> {initialState};
		this.initialState = initialState;
		currentState = initialState;
	}
}

public class State {
	public string description;
	public Dictionary<KeyCode, State> nextStates;

	public State(string description) {
		this.description = description;
		nextStates = new Dictionary<KeyCode, State>();
	}
}