using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterraction : MonoBehaviour, InterractorInterface
{

    [SerializeField] private string openText;
    [SerializeField] private string closeText;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private Animator myDoor = null;

    private string test;
    public string InteractionPrompt => test;

    public bool Interact(Player interactor)
    {
        if(isOpen)
        {
            myDoor.Play("DoorOpen", 0, 0.0f);
            isOpen = false;
            test = closeText;
        }
        else
        {
            myDoor.Play("DoorClose", 0, 0.0f);
            isOpen = true;
            test = openText;
        }
        return true;
    }
}
