using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SoundPlayer
{
    private static SoundManager SoundManager;

    public static void SetUp(GameObject soundObj)
    {
        soundObj.TryGetComponent(out SoundManager);
    }

    public static void PlayBGM(in eBGM type)
    {
        SoundManager.PlayBGM(type);
    }

    public static void PlaySFX(in eSFX type)
    {
        SoundManager.PlaySFX(type);
    }

    public static void PlaySFX_With_Scene(in eSFX type, in string scene)
    {
        SoundManager.StartCoroutine(GoToScene(type, scene));
    }

    private static IEnumerator GoToScene(eSFX type, string scene)
    {
        SoundManager.AudioPlayer audioPlayer = SoundManager.GetUnUsedPlayer();
        SoundManager.PlaySFX(type);
        var nextScene = SceneManager.LoadSceneAsync(scene);
        nextScene.allowSceneActivation = false;
        while (!nextScene.allowSceneActivation)
        {
            yield return new WaitForFixedUpdate();
            if(!audioPlayer.audioSource.isPlaying)
            {
                nextScene.allowSceneActivation = true;
            }
        }
    }
}
