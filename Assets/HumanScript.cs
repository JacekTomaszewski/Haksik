using System;
using UnityEngine;

public class HumanScript : MonoBehaviour {

    #region Const
    public static string ballObjectName = "ball";
    public static float runSpeed = 0.13f;
    public static float shotSpeed = 0.003f;
    #endregion

    #region Properties
    private Rigidbody2D ballObject;
    private Rigidbody2D humanObject;
    #endregion

    #region Methods

    void Start () {

    }
	
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y+= runSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.y-= runSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x-= runSpeed;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x+= runSpeed;
            this.transform.position = position;
        }

        if(Input.GetKey(KeyCode.Space) && HumanVsBallPositionIsCorrect())
        {
            DoShot();
        }

    }

    void DoShot()
    {
        Vector3 shotVector = (ballObject.transform.position - humanObject.transform.position);
        ballObject.AddForce(shotVector * shotSpeed);
    }

    public bool HumanVsBallPositionIsCorrect()
    {
        ballObject = GameObject.Find(ballObjectName).GetComponent<Rigidbody2D>();
        humanObject = GetComponent<Rigidbody2D>();

        //
        // #TODO Wyliczenie możliwości strzału, teraz jest to spieprzone ;)
        //
        if ((Math.Abs(ballObject.transform.position.x) - Math.Abs(humanObject.transform.position.x) < 0.1) || 
            (Math.Abs(ballObject.transform.position.y) - Math.Abs(humanObject.transform.position.y) < 0.1))
            return true;
        return false;
    }

    #endregion

}