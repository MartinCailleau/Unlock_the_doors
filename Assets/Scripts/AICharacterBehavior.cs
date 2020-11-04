using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public enum AIState { Follow,Stay,Wait}

public class AICharacterBehavior : MonoBehaviour {
    public AIState currentState = AIState.Wait;
    public Transform target;

    private AICharacterControl control;
	// Use this for initialization
	void Start () {
        currentState = AIState.Wait;
        control = GetComponent<AICharacterControl>();

    }
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case AIState.Follow:
                control.target = target;
            break;
            case AIState.Stay:
                control.target = null;
            break;
            case AIState.Wait:
                control.target = null;
            break;

        }
    }

    void nextState(AIState newState){
        //switch(newState){
        //..case...
        //}

        currentState = newState;
    }
}
