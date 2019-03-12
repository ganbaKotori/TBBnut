using UnityEngine;

public class PlayerShoot : MonoBehaviour
{


    private const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;


    [SerializeField]

    private Camera cam;


    [SerializeField]

    private LayerMask mask;

    void Start()

    { 

    }

    void Update()

    {

        if (Input.GetButtonDown("Fire1"))

        {

            Shoot();

        }

    }

    void Shoot()

    {

        RaycastHit _hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))

        {

            Debug.Log("We hit " + _hit.collider.name);

        }

    }

}