using FeatureSystem.Systems;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FeatureSystem.Features
{
    public class Features : MonoBehaviour
    {
        public Feature[] features;

        private static Features _instance;

        private readonly Dictionary<Type, IFeature> _typesToFeature = new Dictionary<Type, IFeature>();

        private void Awake()
        {
            DontDestroyOnLoad(this);

            _instance = this;

            foreach (var feature in features)
            {
                _typesToFeature.Add(feature.GetType(), feature);
            }
        }

        public static Feature[] GetFeatures()
        {
            return _instance.features;
        }

        public static T GetFeature<T>() where T : IFeature
        {
            if (_instance._typesToFeature.TryGetValue(typeof(T), out var feature))
                return (T)feature;

            Debug.LogError($"No Feature of type {typeof(T).Name} was founded!");
            return default;
        }

        public static void InitializeFeaturesAndSystems()
        {
            var features = GetFeatures();

            foreach (var feature in features)
                feature.Initialize();

            var systems = GameSystems.Systems.Values;

            foreach (var system in systems)
                system.Initialize();
        }
    }
}