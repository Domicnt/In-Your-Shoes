using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 42.0F;
    public float jumpSpeed = 100.0F;
    public float distToGround;
    public bool grounded = true;
    private Rigidbody2D m_Rigidbody2D;
    private BoxCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        distToGround = m_Collider.bounds.extents.y;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.drag = 0F;
        m_Rigidbody2D.freezeRotation = true;
        grounded = true;
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKey("a"))
            m_Rigidbody2D.velocity = new Vector2(-speed, m_Rigidbody2D.velocity.y);
        if (Input.GetKey("d"))
            m_Rigidbody2D.velocity = new Vector2(speed, m_Rigidbody2D.velocity.y);
        else if (!Input.GetKey("a"))
            m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
        if (Input.GetButton("Jump") && grounded)
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpSpeed);
    }

    void OnCollisionEnter2D(Collision2D col) {
        grounded = true;
        Debug.Log("grounded");
    }
    void OnCollisionExit2D(Collision2D col) {
        grounded = false;
        Debug.Log("groundedn't");
    }
}
