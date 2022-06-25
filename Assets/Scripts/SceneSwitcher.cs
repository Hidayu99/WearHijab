using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Main Page");
    }

    public void MainPage()
    {
        SceneManager.LoadScene("Discover Page");
    }

    public void InstructionPage()
    {
        SceneManager.LoadScene("Face Tracking AR");
    }

    public void Purchase()
    {
        SceneManager.LoadScene("Login");
    }

    public void Register()
    {
        SceneManager.LoadScene("Register");
    }

    public void Sites()
    {
        SceneManager.LoadScene("Hijab Materials");
    }

}
