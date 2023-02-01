using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;

    
    private void Start()
    {   
        for(int i = 0; i < weapons.Length; i++)
        {
            Instantiate(weapons[i], transform.position, transform.rotation).transform.SetParent(transform);
        }
        
        foreach(Transform weapon in transform) {
            weapon.gameObject.SetActive(true);   
        }

        bool b = true;
        foreach(Transform weapon in transform) {
            if(b)
               { weapon.gameObject.SetActive(true);
               b = false;
               }
            else
            {
                weapon.gameObject.SetActive(false);
            }    
        }
    }
}
