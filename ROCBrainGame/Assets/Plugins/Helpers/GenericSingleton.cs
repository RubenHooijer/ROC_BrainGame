using UnityEngine;

namespace Extensions.Generics.Singleton
{
    /// <summary>
    /// Generic singleton class
    /// </summary>
    /// <typeparam name="T">typeof(Class)</typeparam>
    /// <typeparam name="A">Calltype for example: interface or the same class</typeparam>
    public abstract class GenericSingleton<T, A> : MonoBehaviour where T : Component, A
    {
        public static A Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if(instance == null)
                    {
                        var t = new GameObject("Singleton");
                        instance = t.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        private static T instance;

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
