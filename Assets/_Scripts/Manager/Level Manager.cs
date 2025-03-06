using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevelIndex;

    [SerializeField] private GameObject levelContainer;
    [SerializeField] private GameObject currentLevelInstance; // Lưu trữ instance thực tế

    [SerializeField] private TextMeshProUGUI levelText;
    private bool isLoading = false;
    void Awake()
    {
        // PlayerPrefs.SetInt("CurrentLevel", );
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 1);
        LoadLevel(currentLevelIndex);
        levelText.text = "Level " + currentLevelIndex;

    }

    void OnEnable()
    {
        Player.onPlayerEnterSuccessSpot += LoadNextLevel;
        // CatDetection.onDetectCat += LoadCurrentLevel;
        Laser.onCollisionEnterLaser += LoadCurrentLevel;
        Electricity.onElectrized += LoadCurrentLevel;
        LaserWireCollider.onCollisionEnterLaser += LoadCurrentLevel;
        FieldOfView.onFieldOfViewDetectPlayer += LoadCurrentLevel;
    }

    void OnDisable()
    {
        Player.onPlayerEnterSuccessSpot -= LoadNextLevel;
        // CatDetection.onDetectCat -= LoadCurrentLevel;
        Laser.onCollisionEnterLaser -= LoadCurrentLevel;
        Electricity.onElectrized -= LoadCurrentLevel;
        LaserWireCollider.onCollisionEnterLaser -= LoadCurrentLevel;
        FieldOfView.onFieldOfViewDetectPlayer -= LoadCurrentLevel;
    }

    void LoadNextLevel()
    {
        currentLevelIndex++;
        StartCoroutine(DestroyAndLoadLevel());
        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);

        levelText.text = "Level " + currentLevelIndex;
    }

    IEnumerator DestroyAndLoadLevel()
    {
        Debug.Log("Destroying current level");
        Debug.Log("currentLevelInstance: " + currentLevelInstance);
        // Xóa level cũ nếu nó tồn tại
        if (currentLevelInstance != null)
        {
            Debug.Log("Destroying current level");
            Destroy(currentLevelInstance);
            yield return new WaitForEndOfFrame();
            LoadLevel(currentLevelIndex);
            yield return null;
            isLoading = false;
        }

        // Load level mới
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
        Debug.Log("Level Prefab: " + levelPrefab.name);
        currentLevelInstance = Instantiate(levelPrefab, levelContainer.transform);
        Debug.Log("Level Loaded: " + currentLevelInstance.name);
    }

    void LoadCurrentLevel()
    {
        if (isLoading) return;
        isLoading = true;
        Debug.Log("Loading current level");
        StartCoroutine(DestroyAndLoadLevel());
    }
}
