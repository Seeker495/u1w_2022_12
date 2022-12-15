using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChara_Audience : MonoBehaviour
{
    // Start is called before the first frame update
    public AudiencePernonality per=new AudiencePernonality();
    // Start is called before the first frame update
    public EventHandler<AudiencePernonality> E_report;

    public GameObject TargetMarck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        E_report(this, per);
    }
}
public class AudiencePernonality
{
   public int AudienceID { get; set; }
   public bool IsAudience { get; set; }
}
