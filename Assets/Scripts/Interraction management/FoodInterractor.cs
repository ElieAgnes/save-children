using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInteractor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("_Player"))
        {
            Debug.Log("MA GUEULE");
            
        }
    }
}