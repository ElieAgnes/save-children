using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInterractor : MonoBehaviour, InterractorInterface
{
    
    public string InteractionPrompt => "Eat";
    public bool Interact(Player interactor)
    {
        

        return true;
    }
}
