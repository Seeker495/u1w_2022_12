using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private Button m_closeButton;
    [SerializeField]
    private GameObject m_backGround;
    [SerializeField]
    private Slider m_masterSlider;
    [SerializeField]
    private Slider m_bgmSlider;
    [SerializeField]
    private Slider m_seSlider;
    [SerializeField]
    private AudioMixer m_mixer;

    // Start is called before the first frame update
    void Awake()
    {

        var sequence = DOTween.Sequence();
        sequence.Append(m_backGround.transform.DOScale(1.0f, 0.5f));
        sequence.SetUpdate(true);
        sequence.Play();

        m_closeButton.onClick.AddListener(Press_Close);


        GetVolumeFromMixer("MasterVolume", out float masterVolume);
        GetVolumeFromMixer("BGMVolume", out float bgmVolume);
        GetVolumeFromMixer("SEVolume", out float seVolume);

        m_masterSlider.value = masterVolume;
        m_bgmSlider.value = bgmVolume;
        m_seSlider.value = seVolume;


        m_masterSlider.onValueChanged.AddListener(value => m_mixer.SetFloat("MasterVolume", ConvertVolume2dB(value)));
        m_bgmSlider.onValueChanged.AddListener(value => m_mixer.SetFloat("BGMVolume", ConvertVolume2dB(value)));
        m_seSlider.onValueChanged.AddListener(value => m_mixer.SetFloat("SEVolume", ConvertVolume2dB(value)));

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Press_Close()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(m_backGround.transform.DOScale(0.0f, 0.5f));
        sequence.onComplete += () =>
        {
            SoundPlayer.SetVolume(m_masterSlider.value, m_bgmSlider.value, m_seSlider.value);
            Destroy(gameObject);
        };
        sequence.SetUpdate(true);
        sequence.Play();
    }

    float ConvertVolume2dB(float volume) => Mathf.Clamp(20f * Mathf.Log10(Mathf.Clamp01(volume)), -80f, 0f);

    void GetVolumeFromMixer(in string groupName, out float volume)
    {
        m_mixer.GetFloat(groupName, out float value);
        volume = Mathf.Clamp01(Mathf.Pow(10f, value / 20f));
    }
}
