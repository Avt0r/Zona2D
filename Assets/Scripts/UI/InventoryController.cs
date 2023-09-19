using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        TimeManager.StopTime();
    }

    private void OnDisable()
    {
        TimeManager.ResumeTime();
    }
}
