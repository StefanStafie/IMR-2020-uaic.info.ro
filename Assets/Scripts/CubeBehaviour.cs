using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{

    public GameObject cube;
    private Renderer cubeRenderer;
    void Start()
    {
        cubeRenderer = cube.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cube.transform.position.y<-0.4f)
            cubeRenderer.material.SetColor("_Color", Color.red);
        else
            cubeRenderer.material.SetColor("_Color", Color.blue);
    }
}
