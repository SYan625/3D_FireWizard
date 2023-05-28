using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] Text ui_text;
    [SerializeField] PlayerData data;
    [SerializeField] Text �W��;
    [SerializeField] Text ����;

    void Start()
    {
 
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ui_text.text = "�x�s����";
            data.name = �W��.text;
            data.level = int.Parse(����.text);
            PlayerPrefs.SetString("jsonData",JsonUtility.ToJson(data));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
   
            data = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("jsonData"));
            ui_text.text = "���J����\n" + PlayerPrefs.GetString("jsonData");
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int level;
    }
}
