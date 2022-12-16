using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_UICounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Play_Timer Timer;
    [SerializeField] Play_Audience Audi;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI CountText;
    void Start()
    {
        Timer.E_Timer +=
            new System.EventHandler<int>(Time);
        Audi.E_Counter +=
            new System.EventHandler<int>(Counter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Time(object sender, int time)
    {
        //�^�C�}�[��0�ɂȂ����Ƃ��A�Q�[���I�[�o�[����������
        if (time >= 0)
        {
            TimerText.text = time.ToString()+"�b";
        }
        else
        {
            TimerText.text = "0�b";
        }
    }
    private void Counter(object sender, int count)
    {
        if (count >= 0)
        {
            CountText.text="�c��"+count.ToString()+"�l";
        }
        else
        {
            CountText.text = "�c��0�l";
        }
    }
}
