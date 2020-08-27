using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float accelSpeed = 1.0F;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 10.0F;
    private Vector2 velocity = Vector2.zero;
    private Rigidbody2D m_Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("a"))
            velocity.x -= accelSpeed * Time.deltaTime;
        if (Input.GetKey("d"))
            velocity.x += accelSpeed * Time.deltaTime;
        /*if (controller.isGrounded && Input.GetButton("Jump"))
            velocity.y = jumpSpeed;
             
        if (velocity.x > speed)
            velocity.x = speed;
        else if (velocity.x < -speed)
            velocity.x = -speed;
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);*/
     }
}
