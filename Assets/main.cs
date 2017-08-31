using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    player train;
    Vector3 cam2train;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        train = GameObject.Find("train").GetComponent<player>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam2train = cam.transform.position - train.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        control();
        camFollowTrain();


    }
    void camFollowTrain()
    {
        cam.transform.position = train.transform.position + cam2train;

    }
    void control()
    {
        if (Input.GetKey("a"))
        {
            train.forward();

        }
        if (Input.GetKey("d"))
        {
            train.backward();
        }
    }
}
