using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

// این کلاس ساختار متغیرهایی که قرار است سیو شوند را مشخص می‌کند
[System.Serializable]
public class SaveData
{
    public int sceneBuildIndex;
    
    // داده‌های شوالیه
    public float knightX;
    public float knightY;
    public float knightHP;

    // داده‌های پری
    public float fairyX;
    public float fairyY;
    public float fairyHP;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool hasStar1 = false;
    public bool hasStar2 = false;
    public bool hasStar3 = false;

    private string saveFilePath;
    private SaveData loadedData; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            saveFilePath = Application.persistentDataPath + "/gamesave.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (loadedData != null)
        {
            ApplyLoadedData();
            loadedData = null; 
        }
    }

    public bool AllStarsCollected()
    {
        return hasStar1 && hasStar2 && hasStar3;
    }

    public void ResetStars()
    {
        hasStar1 = false;
        hasStar2 = false;
        hasStar3 = false;
        Debug.Log("وضعیت ستاره‌های موقت در GameManager ریست شد.");
    }

    public void SaveCurrentMissionStars()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(currentScene + "_Star1", hasStar1 ? 1 : 0);
        PlayerPrefs.SetInt(currentScene + "_Star2", hasStar2 ? 1 : 0);
        PlayerPrefs.SetInt(currentScene + "_Star3", hasStar3 ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log($"ستاره‌های مرحله {currentScene} با موفقیت سیو شدند!");
    }

    public bool IsStarCollected(string sceneName, int starID)
    {
        return PlayerPrefs.GetInt(sceneName + "_Star" + starID, 0) == 1;
    }


    public void SaveGame(float knightHP, float fairyHP)
    {
        GameObject knight = GameObject.FindWithTag("Knight");
        GameObject fairy = GameObject.FindWithTag("Fairy");

        if (knight == null || fairy == null)
        {
            Debug.LogWarning("کاراکترهای Knight یا Fairy در صحنه پیدا نشدند! سیو متوقف شد.");
            return;
        }

        SaveData data = new SaveData();
        data.sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        data.knightX = knight.transform.position.x;
        data.knightY = knight.transform.position.y;
        data.knightHP = knightHP;

        data.fairyX = fairy.transform.position.x;
        data.fairyY = fairy.transform.position.y;
        data.fairyHP = fairyHP;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("بازی با موفقیت در مسیر زیر ذخیره شد:\n" + saveFilePath);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            loadedData = JsonUtility.FromJson<SaveData>(json);

            SceneManager.LoadScene(loadedData.sceneBuildIndex);
        }
        else
        {
            Debug.LogWarning("هیچ فایل ذخیره‌ای پیدا نشد!");
        }
    }

    private void ApplyLoadedData()
    {
        GameObject knight = GameObject.FindWithTag("Knight");
        GameObject fairy = GameObject.FindWithTag("Fairy");

        if (knight != null)
        {
            knight.transform.position = new Vector3(loadedData.knightX, loadedData.knightY, knight.transform.position.z);
            
        }

        if (fairy != null)
        {
            fairy.transform.position = new Vector3(loadedData.fairyX, loadedData.fairyY, fairy.transform.position.z);
            
        }

        Debug.Log("موقعیت و سلامتی کاراکترها با موفقیت بازیابی شد.");
    }
}