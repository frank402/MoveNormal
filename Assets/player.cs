using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    GameObject[] tracks;
    public GameObject closesetTrack;
    Transform oParent;

    // Use this for initialization
    void Start()
    {
        tracks = GameObject.FindGameObjectsWithTag("track");
    }

    // Update is called once per frame
    void Update()
    {
        keepTrainOnTrack();
    }
    void keepTrainOnTrack()
    {
        //取得與我最近的軌道
        closesetTrack = getClosetTrack();

        //讓我跟最近的軌道一樣旋轉值
        setRoate(closesetTrack.transform.eulerAngles);



    }
    //取得最近的軌道值
    GameObject getClosetTrack()
    {
        float dist = Mathf.Infinity;//DIST = 正無窮大
        GameObject closesetTrack = null;

        foreach (var t in tracks)
        {
            float tempDist = Vector3.Distance(transform.position, t.transform.position);
            if (tempDist < dist)
            {
                dist = tempDist;
                closesetTrack = t;             
            }          
        } 
        return closesetTrack;

    }
    public void forward()
    {
        //浮在最近的軌道上面
        oParent = transform.parent;
        transform.parent = closesetTrack.transform;
        transform.localPosition = new Vector3(transform.localPosition.x, 2, 0);
        transform.position += transform.up * 0.5f;
        transform.parent = oParent;
    }
    public void backward()
    {
        oParent = transform.parent;
        transform.parent = closesetTrack.transform;
        transform.localPosition = new Vector3(transform.localPosition.x, 2, 0);
        transform.position -= transform.up * 0.5f;
        transform.parent = oParent;
    }
    void setRoate(Vector3 r)
    {
        transform.eulerAngles = r;
        transform.eulerAngles += new Vector3(0, 0, 90);
    }
}
