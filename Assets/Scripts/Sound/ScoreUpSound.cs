using System;
using Events;
using UnityEngine;
using Utils;

namespace Sensors
{
    public class ScoreUpSound : MonoBehaviour
    {

        [SerializeField] private AudioClip audioClip;
        
        private PipePassedEventChannel pipePassedEventChannel;
        private AudioSource audioSource;

        private void Awake()
        {
            pipePassedEventChannel = Finder<PipePassedEventChannel>.Find;
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void OnEnable()
        {
            pipePassedEventChannel.OnPipePassed += PlayScoreSound;
        }

        private void OnDisable()
        {
            pipePassedEventChannel.OnPipePassed -= PlayScoreSound;
        }

        private void PlayScoreSound()
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
