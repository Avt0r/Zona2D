using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReloadAnim
{
    [RequireComponent(typeof(Animator))]
    internal class Part : MonoBehaviour
    {

        [SerializeField, HideInInspector]
        private Controller _controller;
        [SerializeField, HideInInspector]
        private Animator _anim;
        [SerializeField, HideInInspector]
        private int _hashIdle;
        [SerializeField, HideInInspector]
        private int _hashStart;
        [SerializeField, HideInInspector]
        private int _hashContinue;

        private void Awake()
        {
            _anim = GetComponent<Animator>();

            _hashIdle = Animator.StringToHash("Idle");
            _hashStart = Animator.StringToHash("Start");
            _hashContinue = Animator.StringToHash("Continue");
        }

        private void StartNextPart()
        {
            if( _controller == null) return;
            _controller.startNextPart();
        }

        internal void SetController(Controller c)
        {
            _controller = c;
        }

        internal void PlayIdle()
        {
            _anim.Play(_hashIdle);
        }

        internal void PlayStart()
        {
            _anim.Play(_hashStart);
        }

        private void PlayContinue()
        {
            _anim.Play(_hashContinue);
        }
    }
}
