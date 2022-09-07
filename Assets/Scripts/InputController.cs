using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Vector2 wasd = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controller.rec.moveParticle(new Vector3(2,2,2), wasd*3);
    }

    public void getInput(InputAction.CallbackContext context){
        wasd = context.ReadValue<Vector2>();
    }
}
