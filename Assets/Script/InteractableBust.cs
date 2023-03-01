using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBust : MonoBehaviour, IInteractable
{

    /*this is a test script to display how stuff is displayed,
     * when combined fwith tags, names and bools a master script
     * could be made and appliedd ot all interactibles that result
     * in different responses. */
    //Function that calls what will happen when this object is clicked.
    public void OnClickAction()
    {
        Debug.Log("you Clicked on the Bust"); //Action example
    }

   /* When this Object is enabled,
    * it will be added to the list.
    * When it is Disabled the Opposite happens.
    * We can make use of this by having
    * objects only be enabled when they
    * are in cmaera view, or alternate
    * enabling and disabling every time
    * the camera moves */
   void OnEnable()
    {
        InteractableManager.AddToInteractablesEvent.Invoke(transform);
    }

    void OnDisable()
    {
        InteractableManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
