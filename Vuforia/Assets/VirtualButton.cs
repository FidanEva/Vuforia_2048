using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using DG.Tweening;
public class VirtualButton : MonoBehaviour
{
    [SerializeField] private VirtualButtonBehaviour _virtualButton;
    [SerializeField] private GameObject _cube;
    private bool _rotating = true;

    Sequence seq;
    void Start()
    {
        //_virtualButton.GetComponent<VirtualButtonBehaviour>();

        _virtualButton.RegisterOnButtonPressed(OnButtonPressed);
        _virtualButton.RegisterOnButtonReleased(OnButtonReleased);
        
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        //if bool == true =>
        if(_rotating)
        {
            seq = DOTween.Sequence();
            seq.Append(_cube.transform.DORotate(new Vector3(0,180,0), 0.5F).SetLoops(-1, LoopType.Incremental));
            Debug.Log("pressed");
        }
        else{ seq.Kill();}
        //if bool false =>
        //seq.kill
    }    
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //!bool
        _rotating = !_rotating;
        Debug.Log("released");
        //seq.Kill();
    }
}
