using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
     /* public Transform player;
      private Vector3 trackPos;*/

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*trackPos = player.position - transform.position;
        trackPos.y = 0;*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.tag == "Torch_left")
        {
            GameManager.wood_door_left = true;
            print("¥ª¤õ§â");
        }
        if (collision.gameObject.tag == "Torch_right")
        {
            GameManager.wood_door_right = true;
            print("¥k¤õ§â");
        }
        if (collision.gameObject.tag == "Fire")
        {
            //collision.rigidbody.AddForce(-trackPos,ForceMode.Force);
        }
    }
}
