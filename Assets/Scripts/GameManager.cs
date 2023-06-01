using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject ���_��;
    GameObject ���_�k;
    GameObject ���_�̲�;
    public static bool wood_door_left = false;
    public static bool wood_door_right = false;
    public static bool wood_door_last = false;
    public static bool gameOn;
    public static bool key = false;

    public GameObject SetUI;
    public GameObject DeadUI;
    public GameObject _fire1;
    public GameObject _fire2;

    void Start()
    {
        ���_�� = GameObject.Find("���_��");
        ���_�k = GameObject.Find("���_�k");
        ���_�̲� = GameObject.Find("���_�̲�");
        gameOn = true;
        Time.timeScale = 1f; // �w�����a���`��A���s�}�l�e���|�d�� & �^�쭺����}�l�|�d��
    }

    // Update is called once per frame
    void Update() 
    {

        if (PlayerController.hp <= 0 && gameOn)
        {
            OpenDeadUI();
        }

        if (wood_door_left == true && wood_door_right == true)
        {
            ���_��.transform.Rotate(new Vector3(0, -75,0));
            ���_�k.transform.rotation = Quaternion.Euler(0, 75, 0);
            wood_door_left = false;
            wood_door_right = false;
        }

        if (wood_door_last == true)
        {
            ���_�̲�.transform.Rotate(new Vector3(0, 90, 0)); //�H�쥻�����צA��90��
            _fire1.SetActive(true);
            _fire2.SetActive(true);
            wood_door_last = false;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOn = true;
        SceneManager.LoadScene(1);
    }

    public void HomePage()
    {
        SceneManager.LoadScene(0);
    }

    public void backToGame()
    {
        Time.timeScale = 1f;
        SetUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOn = true;
    }

    public void OpenSetUI()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        SetUI.SetActive(true);
        gameOn = false;
    }

    public void OpenDeadUI()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        DeadUI.SetActive(true);
        gameOn = false;
    }
}
