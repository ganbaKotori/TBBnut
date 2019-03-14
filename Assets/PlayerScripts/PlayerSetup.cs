//-------------------------------------
// Responsible for setting up the player.

using UnityEngine;


[RequireComponent(typeof(Player))]
public class PlayerSetup : MonoBehaviour
{


    void Start()
    {


        GetComponent<Player>().Setup();
    }


    // When we are destroyed
    void OnDisable()
    {
       
    }

}