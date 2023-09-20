using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public abstract class Spawnable : MonoBehaviour
    {
        internal abstract void OnSpawn();
    }
}
