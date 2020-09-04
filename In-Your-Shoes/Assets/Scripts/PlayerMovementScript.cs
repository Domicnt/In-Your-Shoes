using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 10.0F;
    public float jumpSpeed = 22.5F;
    public bool grounded = true;
    private Rigidbody2D m_Rigidbody2D;
    private PolygonCollider2D m_Collider;

    private bool gameStart;
    public DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<PolygonCollider2D>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.drag = 0F;
        m_Rigidbody2D.freezeRotation = true;
        grounded = true;
        gameStart = true;
    }


    // Update is called once per frame
    void Update() {
        if (gameStart)
        {
            dialogueTrigger.TriggerDialogue();
            gameStart = false;
        }

        transform.LookAt(m_Rigidbody2D.transform.position);

        if (Input.GetKey("a"))
            m_Rigidbody2D.velocity = new Vector2(-speed, m_Rigidbody2D.velocity.y);
        if (Input.GetKey("d"))
            m_Rigidbody2D.velocity = new Vector2(speed, m_Rigidbody2D.velocity.y);
        else if (!Input.GetKey("a"))
            m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
        if (Input.GetButton("Jump") && grounded)
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpSpeed);
        grounded = false;
    }


    void OnCollisionStay2D(Collision2D col) {
        ContactPoint2D[] points = {};
        col.GetContacts(points);
        grounded = true;
        /*foreach(ContactPoint2D p in points) {
            if (p.collider == m_Collider || p.otherCollider == m_Collider) {
                grounded = true;
            } 
        }*/
        Debug.Log(col.contactCount);
    }
}
