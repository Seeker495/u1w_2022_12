using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Car, Siren, Speech;

    [SerializeField] GameObject Car_Mark, Siren_Mark, Speech_Mark;

    [SerializeField] Play_Input Input;
    void Start()
    {
        Input.E_Button +=
            new System.EventHandler<ButtonEvent>(Event);
        Siren_Mark.transform.localScale = Vector3.zero;
        Speech_Mark.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ボタンを押すことで発生するイベントの関数、Dotweenで操作している
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="eve"></param>
    private void Event(object sender,ButtonEvent eve)
    {
        switch (eve)
        {
            case ButtonEvent.Car:
                Car.transform.DOMove(new Vector3(5, 0, 0), 2f)
                .OnStart(() =>
                {
                    EventStart(EventState.Start);
                })
                .OnKill(() =>
                {
                    Car.transform.DOMove(new Vector3(5, 8, 0), 4f).SetDelay(5f);
                    EventStart(EventState.Kill);
                });
                return;

            case ButtonEvent.Siren:
                Siren_Mark.transform.DOScale(0.2f,1f).SetEase(Ease.OutBounce)
                .OnStart(() =>
                {
                    EventStart(EventState.Start);
                })
                .OnKill(() =>
                {
                    Siren_Mark.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce).SetDelay(5f).OnKill(() =>
                    {
                        EventStart(EventState.Kill);
                    });
                   
                });
                return;

            case ButtonEvent.Speech:
                Speech.transform.DOMove(new Vector3(-3, -4.5f, 0), 2f).OnKill(() =>
                {
                    Speech_Mark.transform.DOScale(0.4f, 1f).SetEase(Ease.OutBounce)
                    .OnStart(() =>
                    {
                        EventStart(EventState.Start);
                    })
                    .OnKill(() =>
                    {
                        Speech_Mark.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce).SetDelay(5f)
                        .OnKill(() =>
                        {
                            Speech.transform.DOMove(new Vector3(-3, -8f, 0), 2f);
                            EventStart(EventState.Kill);
                        }); 
                    });
                    
                });
                
                return;
        }
    }
    void EventStart(EventState state)
    {

    }
}
public enum ButtonEvent
{
    Car,
    Speech,
    Siren,
    Report
}
public enum EventState
{
    Start,
    Update,
    Kill
}