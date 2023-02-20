using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player{
[RequireComponent(typeof(Player.States))]
[RequireComponent(typeof(Player.Moving))]
[RequireComponent(typeof(Player.AnimationHandler))]
public class Controller : MonoBehaviour
{

    [SerializeField, HideInInspector]
    private Vector2 moveVector;
    [SerializeField, HideInInspector]
    private States states;

    [SerializeField]
    internal Action<Vector2> move;
    [SerializeField]
    internal Action run;
    [SerializeField]
    internal Action walk;
    [SerializeField]
    internal Action idle;
    [SerializeField]
    internal Action die;
    [SerializeField]
    internal Action<int> heal;
    [SerializeField]
    internal Action<int> XPRise;
    [SerializeField]
    public Action<int> hurt;

    private void Awake() {
        states = GetComponent<States>();
        PetsManager.SENDTRANSFORM?.Invoke(this.transform);
    }
    
    private void Update() {
        if(!PauseMenu.GAMEISPAUSED)
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.y = Input.GetAxis("Vertical");

            Scale();
        }
    }

    private void FixedUpdate() {
        CheckMoveStatus();
        move?.Invoke(moveVector.normalized);
        GameUIManager.CAMERAFOLLOW?.Invoke(this.transform);
    }
    
    private void CheckMoveStatus()
    {
        if(moveVector.x != 0 || moveVector.y != 0){
            CheckShiftPressed();
        }else
        {
            idle?.Invoke();
        }
    
    }
    private void CheckShiftPressed()
    {
        if(Input.GetKey(KeyCode.LeftShift) && states.HasStamina()){
                run?.Invoke();
            }else {
                walk?.Invoke();
            }
    }

    private void Scale()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if(difference.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if(difference.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void ShowDeathScreen()
    {
        GameUIManager.SHOWDEATHSCREEN?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Health>() && !states.IsItFullHP())
        {
            heal?.Invoke(10);
            Destroy(other.gameObject);
        }
        if(other.GetComponent<XP>())
        {
            XPRise?.Invoke(other.GetComponent<XP>().GetCount());
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Ammo"))
        {
            WeaponManager.PICKAMMO?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
}