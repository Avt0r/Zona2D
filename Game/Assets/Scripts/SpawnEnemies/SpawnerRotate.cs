using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRotate : MonoBehaviour
{
   
    private void FixedUpdate() {
        transform.Rotate(0f, 0f, Random.Range(0, 361), Space.Self);

    }
}
