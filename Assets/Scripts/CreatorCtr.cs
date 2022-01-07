using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorCtr : SingletonMonoBehavier<CreatorCtr>
{
    public Ball ball;
    Vector3 velocity;

    float angle = 5f;

    public void CreatorBallHell(int count,int id)
    {
        for (int i = 1; i < count + 1; i++)
            if (i % 2 == 0)
            {
                float projectileDirXPosition = velocity.x * Mathf.Cos((i / 2 * angle * Mathf.PI) / 180) - velocity.z * Mathf.Sin((i / 2 * angle * Mathf.PI) / 180);
                float projectileDirYPosition = velocity.x * Mathf.Sin((i / 2 * angle * Mathf.PI) / 180) + velocity.z * Mathf.Cos((i / 2 * angle * Mathf.PI) / 180);

                Vector3 ballnew1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                var ballnew = Instantiate(ball, ballnew1, Quaternion.identity);
                ballnew.SetDirection( new Vector3(projectileDirXPosition, 0.1f, projectileDirYPosition));
                ballnew.listIdDoor.Add(id);

            }
            else
            {
                float projectileDirXPosition = velocity.x * Mathf.Cos((-(i - 1) / 2 * angle * Mathf.PI) / 180) - velocity.z * Mathf.Sin((-(i - 1) / 2 * angle * Mathf.PI) / 180);
                float projectileDirYPosition = velocity.x * Mathf.Sin((-(i - 1) / 2 * angle * Mathf.PI) / 180) + velocity.z * Mathf.Cos((-(i - 1) / 2 * angle * Mathf.PI) / 180);

                Vector3 ballnew1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                var ballnew = Instantiate(ball, ballnew1, Quaternion.identity);
                ballnew.SetDirection(new Vector3(projectileDirXPosition, 0.1f, projectileDirYPosition));
                ballnew.listIdDoor.Add(id);
     
            }
    }
}
