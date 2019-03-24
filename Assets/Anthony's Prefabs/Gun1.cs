using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject projectile;

    public Camera fpsCam;
    public GameObject shootPoint;
    public float shootSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Creates a projectile object
        GameObject temp = GameObject.Instantiate(projectile, shootPoint.transform.position, new Quaternion());

        //Sets the speed of the projectile
        temp.GetComponent<Rigidbody>().velocity = fpsCam.transform.forward * shootSpeed;




        /*
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        */
    }
}
