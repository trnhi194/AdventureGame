using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if(_instance != null )
                {
                    return _instance;
                }
                var go = new GameObject
                {
                    name = typeof(T).Name,
                };
                _instance = go.AddComponent<T>();
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.LogError($"Destroy {typeof(T)} instance in {gameObject.name}");
                Destroy(this as T);
            }
            else
            {
                _instance = this as T;
            }
        }
    }
}
