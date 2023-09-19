using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private int distance;
    [SerializeField]
    private int speed;

    private void OnEnable() {
        GameUIManager.CAMERAFOLLOW += Follow;
    }

    private void OnDisable() {
        GameUIManager.CAMERAFOLLOW -= Follow;
    }

    private void Follow(Transform t)
    {
        Vector3 target = new Vector3()
        {
          x=t.position.x,
          y=t.position.y,
          z=t.position.z - distance
        };

        Vector3 follow = Vector3.Lerp(this.transform.position, target, speed * 0.1f);

        this.transform.position = follow;
    }
}
