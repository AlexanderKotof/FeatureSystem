using UnityEngine;

namespace FeatureSystem.Singleton
{
    public class MonoBehaviourSingletonLazy<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    CreateInstance();

                return _instance;
            }
            protected set
            {
                _instance = value;
            }
        }

        private static T _instance;

        private static void CreateInstance()
        {
            _instance = new GameObject(typeof(T).Name).AddComponent<T>();
        }
    }
}