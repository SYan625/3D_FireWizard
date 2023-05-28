using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    public GameObject fire;
    public GameObject light;

    void Start()
    {
        fire.SetActive(false);
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            fire.SetActive(true);
            light.SetActive(true);
        }
    }
}

