using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public static bool gameOn;
    public static bool key = false;

    public GameObject SetUI;
    public GameObject DeadUI;
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
            OpenDeadUI();
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
