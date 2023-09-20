using SpawnSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Spawnable _object;

        public void Spawn()
        {
            Instantiate(_object.GetMe());
        }
    }
}
