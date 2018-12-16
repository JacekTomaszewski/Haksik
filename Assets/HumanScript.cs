using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour {

    BallScript ball;
    private float speed = 0.1f;
    Vector3 ballPosition;
    Vector3 humanPosition;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y+=speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.y-= speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x-= speed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x+= speed;
            this.transform.position = position;
        }

        if(Input.GetKey(KeyCode.Space) && HumanVsBallPositionIsCorrect())
        {
            Fire();
        }

    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = GameObject.Find("ball").GetComponent<Rigidbody2D>();
        var currentHumanPosition = GetComponent<Rigidbody2D>().transform.position;
        currentHumanPosition.x = currentHumanPosition.x;
        currentHumanPosition.y = currentHumanPosition.y;
        // Add velocity to the bullet
        Vector3 shoot = ( bullet.transform.position + currentHumanPosition).normalized;
        bullet.AddForce(shoot * 0.003f);

    }

    public bool HumanVsBallPositionIsCorrect()
    {
        ballPosition = GameObject.Find("ball").transform.position;
        humanPosition = GetComponent<Rigidbody2D>().transform.position;
        if (ballPosition.x - humanPosition.x < 1)
            return true;
        if (ballPosition.y - humanPosition.y < 1)
            return true;
        return false;
    }

}
