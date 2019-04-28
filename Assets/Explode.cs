using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    bool hasExploded = false;
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
           // Instantiate(explosionEffect, transform.position, transform.rotation);
            Collider[] colliders =  Physics.OverlapSphere(transform.position,radius);

            foreach(Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position,radius);
                }
            }
            Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
