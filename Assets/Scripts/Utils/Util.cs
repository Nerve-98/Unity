﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static GameObject FindChild(GameObject go, string name = null, bool recursice = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursice);
        if (transform == null)
            return null;

        return transform.gameObject;




    }
    
    public static T FindChild<T>(GameObject go, string name = null, bool recursice = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursice == false)
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {

                Transform transform = go.transform.GetChild(i);

                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }

            }
        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

}
