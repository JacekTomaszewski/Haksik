using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float speed = 150f;
    public Rigidbody2D rb2D;
	// Use this for initialization
	void Start ()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
     //   rb2D.velocity = Vector2.right * speed;
    }
	
	// Update is called once per frame
	void Update () {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir;// * speed;
        }
    }

    public float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight, bool getShot = false)
    {
        float hitFactor = (ballPos.y - racketPos.y) / racketHeight;
        return hitFactor;
    }
}
