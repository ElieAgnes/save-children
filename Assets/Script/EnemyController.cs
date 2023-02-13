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
    public float escapeRange, attackRange, cooldownAttack;
    private float distancePlayer, lastAttack;
    public bool purchasingPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayer = Vector3.Distance(transform.position, player.transform.position); //Check distance between ennemi and player

        if (attackRange > distancePlayer) AttackPlayer();
        else if (isVisible(camera, player) && distancePlayer < escapeRange || purchasingPlayer) ChasePlayer();
        else if (!isVisible(camera, player)) Patroling(); //If player isnt see, patrol

    }


    bool isVisible (Camera cam, GameObject target)
    {

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
        if(transform.position == patrolPoint[targetPoint].position){
            
            targetPoint++;
            if (targetPoint >= patrolPoint.Length) targetPoint = 0;
        }

        agent.SetDestination(patrolPoint[targetPoint].position);
    }

    private void ChasePlayer()
    {
        if (distancePlayer > escapeRange)
        {
            purchasingPlayer = false;
            
            //Step for give up purchase
            
        } else if (!purchasingPlayer)
        {
            purchasingPlayer = true;

            //Step for engage purchase
        }

        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        if(Time.time - lastAttack > cooldownAttack){
            lastAttack = Time.time;
            Debug.Log("Bonk"); //LE JOUEUR PERD DES PV LA SUITE AU PROCHAIN EPISODE
        }
    }


}
