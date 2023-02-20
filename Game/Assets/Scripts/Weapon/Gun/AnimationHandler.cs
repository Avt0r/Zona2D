using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(Controller))]
    [RequireComponent((typeof(Animator)))]
    internal class AnimationHandler : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            Controller c = GetComponent<Controller>();
            c.shot += Shot;
            c.idle += Idle;
            c.reloadStart += ReloadStart;
            c.reloadStop += ReloadStop;
        }

        private void OnDisable()
        {
            ReloadStop();
        }

        private void OnDestroy()
        {
            Controller c = GetComponent<Controller>();
            c.shot -= Shot;
            c.idle -= Idle;
            c.reloadStart -= ReloadStart;
            c.reloadStop -= ReloadStop;
        }

        private void Shot()
        {
            anim.Play("Shot");
        }

        private void Idle()
        {
            anim.Play("Idle");
        }

        private void ReloadStart()
        {
            GameUIManager.RELOADSTART?.Invoke();
        }

        private void ReloadStop()
        {
            GameUIManager.RELOADSTOP?.Invoke();
        }
    }
}