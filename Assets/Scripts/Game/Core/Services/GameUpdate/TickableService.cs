using System.Collections.Generic;
using UnityEngine;

namespace TapTest
{
    public class TickableService : MonoBehaviour
    {
        private readonly List<ITickable> _tickables = new();

        public void Add(ITickable tickable) => _tickables.Add(tickable);

        private void Update()
        {
            for (int i = 0; i < _tickables.Count; i++)
            {
                _tickables[i].Tick(Time.deltaTime);
            }
        }
    }
}