using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class neocontrol : NetworkBehaviour {

    public float speed = 3.0F;
    public float jumpForce = 7.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public bool isDead = false;

    void Start()
    {

        //Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded || isDead)
        {

            moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButton("Jump"))
                moveDirection.y = jumpForce;
        }


        moveDirection.y -= gravity * Time.deltaTime;


        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown("escape"))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }
}
