using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject 木門_左;
    GameObject 木門_右;
    GameObject 木門_最終;
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

    [Header("機關")]
    public GameObject _fire1;
    public GameObject _fire2;

    void Start()
    {
        木門_左 = GameObject.Find("木門_左");
        木門_右 = GameObject.Find("木門_右");
        木門_最終 = GameObject.Find("木門_最終");
        gameOn = true;
        Time.timeScale = 1f; // 預防玩家死亡後，重新開始畫面會卡住 & 回到首頁後開始會卡住
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
            木門_左.transform.Rotate(new Vector3(0, -75,0));
            木門_右.transform.rotation = Quaternion.Euler(0, 75, 0);
            wood_door_left = false;
            wood_door_right = false;
        }

        if (wood_door_last == true)
        {
            木門_最終.transform.Rotate(new Vector3(0, 90, 0)); //以原本的角度再轉90度
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
        Application.Quit(); // build後才會實現
        //EditorApplication.isPlaying = false; // 編輯時關閉Run狀態
    }
}
