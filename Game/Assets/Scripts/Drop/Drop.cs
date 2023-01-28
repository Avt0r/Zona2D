using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField]
    private int destroyDelay;
    [SerializeField]
    private int dropChance;
    [SerializeField]
    private GameObject drop;

    private void Start()
    {
       Destroy(gameObject, destroyDelay); 
    }
    
    public int GetDropChance()
    {
        return dropChance;
    }

    public GameObject ReturnDropObject()
    {
        return drop;
    }

    public static Drop ReturnDropFromArray(Drop [] items)
    {
        Drop result = items[0];
        int x = Random.Range(0,101);
        for(int i = 1; i < items.Length; i ++)
        {
            if(result.GetDropChance() > items[i].GetDropChance())
            {
                if(x <= items[i].GetDropChance())
                {
                    result = items[i];
                }
            }else if(x > result.GetDropChance())
            {
                result = items[i];
            }
        }
        return result;
    }
}
