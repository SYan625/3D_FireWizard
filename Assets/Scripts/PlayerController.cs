using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public int jumpPower;
    public Slider ��q��;
    public Slider �]�q��;
    public LayerMask groundMask;
    public AudioClip[] audio;
    public GameObject setUI;

    Rigidbody myRigidbody;
    AudioSource walkSound;

    public static int hp = 100;
    public static float mp = 100;

    float rcSpeed;
    bool countDown = false;
    bool isWalk;
    bool isJump;
    bool isGrounded;
    float ����ɶ�;
    Vector2 moveVector;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        walkSound = GetComponent<AudioSource>();
        ��q��.value = hp;
        �]�q��.value = mp;
        isGrounded = true;
        rcSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        ��q��.value = hp;
        �]�q��.value = mp;

        if (mp < 0)
        {
            mp = 0;
        }
        if (mp<100)
        {
            mp += 6f * Time.deltaTime;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down ,1.2f, groundMask); //�o�g�p�g�˴��O�_�IĲ��a�O

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

        if (countDown == true) //�k0���٬O�|�y�L�|�[v
        {
            ����ɶ� += 1 * Time.deltaTime;
            if (����ɶ� > 1.5f)
            {
                myRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                myRigidbody.constraints = RigidbodyConstraints.None;
                ����ɶ� = 0;
                countDown = false;
                print("�ثe���A" + countDown);
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

        if (isWalk == false)
        {
            walkSound.clip = audio[0];
            walkSound.Play();
        }

        isWalk = true;

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
            walkSound.clip = audio[1];
            walkSound.Play();
            speed = rcSpeed + 25f;

        }
        if(ctx.canceled  && isWalk)
        {
            speed = rcSpeed;
            walkSound.clip = audio[0];
            walkSound.Play();

        }
    }


    private void OnCollisionEnter(Collision other)
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

}
