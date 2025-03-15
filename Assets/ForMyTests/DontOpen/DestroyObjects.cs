using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] private Transform poolObjects;
    [SerializeField] private int value;
    [SerializeField] GameObject prefab;
    private readonly List<GameObject> poolList = new();

    private void Awake()
    {
        for (int i = 0; i < value; i++)
        {
            var go = Instantiate(prefab, poolObjects);
            poolList.Add(go);
        }
        Debug.Log(poolList.Count);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            poolList.Clear();
            Debug.Log(poolList.Count);
        }

    }
}
