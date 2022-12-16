using System;
using UnityEngine;
using DG.Tweening;

public class PlayChara_Audience : MonoBehaviour
{
    // Start is called before the first frame update
    public AudiencePernonality per=new AudiencePernonality();
    // Start is called before the first frame update
    public EventHandler<AudiencePernonality> E_report;

    public GameObject TargetMarck;
    public Play_Manager PlayMana;

    Animator ani;
    void Start()
    {
        PlayMana.E_Manager +=
            new EventHandler<E_ManaDate>(CharaEvent);
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        E_report(this, per);
    }
    /// <summary>
    /// キャラクター個々の動きの制御
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eve"></param>
    private void CharaEvent(object sender, E_ManaDate eve)
    {
        switch (eve.State)
        {
            case EventState.Start:
                CharaMove_Start(eve.Button);
                return;
            case EventState.Play:
                CharaMove_Play(eve.Button);
                return;
            case EventState.Kill:
                CharaMove_Kill(eve.Button);
                return;
        }
    }
    void CharaMove_Start(ButtonEvent button)
    {
        if (per.IsAudience)
        {
            switch (button)
            {
                case ButtonEvent.Car:
                    return;
                case ButtonEvent.Siren:
                    return;
                case ButtonEvent.Speech:
                    return;
            }
        }
        else
        {
            switch (button)
            {
                case ButtonEvent.Car:
                    return;
                case ButtonEvent.Siren:
                    return;
                case ButtonEvent.Speech:
                    return;
            }
        }
    }
    void CharaMove_Play(ButtonEvent button)
    {
        Vector3 targetpos=this.transform.position;
        //キャラをイベントに応じた一定範囲内のランダムな位置に移動させる、移動処理をSwitch文以下に書くと動作しない
        if (per.IsAudience)
        {
            bool FieldCheck;
            switch (button)
            {
                case ButtonEvent.Car:
                    FieldCheck = (this.transform.position.x > 0 && this.transform.position.x < 2) && (this.transform.position.y > -1.5f && this.transform.position.y < 1.5f);
                    if (!FieldCheck)
                    {
                        float posX = UnityEngine.Random.Range(0f, 2f);
                        float posY = UnityEngine.Random.Range(-1.5f, 1.5f);
                        targetpos = new Vector3(posX,posY, 0);
                        this.transform.DOMove(targetpos, 2f).OnKill(() =>
                        {
                            ani.SetBool("Reaction", true);
                            DOVirtual.DelayedCall(1f, () => ani.SetBool("Reaction", false));

                        }) ;
                    }
                    
                    return;
                case ButtonEvent.Siren:
                    FieldCheck = (this.transform.position.x > -8 && this.transform.position.x < -6) && (this.transform.position.y > -1.5f && this.transform.position.y < 2f);
                    if (!FieldCheck)
                    {
                        float posX = UnityEngine.Random.Range(-8f, -6f);
                        float posY = UnityEngine.Random.Range(-1.5f, 2f);
                        targetpos = new Vector3(posX, posY, 0);
                        this.transform.DOMove(targetpos, 2f).OnKill(() =>
                        {
                            ani.SetBool("Reaction", true);
                            DOVirtual.DelayedCall(1f, () => ani.SetBool("Reaction", false));

                        }); ;
                    }
                    return;
                case ButtonEvent.Speech:
                    FieldCheck = (this.transform.position.x > -4.5f && this.transform.position.x < -1.5f) && (this.transform.position.y > -2.5f && this.transform.position.y < -3.5f);
                    Debug.Log(FieldCheck);
                    if (!FieldCheck)
                    {
                        float posX = UnityEngine.Random.Range(-1.5f, -4.5f);
                        float posY = UnityEngine.Random.Range(-3.5f, -2.5f);
                        targetpos = new Vector3(posX, posY, 0);
                        this.transform.DOMove(targetpos, 2f).OnKill(() =>
                        {
                            ani.SetBool("Reaction", true);
                            DOVirtual.DelayedCall(1f, () => ani.SetBool("Reaction", false));

                        });
                    }
                    targetpos = new Vector3(-3, -4.5f, 0);
                    return;
            }
        }
        else
        {
            switch (button)
            {
                case ButtonEvent.Car:
                    ani.SetBool("Reaction", true);
                    DOVirtual.DelayedCall(1f, () => ani.SetBool("Reaction", false));
                    return;
                case ButtonEvent.Siren:
                    ani.SetBool("Reaction", true);
                    DOVirtual.DelayedCall(1f, () => ani.SetBool("Reaction", false));
                    return;
                case ButtonEvent.Speech:
                    ani.SetBool("Reaction", true);
                    DOVirtual.DelayedCall(1f, () => ani.SetBool("Reaction", false));
                    return;
            }
        } 
    }
    void CharaMove_Kill(ButtonEvent button)
    {
        if (per.IsAudience)
        {
            switch (button)
            {
                case ButtonEvent.Car:
                    return;
                case ButtonEvent.Siren:
                    return;
                case ButtonEvent.Speech:
                    return;
            }
        }
        else
        {
            switch (button)
            {
                case ButtonEvent.Car:
                    return;
                case ButtonEvent.Siren:
                    return;
                case ButtonEvent.Speech:
                    return;
            }
        }
    }
}
public class AudiencePernonality
{
   public int AudienceID { get; set; }
   public bool IsAudience { get; set; }
}
