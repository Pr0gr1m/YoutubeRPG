using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
//We need cinemachine in order for the code to work

public class CameraMovement : MonoBehaviour
{
    //Virtual camera is the componnent of cinemachine library
    public CinemachineVirtualCamera vcam;

    //You can change these values in inspector to whatever you want
    public float YDecrease = 1, ZDecrease = 0.75f;

    //These are values used in clamping
    public float MinY = 0.4f, MinZ = 5;
    public float MaxY = 12, MaxZ = 17;
  
    void Start()
    {
        vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        //We will only have one virtual camera in this video
    }

    // Update is called once per frame
    void Update()
    {
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel");

        //We get the value of scroll wheel, it usaully goes from 0.1 to -0.1
        //So lets change it to -1 and 1

        float MouseWheel = 0;

        if(MouseScroll > 0) MouseWheel = -1;
        else if(MouseScroll < 0) MouseWheel = 1;

        Cinemachine3rdPersonFollow follow = vcam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        //We get the 3rd person follow in order to change shoulder offset

        if(MouseScroll != 0)
        {
            //If we moved the scroll wheel
            //We add a new vector to the shoulder offset
            follow.ShoulderOffset += (new Vector3(0,YDecrease,ZDecrease) * MouseWheel);

            //Now we are clamping the values
            follow.ShoulderOffset.y = Mathf.Clamp(follow.ShoulderOffset.y, MinY, MaxY);
            follow.ShoulderOffset.z = Mathf.Clamp(follow.ShoulderOffset.z, MinZ, MaxZ);

         
        }
    }
}
