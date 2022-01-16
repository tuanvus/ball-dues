using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Push : MonoBehaviour
public class Push : MonoBehaviour
{

    public Rigidbody rb;

   private float _speedMove = 5;


    void Start()
    {
    }
    private void Update()
    {

    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            var ball = col.GetComponent<Ball>();
            if (ball.GetTypeBall() == NodeBall.PLAYER)
            {
                PlayerCtr.Instance.SetCurrentBall();
            }

            if (col.transform.position.z <= transform.position.z)
            {
                rb.AddForce(new Vector3(0, 0, 1000));
            }
            else
            {
            }

            col.gameObject.SetActive(false);


        }


    }
}