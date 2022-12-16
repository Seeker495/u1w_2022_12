using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LicenceUI : MonoBehaviour
{
    [SerializeField]
    private Button m_closeButton;
    [SerializeField]
    private GameObject m_backGround;

    // Start is called before the first frame update
    void Awake()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(m_backGround.transform.DOScale(1.0f, 0.5f));
        sequence.SetUpdate(true);
        sequence.Play();

        m_closeButton.onClick.AddListener(Press_Close);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Press_Close()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(m_backGround.transform.DOScale(0.0f, 0.5f));
        sequence.onComplete += () => Destroy(gameObject);
        sequence.SetUpdate(true);
        sequence.Play();
    }
}
