using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [Serializable]
    public struct BGMInfo
    {
        public eBGM type;
        public AudioClip clip;
    }

    [Serializable]
    public struct SFXInfo
    {
        public eSFX type;
        public AudioClip clip;
    }

    [Serializable]
    public struct AudioPlayer
    {
        public AudioSource audioSource;
        public float volume;
    }

    [SerializeField]
    private List<BGMInfo> m_bgmList;
    [SerializeField]
    private List<SFXInfo> m_sfxList;
    [SerializeField]
    private AudioPlayer m_bgmPlayer;
    [SerializeField]
    private List<AudioPlayer> m_multiSfxPlayer;

    private float m_masterVolume;
    private float m_bgmVolume;
    private float m_seVolume;
    // Start is called before the first frame update
    void Awake()
    {
        AudioPlayer audioPlayer;
        for(int i = 0; i < m_multiSfxPlayer.Count; i++)
        {
            audioPlayer.audioSource = gameObject.AddComponent<AudioSource>();
            audioPlayer.volume = m_multiSfxPlayer[i].volume;
            m_multiSfxPlayer[i] = audioPlayer;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioClip GetBGM(eBGM type)
    {
        return m_bgmList.Find(bgm => bgm.type == type).clip;
    }

    public AudioClip GetSFX(eSFX type)
    {
        return m_sfxList.Find(sfx => sfx.type == type).clip;
    }

    public void PlayBGM(in eBGM type)
    {
        m_bgmPlayer.audioSource.clip = GetBGM(type);
        m_bgmPlayer.audioSource.volume = m_bgmPlayer.volume * m_masterVolume * m_bgmVolume;
        m_bgmPlayer.audioSource.Play();
    }

    public void PlaySFX(in eSFX type)
    {
        AudioPlayer sfxPlayer = GetUnUsedPlayer();
        sfxPlayer.audioSource.PlayOneShot(GetSFX(type), sfxPlayer.volume * m_masterVolume * m_seVolume);
    }

    public AudioPlayer GetUnUsedPlayer()
    {
        return m_multiSfxPlayer.Find(player => player.audioSource.isPlaying == false);
    }

    public void SetVolume(float master, float bgm, float se)
    {
        m_masterVolume = master;
        m_bgmVolume = bgm;
        m_seVolume = se;
    }
}


public enum eBGM
{
    TITLE,
}

public enum eSFX
{
    CLICK,
}
