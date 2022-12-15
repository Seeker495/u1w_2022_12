using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Audience : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField, TooltipAttribute("民衆のプレハブ")] List<GameObject> Audience;
    [SerializeField, TooltipAttribute("反乱者のプレハブ")] List<GameObject> Resister;
    [SerializeField, TooltipAttribute("民衆の数")] int AudienceCount;
    [SerializeField, TooltipAttribute("反乱者の数")] int ResisterCount;

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
