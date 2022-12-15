using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ボタンが押された時にイベントを発生させるクラス
/// </summary>
public class Play_Input : MonoBehaviour
{
    // Start is called before the first frame update
    public EventHandler<ButtonEvent> E_Button;
　　//それぞれのボタンの押す回数の制限
    int m_haveCar, m_haveSiren, m_haveSpeech;
    void Start()
    {
        m_haveCar = 0;
        m_haveSiren = 0;
        m_haveSpeech = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEvent(int eve)
    {
        if (E_Button == null) return;
        switch (eve)
        {
            case 0:
                if (m_haveCar < 1)
                {
                    E_Button(this, ButtonEvent.Car);
                    m_haveCar++;
                }                
                return;
            case 1:
                if (m_haveSiren < 1)
                {
                    E_Button(this, ButtonEvent.Siren);
                    m_haveSiren++;
                }                
                return;
            case 2:
                if (m_haveSpeech < 1)
                {
                    E_Button(this, ButtonEvent.Speech);
                    m_haveSpeech++;
                }
                return;
            case 3:
                E_Button(this, ButtonEvent.Report);
                return;

            default:
                Debug.LogError("Play_InputクラスOnEvent：未設定の引数が使用された");
                return;
        }
    }
}
