using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float sensitivityX = 5f;
    public float sensitivityY = 5f;
    public float gravity = 9.81f;
    public float jumpSpeed = 30f;
    public float smoothTime = 0.1f;
    public float turnVelocity;
    private CharacterController characterController;
    private Rigidbody rigidBody;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxisRaw("Horizontal");
        float vinput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hinput, 0, vinput).normalized;
        if(direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            direction = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized*speed;
            if (Input.GetKey(KeyCode.LeftShift)) direction *= 2;
            characterController.Move(direction * Time.deltaTime);
        }
        
        
    }
}
