using FeatureSystem.Singleton;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FeatureSystem.Systems
{
    public class GameSystems : MonoBehaviourSingletonLazy<GameSystems>
    {
        public static Dictionary<Type, ISystem> Systems => Instance._systems;

        private Dictionary<Type, ISystem> _systems = new Dictionary<Type, ISystem>();

        private readonly List<ISystemUpdate> _updateSystems = new List<ISystemUpdate>();

        bool _isStoped = false;

        public void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (_isStoped)
                return;

            UpdateSystems();
        }

        public static void RegisterSystem(ISystem system)
        {
            Instance._systems.Add(system.GetType(), system);

            if (system is ISystemUpdate updateSystem)
            {
                Instance._updateSystems.Add(updateSystem);
            }

            Instance._isStoped = false;
        }

        public static T GetSystem<T>() where T : ISystem
        {
            if (Instance._systems.TryGetValue(typeof(T), out var system))
                return (T)system;

            Debug.LogError($"No system of type {typeof(T).Name} was founded!");
            return default;
        }

        public void UpdateSystems()
        {
            for (int i = 0; i < _updateSystems.Count; i++)
            {
                ISystemUpdate system = _updateSystems[i];
                system.Update();
            }
        }

        public static void DestroySystems()
        {
            Instance._isStoped = true;

            foreach (var system in Instance._systems.Values)
            {
                system.Destroy();
            }

            Instance._systems.Clear();
            Instance._updateSystems.Clear();

            GC.Collect();
        }
    }
}