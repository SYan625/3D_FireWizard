using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Sword : MonoBehaviour
{

    Rigidbody _player;
    Image _redScreen;
    AudioSource _audio;

    Color _color = new Color(1f, 0f, 0f, 0.45f);
    bool hurt = false;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _player = GameObject.Find("Player").GetComponent<Rigidbody>();
        _redScreen = GameObject.Find("redScreen").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_redScreen.color.a > 0)
        {
            float Alpha = _redScreen.color.a;
            Alpha -= Time.deltaTime;
            _redScreen.color = new Color(_redScreen.color.r, _redScreen.color.g , _redScreen.color.b, Alpha);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audio.Play();
            _redScreen.color = _color;
            PlayerController.hp -= 25;
            _player.AddRelativeForce(Vector3.back * 500f ,ForceMode.Force);
        }
    }
}
