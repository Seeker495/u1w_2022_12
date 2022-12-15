using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Car, Siren, Speech;
    [SerializeField] GameObject Car_Mark, Siren_Mark, Speech_Mark;
    [SerializeField] Play_Input Input;
    [SerializeField] Play_Timer Timer;

    public EventHandler<E_ManaDate> E_Manager;
    void Start()
    {
        Input.E_Button +=
            new System.EventHandler<ButtonEvent>(Event);
        Timer.E_Timer +=
            new System.EventHandler<int>(Time);

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
                    EventStart(ButtonEvent.Car, EventState.Start);
                })
                .OnKill(() =>
                {
                    EventStart(ButtonEvent.Car, EventState.Play);
                    Car.transform.DOMove(new Vector3(5, 8, 0), 4f).SetDelay(5f).OnKill(() =>
                    {
                        EventStart(ButtonEvent.Car, EventState.Kill);
                    });
                    
                });
                return;

            case ButtonEvent.Siren:
                Siren_Mark.transform.DOScale(0.2f,1f).SetEase(Ease.OutBounce)
                .OnStart(() =>
                {
                    EventStart(ButtonEvent.Siren, EventState.Start);
                    EventStart(ButtonEvent.Siren, EventState.Play);
                })
                .OnKill(() =>
                {
                    Siren_Mark.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce).SetDelay(5f)
                    .OnKill(() =>
                    {
                        EventStart(ButtonEvent.Siren, EventState.Kill);
                    });
                   
                });
                return;

            case ButtonEvent.Speech:
                Speech.transform.DOMove(new Vector3(-3, -4.5f, 0), 2f).OnStart(() =>
                {
                    EventStart(ButtonEvent.Speech, EventState.Start);
                }).OnKill(() =>
                {
                    Speech_Mark.transform.DOScale(0.4f, 1f).SetEase(Ease.OutBounce)
                    .OnStart(() =>
                    {
                        EventStart(ButtonEvent.Speech, EventState.Play);
                    })
                    .OnKill(() =>
                    {
                        Speech_Mark.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce).SetDelay(5f)
                        .OnKill(() =>
                        {
                            Speech.transform.DOMove(new Vector3(-3, -8f, 0), 2f);
                            EventStart(ButtonEvent.Speech, EventState.Kill);
                        }); 
                    });                    
                });                
                return;
        }
    }
    void EventStart(ButtonEvent button, EventState state)
    {
        E_ManaDate _ManaDate = new E_ManaDate();
        _ManaDate.Button = button;
        _ManaDate.State = state;
        E_Manager(this, _ManaDate );
        switch (state)
        {
            case EventState.Start:
                Input.isPressed = true;
                return;
            case EventState.Play:
                return;
            case EventState.Kill:
                Input.isPressed = false;
                return;
        }
    }
    private void Time(object sender, int time)
    {
        //タイマーが0になったとき、ゲームオーバー処理をする
        if (time < 0)
        {
            Debug.Log("げーむおーばー");
        }
    }
} 
public class E_ManaDate
{
    public ButtonEvent Button { get; set; }
    public EventState State { get; set; }
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
        Play,
        Kill 
    }
