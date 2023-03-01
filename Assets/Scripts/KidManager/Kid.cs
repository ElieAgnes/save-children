using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour, InterractorInterface
{
    public string InteractionPrompt => "Save";
    public bool Interact(Player interactor)
    {
        interactor.SaveKid();
        Destroy(this.gameObject);
        Debug.Log("Saved 1 kid");
        return true;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
        Debug.Log("Saved 1 kid");
    }
}
