using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("_Player"))
        {
            if(openTrigger)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
