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

    //List<GameObject> m_Audiencelist=new List<GameObject>();
    GameObject[] m_Audiencelist;//=new List<GameObject>();


    //List<GameObject> m_Resisterlist = new List<GameObject>();
    GameObject[] m_Resisterlist;// = new List<GameObject>();

    GameObject m_ReportedSetman;

    [SerializeField]Play_Input Input;
    void Start()
    {
        Input.E_Button +=
            new System.EventHandler<ButtonEvent>(Report);
        m_Audiencelist = new GameObject[AudienceCount];
        m_Resisterlist = new GameObject[ResisterCount];
        for(int i = 0; i < AudienceCount; i++)
        {
            int index = Random.Range(0, Audience.Count);
            float posX = Random.Range(-8f, 2f);
            float posY = Random.Range(-3.5f, 3.5f);
            m_Audiencelist[i]=(Instantiate(Audience[index], new Vector3(posX, posY, 0), Quaternion.identity));
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().per.AudienceID = i;
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().per.IsAudience = true;
            m_Audiencelist[i].GetComponent<PlayChara_Audience>().E_report
                += new System.EventHandler<AudiencePernonality>(ReportSet_Miss);
        }
        for (int i = 0; i < ResisterCount; i++)
        {
            int index = Random.Range(0, Resister.Count);
            float posX = Random.Range(-8f, 2f);
            float posY = Random.Range(-3.5f, 3.5f);
            m_Resisterlist[i] = (Instantiate(Resister[index], new Vector3(posX, posY, 0), Quaternion.identity));
            m_Resisterlist[i].GetComponent<PlayChara_Audience>().per.AudienceID = i;
            m_Resisterlist[i].GetComponent<PlayChara_Audience>().per.IsAudience = false;
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
        //�ʕ�^�[�Q�b�g�������o
        if (m_ReportedSetman != null) m_ReportedSetman.GetComponent<PlayChara_Audience>().TargetMarck.SetActive(false);
        //�ʕ�^�[�Q�b�g�ւ̑I�o���o
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
                Debug.Log("���s�I");
            }
            else
            {
                Debug.Log("�����I");
            }
        }
    }
}
