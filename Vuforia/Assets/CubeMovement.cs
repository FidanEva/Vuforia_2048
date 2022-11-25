using System;
using System.Collections;
using UnityEngine;
public class CubeMovement : MonoBehaviour
{
    //private float _horizontal;
    private Transform _transform;
    private Rigidbody _rb;
    //private bool _active = true;
    //public  static bool nextCube = false;
    private bool _throwable = true;
    // public delegate void ClickAction();
     public event Action OnClicked;
     public event Action OnDeactivate;
    private bool _wait=true;
    // [SerializeField] private LayerMask _cube;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // if (_active)
        // {
        //     _horizontal = Input.GetAxis("Mouse X");
        //     _transform.Translate(_horizontal/10, 0, 0);          
        // }
        ThrowCube();
    }

    private void ThrowCube()
    {
        if (Input.GetMouseButtonDown(0) && _wait)
        {
            _wait=false;
            StartCoroutine(Instant());
            //_active = false;
            OnDeactivate?.Invoke();
            if (_throwable)
            {
                _throwable = false;
                _rb.AddForce(_transform.forward * 20, ForceMode.Impulse);
            }
            //nextCube = true;
            
        }
    }
    
    private IEnumerator Instant()
    {
        yield return new WaitForSeconds(1f);
        OnClicked?.Invoke();
        _wait=true;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Finish"))
        {
            gameObject.tag = "Cube";
            
        }
    }
}
