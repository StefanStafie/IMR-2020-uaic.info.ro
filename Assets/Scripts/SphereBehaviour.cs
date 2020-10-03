using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{
    public GameObject sphere;
    public GameObject imageTarget;
    private Vector3 location;
    void Start()
    {
        location = new Vector3(1,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(imageTarget.transform.position.y>-0.3f)
        {
            location = location + new Vector3(0.01f,0.01f,0.01f);
        }
        else{
            location = new Vector3(1f,1f,1f);
        }
        sphere.transform.localScale = location;
    }
}
