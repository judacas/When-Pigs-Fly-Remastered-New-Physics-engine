// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CamTarg : MonoBehaviour
// {
//     Transform player;
//     newMovement movement;
//     public float lookAhead;
//     Vector3 target;
//     Variables settings;

//     public float dampening;
//     // Start is called before the first frame update
//     void Awake()
//     {
//         settings = GameObject.Find("Controller").GetComponent<Variables>();
//         player = settings.PLAYER;
//         movement = player.GetComponent<newMovement>();
//         transform.position = player.position;
//         target = transform.position;
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         target = player.position + movement.finalVelocity * lookAhead;
//         transform.position = (transform.position + (target-transform.position)/dampening);
//         updateCam();
//     }

//     void updateCam(){
//         settings.CAM.transform.position = transform.position + new Vector3(0, Mathf.Sin(settings.CAM_ANGLE * Mathf.Deg2Rad), -Mathf.Cos(settings.CAM_ANGLE * Mathf.Deg2Rad)) * settings.CAM_DIST;
//         settings.CAM.transform.rotation = Quaternion.Euler(new Vector3(settings.CAM_ANGLE + settings.CAM_OFFSET_ANGLE, 0, 0));
//     }


// }
