using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
    /*Enum that Stores Cursor Modes. 
     * If managed we can use to 
     * change the Mouse Icon based 
     * on desired interaction */
    public enum CursorMode
    {
        Default,
        View,
        Potato,
        Clock,
        Smooch
    }
    //Cursor Mode Current Mode Tracker
    public CursorMode currentMode;

    //Call The New Input Method
    private CursorControls controls;

    //Calling in the Script from the other Interactable components Manager
    [SerializeField]
    private InteractableManager interactableManager;

    //Grabbing Textures to use for the Mouse based on Mode
    [SerializeField]
    private Texture2D interactCursorTexture;

    //Extra Sprites for extra modes
    public Texture2D defaultInfoCursorTexture;
    public Texture2D viewCursorTexture;
    public Texture2D potatoCursorTexture;
    public Texture2D clockCursorTexture;

    //Textures for whether there is new interactions or not.
    public Texture2D knownInfoCursorTexture;
    public Texture2D newInfoCursorTexture;

    //Joke Atm Cursor
    public Texture2D smoochCursorTexture;

    //Grabbing the Cursor itself so as to alter it.
    private Cursor cursorControl;

    //Tracking of the transforms for Item Cursor is currently over.
    [SerializeField]
    private Transform newSelectionTransform;
    private Transform currentSelectionTransform;

    //Cursor Altered Forms Based on desired Action,
    //like Interacting, talking etc. Related to textures.
    public static Action DefaultCursor;
    public static Action InteractionACursor;

    //Bool that tracks whether an item is interactable.
    private bool cursorIsInteractive = false;

    //Bool that determines if the Object has New Info or not
    public bool checkThisOut;

    //Distance Threshold to determine whether can interact (in Pixels)
    public float DistanceThreshold;


    private void Awake()
    {
        //Call for the Custom "Cursor Controls"
        controls = new CursorControls(); 

        //Mouse Clicking Tracker
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();

        //Forms of the Cursor Based on Mode
        DefaultCursor += DefaultCursorTexture;
        InteractionACursor += InteractionCursorTexture;

        //Set Default Mode
        currentMode = CursorMode.Default;
    }

    //When the game Object is enabled, activate the control function
    private void OnEnable()
    {

        controls.Enable();
   
    }

    //if the game Object is disabled, deactivate the control funtion
    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        FindInteractableInRange();
    }

    private void FindInteractableInRange()
    {
        //Check for Nearby Interactable Objects
        newSelectionTransform = null;

        //Add In Interactable objects to the List
        for (int itemIndex = 0; itemIndex < interactableManager.Interactables.Count; itemIndex++)
        {
            //Check for Distance From Interactable and Cursor.
            Vector3 fromMouseToInteractableOffSet = interactableManager.Interactables[itemIndex].position 
                - new Vector3(controls.Mouse.Position.ReadValue<Vector2>().x, controls.Mouse.Position.ReadValue<Vector2>().y, 0f);

            float sqrMag = fromMouseToInteractableOffSet.sqrMagnitude;

            /* Check that mouse cursor is actually where the interactable object is,
             * reading from the list to determine which one if so and altering the mouse
             * by calling other functions based on interactability state. */
            if (sqrMag < DistanceThreshold * DistanceThreshold) 
            {
                newSelectionTransform = interactableManager.Interactables[itemIndex].transform;
                //Simply used to change state bassed on if interactable
                if (cursorIsInteractive == false)
                {
                    InteractionCursorTexture();
                }

                break;
            }
        }

        //Used to reset State if not interactable state.
        if (currentSelectionTransform != newSelectionTransform)
        {
            currentSelectionTransform = newSelectionTransform;
            DefaultCursorTexture();
        }
    }

    //This Function resets cursor mode state and form
    private void DefaultCursorTexture()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(default,default,default);
    }

    // This Function ALters the Form of the Cursor if the Object is interactible
    private void InteractionCursorTexture()
    {
        //Set Cursor to Interactive state
        cursorIsInteractive = true;

        //Change Sprite to Interactive.
        ChangeCursor();
    }

    //Use to alternate between Textures for Cursor When interacting, and mode of interaction as well as texture ultimately
    void ChangeCursor()
    {
        //Use this to alter the Cursor based on form by calling diofferent textures.
        if (currentMode == CursorMode.Default)
        {
            if(checkThisOut == true)
            {
                interactCursorTexture = newInfoCursorTexture;
            } else if (checkThisOut == false)
            {
                interactCursorTexture = knownInfoCursorTexture;
            }

            interactCursorTexture = defaultInfoCursorTexture;

        } else if (currentMode == CursorMode.View)
        {

            interactCursorTexture = viewCursorTexture;

        } else if (currentMode == CursorMode.Clock)
        {

            interactCursorTexture = clockCursorTexture;

        } else if (currentMode == CursorMode.Potato)
        {

            interactCursorTexture = potatoCursorTexture;

        } else if (currentMode == CursorMode.Smooch)
        {

            interactCursorTexture = smoochCursorTexture;

        }

        Vector2 hotspot = new Vector2(interactCursorTexture.width / 2, 0);
        Cursor.SetCursor(interactCursorTexture, hotspot, UnityEngine.CursorMode.Auto);

    }

    //Here in case wanna use for when a click is started.
    private void StartedClick()
    {

    }

   //When the click action is taken, apply function
    private void EndedClick()
    {
        OnClickInteractable();
    }

    //When the interactable is clicked, activate the on click action attributed to it by the interface Script
    private void OnClickInteractable()
    {
        if (newSelectionTransform != null)
        {
            IInteractable interactable =
                newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if(interactable != null ) { interactable.OnClickAction();}
            newSelectionTransform = null;
        }
    }
}
