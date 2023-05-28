using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackRange : MonoBehaviour
{

    public NavMeshAgent _nav;
    public GameObject hp_bar;

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
            _nav.enabled = true;
            hp_bar.SetActive(true);
            Skeleton.¶}©l°Ê = true;
        }
    }
}
