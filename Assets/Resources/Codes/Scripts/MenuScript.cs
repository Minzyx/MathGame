using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public int difficulty;
    public int menu = 0;
    public GameObject canvasObject;

    public List<GameObject> mainMenuButtons;
    public List<GameObject> difficultyMenuButtons;

    public float speed = 0.5f;
    
    void Start()
    {
        canvasObject.SetActive(true);
    }

    void Update()
    {
        if (menu == 0)
        {
            foreach (GameObject @object in difficultyMenuButtons)
            {
                if (@object != null)
                {
                    @object.SetActive(false);
                }
            }
        }
        else if (menu == 1)
        {
            foreach (GameObject @object in difficultyMenuButtons)
            {
                if (@object != null)
                {
                    @object.SetActive(true);
                }
            }
        }
    }

    public void GameStart()
    {
        if (menu != 1)
        {
            if (difficulty == 0)
            {
                SceneManager.LoadScene("Easy");
            } 

            if (difficulty == 1)
            {
                SceneManager.LoadScene("Normal");
            }

            if (difficulty == 2)
            {
                SceneManager.LoadScene("Hard");
            }
        }
    }

    public void DifficultyMenuOpen()
    {
        if (menu != 1)
        {
            menu = 1;

        }
    }

    public void GameClose()
    {
        if (menu != 1)
        {
            Debug.Log("Jogo Fechado");
        }
    }

    public void DifficultyMenuClose()
    {
        if (menu == 1)
        {
            menu = 0;
        }
    }

    public void DifficultyEasy()
    {
        difficulty = 0;
    }

    public void DifficultyMedium()
    {
        difficulty = 1;
    }

    public void DifficultyHard()
    {
        difficulty = 2;
    }
}
