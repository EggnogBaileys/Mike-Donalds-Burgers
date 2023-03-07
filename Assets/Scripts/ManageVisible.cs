using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageVisible : MonoBehaviour
{
    void OnBecameInvisible()
    {
        GetComponent<InteractableBust>().enabled = false;
    }

    void OnBecameVisible()
    {
        GetComponent<InteractableManager>().LocateAllInteractableObjects();
        GetComponent<InteractableBust>().enabled = true;
    }
}
