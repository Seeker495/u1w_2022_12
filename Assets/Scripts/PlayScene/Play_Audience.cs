using System;
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
    [SerializeField, TooltipAttribute("PlayManagerクラス")] Play_Manager Mana;

    //List<GameObject> m_Audiencelist=new List<GameObject>();
    GameObject[] m_Audiencelist;//=new List<GameObject>();
    //List<GameObject> m_Resisterlist = new List<GameObject>();
    GameObject[] m_Resisterlist;// = new List<GameObject>();

    GameObject m_ReportedSetman;

    [SerializeField]Play_Input Input;
    [SerializeField] Player_UICounter UICounter;
    [SerializeField] Play_Timer Timer;

    int m_nowResister;
    public EventHandler<int> E_Counter;
    void Start()
    {
        m_nowResister = ResisterCount;
        Input.E_Button +=
            new System.EventHandler<ButtonEvent>(Report);
        m_Audiencelist = new GameObject[AudienceCount];
        m_Resisterlist = new GameObject[ResisterCount];
        for(int i = 0; i < AudienceCount; i++)
        {
            int index = UnityEngine.Random.Range(0, Audience.Count);
            float posX = UnityEngine.Random.Range(-8f, 2f);
            float posY = UnityEngine.Random.Range(-3.5f, 3.5f);
            m_Audiencelist[i]=(Instantiate(Audience[index], new Vector3(posX, posY, 0), Quaternion.identity));
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().per.AudienceID = i;
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().per.IsAudience = true;
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().PlayMana = Mana;
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().E_report
                += new System.EventHandler<AudiencePernonality>(ReportSet_Miss);
        }
        for (int i = 0; i < ResisterCount; i++)
        {
            int index = UnityEngine.Random.Range(0, Resister.Count);
            float posX = UnityEngine.Random.Range(-8f, 2f);
            float posY = UnityEngine.Random.Range(-3.5f, 3.5f);
            m_Resisterlist[i] = (Instantiate(Resister[index], new Vector3(posX, posY, 0), Quaternion.identity));
            m_Resisterlist[i].GetComponent<PlayChara_Audience>().per.AudienceID = i;
            m_Resisterlist[i].GetComponent<PlayChara_Audience>().per.IsAudience = false;
            m_Resisterlist[i].GetComponent<PlayChara_Audience>().PlayMana = Mana;
            m_Resisterlist[i].GetComponent<PlayChara_Audience>().E_report
                += new System.EventHandler<AudiencePernonality>(ReportSet_Miss);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReportSet_Miss(object sender,AudiencePernonality personal)
    {
        //通報ターゲット解除演出
        if (m_ReportedSetman != null) m_ReportedSetman.GetComponent<PlayChara_Audience>().TargetMarck.SetActive(false);
        //通報ターゲットへの選出演出
        if (personal.IsAudience) 
        {
            m_ReportedSetman = m_Audiencelist[personal.AudienceID];
        }
        else
        {
            m_ReportedSetman = m_Resisterlist[personal.AudienceID];
        }
        
       
        m_ReportedSetman.GetComponent<PlayChara_Audience>().TargetMarck.SetActive(true);
    }
    void Report(object sender, ButtonEvent eve)
    {
        if (m_ReportedSetman != null&& eve == ButtonEvent.Report)
        {
            if (m_ReportedSetman.GetComponent<PlayChara_Audience>().per.IsAudience)
            {
                m_ReportedSetman.GetComponent<PlayChara_Audience>().TargetMarck.SetActive(false);
                m_ReportedSetman = null;
                Timer.TimeMiss(10);
            }
            else
            {
                m_nowResister--;
                E_Counter(this, m_nowResister);
                m_ReportedSetman.SetActive(false);
                m_ReportedSetman = null;
            }
        }
    }
}
