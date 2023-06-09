using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
    public static bool _hurtSkeleton = false;
    public static bool gameOn;
    public static bool key = false;
    public static bool _gamePass = false;
    public static float _time;

    [Header("UI")]
    public GameObject SetUI;
    public GameObject DeadUI;
    public GameObject IntroUI;
    public GameObject _keyText;
    public GameObject _passUI;

    [Header("����")]
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
            Open_DeadUI();
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

        if (_gamePass)
        {
            _time += 1 * Time.deltaTime;
        }

        if (_time >= 1.6f)
        {
            _passUI.SetActive(true);
            _time = 0f;
            _gamePass = false;
            StopGame();
        }

    }

    public void Esc(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Open_SetUI();
            Debug.Log("Esc");
        }
    }

    public void Enter(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _keyText.SetActive(false);
            Debug.Log("Enter");
        }
    }

    public void HomePage()
    {
        SceneManager.LoadScene(0);
        PlayerController.hp = 100;
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOn = true;
        SceneManager.LoadScene(1);
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        gameOn = false;
    }

    public void backToGame()
    {
        Time.timeScale = 1f;
        SetUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOn = true;
    }

    public void Open_SetUI()
    {   
        SetUI.SetActive(true);
        StopGame();
    }

    public void Open_DeadUI()
    {
        DeadUI.SetActive(true);
        StopGame();
    }

    public void Open_IntroUI()
    {
        IntroUI.SetActive(true);
    }

    public void Exit_IntroUI()
    {
        IntroUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); // build��~�|��{
        //EditorApplication.isPlaying = false; // �s�������Run���A
    }
}
