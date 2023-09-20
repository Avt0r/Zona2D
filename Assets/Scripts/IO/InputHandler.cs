using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameIO
{
    [RequireComponent(typeof(Controllable))]
    public abstract class InputHandler : MonoBehaviour
    {
        [SerializeField] private Controllable _controllable;
        
        protected void InitControllable()
        {
            if (_controllable == null)
            {
                _controllable = GetComponent<Controllable>();
            }
        }

        public void SetControllable(Controllable controllable)
        {
            _controllable = controllable;
        }
    }
}
