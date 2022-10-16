using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Manager : MonoBehaviour
{

    public static Manager instance;

    public TextMeshProUGUI enteredName;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        loadName();
    }

    [System.Serializable]
    class SaveData
    {
        public TextMeshProUGUI enteredName;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
        }
    }
}
