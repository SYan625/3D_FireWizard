using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject ���_��;
    GameObject ���_�k;
    public static bool wood_door_left = false;
    public static bool wood_door_right = false;
    public static bool gameOn;

    public GameObject setUI;

    void Start()
    {
        ���_�� = GameObject.Find("���_��");
        ���_�k = GameObject.Find("���_�k");
        gameOn = true;
    }

    // Update is called once per frame
    void Update() 
    {

        if (PlayerController.hp <= 0)
        {
            // ���X���s�}�l�C��������
        }

        if (wood_door_left == true && wood_door_right == true)
        {
            ���_��.transform.Rotate(new Vector3(0, -75,0));
            ���_�k.transform.rotation = Quaternion.Euler(0, 75, 0);
            wood_door_left = false;
            wood_door_right = false;
        }

    }

    public void Esc(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            OpenSetUI();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void backToGame()
    {
        Time.timeScale = 1f;
        setUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOn = true;
    }

    public void OpenSetUI()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        setUI.SetActive(true);
        gameOn = false;
    }

}
