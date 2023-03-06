using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private GameObject Player;
    private Vector3 target;

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.LookAt(target, Vector3.up);
    }
}
