using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int healthMax;
    [SerializeField]
    private int health;
    [SerializeField]
    private int staminaMax;
    [SerializeField]
    private float stamina; 
    [SerializeField]
    private int speed = 10;
    [SerializeField]
    private int speedRun = 10;
    [SerializeField]
    private int speedCurrent;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 moveVector;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Image staminaBar;
    [SerializeField]
    private Image healthBar;

    private void Start() {
        healthBar.fillAmount = ((float) health) / healthMax;
        staminaBar.fillAmount = ((float) stamina) / staminaMax;
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveVector * speedCurrent * 0.01f);
    }

    private void Update()
    {
       
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift) && HasStamina()){
            speedCurrent = speed + speedRun;
            stamina--;
        }else {
            speedCurrent = speed;
            if(stamina < staminaMax) stamina+= 0.3f;
        }

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
        } else if(difference.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if(Input.GetKeyDown(KeyCode.I)){
            ChangeHealth(10);
        }
        if(Input.GetKeyDown(KeyCode.O)){
            ChangeHealth(-10);
        }
        staminaBar.fillAmount = ((float) stamina) / staminaMax;
    }

    private bool IsAlive(){
        return health > 0;
    }

    private bool HasStamina(){
        return stamina > 0;
    }

    public void ChangeHealth(int diff)
    {
        health += health + diff > healthMax? healthMax - health: (health + diff < 0? -health : diff);
        healthBar.fillAmount = ((float) health) / healthMax;
    }

    private void Die(){}

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Health>() && !IsFullHealth())
        {
            ChangeHealth(10);
            Destroy(other.gameObject);
        }
    }

    private bool IsFullHealth()
    {
        return health == healthMax;
    }
}