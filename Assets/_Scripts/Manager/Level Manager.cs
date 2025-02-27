using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private int currentLevelIndex = 1;
    
    [SerializeField] private GameObject levelContainer;
    private GameObject currentLevelInstance; // Lưu trữ instance thực tế

    void Awake()
    {
        LoadLevel(currentLevelIndex);
    }

    void OnEnable()
    {
        Messenger.AddListener(EventKey.LOAD_NEXT_LEVEL, LoadNextLevel);
        Messenger.AddListener(EventKey.LOAD_CURRENT_LEVEL, LoadCurrentLevel);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(EventKey.LOAD_NEXT_LEVEL, LoadNextLevel);
        Messenger.RemoveListener(EventKey.LOAD_CURRENT_LEVEL, LoadCurrentLevel);
    }

    void LoadNextLevel()
    {
        currentLevelIndex++;
        StartCoroutine(DestroyAndLoadLevel());
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
