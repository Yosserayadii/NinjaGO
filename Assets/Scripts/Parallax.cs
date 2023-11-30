using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Parallax : MonoBehaviour
{
    private Transform theCam;
    public Transform sky, treeLine;
   [ Range(0f, 1f)] 
    public float ParallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        sky.position=new Vector3(theCam.position.x,theCam.position.y,sky.position.z);
        treeLine.position = new Vector3(theCam.position.x * ParallaxSpeed, theCam.position.y, treeLine.position.z);
    }
}
