using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public HashSet<GameObject> GameObjects { get; private set; } = new HashSet<GameObject>();

    public GameObject Spawn(Vector3 position)
    {
        GameObject gameObject = Managers.Resource.Instantiate("GameObejct.prefab");
        gameObject.transform.position = position;
        GameObjects.Add(gameObject);
        return gameObject;
    }

    public void Despawn(GameObject gameObject)
    {
        GameObjects.Remove(gameObject);
        Managers.Resource.Destroy(gameObject.gameObject);
    }

    public void DespawnAllGameObejcts()
    {
        foreach (var gameObject in GameObjects)
        {
            Despawn(gameObject);
        }
    }

    public void Clear()
    {
        DespawnAllGameObejcts();
    }
}
