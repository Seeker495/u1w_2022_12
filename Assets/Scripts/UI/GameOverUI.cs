using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Button m_restart_Button;
    [SerializeField]
    private Button m_endPlay_Button;

    private void Awake()
    {
        m_restart_Button.onClick.AddListener(Press_Restart);
        m_endPlay_Button.onClick.AddListener(Press_EndPlay);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Press_Restart()
    {
        SceneManager.LoadSceneAsync("Play");
    }

    private void Press_EndPlay()
    {
        SceneManager.LoadSceneAsync("Title");
    }
}
