using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 30f;
    public float shootTimer = 5f;
    Transform target;
    NavMeshAgent agent;
    public GameObject Player;
    public Rigidbody rocketPrefab;
    public Transform barrelEnd;
    float timer;

    private bool _isDead = false;
    public bool isDead;

    [SerializeField]
    public float startHealth = 100;

    private float health;


    private float currentHealth;



    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.gameObject.transform;
        agent = GetComponent<NavMeshAgent>();
        timer = 0;
        health = startHealth;
    }

    public void Setup()
    {
        SetDefaults();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
            if (timer > 3.0f)
            {
                StartCoroutine(Shoot());
                timer = 0;
            }   



        }

        
    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage(int _amount)
    {
        if (isDead)
            return;
        health -= _amount;
        

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Destroy(gameObject);

    }


    IEnumerator Shoot()
    {
        Rigidbody rocketInstance;
        rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
        rocketInstance.AddForce(barrelEnd.forward * 5000);
        //Player.GetComponent<Player>().TakeDamage(10);
       
        yield return new WaitForSeconds(2);
    }

    public void SetDefaults()
    {
        isDead = false;
        currentHealth = startHealth;
    }

}