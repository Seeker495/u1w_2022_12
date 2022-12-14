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
    private void Event(object sender,ButtonEvent eve)
    {
        switch (eve)
        {
            case ButtonEvent.Car:
                Car.transform.DOMove(new Vector3(5, 7, 0), 4f)
                .OnStart(() =>
                {
                    EventStart(EventState.Start);
                })
                .OnKill(() =>
                {
                    Car.transform.position=new Vector3(5, -8, 0);
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
                    Siren_Mark.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce);
                    EventStart(EventState.Kill);
                });
                return;
            case ButtonEvent.Speech:
                Speech_Mark.transform.DOScale(0.4f, 1f).SetEase(Ease.OutBounce)
                .OnStart(() =>
                {
                    EventStart(EventState.Start);
                })
                .OnKill(() =>
                {
                    Speech_Mark.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce);
                    EventStart(EventState.Kill);
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
    Siren
}
public enum EventState
{
    Start,
    Update,
    Kill
}