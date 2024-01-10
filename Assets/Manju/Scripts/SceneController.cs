using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneController>();
            }
            return instance;
        }
    }
    private static SceneController instance;
    public void SceneLoader(string sceneName)   // �� �ҷ�����
    {   
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()                          // ���� ����
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}