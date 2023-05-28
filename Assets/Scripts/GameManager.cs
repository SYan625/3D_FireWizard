using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    GameObject 木門_左;
    GameObject 木門_右;
    public static bool wood_door_left = false;
    public static bool wood_door_right = false;
    public static bool gameOn;

    public GameObject setUI;

    void Start()
    {
        木門_左 = GameObject.Find("木門_左");
        木門_右 = GameObject.Find("木門_右");
        gameOn = true;
    }

    // Update is called once per frame
    void Update() 
    {

        if (PlayerController.hp <= 0)
        {
            // 跳出重新開始遊戲的介面
        }

        if (wood_door_left == true && wood_door_right == true)
        {
            木門_左.transform.Rotate(new Vector3(0, -75,0));
            木門_右.transform.rotation = Quaternion.Euler(0, 75, 0);
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
