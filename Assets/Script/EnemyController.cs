using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject player;
    public Camera camera;
    public Transform [] patrolPoint;
    
    public int targetPoint = 0;
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

        if (!isVisible(camera, player) && !playerInAttackRange) Patroling(); //If player isnt see, patrol

        if (isVisible(camera, player) && !playerInAttackRange) ChasePlayer();

        //else 
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
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds);
    }

    private void Patroling()
    {
        
        Debug.Log("Hey " + targetPoint);

        if(transform.position == patrolPoint[targetPoint].position){
            
            targetPoint++;
            if (targetPoint >= patrolPoint.Length) targetPoint = 0;
        }

        agent.SetDestination(patrolPoint[targetPoint].position);
    }

    private void ChasePlayer()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position); //Check distance between ennemi and player

        if (distance < 10) {
            agent.SetDestination(player.transform.position);
        } 
        //else take position for patrol

    }

    private void AttackPlayer()
    {
        
        Debug.Log("Listen");
    }


}
