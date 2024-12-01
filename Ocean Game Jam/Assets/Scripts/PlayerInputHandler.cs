using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] Ship playerShip;

    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero; 
        if (Input.GetKey(KeyCode.W)){
            movement += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S)){
            movement += new Vector3(0, -1, 0);
        }
        playerShip.Move(movement);
    }
}
