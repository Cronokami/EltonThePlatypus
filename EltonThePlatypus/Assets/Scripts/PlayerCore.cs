using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public static GameObject SingletonObject;

    private void Awake()
    {
        if(SingletonObject != null)
        {
            Destroy(gameObject);
            return;
        }

        SingletonObject = gameObject;
    }
}
