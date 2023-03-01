using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    //list of all Interactibles in the field.
    [SerializeField]
    private List<Transform> interactables;

    public List<Transform> Interactables
    {
        get => interactables;
    }

    //Access to game assets and Components
    private Camera mainCamera;

    //Actions Performed When Interacting
    public static Action<Transform> AddToInteractablesEvent;
    public static Action<Transform> RemoveFromInteractablesEvent;

    //Applied at start of function
    private void Awake()
    {
        AddToInteractablesEvent += AddToListOfInteractables;
        RemoveFromInteractablesEvent += RemoveFromListOfInteractables;
    }

    //This function adds the transforms of the children to the list, so they may be tracked.
    private void AddToListOfInteractables(Transform transformToAdd)
    {
        interactables.Add(transformToAdd);
    }
    //This one Removes the transforms from the list.
    private void RemoveFromListOfInteractables (Transform transformToRemove)
    {
        interactables.Remove(transformToRemove);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Access Main Camera
        mainCamera = Camera.main;

        //Locate Interactables in the children of this Game Object
        LocateAllInteractableObjects();
    }

    //This Function is used to locate all objects in the camera view related to interactable object
    void LocateAllInteractableObjects()
    {
        for (int i = 0; i < this.transform.childCount; i++) 
        {
            transform.GetChild(i).position =
                mainCamera.WorldToScreenPoint(transform.GetChild(i).position);

            transform.GetChild(i).localScale = Vector3.one * 100;
        }
        
    }
}
