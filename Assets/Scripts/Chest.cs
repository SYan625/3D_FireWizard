using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    Animator _ani;

    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.key)
        {
            _ani.SetBool("open",true);
        }
    }
}
