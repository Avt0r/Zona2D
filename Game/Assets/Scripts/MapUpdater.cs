using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpdater : MonoBehaviour
{
    [SerializeField]
    private GameObject anchorCenter;
    [SerializeField]
    private GameObject anchorMine;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collise");
        if (other.GetComponent<Player>())
        {
            anchorCenter.transform.position = anchorMine.transform.position;
        }
    }
}
