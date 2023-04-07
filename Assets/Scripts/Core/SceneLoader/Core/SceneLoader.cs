using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TapTest
{
    public class SceneLoader : MonoBehaviour
    {
        private SceneLoaderView _sceneLoaderView;

        [Inject]
        private void Construct(SceneLoaderView sceneLoaderView)
        {
            _sceneLoaderView = sceneLoaderView;
            _sceneLoaderView.Deactivate();
        }
        
        private void Load(string sceneId)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
            StartCoroutine(AnimateLoadingBar(operation));
        }

        private IEnumerator AnimateLoadingBar(AsyncOperation operation)
        {
            _sceneLoaderView.Activate();

            while (operation.isDone == false)
            {
                yield return null;
            }
            
            _sceneLoaderView.Deactivate();
        }

        private IEnumerator LoadWait(float wait, Action callback)
        {
            yield return new WaitForSeconds(wait);
            callback?.Invoke();
        }

        public void Load(LoadableScene scene) => Load(scene.ToString());

        public void Load(LoadableScene scene, float wait) =>
            StartCoroutine(LoadWait(wait, callback: () => Load(scene.ToString())));
    }
}
