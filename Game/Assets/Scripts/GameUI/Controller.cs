using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ReloadAnim
{
    public class Controller : MonoBehaviour
    {
        [SerializeField]
        private Part _firstPart;
        [SerializeField]
        private Part[] _parts;
        [SerializeField]
        private int _index = 0;

        [SerializeField]
        internal Action startNextPart;

        private void Awake()
        {
            _parts = new Part[8];
            for(int i = 0; i < _parts.Length; i++)
            {
                Part p = Instantiate(_firstPart, _firstPart.transform.position, _firstPart.transform.rotation);
                p.transform.parent = this.transform;
                p.transform.localScale = _firstPart.transform.localScale;
                p.SetController(this);
                _parts[i] = p;
            }
        }

        private void OnEnable()
        {
            startNextPart += StartNextPart;
        }

        private void OnDisable()
        {
            startNextPart -= StartNextPart; 
        }

        public void StartAnimation()
        {
            _parts[0].PlayStart();
        }

        public void StopAnimation()
        {
            _index = 0;
            foreach (Part p in _parts)
            {
                p.PlayIdle();
            }
        }

        private void StartNextPart()
        {
            if (_index + 1 >= _parts.Length) { return; }
            _index++;
            _parts[_index].PlayStart();
        }
    }
}
