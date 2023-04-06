using System.Collections.Generic;
using UnityEngine;

namespace TapTest
{
    public class TickableService : MonoBehaviour
    {
        private readonly List<ITickable> _tickables = new();
        private readonly List<IFixedTickable> _fixedTickables = new();

        public void Add(ITickable tickable)
        {
            if (tickable is IFixedTickable fixedTickable)
            {
                _fixedTickables.Add(fixedTickable);
            }
            else
            {
                _tickables.Add(tickable);
            }
        }

        private void Update()
        {
            for (int i = 0; i < _tickables.Count; i++)
            {
                _tickables[i].Tick(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedTickables.Count; i++)
            {
                _fixedTickables[i].Tick(Time.fixedDeltaTime);
            }
        }
    }
}