using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICommandment : MonoBehaviour {
    public float broadcastRadius;
    public Transform selectionHelper;

    private float broadcastPower = 0;
    private Vector3 selectionHelperInitialScale = new Vector3(0,1,0);

    private List<AICharacterBehavior> AIControled = new List<AICharacterBehavior>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            if((broadcastPower + 0.1f) < 1)
            {
                broadcastPower += 0.02f;

                //Debug.Log("BroadcastPower : "+ broadcastRadius * broadcastPower);
            }
            updateBroadcastZone();
            searchAI();
        }
        else
        {
            broadcastPower = 0;
            selectionHelper.transform.localScale = Vector3.Lerp(selectionHelper.transform.localScale, selectionHelperInitialScale, 0.2f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            sayStay();
        }
        

    }

    void updateBroadcastZone()
    {
        selectionHelper.transform.localScale = new Vector3(broadcastRadius * broadcastPower, 
                                                selectionHelper.transform.localScale.y, 
                                                broadcastRadius * broadcastPower);
    }

    void searchAI()
    {
        Collider[] characters = Physics.OverlapSphere(selectionHelper.position,selectionHelper.localScale.x/2, 1<<8);
      
        Debug.Log("Search AI : " + characters.Length);
        foreach(Collider character in characters)
        {
            character.GetComponent<AICharacterBehavior>().currentState = AIState.Follow;
            if (!AIControled.Contains(character.GetComponent<AICharacterBehavior>()))
            {
                AIControled.Add(character.GetComponent<AICharacterBehavior>());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(selectionHelper.position, selectionHelper.localScale.x / 2);
    }

    void sayStay()
    {
        foreach (AICharacterBehavior ai in AIControled)
        {
            ai.currentState = AIState.Stay;
        }
    }
}
