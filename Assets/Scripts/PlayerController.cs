using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Constitution")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private int jumpPower;

    [Header("Player UI")]
    public Slider 血量條;
    public Slider 魔量條;
    public LayerMask groundMask;
    public AudioClip[] audio;

    Rigidbody myRigidbody;
    AudioSource walkSound;
    CapsuleCollider _capCollider;

    public static float hp = 100;
    public static float mp = 100;

    float rcSpeed;
    bool countDown = false;
    bool isWalk;
    bool isRun;
    bool isJump;
    bool isGrounded;
    float 持續時間;
    Vector2 moveVector;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        walkSound = GetComponent<AudioSource>();
        _capCollider = GetComponent<CapsuleCollider>();
        hp = 100;
        mp = 100;
        血量條.value = hp;
        魔量條.value = mp;
        isGrounded = true;
        rcSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        血量條.value = hp;
        魔量條.value = mp;

        if (mp < 0)
        {
            mp = 0;
        }
        if (mp<100)
        {
            mp += 6f * Time.deltaTime;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down ,1.2f, groundMask); //發射雷射檢測是否碰觸到地板

    }

    private void FixedUpdate()
    {
        Vector3 direction = transform.right * moveVector.x + transform.forward * moveVector.y;
        if (countDown == false)
        {
            if (moveVector != Vector2.zero)
            {
                myRigidbody.AddForce(direction.normalized * speed);
            }
        }

        if (countDown == true) //歸0後還是會稍微疊加v
        {
            持續時間 += 1 * Time.deltaTime;
            if (持續時間 > 1.5f)
            {
                myRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                myRigidbody.constraints = RigidbodyConstraints.None;
                持續時間 = 0;
                countDown = false;
                print("目前狀態" + countDown);
            }
        }

        if (isGrounded && isJump == true)
        {
            myRigidbody.mass = 1;
            isJump = false;
        }

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        moveVector = ctx.ReadValue<Vector2>();
        isWalk = true;

        if (ctx.started)
        {
            if (isWalk == true && isRun == false)
            {
                walkSound.clip = audio[0];             
            }
            walkSound.Play();
        }

        if (ctx.canceled)
        {
            walkSound.Stop();
            isWalk = false;
        }

        //print(moveVector);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        //print(ctx);
        if (ctx.performed && isGrounded)
        {
            isJump = true;
            speed = rcSpeed;
            myRigidbody.mass = 2;
            myRigidbody.AddForce(Vector3.up * jumpPower ,ForceMode.Force);
        }

    }
    public void Run(InputAction.CallbackContext ctx) 
    {
        if (ctx.performed && isGrounded && isWalk)
        {
            isRun = true;
            speed = rcSpeed + 10f;
            walkSound.clip = audio[1];
            walkSound.Play();
        }
        if(ctx.canceled)
        {
            isRun = false;
            speed = rcSpeed;
            walkSound.clip = audio[0];
            walkSound.Play();
            if (isWalk == false && isRun == false)
            {
                walkSound.Stop();
            }
        }
    }


    private void OnCollisionEnter(Collision other) // 撞到火焰反彈
    {
        if (other.gameObject.tag == "Fire")
        {
            countDown = true;
            print(countDown);
            if (transform.position.x < other.transform.position.x + 0.5f)
            {
                myRigidbody.AddForce(new Vector3(-1, 0, 0) * 4, ForceMode.Impulse);
            }
            else
            {
                myRigidbody.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
            }

            if (transform.position.z < other.transform.position.z + 0.5f)
            {
                myRigidbody.AddForce(new Vector3(0,0,1) * 4, ForceMode.Impulse);
            }
            else
            {
                myRigidbody.AddForce(new Vector3(0,0,-1) * 4, ForceMode.Impulse);
            }

        }
    }

    private void OnCollisionStay(Collision collision)  // 人物碰到牆壁後把摩擦力改成 0 讓人物不會一直卡在牆上
    {
        if (collision.gameObject.tag == "Wall")
        {
            _capCollider.material.dynamicFriction = 0f;
            _capCollider.material.staticFriction = 0f;
        }

    }

    private void OnCollisionExit(Collision collision)  // 離開牆壁後摩擦力恢復 
    {
        _capCollider.material.dynamicFriction = 1f;
        _capCollider.material.staticFriction = 1f;
    }

}
