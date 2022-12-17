using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [SerializeField]
    private Button m_gotoTitle_Button;

    private void Awake()
    {
        m_gotoTitle_Button.onClick.AddListener(Press_GoToTitle);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Press_GoToTitle()
    {
        SceneManager.LoadSceneAsync("Title");
    }
}
