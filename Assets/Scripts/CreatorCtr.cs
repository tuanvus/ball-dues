using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorCtr : SingletonMonoBehavier<CreatorCtr>
{
    public Ball ball;
    Vector3 velocity;

    float angle = 5f;

    public Ball CreatorBallHell(Vector3 pos, int i, int id)
    {

        var ballnew = PoolingObject.GetObjectFree(ball);
        ballnew.AddID_Door(id);
        ballnew.transform.position = pos;
        ballnew.SetDirectionWithSpawn(i);
        ballnew.transform.SetParent(transform);
        return ballnew;

    }
    public Ball CreatorBall(Vector3 pos)
    {

        var ballnew = PoolingObject.GetObjectFree(ball);
        ballnew.transform.position = pos;

        ballnew.SetDirection(pos);
        ballnew.transform.SetParent(transform);
        return ballnew;
    }
}
