using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static Vector2 wasd = Vector2.zero;
    public static Vector3 movement = Vector3.zero;
    public static int change = 0;

    public static int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void getMovement(InputAction.CallbackContext context){
        wasd = context.ReadValue<Vector2>();
        movement.x = wasd.x;
        movement.y = wasd.y;
    }

    public void getChange(InputAction.CallbackContext context){
        change = (int)context.ReadValue<float>();
        index += change;
    }
}
