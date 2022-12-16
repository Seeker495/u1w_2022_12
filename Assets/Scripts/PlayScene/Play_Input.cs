using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// ボタンが押された時にイベントを発生させるクラス
/// </summary>
public class Play_Input : MonoBehaviour
{
    // Start is called before the first frame update
    public EventHandler<ButtonEvent> E_Button;
　　//それぞれのボタンの押す回数の制限
    int m_haveCar, m_haveSiren, m_haveSpeech;
    //同時押し防止のbool、Play_Managerで操作
    public bool isPressed;
    [SerializeField] Image Car, Siren, Speech,Report;
    [SerializeField] Play_Audience Audience;
    void Start()
    {
        isPressed = false;
        m_haveCar = 0;
        m_haveSiren = 0;
        m_haveSpeech = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //
        if (isPressed)
        {
            Car.DOColor(Color.gray, 0f);
            Siren.DOColor(Color.gray, 0f);
            Speech.DOColor(Color.gray, 0f);
            Report.DOColor(Color.gray, 0f);
            
        }
        else
        {
            if (m_haveCar < 1) Car.DOColor(Color.white, 0f);
            if (m_haveSiren < 1) Siren.DOColor(Color.white, 0f);
            if (m_haveSpeech < 1) Speech.DOColor(Color.white, 0f);
            Report.DOColor(Color.white, 0f);
        }
        if(Audience.m_ReportedSetman==null) Report.DOColor(Color.gray, 0f);
    }
    public void OnEvent(int eve)
    {
        if (E_Button == null) return;
        if (isPressed) return;
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
