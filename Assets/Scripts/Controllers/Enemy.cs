using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Health = 40f;

    private NavMeshAgent _navMeshAgent;

    public GameObject Player;

    Transform target;



    public float AttackDistance = 10.0f;

    public float FollowDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 5f;

    public float DamagePoints = 2.0f;

    public GameObject acorn;



    public Transform[] patrolPoints;

    private int currentControlPointIndex = 0;

    public void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.gameObject.transform;
        MoveToNextPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(target.position, transform.position);

            bool shoot = false;
            bool patrol = false;
            bool follow = (dist < FollowDistance);

            if (follow)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - AttackProbability) && dist < AttackDistance)
                {
                    shoot = true;
                    
                }

                _navMeshAgent.SetDestination(Player.transform.position);
            }

            patrol = !follow && !shoot && patrolPoints.Length > 0;

            if ((!follow || shoot) && !patrol)
                _navMeshAgent.SetDestination(transform.position);

            // Patrolling between points if there are patrol points
            if (patrol)
            {
                if (!_navMeshAgent.pathPending &&
                    _navMeshAgent.remainingDistance < 0.5f)
                    MoveToNextPatrolPoint();
            }

            

        }
    }


    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            _navMeshAgent.destination = patrolPoints[currentControlPointIndex].position;

            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
        }
    }

    public void ShootEvent()
    {

        float random = Random.Range(0.0f, 1.0f);
        

        // The higher the accuracy is, the more likely the player will be hit
        bool isHit = random > 1.0f - HitAccuracy;

        if (isHit)
        {

            Player.GetComponent<Player>().TakeDamage(10);

        }
    }

    


    public void TakeDamage(float amount)
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
