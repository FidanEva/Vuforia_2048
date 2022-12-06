using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using DG.Tweening;
public class Pingu : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour _virtualButton;
    private Animator _anim;
    private bool _isVawing;
    void Start()
    {
        //_virtualButton.GetComponent<VirtualButtonBehaviour>();

        _virtualButton.RegisterOnButtonPressed(OnButtonPressed);
        _virtualButton.RegisterOnButtonReleased(OnButtonReleased);

        _anim = transform.GetChild(2).GetComponent<Animator>();
        
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("button pressed");

        if(_isVawing)
        {
            _anim.SetBool("vawingHand", true);
        }
        else
        {
            _anim.SetBool("vawingHand", false);
        }

    }    
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        _isVawing =!_isVawing;
    }
}
