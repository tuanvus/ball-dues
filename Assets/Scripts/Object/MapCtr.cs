using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtr : SingletonMonoBehavier<MapCtr>
{
    [SerializeField] Transform wallLeft;
    [SerializeField] Transform wallRight;


    void Start()
    {

    }
    public bool CheckWallLeft(Vector3 pos)
    {
         return pos.x <= wallLeft.position.x+0.5f;
    }
    public bool CheckWallRight(Vector3 pos)
    {
         return pos.x >= wallRight.position.x-0.5f;
    }
}
