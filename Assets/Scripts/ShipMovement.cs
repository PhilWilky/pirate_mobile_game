using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Vector3 initialMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float mouseX = Input.mousePosition.x - initialMousePosition.x;
            float mouseY = Input.mousePosition.y - initialMousePosition.y;

            float rotation = -mouseX * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.down, rotation);

            float forwardMovement = mouseY * moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * forwardMovement);
        }
    }
}
