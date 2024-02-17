using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInteractions : MonoBehaviour
{
   Vector3 mousePositionOffset;
    public Material[] materials = new Material[2];
    [SerializeField]public bool outlined = false;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {   

        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
        outlined = !outlined;

        if (outlined){
            this.transform.parent.GetComponent<catChecker>().SelectLoop();
            gameObject.GetComponent<SpriteRenderer>().material = materials[1];
            outlined = true;

        }
        else{
            gameObject.GetComponent<SpriteRenderer>().material = materials[0]; 
        }

    }

    private void OnMouseDrag()
    {
        if (outlined){
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
         
    }

    public void Unselect()
    {
        outlined = false;
        gameObject.GetComponent<SpriteRenderer>().material = materials[0]; 
    }

    public void CheckWin()
    {
        if (this.tag == "Mittens"){
            Debug.Log("Win");
        }
        else{
            Debug.Log("Lose");
        }
        Unselect();
    }

}
