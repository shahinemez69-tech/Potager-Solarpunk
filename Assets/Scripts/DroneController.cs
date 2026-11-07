using UnityEngine;
using UnityEngine.InputSystem;

public class DroneController : MonoBehaviour
{
    public float speed = 5f;                
    public InputActionReference moveAction;   
    public Vector2 minBounds = new Vector2(-4.5f, -4.5f); 
    public Vector2 maxBounds = new Vector2(4.5f, 4.5f);   

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        float moveX = input.x * speed * Time.deltaTime;
        float moveZ = input.y * speed * Time.deltaTime;
        transform.Translate(moveX, 0f, moveZ, Space.World);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.z = Mathf.Clamp(pos.z, minBounds.y, maxBounds.y);
        transform.position = pos;
    }
}