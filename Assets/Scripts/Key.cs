using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    AudioSource _audio;

    public GameObject _keyText;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audio.Play();
            GameManager.key = true;
            _keyText.SetActive(true);
            Destroy(gameObject,0.3f);
        }
    }
}
