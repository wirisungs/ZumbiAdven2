using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera camPlayer;
    public Transform followPlayer;



    Vector2 startingPostion;
    float startingZ;

    Vector2 camMoveSinceStart => (Vector2)camPlayer.transform.position - startingPostion;

    float zDistanceFromTarget => transform.position.z - followPlayer.transform.position.z;

    float clippingPlane => (camPlayer.transform.position.z + (zDistanceFromTarget > 0 ? camPlayer.farClipPlane : camPlayer.nearClipPlane)); 

    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;


    // Start is called before the first frame update
    void Start()
    {
        startingPostion = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startingPostion + camMoveSinceStart * parallaxFactor;

        transform.position = new Vector3(newPos.x, newPos.y, startingZ);
    }
}
