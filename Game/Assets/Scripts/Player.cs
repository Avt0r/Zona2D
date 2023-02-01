using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private int XPMax;
    [SerializeField]
    private int XP;
    [SerializeField]
    private int HPMax;
    [SerializeField]
    private int HP;
    [SerializeField]
    private int staminaMax;
    [SerializeField]
    private float stamina; 
    [SerializeField]
    private int speed = 4;
    [SerializeField]
    private float speedRun = 1.5f;
    [SerializeField, HideInInspector]
    private float speedCurrent;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField, HideInInspector]
    private Vector2 moveVector;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Image staminaBar;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private Image XPBar;
    [SerializeField]
    private GameObject deathScreen;
    [SerializeField]
    private Text levelText;

    private void Start() {
        healthBar.fillAmount = ((float) HP) / HPMax;
        staminaBar.fillAmount = ((float) stamina) / staminaMax;
        XPBar.fillAmount = ((float) XP) / XPMax;
        levelText.text = level + "";
    }

    private void Update()
    {
        if(!PauseMenu.GAMEISPAUSED){
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        rb.velocity = moveVector.normalized * speedCurrent;

        if(Input.GetKey(KeyCode.LeftShift) && HasStamina()){
            speedCurrent = speed * speedRun;
            stamina--;
        }else {
            speedCurrent = speed;
            if(stamina < staminaMax)
            stamina+= 0.3f;
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

        UpdateBars();
        }
    }

    private void UpdateBars()
    {
        staminaBar.fillAmount = ((float) stamina) / staminaMax;
        healthBar.fillAmount = ((float) HP) / HPMax;
        XPBar.fillAmount = ((float) XP) / XPMax; 
    }

    private bool IsAlive(){
        return HP > 0;
    }

    private bool HasStamina(){
        return stamina > 0;
    }

    public void ChangeHealth(int diff)
    {
        HP += HP + diff > HPMax? HPMax - HP: (HP + diff < 0? -HP : diff);
        if(HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.Play("PlayerDead");
        speed = 0;
    }

    private void ShowDeathScreen()
    {
       deathScreen.SetActive(true); 
       deathScreen.GetComponent<DeathScreen>().StopTime();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Health>() && !IsFullHealth())
        {
            ChangeHealth(10);
            Destroy(other.gameObject);
        }
        if(other.GetComponent<XP>())
        {
            GetXP(other.GetComponent<XP>().GetCount());
            Destroy(other.gameObject);
        }
    }

    private void GetXP(int x)
    {
        XP+=x;
        if(XP >= XPMax)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        XP = XPMax - XP;
        XPMax *= 2;
        levelText.text = level + "";
    }

    private bool IsFullHealth()
    {
        return HP == HPMax;
    }
}