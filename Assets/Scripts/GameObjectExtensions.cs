using UnityEngine;
using System.Collections.Generic;

public static class GameObjectExtensions
{
    public static T[] FindObjectOfIntarcafe<T>() where T : class
    {
        List<T> result = new List<T>();

        foreach (var n in GameObject.FindObjectsOfType<Component>())
        {
            var component = n as T;
            if (component != null)
            {
                result.Add(component);
            }
        }
        return result.ToArray();
    }
}
