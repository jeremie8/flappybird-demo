using System;
using UnityEngine;

namespace Sensors
{
    public class Stimuli : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var sensor = other.gameObject.GetComponent<Sensor>();
            if (sensor != null)
            {
                sensor.Hit(this);
            }
        }
    }
}