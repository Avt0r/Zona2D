using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowAD()
    {
        Application.ExternalCall("ShowAD");
    }
}
