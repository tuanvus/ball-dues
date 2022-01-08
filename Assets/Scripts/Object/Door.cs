using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Door : MonoBehaviour
{

    public List<Color> listC;
    public TextMeshPro TextComponent;
    public int id;
    public int k_Plus;
    bool check = false;
    private void Start()
    {

        //id.Clear();
        TextComponent = GetComponent<TextMeshPro>();
    }
    public void initc(int id)
    {
        this.id = id;
        k_Plus = Random.RandomRange(2, 5);
        GetComponent<MeshRenderer>().material.color = listC[k_Plus - 1];
        TextComponent.text = "x" + k_Plus.ToString();
    }

    private void Update()
    {
        CheckBullet();
    }
    void CheckBullet()
    {
        if (check) return;
        StartCoroutine(Check());
        if (!check) check = true;


    }
    IEnumerator Check()
    {
        while (true)
        {
            foreach (Transform item in CreatorCtr.Instance.transform)
            {


                //if (!item.gameObject.active) continue;
                float dist = Vector3.Distance(transform.position, item.position);
                Debug.LogError("dist =" + dist);
                if (dist < 5.1f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Debug.Log("vaoooo");

                        CreatorCtr.Instance.CreatorBallHell(transform.position, i, i);

                        if (i == 2)
                        {
                            StopCoroutine(Check());

                        }
                    }

                }

            }
            yield return new WaitForSeconds(0.1f);

        }

    }

}