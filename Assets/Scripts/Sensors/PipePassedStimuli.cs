using System;
using Events;
using UnityEngine;
using Utils;

namespace Sensors
{
    public class PipePassedStimuli : MonoBehaviour
    {
        private PipePassedEventChannel pipePassedEventChannel;

        private void Awake()
        {
            pipePassedEventChannel = Finder<PipePassedEventChannel>.Find;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var sensor = other.GetComponentInChildren<Sensor>();
            if(sensor != null)
                if (pipePassedEventChannel != null) pipePassedEventChannel.NotifyPipePassed();
        }
    }
}