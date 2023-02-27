using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterractorInterface
{
    public string InteractionPrompt {get;}

    public bool Interact(Player interactor);
}
