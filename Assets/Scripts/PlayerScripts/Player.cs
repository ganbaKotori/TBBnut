using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }

    [SerializeField]
    public float startHealth = 100;

    private float health;


    private float currentHealth;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform respawnPoint;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
    }


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
        health -= _amount;
        Debug.Log(transform.name + " now has " + health + " health.");
        healthBar.fillAmount = health / startHealth;

        if(health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Debug.Log(transform.name + "is DEAD!");

        //CALL RESPAWN METHOD
        //StartCoroutine(Respawn());
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
        currentHealth = startHealth;
    }
}
