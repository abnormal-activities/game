using UnityEngine;

namespace WorkshopSoft.Abnormal.Arch
{
    public abstract class Singleton<T> : SyncSingleton where T : MonoBehaviour
    {
        private static T _instance;

        [SerializeField]
        protected bool persistent = true;

        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance != null)
                        return _instance;

                    var instances = FindObjectsOfType<T>();
                    var count = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                            return _instance = instances[0];
                        
                        Debug.LogWarning($"[{nameof(Singleton<T>)}] There should never be more than one {nameof(Singleton<T>)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                        
                        for (var i = 1; i < instances.Length; i++)
                            Destroy(instances[i]);
                        
                        return _instance = instances[0];
                    }
                    
                    Debug.LogWarning($"[{nameof(Singleton<T>)}] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
                    return _instance = new GameObject($"({nameof(Singleton<T>)})")
                        .AddComponent<T>();
                }
            }
        }

        private void Awake()
        {
            if (persistent)
                DontDestroyOnLoad(gameObject);

            OnAwake();
        }
        
        protected virtual void OnAwake() { }
    }
}