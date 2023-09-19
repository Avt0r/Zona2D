using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField]
    private float offset;
    private Vector2 _direction;

    private void Update()
    {
        if(!TimeManager.TIMEISSTOPPED){
            float rotZ = Mathf.Atan2(_direction.y,_direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
    }

    public void SetDirection(Vector2 input)
    {
        _direction = input;
    }
}
