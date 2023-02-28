using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Character
{
    [RequireComponent(typeof(States))]
    [RequireComponent(typeof(Moving))]
    [RequireComponent(typeof(AnimationHandler))]
    public class Controller : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        internal States states;

        [SerializeField] internal Action run;
        [SerializeField] internal Action walk;
        [SerializeField] internal Action idle;
        [SerializeField] internal Action die;
        [SerializeField] internal Action levelUp;
        [SerializeField] internal Action hpChange;
        [SerializeField] internal Action spChange;
        [SerializeField] internal Action xpChange;
        [SerializeField] internal Action<int> heal;
        [SerializeField] public Action<int> xpRise;
        [SerializeField] public Action<int> hurt;

        private void Awake()
        {
            states = GetComponent<States>();
            MobsManager.getPlayer += GetMe;
        }

        private void OnDestroy()
        {
            MobsManager.getPlayer -= GetMe;
        }

        private void Update()
        {
            if (!PauseMenu.GAMEISPAUSED)
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
            if (other.GetComponent<Health>() && !states.IsItFullHP())
            {
                heal?.Invoke(10);
                Destroy(other.gameObject);
            }
            if (other.GetComponent<XP>())
            {
                xpRise?.Invoke(other.GetComponent<XP>().GetCount());
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