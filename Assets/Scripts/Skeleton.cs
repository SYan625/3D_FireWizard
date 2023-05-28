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

    public static int hp = 100;
    public static bool 開始動 = false;

    public Slider 血量條;
    public GameObject hp_bar;
    public Transform target;
    public List<Rigidbody> rigidList;
    float forward;
    


    void Start()
    {
        myRigibody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        _nav = GetComponent<NavMeshAgent>();
        血量條.value = hp;
    }


    void Update()
    {

        血量條.value = hp;

        if (開始動)
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
            開始動 = true;
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
        開始動 = false;
        _nav.enabled = false;
        hp_bar.SetActive(false);
        myAnimator.enabled = false;
        foreach (Rigidbody r in rigidList)
        {
            r.isKinematic = false;
        }
    }
}
