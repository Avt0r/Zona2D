using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo{
    [RequireComponent(typeof(Rigidbody2D))]
public class Moving : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private int speed;
    [SerializeField, HideInInspector]
    private Vector2 move;
    [SerializeField, HideInInspector]
    private Rigidbody2D rb;
    [SerializeField, HideInInspector]
    private Transform owner;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        PetsManager.SENDTRANSFORM += RecordOwnerTransform;
    } 

    private void OnDisable() {
        PetsManager.SENDTRANSFORM -= RecordOwnerTransform;
    }

    private void FixedUpdate() {
        Follow();
    }

    private void RecordOwnerTransform(Transform t)
    {
        owner = t;
    }

    private void Follow()
    {
        move.x = owner.position.x - this.transform.position.x;
        move.y = owner.position.y - this.transform.position.y;
      
        rb.velocity = move.normalized * (move.magnitude > distance? speed * (move.magnitude - distance) : 0);
    }
}
}