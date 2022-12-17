using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_gameClear_Object;
    [SerializeField]
    private GameObject m_gameOver_Object;

    private void Awake()
    {
        GameObject instance = Paramator.Is_Clear ? m_gameClear_Object : m_gameOver_Object;
        Instantiate(instance, GameObject.FindWithTag("Canvas").transform);
    }

}
