using UnityEngine;

namespace RavenwoodRome;

public static class Extensions
{
    public static void Remove<T>(this GameObject prefab) where T : Component
    {
        if (!prefab.TryGetComponent(out T component)) return;
        Object.DestroyImmediate(component);
    }
}