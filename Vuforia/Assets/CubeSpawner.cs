using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private GameObject _instantiatetCube;
    public Transform transformCubeSpawner;
    private CubeMovement _cubeMovement;  

    public event Action<GameObject> OnInstantiateCube;
    void Start()
    {
        transformCubeSpawner = GetComponent<Transform>();
        
        _instantiatetCube = Instantiate(_cubePrefab, transformCubeSpawner.position, Quaternion.Euler(20,0,0));
        _cubeMovement  = _instantiatetCube.GetComponent<CubeMovement>();
        _cubeMovement.OnClicked += NextCube;           

    }
    void OnEnable()
    {
    
    }

    private void NextCube()
    {
        //Debug.Log("New Cube");
        _instantiatetCube= Instantiate(_cubePrefab, transformCubeSpawner.position,  Quaternion.Euler(20,0,0)); 
        OnInstantiateCube?.Invoke(_instantiatetCube);

    }
    void OnDisable()
    {
        _cubeMovement.OnClicked -= NextCube;
    }   
    
    
}
