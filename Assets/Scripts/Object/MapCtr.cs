using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtr : SingletonMonoBehavier<MapCtr>
{

    [SerializeField] Transform door;

    [SerializeField] Transform wallLeft;
    [SerializeField] Transform wallRight;


    void Start()
    {

    }
    public bool CheckWallLeft(Vector3 pos)
    {
        return pos.x <= wallLeft.position.x + 0.5f;
    }
    public bool CheckWallRight(Vector3 pos)
    {
        return pos.x >= wallRight.position.x - 0.5f;
    }

    public bool CheckDistanceDoor(Vector3 pos)
    {
        foreach (Transform item in door)
        {
            if (!item.gameObject.active) continue;
            float dist = Vector3.Distance(pos, item.position);

            if (dist < 5.1f)
            {
                return true;
            }
        }
        return false;


    }
}
