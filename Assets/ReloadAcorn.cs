using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAcorn : MonoBehaviour
{
    public bool isHere;
    private AudioManager audioManager;

    void Start()
    {
        isHere = false;
        audioManager = AudioManager.instance;
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        isHere = true;
        if (collision.gameObject.name == "SquirrelPlayer")
        {
            if (isHere)
            {
                collision.gameObject.GetComponent<PlayerMovement>().acornCount += 1;
                audioManager.PlaySound("Squirrel");
            }
            

            //Instantiate(explosionEffect, transform.position, transform.rotation);

            //Destroy(gameObject);

            //gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit()
    {
        isHere = false;
       
    }




}