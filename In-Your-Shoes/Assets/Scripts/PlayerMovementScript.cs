using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 10.0F;
    public float jumpSpeed = 22.5F;
    public bool grounded = false;
    private Rigidbody2D m_Rigidbody2D;
    private PolygonCollider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.drag = 0F;
        m_Rigidbody2D.freezeRotation = true;
        grounded = false;
    }


    // Update is called once per frame
    void Update() {
        transform.LookAt(m_Rigidbody2D.transform.position);

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
        Vector2 point2 = Vector2.zero;
        ContactPoint2D point = col.GetContact(0);
        point2 = m_Rigidbody2D.GetPoint(point2);
        if (point.point.y < -point2.y) {
            grounded = true;
        }
        Debug.Log("p1:" + point.point.y + "p2: " + -point2.y);
    }

    void OnCollisionExit2D(Collision2D col) {
        grounded = false;
    }
}
