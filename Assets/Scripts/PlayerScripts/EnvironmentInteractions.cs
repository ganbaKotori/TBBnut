using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractions : MonoBehaviour
{

    [SerializeField] private PlayerMovement pm;
    private List<GameObject> acorns;
    private bool nextToTree;

    // Start is called before the first frame update
    void Start()
    {
        acorns = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Number of acorns in range: " + acorns.Count);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Acorn"))
            acorns.Add(other.gameObject);
        if (other.CompareTag("Tree"))
            nextToTree = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Climbable"))
            pm.canClimb = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Acorn"))
            acorns.Remove(other.gameObject);
        if (other.CompareTag("Tree"))
            nextToTree = false;
    }

    public bool askPolitelyForAcorn(string password)
    {
        if (password.Equals("Please") && acorns.Count > 0)
        {
            Destroy(acorns[0]);
            acorns.RemoveAt(0);
            return true;
        }
        else if (password.Equals("Please") && nextToTree)
            return true;
        return false;
    }



}
