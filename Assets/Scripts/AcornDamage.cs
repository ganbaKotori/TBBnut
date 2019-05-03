using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornDamage : MonoBehaviour
{
    bool hasExploded = false;
    private AudioManager audioManager;
    //public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            Collider[] colliders =  Physics.OverlapSphere(transform.position,radius);

            foreach(Collider nearbyObject in colliders)
            {

                if (nearbyObject.gameObject.name == "Giraffe")
                {

                    
                    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, radius);
                        collision.gameObject.GetComponent<EnemyController>().TakeDamage(100);
                    }


                }
                
            }
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
