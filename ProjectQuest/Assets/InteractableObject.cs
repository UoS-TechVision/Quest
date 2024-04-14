using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object", menuName = "Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public new string name;
    public int quantityHeld;
    public Sprite sprite;

    public void Pickup ()
    {
        // TODO
    }
}
