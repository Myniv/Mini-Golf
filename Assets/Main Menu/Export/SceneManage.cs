using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void Level1(){
        SceneManager.LoadScene("Level 1");
    }
    public void Level2(){
        SceneManager.LoadScene("Level 2");
    }
    public void MenuLevel(){
        SceneManager.LoadScene("Select Level");
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
    
    public void Quit(){
        Application.Quit();
    }
}
