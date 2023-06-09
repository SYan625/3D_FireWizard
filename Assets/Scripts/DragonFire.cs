using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonFire : MonoBehaviour
{
    
    AudioSource _audio;
    Image _redScreen;

    Color _color = new Color(1f, 0f, 0f, 0.30f);

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _redScreen = GameObject.Find("redScreen").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_redScreen.color.a > 0)
        {
            float Alpha = _redScreen.color.a;
            Alpha -= Time.deltaTime;
            _redScreen.color = new Color(_redScreen.color.r, _redScreen.color.g, _redScreen.color.b, Alpha);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audio.Play();
        }   
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.hp -= 0.5f;
            _redScreen.color = _color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _audio.Stop();
        }
    }
}
