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
    public static bool 開始動 = false;

    [Header("Skeleton Constitution")]
    public  int hp = 100;

    public Slider 血量條;
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
        開始動 = false;
        _nav.enabled = false;
        myAnimator.enabled = false;

        // 預防死亡後骷髏會亂彈
        myRigibody.useGravity = false;
        myRigibody.isKinematic = true;

        swordCollider.SetActive(false); // 預防骷髏死亡後劍還會對玩家扣血   
        hp_bar.SetActive(false);
        
        foreach (Rigidbody r in rigidList)
        {
            r.isKinematic = false;
        }
    }
}
