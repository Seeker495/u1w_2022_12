using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField]
    private Button m_startButton;
    [SerializeField]
    private Button m_settingButton;
    [SerializeField]
    private Button m_licenceButton;

    [SerializeField]
    private GameObject m_setting_Object;
    [SerializeField]
    private GameObject m_licence_Object;

    private void Awake()
    {
        m_startButton.onClick.AddListener(Press_Start);
        m_settingButton.onClick.AddListener(Press_Setting);
        m_licenceButton.onClick.AddListener(Press_Licence);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Press_Start()
    {
        SceneManager.LoadSceneAsync("Play");
    }

    void Press_Setting()
    {
        Instantiate(m_setting_Object, GameObject.FindWithTag("Canvas").transform);
    }

    void Press_Licence()
    {
        Instantiate(m_licence_Object, GameObject.FindWithTag("Canvas").transform);
    }
}
