using UnityEngine;

public class Dial : MonoBehaviour
{

    [SerializeField] int size; //number of numbers on the dial
    float initialAngle; //angle of the dial when clicked (relative to up)
    float initialMouseAngle; //angle of mouse when clicked (relative to up)

    void OnMouseDown()
    {
        initialAngle = transform.eulerAngles.z;
        Debug.Log(initialAngle);
        initialMouseAngle = MouseAngle();
    }

    void OnMouseDrag()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, initialAngle + (MouseAngle() - initialMouseAngle)));
    }
    
    private float MouseAngle()
    {
        Vector3 mouseScreenPosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        return Mathf.Atan2(mouseScreenPosition.y, mouseScreenPosition.x) * Mathf.Rad2Deg - 90;
    }
}
