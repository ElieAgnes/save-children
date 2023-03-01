using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInterractor : MonoBehaviour, InterractorInterface
{
    public string InteractionPrompt => "Eat";
    public bool Interact(Player interactor)
    {
        interactor.Feed(10.0f);
        Debug.Log("Feeded Player");
        Destroy(this.gameObject);
        return true;
    }
}
