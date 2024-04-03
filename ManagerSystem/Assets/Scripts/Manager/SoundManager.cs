using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("_Sound");
        if (root == null)
        {
            root = new GameObject { name = "_Sound" };
            UnityEngine.Object.DontDestroyOnLoad(root);

            string[] soundNames = Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject gameObject = new GameObject { name = soundNames[i] };
                _audioSources[i] = gameObject.AddComponent<AudioSource>();
                gameObject.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Play(string name, Define.Sound type = Define.Sound.Effect)
    {
        AudioClip audioClip = Managers.Resource.Load<AudioClip>($"{name}.wav");
        if (audioClip == null)
        {
            return;
        }

        if (type == Define.Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else if (type == Define.Sound.Effect)
        {
            if (_audioClips.ContainsKey(name) == false)
            {
                _audioClips.Add(name, audioClip);
            }

            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.PlayOneShot(audioClip);
        }
    }
}
