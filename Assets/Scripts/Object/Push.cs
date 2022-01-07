using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Push : MonoBehaviour
public class Push : MonoBehaviour
{

    public Rigidbody rb;

    float speedMove = 5;

    void Start()
    {
    }
    private void Update()
    {

    }

    bool isFirstTime;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            var ball = col.GetComponent<Ball>();
            if (ball.GetTypeBall() == TypeBall.player)
            {
                PlayerCtr.Instance.SetCurrentBall();
            }

            if (col.transform.position.z <= transform.position.z)
            {
                Debug.Log("nho hon ");
                rb.AddForce(new Vector3(0, 0, 1000));
            }
            else
            {
                Debug.Log("lon hon ");
            }

            Destroy(col.gameObject);


        }


    }
}