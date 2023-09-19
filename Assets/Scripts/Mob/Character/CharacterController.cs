using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CharacterComponents
{
    [RequireComponent(typeof(States))]
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(AnimationHandler))]
    [RequireComponent(typeof(EventController))]

    public class CharacterController : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        internal States states;
        [SerializeField]
        private WeaponRotation _weapon;

        internal Action openCloseInventory;
        internal Action reload;
        internal Action fire;
        internal Action<Vector2> readGazeDirection;
        internal Action<Vector2> readMove;
        internal Action move;
        internal Action run;
        internal Action walk;
        internal Action idle;
        internal Action die;
        internal Action levelUp;
        internal Action spChange;
        internal Action xpChange;
        internal Action hpChange;
        internal Action<bool> runButtonPressed;
        public Action<int> changeHp;
        public Action<int> riseXp;

        private void Awake()
        {
            states = GetComponent<States>();
            MobsManager.getPlayer += GetMe;
        }

        private void OnEnable()
        {
            readGazeDirection += _weapon.SetDirection;
        }

        private void OnDisable()
        {
            readGazeDirection -= _weapon.SetDirection;
        }

        private void OnDestroy()
        {
            MobsManager.getPlayer -= GetMe;
        }

        private void Update()
        {
            if (!TimeManager.TIMEISSTOPPED)
            {
                Scale();
            }
        }

        private void FixedUpdate()
        {
            GameUIManager.CAMERAFOLLOW?.Invoke(this.transform);
        }

        private void Scale()
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            if (difference.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (difference.x < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Health>() && !states.IsItFullHp())
            {
                changeHp?.Invoke(10);
                Destroy(other.gameObject);
            }
            if (other.GetComponent<XP>())
            {
                riseXp?.Invoke(other.GetComponent<XP>().GetCount());
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Ammo"))
            {
                WeaponManager.PICKAMMO?.Invoke();
                Destroy(other.gameObject);
            }
        }

        private GameObject GetMe()
        {
            return this.gameObject;
        }
    }
}