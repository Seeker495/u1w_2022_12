using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Audience : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, TooltipAttribute("���O�̃v���n�u")] List<GameObject> Audience;
    [SerializeField, TooltipAttribute("�����҂̃v���n�u")] List<GameObject> Resister;
    [SerializeField, TooltipAttribute("���O�̐�")] int AudienceCount;
    [SerializeField, TooltipAttribute("�����҂̐�")] int ResisterCount;

    List<GameObject> m_charalist;
    void Start()
    {
        for(int i = 0; i < AudienceCount + ResisterCount; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
