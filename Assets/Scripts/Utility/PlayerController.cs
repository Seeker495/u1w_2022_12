using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{

    private void OnEnable()
    {
        Enable();
    }

    public void Enable()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Contains("Title"))
        {

        }
        else if (currentSceneName.Contains("Tutorial"))
        {

        }
        else if (currentSceneName.Contains("Play"))
        {
        }
        else if (currentSceneName.Contains("Result"))
        {

        }

    }

    public void Disable()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName.Contains("Title"))
        {

        }
        else if (currentSceneName.Contains("Tutorial"))
        {

        }
        else if (currentSceneName.Contains("Play"))
        {
        }
        else if (currentSceneName.Contains("Result"))
        {

        }
    }


}
