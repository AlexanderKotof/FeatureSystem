using UnityEngine;

namespace FeatureSystem.Features
{

    public abstract class Feature : ScriptableObject, IFeature
    {
        public abstract void Initialize();
    }
}