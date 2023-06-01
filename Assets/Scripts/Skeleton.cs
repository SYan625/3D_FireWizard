using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{

    Rigidbody myRigibody;
    Animator myAnimator;
    NavMeshAgent _nav;
    Transform target;

    public  int hp = 100;
    public static bool �}�l�� = false;

    public GameObject swordCollider;
    public Slider ��q��;
    public GameObject hp_bar;
    public List<Rigidbody> rigidList;
    public BoxCollider _boxCollider;

    float forward;
    


    void Start()
    {
        myRigibody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        ��q��.value = hp;
    }


    void Update()
    {

        ��q��.value = hp;

        if (�}�l��)
        {
            _nav.SetDestination(target.position);
        }
            
        forward = Mathf.Abs(_nav.desiredVelocity.z);
        myAnimator.SetFloat("Forward", forward, 0.1f, Time.deltaTime);

        if (hp <= 0)
        {
            kill();
            Destroy(this.gameObject, 5f);
        }

        if (hp < 100 )
        {
            _nav.enabled = true;
            �}�l�� = true;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "FireBall")
        {
            hp -= 25;
            hp_bar.SetActive(true);
        }

    }

    public void kill()
    {
        �}�l�� = false;
        _nav.enabled = false;
        myAnimator.enabled = false;

        // �w�����`��u�\�|�üu
        _boxCollider.enabled = false;
        myRigibody.useGravity = false;
        myRigibody.isKinematic = true;

        swordCollider.SetActive(false); // �w���u�\���`��C�ٷ|�缾�a����   
        hp_bar.SetActive(false);
        
        foreach (Rigidbody r in rigidList)
        {
            r.isKinematic = false;
        }
    }
}
