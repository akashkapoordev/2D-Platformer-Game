using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance {  get { return instance; } }

    [SerializeField] private string[] Levels;
    [SerializeField] public GameObject LevelSelectionScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus status)
    {
        PlayerPrefs.SetInt(level, (int)status);
        Debug.Log(level + status);
    }

    public void MarkCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        int currentSceneIndex = Array.FindIndex(Levels, (level) => level == currentScene.name);
        int nextScene  = currentSceneIndex + 1;

        if(nextScene < Levels.Length)
        {
            SetLevelStatus(Levels[nextScene], LevelStatus.Unlocked);
           
        }
    }
}
