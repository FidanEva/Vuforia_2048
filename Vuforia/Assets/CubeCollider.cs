using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CubeCollider : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private LayerMask _cubeLayer;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            //Debug.Log("collided");
            if (int.Parse(other.gameObject.GetComponentInChildren<Text>().text) == int.Parse(gameObject.GetComponentInChildren<Text>().text))
            {
                //Debug.Log(int.Parse(other.gameObject.GetComponentInChildren<Text>().text));
                //Debug.Log(int.Parse(gameObject.GetComponentInChildren<Text>().text));
                //other.transform.DOJump(Vector3.up, 1/5f, 1, 1);
                var seq1 = DOTween.Sequence();
                seq1.Append(other.transform.DOJump(new Vector3(other.transform.position.x, other.transform.position.y + 3, other.transform.position.z), 0.1f, 1, 1f)).Join(other.transform.DORotate(new Vector3(0,180,0), 0.2F)).Insert(0.5f, other.transform.DOScale(1.5f,0.3f)).Insert(0.8f, other.transform.DOScale(1,0.25f));

                Destroy(_transform.gameObject);
                foreach(var item in other.gameObject.GetComponentsInChildren<Text>())
                {
                    item.text = (int.Parse(item.text) * 2).ToString();
                }
                
                Collider[] hitColliders = Physics.OverlapSphere(other.transform.position, 1, _cubeLayer);
                
                foreach (var hitCollider in hitColliders)
                {//(int.Parse(other.gameObject.GetComponentInChildren<Text>().text) == int.Parse(hitCollider.gameObject.GetComponentInChildren<Text>().text)
                    Debug.Log(other.transform.name);
                    if (other.gameObject != hitCollider.gameObject && int.Parse(other.gameObject.GetComponentInChildren<Text>().text) == int.Parse(hitCollider.gameObject.GetComponentInChildren<Text>().text))
                    {
                        var seq2 = DOTween.Sequence();
                        seq2.Append(other.transform.DOJump(new Vector3(hitCollider.transform.position.x, hitCollider.transform.position.y + 3, hitCollider.transform.position.z), 1/5f, 1, 1f)).Join(other.transform.DORotate(new Vector3(0,180,0), 0.2F)).Insert(0.5f, other.transform.DOScale(1.5f,0.3f)).Insert(0.8f, other.transform.DOScale(1,0.25f));
                        //other.gameObject.GetComponent<Rigidbody>().AddForce(hitCollider.transform.position * 5, ForceMode.Impulse);
                        Debug.Log("inside if");
                    }
                }
            }
        }
    }
}
