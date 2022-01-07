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
    
     private void OnTriggerEnter(Collider col)
     {
         
     }
    void CheckBullet()
    {
        //  if (!listIdDoor.Contains(door.id))
        //     {
        //         listIdDoor.Add(door.id);
        //         for (int i = 1; i < door.k_Plus + 1; i++)

        //             if (i % 2 == 0)
        //             {
        //                 float projectileDirXPosition = velocity.x * Mathf.Cos((i / 2 * angle * Mathf.PI) / 180) - velocity.z * Mathf.Sin((i / 2 * angle * Mathf.PI) / 180);
        //                 float projectileDirYPosition = velocity.x * Mathf.Sin((i / 2 * angle * Mathf.PI) / 180) + velocity.z * Mathf.Cos((i / 2 * angle * Mathf.PI) / 180);
        //                 Vector3 ballnew1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //                 var ballnew = Instantiate(projectileBot, ballnew1, Quaternion.identity);
        //                 ballnew.velocity = new Vector3(projectileDirXPosition, 0.1f, projectileDirYPosition);

        //                 projectileBot.listIdDoor.Add(id);


        //             }
        //             else
        //             {
        //                 float projectileDirXPosition = velocity.x * Mathf.Cos((-(i - 1) / 2 * angle * Mathf.PI) / 180) - velocity.z * Mathf.Sin((-(i - 1) / 2 * angle * Mathf.PI) / 180);
        //                 float projectileDirYPosition = velocity.x * Mathf.Sin((-(i - 1) / 2 * angle * Mathf.PI) / 180) + velocity.z * Mathf.Cos((-(i - 1) / 2 * angle * Mathf.PI) / 180);
        //                 Vector3 ballnew1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //                 var ballnew = Instantiate(projectileBot, ballnew1, Quaternion.identity);
        //                 ballnew.velocity = new Vector3(projectileDirXPosition, 0.1f, projectileDirYPosition);

        //                 projectileBot.listIdDoor.Add(id);


        //             }

        //     }
    }

}