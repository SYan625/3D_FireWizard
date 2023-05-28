using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Sword : MonoBehaviour
{

    public Rigidbody _player;
    public Image _img;
    AudioSource _audio;

    Color _color = new Color(1f, 0f, 0f, 0.45f);
    bool hurt = false;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Skeleton.hp <= 0)  // 防止怪物死後的劍還是可以攻擊玩家
            Destroy(this);

        if (_img.color.a > 0)
        {
            float Alpha = _img.color.a;
            Alpha -= Time.deltaTime;
            _img.color = new Color(_img.color.r, _img.color.g , _img.color.b, Alpha);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audio.Play();
            _img.color = _color;
            PlayerController.hp -= 25;
            _player.AddRelativeForce(Vector3.back * 500f ,ForceMode.Force);
        }
    }
}
