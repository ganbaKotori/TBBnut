using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private const string PLAYER_ID_PREFIX = "Player ";
    bool Aacquired;
    bool Cacquired;
    bool Oacquired;
    bool Racquired;
    bool Nacquired;
    public GameObject A;
    public GameObject C;
    public GameObject O;
    public GameObject R;
    public GameObject N;

    //private static Dictionary<string,Player> players = new Dictionary<string, Player>();

    //public void RegisterPlayer(string _netID, Player _player)
    //{
    //    string _playerID = PLAYER_ID_PREFIX + _netID;
    //    players.Add(_playerID, _player);
    //     _player.transform.name = _playerID;
    // }

    void Start()
    {
        bool Aacquired = false;
        bool Cacquired = false;
        bool Oacquired = false;
        bool Racquired = false;
        bool Nacquired = false;
    }

    // Update is called once per frame
    void Update()
    {
        Aacquired = A.GetComponent<ObtainLetter>().isTaken;
        Cacquired = C.GetComponent<ObtainLetter>().isTaken;
        Oacquired = O.GetComponent<ObtainLetter>().isTaken;
        Racquired = R.GetComponent<ObtainLetter>().isTaken;
        Nacquired = N.GetComponent<ObtainLetter>().isTaken;
        if (Aacquired && Cacquired && Oacquired && Racquired && Nacquired)
        {
            
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DeleteAll();


        }
    }

    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }

}
