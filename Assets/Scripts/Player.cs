using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivityX = 5f;
    public float sensitivityY = 5f;
    public float gravity = 9.81f;
    public float jumpSpeed = 20f;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
        float vinput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hinput, 0, vinput)*speed;
        direction = transform.TransformDirection(direction);
        direction.y -= gravity;
        if (direction.y < 0 && characterController.isGrounded) direction.y = 0f;
        characterController.Move(direction*Time.deltaTime);
        float rotateX = Input.GetAxis("Mouse X") * sensitivityX;
        transform.localEulerAngles += new Vector3(0, rotateX, 0);
    }
}
