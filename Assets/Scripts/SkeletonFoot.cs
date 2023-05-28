using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFoot : MonoBehaviour
{

    public Animator _animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            _animator.SetTrigger("Attack");
        }
    }
}
