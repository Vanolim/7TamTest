using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public static class MonoInstallerExtension
    {
        public static void BindPrefab<T>(this MonoInstaller monoInstaller,
            DiContainer diContainer, T prefab) where T : MonoBehaviour
        {
            diContainer
                .BindInterfacesAndSelfTo<T>()
                .FromComponentInNewPrefab(prefab)
                .AsSingle()
                .NonLazy();
        }

        public static void BindInstance<T>(this MonoInstaller monoInstaller,
            DiContainer diContainer, T instance, List<IInitializable> initializables = null)
        {
            diContainer.QueueForInject(instance);

            diContainer
                .BindInterfacesAndSelfTo<T>()
                .FromInstance(instance)
                .AsSingle();

            if (initializables != null && instance is IInitializable initializable)
            {
                initializables.Add(initializable);
            }
        }

        public static void BindThis<T>(this MonoInstaller monoInstaller,
            DiContainer diContainer, T obj) where T : MonoInstaller, Zenject.IInitializable
        {
            diContainer
                .Bind<Zenject.IInitializable>()
                .To<T>()
                .FromInstance(obj)
                .AsSingle();
        }
    }
}