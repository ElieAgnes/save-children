using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject player;
    public Camera camera;

    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;
    public bool chasePlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = false;

        if (!isVisible(camera, player) && !playerInAttackRange) Patroling();

        if (!chasePlayer){ 
            if (isVisible(camera, player) && !playerInAttackRange) {
                ChasePlayer();
                chasePlayer = true;
            }
        }
        else 
            ChasePlayer();
        //else if 
            //Fonction pour détacher et faire revenir au 
        // if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }


    bool isVisible (Camera cam, GameObject target){

        var planes = GeometryUtility.CalculateFrustumPlanes(cam);
        var point = target.transform.position;

        foreach (var plane in planes)
        {   
            if(plane.GetDistanceToPoint(point) < 0) return false;
        }
        return true;
    }

    private void Patroling()
    {
        
        Debug.Log("Hey");
    }

    private void ChasePlayer()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 10)  agent.SetDestination(player.transform.position);
        else chasePlayer = false;
        
        Debug.Log("Link");
    }

    private void AttackPlayer()
    {
        
        Debug.Log("Listen");
    }


}
