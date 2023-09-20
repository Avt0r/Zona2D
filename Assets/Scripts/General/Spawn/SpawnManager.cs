using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Vector3 _position;

        private void Start()
        {
            _spawner.Spawn(_position);
        }
    }
}
