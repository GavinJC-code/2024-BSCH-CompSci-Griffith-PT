using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MaterialChanger : MonoBehaviour
{
    public Material testMat;
    
    // Start is called before the first frame update
    void Start()
    {
        //assigning the material from this gameobjects's Mesh Renderer component to the testMat Variable
        testMat = GetComponent<MeshRenderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        //changes the material's color to a random color
        testMat.color = Random.ColorHSV();
        throw new NotImplementedException();}
}

