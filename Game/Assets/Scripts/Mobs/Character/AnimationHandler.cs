using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Animator))]
    internal class AnimationHandler : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private Controller controller;
        [SerializeField, HideInInspector]
        private Animator anim;
        [SerializeField, HideInInspector]
        private int hashIdle;
        [SerializeField, HideInInspector]
        private int hashWalk;
        [SerializeField, HideInInspector]
        private int hashDeath;

        private void Awake()
        {
            controller = GetComponent<Controller>(); 
            anim = GetComponent<Animator>();
            hashIdle = Animator.StringToHash("Idle");
            hashWalk = Animator.StringToHash("Walk");
            hashDeath = Animator.StringToHash("Death");
        }

        private void OnEnable()
        {
            controller.idle += Idle;
            controller.walk += Walk;
            controller.run += Walk;
            controller.die += Death;
        }

        private void OnDisable()
        {
            controller.idle -= Idle;
            controller.walk -= Walk;
            controller.run -= Walk;
            controller.die -= Death;
        }

        private void Idle()
        {
            anim.Play(hashIdle);
        }

        private void Walk()
        {
            anim.Play(hashWalk);
        }

        private void Death()
        {
            controller.idle -= Idle;
            controller.walk -= Walk;
            controller.run -= Walk;
            anim.Play(hashDeath);
        }
    }
}
