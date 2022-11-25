using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGameOver : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private GameObject _spawner;
    private GameObject _instant;
    void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("Spawner");
        _cubeSpawner = _spawner.GetComponent<CubeSpawner>();
        //_cubeSpawner = FindObjectOfType<CubeSpawner>();
        _cubeSpawner.OnInstantiateCube += GameOver;
    }

    void OnEnable()
    {
    }
    void OnDisable()
    {
        _cubeSpawner.OnInstantiateCube -= GameOver;
    }

    private void GameOver(GameObject obj)
    {
        _instant = obj;
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (this != _instant)

            if (collider.CompareTag("Finish") && gameObject.CompareTag("Cube"))
            {
                Debug.Log("GameOver");
            }
    }
}
