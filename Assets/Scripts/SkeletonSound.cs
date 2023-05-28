using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSound : MonoBehaviour
{

    public AudioSource _audio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _audio.Play();
        Destroy(gameObject);
    }
}
