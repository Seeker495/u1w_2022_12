using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : MonoBehaviour
{
    [SerializeField]
    private GameObject m_soundManager_Object;

    private void Awake()
    {
        m_soundManager_Object = Instantiate(m_soundManager_Object, null);
        SoundPlayer.SetUp(m_soundManager_Object);
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
