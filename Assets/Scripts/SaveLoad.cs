using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] Text ui_text;
    [SerializeField] PlayerData data;
    [SerializeField] Text 名稱;
    [SerializeField] Text 等級;

    void Start()
    {
 
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ui_text.text = "儲存完成";
            data.name = 名稱.text;
            data.level = int.Parse(等級.text);
            PlayerPrefs.SetString("jsonData",JsonUtility.ToJson(data));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
   
            data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsonData"));
            ui_text.text = "載入完成\n" + PlayerPrefs.GetString("jsonData");
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int level;
    }
}
