using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;
    [SerializeField] private DoorInterractionUI interractionUI = null;
    [SerializeField] private Player playerManager = null;
    private InterractorInterface interactable;

    private void Update() 
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask.value);
        // Debug.Log(_numFound);
        if(_numFound > 0)
        {
            interactable = _colliders[0].GetComponent<InterractorInterface>();
            // Debug.Log(interactable);
            if(interactable != null)
            {
                if(!interractionUI.isDisplayed) interractionUI.activate(interactable.InteractionPrompt);

                if(Input.GetKeyDown(KeyCode.F)) interactable.Interact(playerManager);
            }
        }
        else{
            if(interractionUI.isDisplayed) interractionUI.disable();
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}