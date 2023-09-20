using SpawnSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    internal class Spawner : MonoBehaviour
    {
        [SerializeField] private Spawnable _object;

        internal void Spawn(Vector3 point)
        {

            Instantiate(_object.gameObject, point, Quaternion.identity);

            _object.OnSpawn();
        }
    }
}
