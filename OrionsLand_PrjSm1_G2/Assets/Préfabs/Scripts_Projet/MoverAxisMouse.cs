using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAxisMouse : MonoBehaviour
{
    [Header("Player RigidBody")]
    //public Rigidbody Player;

    [Space(10)]
    [Header("Camera Variables")]
    public CharacterController characterController;
    public Rigidbody player;
    public Transform cam;
    public float speed = 10f;
    public float turnSmooth = 0.1f;
    float turnSmoothVelocity;

    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dirrection = new Vector3(horizontal, 0f, vertical).normalized;

        if (dirrection.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDir = Quaternion.Euler(0, 0, targetAngle) * Vector3.forward;
            player.AddForce(moveDir * Time.deltaTime * speed);
        }
    }
}
