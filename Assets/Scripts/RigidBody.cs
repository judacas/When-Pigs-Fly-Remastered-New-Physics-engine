// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// //todo: Make a new collider that is for walls and floors, so a plane that has a set side where things should not be able to get across
// // like basically a box collider, but the depth is to say that anything inside of the box collider should be on the specific edge, with regular collider it might go to the other side if its too fast

// public class RigidBody : MonoBehaviour
// {
//     bool isStatic;
//     Vector3 position, velocity, acceleration;
//     float mass;

//     public RigidBody (Transform transform, bool isStatic = false){
//         position = transform.position;
//         velocity = Vector3.zero;
//         acceleration = Vector3.zero;
//         this.isStatic = isStatic;


//     }

//     public Vector3 addForce(Vector3 force){
//         acceleration = force * (1.0f / mass);
//         return acceleration;

//     }

//     public Vector3 update(){
//         velocity += acceleration;
//         position += velocity;
//         acceleration = 0;
//         return position;
//     }

//     public Vector3 getPosition(){
//         return position;
//     }
//     public Vector3 getVelocity(){
//         return velocity;
//     }
//      public Vector3 getAcceleration(){
//         return acceleration;
//     }


// }
