using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainLetter : MonoBehaviour
{
    public bool isTaken;

    void Start()
    {
        isTaken = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
       
        {
            
            isTaken = true;
            gameObject.SetActive(false);

        }
    }




}
