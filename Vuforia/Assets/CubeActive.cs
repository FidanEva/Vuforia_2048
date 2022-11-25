using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActive : MonoBehaviour
{

    private float _horizontal;
    private Transform _transform;
    private CubeMovement _cubeMovement;
    void Start()
    {
         _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Mouse X");
        _transform.Translate(_horizontal/10, 0, 0);      
    }
    void OnEnable()
    {
         _cubeMovement = GetComponent<CubeMovement>();
         _cubeMovement.OnDeactivate += Deactive;

    }

    void OnDisable()
    {
         _cubeMovement.OnDeactivate -= Deactive;

    }
    private void Deactive()
    {
        this.enabled = false;
    }
}
