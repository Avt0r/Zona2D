using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GunComponents
{
    [RequireComponent(typeof(Controller))]
    [RequireComponent((typeof(Animator)))]
    internal class AnimationHandler : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private Animator anim;
        [SerializeField, HideInInspector]
        private int hashIdle;
        [SerializeField, HideInInspector]
        private int hashShot;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            hashIdle = Animator.StringToHash("Idle");
            hashShot = Animator.StringToHash("Shot");
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
            anim.Play(hashShot);
        }

        private void Idle()
        {
            anim.Play(hashIdle);
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