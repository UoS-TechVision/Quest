using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class maidFloatScript : MonoBehaviour
{
    private float speed = 3f;
    private float height = 0.3f;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, startY + (newY * height), pos.z);    
    }
}
