using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterManager : MonoBehaviour
{
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
    // Start is called before the first frame update
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
        }
    }
}
