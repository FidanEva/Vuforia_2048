using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeColor : MonoBehaviour
{
    private Renderer _mesh;
    float ourNum1 = 1;
    //public Color colorTest;
    void Start()
    {
        _mesh = GetComponent<Renderer>();
        //colorTest = Color.HSVToRGB(0.07f,1,1);
    }

    // Update is called once per frame
    void Update()
    {

        colorChanger();
        // Color c = Color.HSVToRGB(25,100,100);
        //  ToColorCube(2,colorTest);
        // ToColorCube(8, Color.green);
        // ToColorCube(16, new Color(60, 100,100));

        //for(int x=0, y=0; y<2;y++,x++)


       /* int cubeNum = 2;
        if (forCounter < 100){
        for( float color = 0; color <= 1.06;  color +=0.06f)
        {
           forCounter++;
            Debug.Log(color);
            ToColorCube(cubeNum, Color.HSVToRGB(color,1,1));
            if (color >= 1)
            {
                Debug.Log("sifir");
                color = 0;
            }
            cubeNum +=2;
        }
        }*/
    }

    private void ToColorCube(float number, Color color)
    {
        if (int.Parse(gameObject.GetComponentInChildren<Text>().text) == number)
        {
            
            _mesh.material.color = color;
        }
    }

    private void colorChanger (){
        
        float ourNum = 0.01f * int.Parse(gameObject.GetComponentInChildren<Text>().text) * ourNum1;
        _mesh.material.color = Color.HSVToRGB(ourNum ,1,1);
        if (ourNum >= 1f){
            ourNum1 = ourNum1 * 0.1f;
        }
    }
}
