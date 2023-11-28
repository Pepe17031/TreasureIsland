using System.Collections;
using UnityEngine;

namespace GoraTales.Creatures
{
    public abstract class Patrol : MonoBehaviour
    {
        public abstract IEnumerator DoPatrol();
    }
}
