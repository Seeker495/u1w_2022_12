using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Timer : MonoBehaviour
{
    [SerializeField] int MaxTime;
    int m_nowtime;
    public EventHandler<int> E_Timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Timer()
    {
        m_nowtime = MaxTime;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            m_nowtime--;
            E_Timer(this, m_nowtime);
            if (m_nowtime <= 0) break;
        }
    }
    /// <summary>
    /// ペナルティ等で秒数を減らされた時に使う関数
    /// </summary>
    /// <param name="time"></param>
    public void TimeMiss(int time)
    {
        m_nowtime -= time;
        E_Timer(this, m_nowtime);
    }
}
