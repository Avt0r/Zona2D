using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 moveVector;
    [SerializeField]
    private Animator anim;

    private void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 25;
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 10;
        }
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

        if(moveVector.x != 0 || moveVector.y != 0){
            anim.SetBool("stay",false);
        }else
        {
            anim.SetBool("stay",true);
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(difference.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else
        if(difference.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}