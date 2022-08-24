// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Spawn : MonoBehaviour
// {
//     Variables settings;
//     public enum SpawnType
//     {
//         Pig,
//         Carrot,
//         Catapult
//     }
//     public enum Orientation
//     {
//         Horizontal,
//         Vertical,
//     }

//     public SpawnType type;

//     [Header("If its a catapult then extra settings")]
//     public float Length, strengthOffset;
//     public Orientation catapultDirection;
//     public Orientation railDirection;
//     Quaternion catDir;
//     Vector3 railDir;
//     // Start is called before the first frame update
//     void Awake()
//     {
//         settings = GameObject.Find("Controller").GetComponent<Variables>();
//     }

//     public void Generate()
//     {
//         switch (type)
//         {
//             case SpawnType.Pig:
//                 Instantiate(settings.Pig, transform.position, transform.rotation, transform.parent.parent.parent.Find("Pigs"));
//                 break;
//             case SpawnType.Carrot:
//                 Instantiate(settings.Carrot, transform.position, transform.rotation, transform.parent.parent.parent.Find("Carrots"));
//                 break;
//             case SpawnType.Catapult:
//                 switch (catapultDirection)
//                 {
//                     case Orientation.Horizontal:
//                         catDir = Quaternion.Euler(new Vector3(0, 0, 0));
//                         break;
//                     case Orientation.Vertical:
//                         catDir = Quaternion.Euler(new Vector3(0, 90, 0));
//                         break;
//                 }
//                 switch (railDirection)
//                 {
//                     case Orientation.Horizontal:
//                         railDir = Vector3.right;
//                         break;
//                     case Orientation.Vertical:
//                         railDir = Vector3.forward;
//                         break;
//                 }
//                 Instantiate(settings.Catapult, transform.position, catDir, transform.parent.parent.parent.Find("Catapults")).GetComponent<launcher>().setUp(railDir, Length, transform.position, strengthOffset);
//                 float railLength = settings.Rail.GetComponent<BoxCollider>().size.x /2;
//                 for (int i = 0; i < (Length / railLength); i++)
//                 {
//                     Instantiate(settings.Rail, transform.position - ((float)(i - (((Length / railLength)) / 2f)) * railDir), Quaternion.Euler(new Vector3(90, 0, 0)), transform.parent.parent.parent.Find("Rails"));
//                 }

//                 break;
//         }
//     }
// }
