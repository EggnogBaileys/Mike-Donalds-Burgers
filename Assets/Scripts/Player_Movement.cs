using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEditor.PackageManager;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Inputs: ")]
    [SerializeField] private KeyCode forward = KeyCode.W;
    [SerializeField] private KeyCode back = KeyCode.S;
    [SerializeField] private KeyCode right = KeyCode.A;
    [SerializeField] private KeyCode left = KeyCode.D;

    [Header("Movement: ")]
    [SerializeField] private float step = 1f;
    [SerializeField] private float rot_right = 90f;
    [SerializeField] private float rot_left = -90f;
    [SerializeField] private float rot_back = 180f;

    [Header("Collision: ")]
    [SerializeField] private LayerMask floor;
    private bool can_move = true;
    [SerializeField] private float col_length = 1.1f;
    private Ray movement_ray;
    private RaycastHit movement_hit;

    void Update()
    {
        //Movement
        if(Input.GetKeyDown(forward))
        {
            can_move = true;
            Collision();
            if(can_move)
            {
                transform.position += Camera.main.transform.forward * step;
            }
        }
        //Rotation
        if(Input.GetKeyDown(right))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y+ rot_right, 0);
        }
        if (Input.GetKeyDown(left))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + rot_left, 0);
        }
        if (Input.GetKeyDown(back))
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + rot_back, 0);
        }
    }

    void Collision()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out movement_hit, col_length, floor))
        {
            can_move = false;
        }
    }
}
