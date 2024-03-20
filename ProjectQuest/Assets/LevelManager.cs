using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string scene1;
    public string scene2;
    public string scene3;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene1()
    {
        SceneManager.LoadScene(scene1);
    }

    public void changeScene2()
    {
        SceneManager.LoadScene(scene2);
    }

    public void changeScene3()
    {
        SceneManager.LoadScene(scene3);
    }

    public void pauseGame() {
        PauseGame();
    }

    public void resumeGame() {
        ResumeGame();
    }

    void PauseGame()
    {
        if (!pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f; // Pause the game
            pauseMenuUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            pauseMenuUI.SetActive(false);
        }
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game
        pauseMenuUI.SetActive(false);
    }

}
