using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �{�^���������ꂽ���ɃC�x���g�𔭐�������֐�
/// </summary>
public class Play_Input : MonoBehaviour
{
    // Start is called before the first frame update
    public EventHandler<ButtonEvent> E_Button;
    void Start()
    {
        
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
                E_Button(this, ButtonEvent.Car);
                return;
            case 1:
                E_Button(this, ButtonEvent.Siren);
                return;
            case 2:
                E_Button(this, ButtonEvent.Speech);
                return;
            default:
                Debug.LogError("Play_Input�N���XOnEvent�F���ݒ�̈������g�p���ꂽ");
                return;
        }
    }
}
