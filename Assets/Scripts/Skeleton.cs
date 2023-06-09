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
    public static bool �}�l�� = false;

    [Header("Skeleton Constitution")]
    public  int hp = 100;

    public Slider ��q��;
    public GameObject hp_bar;
    public GameObject swordCollider;
    public List<Rigidbody> rigidList;

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
        if (other.tag == "FireBall" && GameManager._hurtSkeleton)
        {
            hp -= 25;
            Debug.Log("-25");
            GameManager._hurtSkeleton = false;
            hp_bar.SetActive(true);
        }

    }

    public void kill()
    {
        �}�l�� = false;
        _nav.enabled = false;
        myAnimator.enabled = false;

        // �w�����`��u�\�|�üu
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
