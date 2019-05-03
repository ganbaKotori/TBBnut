﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<Player>().TakeDamage(99999);
    }
}
