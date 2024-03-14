using UnityEngine;

public class Dial : MonoBehaviour
{

    [SerializeField] int size; // number of numbers on the dial
    public int fullRotations = 0;
    Vector3 currentMousePosition; // angle of mouse when clicked (relative to up)

    void OnMouseDown() // gets the current angle of the mouse
    {
        currentMousePosition = MousePosition();
    }

    void OnMouseDrag() // rotates the dial by the angle the mouse has moved
    {
        Vector3 newMousePosition = MousePosition();
        float mouseAngle = Vector3.SignedAngle(currentMousePosition, newMousePosition, Vector3.forward);
        Debug.Log(transform.eulerAngles.z);
        if (transform.eulerAngles.z + mouseAngle > 360f)
        {
            fullRotations += 1;
        }
        else if (transform.eulerAngles.z + mouseAngle < 0f)
        {
            fullRotations -= 1;
        }
        transform.Rotate(new Vector3(0f, 0f, mouseAngle));
        currentMousePosition = newMousePosition;
    }
    
    private Vector3 MousePosition() // calculates the current angle of the mouse
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
