using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour {
    
    [SerializeField, HideInInspector]
    private int count;

    public int GetCount()
    {
        return count;
    }

    public void SetCount(int x)
    {
        count = x;
    }
}
