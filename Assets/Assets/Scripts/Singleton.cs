using System.Collections;
using UnityEngine;

// want to make a generic class for otehr classes
public class Singleton<T> : MonoBehaviour where T :MonoBehaviour {

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>(); // find the object of type T and create an instance of it
            }
            else if (instance != FindObjectOfType<T>()) // destroys the same type of oject
            {
                Destroy(FindObjectOfType<T>());
            }
            DontDestroyOnLoad(FindObjectOfType<T>());
            return instance;
        }
    }

}
