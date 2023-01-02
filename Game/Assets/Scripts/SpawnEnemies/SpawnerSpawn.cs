using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawn : MonoBehaviour
{
    [SerializeField]
    private float delay;
    [SerializeField]
    private GameObject enemy;

    private void Start() {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {         
        Instantiate(enemy, transform.position, Quaternion.identity);    
        yield return new WaitForSeconds(delay);
        StartCoroutine(Spawner());
    }
}
