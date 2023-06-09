using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{

    public Animator staffAnimation;
    public GameObject fireBallPref;
    public Transform shootPlace;
    public float speed;

    AudioSource attackSound;

    void Start()
    {
        attackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootPlace.position;

        if (PlayerController.mp >= 25 && GameManager.gameOn)
        {
            if (Input.GetMouseButtonDown(0)) //ÀË´úª±®a¬O§_¦³«ö¤U·Æ¹«¥ªÁä
            {
                GameManager._hurtSkeleton = true;
                PlayerController.mp -= 25;
                staffAnimation.SetBool("Attack", true);
                attackSound.Play();

                GameObject fireball = Instantiate(fireBallPref, shootPlace.position, shootPlace.rotation);
                fireball.GetComponent<Rigidbody>().AddForce(shootPlace.forward * speed * Time.deltaTime, ForceMode.Impulse);
                Destroy(fireball, 2f);

                /*GameObject fireball = Instantiate(fireBallPref, shootPlace.position, shootPlace.rotation);
                fireball.GetComponent<Rigidbody>().AddForce(-shootDirection.normalized * FireBall.speed * Time.deltaTime , ForceMode.Impulse);*/
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            staffAnimation.SetBool("Attack", false);
        }
    }
}
