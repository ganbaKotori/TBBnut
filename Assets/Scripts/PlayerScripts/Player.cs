using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }

    [SerializeField]
    private int maxHealth = 100;


    private int currentHealth;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    void Update()
    {
 

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(99999);
        }
    }

    public void Setup()
    {
        SetDefaults();
    }

    public void TakeDamage(int _amount)
    {
        if (isDead)
            return;
        currentHealth -= _amount;
        Debug.Log(transform.name + " now has " + currentHealth + " health.");

        if(currentHealth <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Debug.Log(transform.name + "is DEAD!");

        //CALL RESPAWN METHOD
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);

        SetDefaults();
        player.transform.position = respawnPoint.transform.position;
    }

    public void SetDefaults()
    {
        isDead = false;
        currentHealth = maxHealth;
    }
}
