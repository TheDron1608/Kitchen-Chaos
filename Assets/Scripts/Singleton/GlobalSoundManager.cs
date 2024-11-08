using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _initialFailSound;
    [SerializeField] private AudioClip _initialSuccessSound;

    private static AudioClip _failSound;
    private static AudioClip _successSound;

    public static float GlobalVolume = 2f;

    private void Awake()
    {
        _failSound = _initialFailSound;
        _successSound = _initialSuccessSound;
    }

    public enum GlobalSoundEnum
    {
        Fail,
        Success
    }

    public static AudioClip GetSound(GlobalSoundEnum clip)
    {
        switch (clip)
        {
            case GlobalSoundEnum.Fail:
                return _failSound;
            case GlobalSoundEnum.Success:
                return _successSound;
            default:
                return null;
        }
    }

    public static void PlaySoundAt(GlobalSoundEnum clip, Vector3? sourcePos = null)
    {
        AudioSource.PlayClipAtPoint(GetSound(clip), sourcePos ?? Camera.main.transform.position, GlobalVolume);
    }
}
