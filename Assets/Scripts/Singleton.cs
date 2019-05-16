using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }

    }

    public void Awake()
    {
        OnInitialize();
        
    }
     public virtual void OnInitialize()
    {
        instance = FindObjectOfType<T>();
        DontDestroyOnLoad(instance);
    }
}

