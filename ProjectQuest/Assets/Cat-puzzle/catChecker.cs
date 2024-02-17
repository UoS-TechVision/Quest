using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catChecker : MonoBehaviour
{
    public void CatLoop()
    {
        foreach(Transform child in transform){
            if (child.GetComponent<CatInteractions>().outlined){
                child.GetComponent<CatInteractions>().CheckWin();
                break;
            }
        }
    }

    public void SelectLoop()
    {
        foreach(Transform child in transform){
            child.GetComponent<CatInteractions>().Unselect();
        }
    }
}
