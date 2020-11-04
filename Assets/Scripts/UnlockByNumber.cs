using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockByNumber : MonoBehaviour {
    public int numberToReach;
    private int numberDetected;
    private bool isLock = true;
    public TextMesh text;

    public bool IsLock
    {
        get
        {
            return isLock;
        }
    }

    // Use this for initialization
    void Start () {
        numberDetected = 0;
        text.text = numberToReach.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Number Detected : " + numberDetected);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character") || other.CompareTag("Player"))
        {
            ++numberDetected;
            if(numberDetected == numberToReach)
            {
                isLock = false;

            }
        }
        text.text = Mathf.Clamp((numberToReach - numberDetected), 0, numberToReach).ToString();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character") || other.CompareTag("Player"))
        {
            --numberDetected;
            if (numberDetected < numberToReach)
            {
                isLock = true;
            }
        }
        text.text = Mathf.Clamp((numberToReach - numberDetected), 0, numberToReach).ToString();
    }
}
