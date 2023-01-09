using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayerOrion : MonoBehaviour
{
    public CharacterController Player;
    public Transform cam;

    public string hInputName = "Horizontal";
    public string vInputName = "Vertical";
    public float speed ;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(0f, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; 
            //Target l'angle visé de la caméra avec la souris quand le joueur bouge sur l'angle Y
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
            //Rend le movement de caméra smooth

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            //Prend l'angle targeté et le choisit comme dirrection pour avancer devant
            transform.rotation = Quaternion.Euler(0f, angle, 0f); 

            Player.Move(moveDir.normalized * speed * Time.deltaTime); // Code pour enclencher le movement
        }
    }
}
