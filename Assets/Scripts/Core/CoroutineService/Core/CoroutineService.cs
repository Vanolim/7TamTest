using System.Collections;
using UnityEngine;

namespace TapTest
{
    public class CoroutineService
    {
        private readonly MonoBehaviour _monoBehaviour;

        public CoroutineService(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }

        public void StartCoroutine(IEnumerator enumerator) =>
            _monoBehaviour.StartCoroutine(enumerator);

        public void StopCoroutine(IEnumerator enumerator) =>
            _monoBehaviour.StopCoroutine(enumerator);
    }
}