using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject bomb;
    AudioSource _audio;
    MeshRenderer _mesh;
    BoxCollider _boxCollider;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _mesh = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audio.Play();
            _mesh.enabled = false;
            _boxCollider.enabled = false;
            
            PlayerController.hp -= 25;
            Instantiate(bomb,this.transform.position,this.transform.rotation);
            Destroy(gameObject,2f);
        }
    }
}
