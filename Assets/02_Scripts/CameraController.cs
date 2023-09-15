using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] movePos;
    public Transform targetPos;

    public int currentIdx = 0;
    public int scroll = 0;
    public float zoomSpeed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Zoom();
    }

    public void CameraMove()
    {
        Camera.main.transform.position = movePos[currentIdx].position;
        Camera.main.transform.rotation = movePos[currentIdx].rotation;
    }

    public void Zoom()
    {
        if(scroll != 0)
        {
            Transform cam = Camera.main.transform;

            if(Camera.main.fieldOfView <= 20 )
            {
                Camera.main.fieldOfView = 20;
            }
            else if(Camera.main.fieldOfView >= 60)
            {
                Camera.main.fieldOfView = 60;
            }
            Camera.main.fieldOfView -= scroll * zoomSpeed;
        }
    }

    public void ZoomInButton()
    {
        scroll = 1;
    }

    public void ZoomOutButton()
    {
        scroll = -1;
    }

    public void ZoomStop()
    {
        scroll = 0;
    }

    public void LeftButton()
    {
        if(currentIdx == 3)
        {
            currentIdx = 0;
        }
        else
        {
            currentIdx += 1;
        }

        CameraMove();
    }

    public void RightButton()
    {
        if(currentIdx == 0)
        {
            currentIdx = 3;
        }
        else
        {
            currentIdx -= 1;
        }

        CameraMove();
    }
}
