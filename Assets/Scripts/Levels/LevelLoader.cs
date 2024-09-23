using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    [SerializeField] string level_name;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        LevelStatus levelStatus =  LevelManager.Instance.GetLevelStatus(level_name);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Cannot play this level");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(level_name);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(level_name);
                break;

        }

        
    }
}
