using System;
using UnityEditor;
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
    String StayAniName;//動かないアニメーションの名前
    //自身のアニメーション
    Animator ani;

    [SerializeField]bool IsAttract;//現在ギミックに注目しているか
    [SerializeField] bool HaveMoved;//ランダムな動きをしているか

    Tweener nowMove;

    Vector3 targetpos;

    void Start()
    {
        targetpos = this.transform.position;
        StayAniName = "Pre_Stay";
        PlayMana.E_Manager +=
            new EventHandler<E_ManaDate>(CharaEvent);
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //AnimatorStateInfo aniinfo = ani.GetCurrentAnimatorStateInfo(0);
        if (!IsAttract&&!HaveMoved)
        {
            HaveMoved = true;
            DOVirtual.DelayedCall(1f, () =>
            {
                while (true)
                {                    
                    targetpos = (Vector2)this.transform.position + UnityEngine.Random.insideUnitCircle;
                    //キャラの行動範囲を制限、Play_Audienceにある範囲と同じもの
                    if ((targetpos.x < 2f && targetpos.x > -8f) && (targetpos.y < 3.5f && targetpos.y > -3.5f)) break;
                }
                 Move(); 
            }
            );
               
        }
 
        if (IsAttract&&!ani.GetCurrentAnimatorStateInfo(0).IsName(StayAniName)&& ani.GetCurrentAnimatorStateInfo(0).normalizedTime>=1)
        {
            HaveMoved = false;
            //if (!per.IsAudience) Debug.Log(IsAttract);
            IsAttract = false;
            ani.SetBool("Reaction", false);
        }
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
        targetpos=this.transform.position;
        if (button != ButtonEvent.Report)
        {
            //Debug.Log("ASDFGH");
            IsAttract = true;
            nowMove.Kill(false);
        }
        //キャラをイベントに応じた一定範囲内のランダムな位置に移動させる、移動処理をSwitch文以下に書くと動作しない
        if (per.IsAudience)
        {
            
            bool FieldCheck;
            float posX;
            float posY;
            switch (button)
            {
                case ButtonEvent.Car:
                    FieldCheck = (this.transform.position.x > 0 && this.transform.position.x < 2) && (this.transform.position.y > -1.5f && this.transform.position.y < 1.5f);
                    
                    posX = UnityEngine.Random.Range(0f, 2f);
                        posY = UnityEngine.Random.Range(-1.5f, 1.5f);
                        targetpos = new Vector3(posX,posY, 0);
                        Move();
                    //else ani.SetBool("Reaction", true);
                    //IsAttract = true;
                    return;
                case ButtonEvent.Siren:
                    FieldCheck = (this.transform.position.x > -8 && this.transform.position.x < -6) && (this.transform.position.y > -1.5f && this.transform.position.y < 2f);
                    
                    posX = UnityEngine.Random.Range(-8f, -6f);
                    posY = UnityEngine.Random.Range(-1.5f, 2f);
                    targetpos = new Vector3(posX, posY, 0);
                    Move();
                    //else ani.SetBool("Reaction", true);
                    //IsAttract = true;
                    return;
                case ButtonEvent.Speech:
                    FieldCheck = (this.transform.position.x > -4.5f && this.transform.position.x < -1.5f) && (this.transform.position.y > -2.5f && this.transform.position.y < -3.5f);
                    
                    posX = UnityEngine.Random.Range(-1.5f, -4.5f);
                        posY = UnityEngine.Random.Range(-3.5f, -2.5f);
                        targetpos = new Vector3(posX, posY, 0);
                        Move();
                    //else ani.SetBool("Reaction", true);
                    //IsAttract = true;
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
                    //DOVirtual.DelayedCall(1f, () => { ani.SetBool("Reaction", false); });
                    //IsAttract = true;
                    return;
                case ButtonEvent.Siren:
                    ani.SetBool("Reaction", true);
                    //.DelayedCall(1f, () => { ani.SetBool("Reaction", false); });
                    //IsAttract = true;
                    return;
                case ButtonEvent.Speech:
                    ani.SetBool("Reaction", true);
                    //DOVirtual.DelayedCall(1f, () => { ani.SetBool("Reaction", false); });
                    //IsAttract = true;
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
    private void Move()
    {

        nowMove.Kill();
        nowMove = this.transform.DOMove(targetpos, 3.5f).OnComplete(() =>
        {
            
            if (IsAttract)
            {
                ani.SetBool("Reaction", true);
                //DOVirtual.DelayedCall(5f, () => { ani.SetBool("Reaction", false); });
                
            }
            else
            {
                HaveMoved = false;
            }
        });
        
    }
}
public class AudiencePernonality
{
   public int AudienceID { get; set; }
   public bool IsAudience { get; set; }
}
