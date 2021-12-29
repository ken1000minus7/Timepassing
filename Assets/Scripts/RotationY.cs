using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotateY = -Input.GetAxis("Mouse Y")*player.sensitivityY;
        Vector3 rotation = transform.localEulerAngles;
        rotation += new Vector3(rotateY,0,0);
        if (rotation.x < 270 && rotation.x>180)
        {
            Debug.Log(rotation.x);
            rotation.x = 270;
        }
        if(rotation.x>40 && rotation.x<180)
        {
            Debug.Log(rotation.x);
            rotation.x = 40;
        }
        transform.localEulerAngles = rotation;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(0);
        }
    }
}
