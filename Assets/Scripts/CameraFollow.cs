using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 maxPos;//bounds
    public Vector2 minPos;//bounds

    public void FixedUpdate(){
        if(transform.position != target.position){
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z); //bring camera to target
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
