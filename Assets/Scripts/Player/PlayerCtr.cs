using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : SingletonMonoBehavier<PlayerCtr>
{
    #region  ShootBall

    [Header("ShootBall")] public int currentBall = 1;
    [SerializeField] private int limitBall;

    [SerializeField] private Transform tranGunTF;
    [SerializeField] private Ball prefabBullet;

    [SerializeField] private float _timeDelaySpamBall = .2f;
    [SerializeField] private bool canShoot = true;

    private float timeDelay = 0.2f;
    private float timeShoot = 0;

    private int ballCount = 0;

    #endregion

    void Start()
    {
    }

    public bool CanShoot()
    {
        return canShoot;
    }

    public void SetCurrentBall()
    {
        currentBall++;
        if (currentBall >= limitBall)
        {
            canShoot = true;
            ballCount = 0;
        }
    }


    public void ShootHandler()
    {
        canShoot = false;
        timeShoot = 0;
        ballCount++;
        StartCoroutine(IE_CreatorBall());
    }

    IEnumerator IE_CreatorBall()
    {
        for (int i = 0; i < limitBall; i++)
        {

            var ball = CreatorCtr.Instance.CreatorBall(tranGunTF.position);
            ball.SetDirection(tranGunTF.forward);
            yield return new WaitForSeconds(_timeDelaySpamBall);
        }

        StopCoroutine(IE_CreatorBall());
    }
}