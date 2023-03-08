using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 10;

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            this.gameObject.SetActive(false);

            // Trigger combat finish.

        }
    }
}
