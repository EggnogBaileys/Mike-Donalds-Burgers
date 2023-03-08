using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAHitbox : MonoBehaviour
{
    public GameObject potlid;

    private void OnCollisionEnter(Collision collision)
    {
        // Not sure if this is the right code for it, but I want to damage the player if the potlid does not enter collision.
        // May need to add another bool to make sure this only applies when active.
        if (potlid == null)
        {
            print("Player damaged");
        }
        else
        {
            print("Blocked");
        }
    }

}
