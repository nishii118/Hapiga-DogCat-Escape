using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private int currentLevelIndex ;
    
    [SerializeField] private GameObject levelContainer;
    private GameObject currentLevelInstance; // Lưu trữ instance thực tế

    void Awake()
    {
        PlayerPrefs.SetInt("CurrentLevel", 17);
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 1);
        LoadLevel(currentLevelIndex);

        
    }

    void OnEnable()
    {
        Player.onPlayerEnterSuccessSpot+= LoadNextLevel;
        CatDetection.onDetectCat+= LoadCurrentLevel;
        Laser.onCollisionEnterLaser+= LoadCurrentLevel;
        Electricity.onElectrized+= LoadCurrentLevel;
    }

    void OnDisable()
    {
        Player.onPlayerEnterSuccessSpot-= LoadNextLevel;
        CatDetection.onDetectCat-= LoadCurrentLevel;
        Laser.onCollisionEnterLaser-= LoadCurrentLevel;
        Electricity.onElectrized-= LoadCurrentLevel;
    }

    void LoadNextLevel()
    {
        currentLevelIndex++;
        StartCoroutine(DestroyAndLoadLevel());
        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
    }

    IEnumerator DestroyAndLoadLevel()
    {
        Debug.Log("Destroying current level");
        // Xóa level cũ nếu nó tồn tại
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
            yield return null; 
        }

        // Load level mới
        LoadLevel(currentLevelIndex);
    }

    void LoadLevel(int levelIndex)
    {
        GameObject levelPrefab = Resources.Load<GameObject>("_Prefabs/Levels/Level" + levelIndex);

        if (levelPrefab == null)
        {
            Debug.LogError("Level " + levelIndex + " not found in Resources!");
            return;
        }

        Debug.Log("Loading Level: " + levelIndex);
        currentLevelInstance = Instantiate(levelPrefab, levelContainer.transform);
    }

     void LoadCurrentLevel()
    {
        Debug.Log("Loading current level");
        StartCoroutine(DestroyAndLoadLevel());
    }
}
