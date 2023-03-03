using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    /*This is an Interface Script,
     * which is accessed in other scripts.
     * With this you can add to the dialog
     * script via OnClick action to determine
     * further responses based on private
     * or public variables. */
    void OnClickAction();
}
