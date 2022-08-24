// using System.Transactions;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// //this class is made just so I can change all of the settings of the game in one spot while still in development
// //especially since most should be static variables, they wouldn't normally show up in inspector otherwise
// public class Variables : MonoBehaviour
// {
//     // variables
//     #region  
//     [Header("General Settings")]
//     public int MAX_LVL = 3;
//     public int START_ON_LVL = 1;
//     public int currentLvl = 1;
//     public int LVL_DELETE_DELAY;
//     private float TIME_TO_DELETE_LVL;

//     public Transform currentController;

//     [Header("Player settings")]
//     public float PL_MAX_VEL = 12f;
//     public float PL_SPEED_UP = 0.1f;
//     public float PL_SLOW_DOWN = 0.1f;
//     public float PL_TURN_DAMP = 10f;
//     public float PL_RAD = 0.6f;
//     public float PL_PIG_GRAB_DIST = 5f;
//     public float PL_CARR_GRAB_DIST = 2f;
//     public float PL_CAT_PICK_DIST = 3;
//     [Space(30)]
//     public Transform HAND;
//     public Transform PLAYER;

//     [Header("Pig settings")]
//     public float PIG_RAD = 0.86f;
//     public float PIG_MAX_VEL = 0.5f;
//     public float PIG_MIN_VEL = 0.05f;
//     public float PIG_SPEED_UP = 3f;
//     public float PIG_SLOW_DOWN = 2f;
//     public float PIG_TURN_DAMP = 10f;
//     public float PIG_FOV = 45f;
//     public float PIG_PICKED_DIST = 5f;
//     public float PIG_LAUNCH_DIST = 5f;
//     public float PIG_LAUNCH_HEIGHT = 10f;
//     public float PIG_LAUNCH_TIME = 1f;

//     public int PIGPREDACC = 10;
//     public float PIG_CAT_ACC = 15;
//     public float PIGPREDSPEED = 0.5f;
//     public Transform pigs;
//     public GameObject predictors;

//     [Header("Prefabs")]
//     public GameObject Pig;
//     public GameObject Carrot;
//     public GameObject Catapult;
//     public GameObject Predictor;

//     [Header("Catapult Settings")]
//     public float CAT_MAX_ANGLE = 15;
//     public float CAT_Y_PRECISION;
//     public float CAT_ROTATE_SPEED;
//     public float CAT_LAUNCH_DIST = 15;
//     public float CAT_LAUNCH_HEIGHT = 15;
//     public int CAT_PRED_ACC;
//     public Transform catapults;
//     public GameObject Rail;

//     [Header("Carrot Settings")]
//     public Transform carrots;

//     [Header("Camera Settings")]
//     public float CAMERA_STIFFNESS = 1;
//     public float CAM_DIST;
//     public float CAM_ANGLE;
//     public float CAM_OFFSET_ANGLE;
//     public Camera CAM;


//     public List<Transform> circles;
//     #endregion

//     void Start()
//     {
//         currentLvl = START_ON_LVL;
//         MAX_LVL = transform.childCount - 2;
//         Pig = Resources.Load("Pig") as GameObject;
//         Carrot = Resources.Load("Carrot") as GameObject;
//         Catapult = Resources.Load("Catapult") as GameObject;
//         Predictor = Resources.Load("predictor") as GameObject;
//         Rail = Resources.Load("Rail") as GameObject;

//         PLAYER = GameObject.Find("Player").transform;
//         HAND = GameObject.Find("R_Arm_Hand_end").transform;
//         CAM = Camera.main;
//         predictors = GameObject.Find("Predictors");
//         predictors.GetComponent<Predictor>().setUp(PIGPREDACC);
//         currentController = transform.GetChild(currentLvl);
//         MAX_LVL = transform.childCount - 2;
//         PLAYER.position = new Vector3((currentLvl-1) * 100 + 50, 0, 0);
//         setLvl(currentLvl);
//     }

//     void setLvl(int lvl)
//     {
//         if (lvl <= MAX_LVL)
//         {
//             currentController = transform.GetChild(lvl-1);
//             currentController.gameObject.SetActive(true);
//             currentController.GetComponent<lvlSettings>().changeSettings();
//             PLAYER.parent = currentController;
//             currentLvl = lvl;
//             pigs = currentController.transform.Find("Pigs");
//             catapults = currentController.transform.Find("Catapults");
//             carrots = currentController.Find("Carrots");
//             circles = new List<Transform>() { pigs, catapults };
//             if (lvl - 1 > 0)
//             {
//                 TIME_TO_DELETE_LVL = Time.time + LVL_DELETE_DELAY;
//             }
//             LoadLvl(lvl);
//         }
//     }

//     void LoadLvl(int lvl)
//     {
//         if (lvl <= MAX_LVL)
//         {
//             foreach (Transform type in transform.GetChild(lvl - 1).Find("Spawners").transform)
//             {
//                 foreach (Transform spawner in type)
//                 {
//                     spawner.gameObject.GetComponent<Spawn>().Generate();
//                 }
//             }
//         }
//     }

//     void destroyLvl(int lvl)
//     {
//         if (lvl > 0)
//         {
//             transform.GetChild(lvl - 1).gameObject.SetActive(false);
//         }
//     }
//     void Update()
//     {
//         if (TIME_TO_DELETE_LVL != 0)
//         {
//             if (Time.time > TIME_TO_DELETE_LVL)
//             {
//                 destroyLvl(currentLvl - 1);
//                 TIME_TO_DELETE_LVL = 0f;
//             }
//         }

//         if ((((int)PLAYER.position.x) / 100) + 1 != currentLvl)
//         {
//             setLvl((((int)PLAYER.position.x) / 100) + 1);
//         }
//     }


// }
