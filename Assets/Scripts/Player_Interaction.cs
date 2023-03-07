using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Player_Interaction : MonoBehaviour
{
    /*Fire raycast from camera origin to mouse position, check if it returns an object with an "Interactable" or 
     * "NPC" tag. Access a script, and call a function*/

    [Header("References: ")]
    [SerializeField] private Camera CameraRef;
    [SerializeField] private LayerMask Interactables;
    
    [Header("Inputs: ")]
    [SerializeField] private int interact = 0; //0 = left
    [SerializeField] private float raycast_range = 1.1f;

    [Header("Cursor: ")]
    [SerializeField] Texture2D cursor;
    [SerializeField] Texture2D defaultcursor;

    //Raycast
    RaycastHit hit;
    Ray ray;

    void Update()
    {
        Hover();
        Click();
        CursorUpdate();
    }
    void Click()
    {
        if(Input.GetMouseButtonDown(interact)) //On left button pressed
        {
            RayCast();
            if (Physics.Raycast(ray, out hit, raycast_range, Interactables))
            {
                hit.collider.gameObject.GetComponent<Interactable>().Interact();
            }
        }
    }
    void Hover() //Mouse Hovering Over Something
    {
        RayCast();
        if (Physics.Raycast(ray, out hit, raycast_range, Interactables))
        {
            cursor = hit.collider.gameObject.GetComponent<Interactable>().cursor_appearance;
        }
        else
        {
            cursor = defaultcursor;
        }
    }

    void RayCast() //Handles the raycast
    {
        ray = CameraRef.ScreenPointToRay(Input.mousePosition);
    }

    void CursorUpdate()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

}
