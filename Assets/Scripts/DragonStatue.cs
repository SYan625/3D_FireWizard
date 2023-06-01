using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatue : MonoBehaviour
{

    public GameObject fire;
    public GameObject blacksmoke;

    void Start()
    {
        fire.SetActive(false);
        blacksmoke.SetActive(false);
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireBall")
        {
            fire.SetActive(false);
            blacksmoke.SetActive(true);
        }
    }
}
