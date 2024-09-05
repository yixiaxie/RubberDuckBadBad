using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    void Awake()
    {
        //// 
        //if (FindObjectsOfType<PersistentCanvas>().Length > 1)
        //{
        //    Destroy(gameObject); // 
        //    return;
        //}

        //// 
        DontDestroyOnLoad(gameObject);
    }
}