using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_soundManager_Object;
    [SerializeField]
    private GameObject m_ui_Object;
    private void Awake()
    {
        m_soundManager_Object = Instantiate(m_soundManager_Object, null);
        SoundPlayer.SetUp(m_soundManager_Object);
        m_ui_Object = Instantiate(m_ui_Object, GameObject.FindWithTag("Canvas").transform);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
