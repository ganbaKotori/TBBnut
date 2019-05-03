using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    bool hasExploded = false;
    //public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    // Start is called before the first frame update
    void Start()
    {

    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "SquirrelPlayer")
        {

            collision.gameObject.GetComponent<Player>().TakeDamage(10);
            
            //Instantiate(explosionEffect, transform.position, transform.rotation);
           
            //Destroy(gameObject);

            //gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
