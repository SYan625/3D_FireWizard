using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "Torch_left")
        {
            GameManager.wood_door_left = true;
            print("左火把");
        }

        if (collision.gameObject.tag == "Torch_right")
        {
            GameManager.wood_door_right = true;
            print("右火把");
        }

        if (collision.gameObject.tag == "Torch_last")
        {
            GameManager.wood_door_last = true;
            print("最終火把");
        }



        if (collision.gameObject.tag == "Fire")
        {
            //collision.rigidbody.AddForce(-trackPos,ForceMode.Force);
        }
    }
}
