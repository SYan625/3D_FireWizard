using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{

    Animator _ani;

    public GameObject _chestText;

    void Start()
    {
        _ani = GetComponent<Animator>();
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.key == true)
        {
            _ani.SetBool("open",true);
            GameManager._gamePass = true;
        }

        if (other.tag == "Player" && GameManager.key == false)
        {
            _chestText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _chestText.SetActive(false);
    }
}
