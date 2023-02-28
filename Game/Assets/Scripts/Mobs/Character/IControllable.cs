using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    internal interface IControllable
    {
        public void ReadMove(Vector2 moveVector);
        public void Move();
        public void Run();
        public void Walk();
        public void Idle();
    }
}