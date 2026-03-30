using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource m_SFXSource;
    [SerializeField] private AudioSource m_MusicSource;
    [Space]
    [SerializeField] private List<AudioClip> m_AudioClipsList;

    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySFX(eAudioClips i_AudioClip)
    {
        int index = (int)i_AudioClip;

        if (index < m_AudioClipsList.Count && m_AudioClipsList[index] != null)
        {
            m_SFXSource.PlayOneShot(m_AudioClipsList[index]);
        }
    }

}
