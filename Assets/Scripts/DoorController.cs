using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

    GameObject avatar;
    public GameObject UnlockerSystem;
    bool actionOn = false;
    public Color colorOn,colorOff;
    bool state = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (avatar != null)
        {
            if (actionOn)
            {
             //   avatar.GetComponent<IKControl>().ikActive = true;
             //   avatar.GetComponent<IKControl>().blend = Mathf.Lerp(avatar.GetComponent<IKControl>().blend, 0.9f, 5f * Time.deltaTime);
            }
            else
            {
                
              //  avatar.GetComponent<IKControl>().blend = Mathf.Lerp(avatar.GetComponent<IKControl>().blend, 0f, 4f * Time.deltaTime);
            }

            //if (avatar.GetComponent<IKControl>().blend < 0.01)
            //{
            //    avatar.GetComponent<IKControl>().ikActive = false;
            //}
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                //actionOn = !actionOn;
                StartCoroutine(gotoButton(0.5f));
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(pushButton(1f));
        }

        //Open the door when the lock is unlock
        if (!UnlockerSystem.GetComponent<UnlockByNumber>().IsLock && !state)
        {
            StartCoroutine(pushButton(0.1f));
        }

        if (UnlockerSystem.GetComponent<UnlockByNumber>().IsLock && state)
        {
            StartCoroutine(pushButton(0.1f));
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Avatar") {
            avatar = other.gameObject;
           // avatar.GetComponent<IKControl>().lookObj = button.transform;
           // avatar.GetComponent<IKControl>().rightHandObj = IKhandler.transform; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Avatar")
        {
            // other.GetComponent<IKControl>().ikActive = false;
            avatar = null;
            actionOn = false;
        }
    }

    IEnumerator gotoButton(float time) {
        actionOn = true;
        yield return new WaitForSeconds(time);
        StartCoroutine(pushButton(1f));
    }

    IEnumerator pushButton(float time) {
        //anim pushButton
        //  UnlockerSystem.GetComponent<Animation>().Play("PushButtonIn_switch");
        state = !state;
        yield return new WaitForSeconds(time);
        Color c = (state)?colorOn:colorOff;
      //  UnlockerSystem.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor",c);
        //transform.Find("DoorLight").GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", c);
        Transform doorLights = transform.Find("DoorLights");
        for(int i = 0; i< doorLights.childCount; ++i)
        {
            doorLights.GetChild(i).GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", c); ;
        }
        transform.Find("Door").GetComponent<Animator>().SetBool("State",state);
      //  UnlockerSystem.GetComponent<Animation>().Play("PushButtonOut_switch");

        actionOn = false;
      
    }


}
