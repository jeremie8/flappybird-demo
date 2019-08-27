using UnityEngine;

namespace Sensors
{
    public class Sensor : MonoBehaviour
    {
        public event SensorEventHandler OnHit;
        public void Hit(Stimuli stimuli)
        {
            var parent = stimuli.transform.parent;
            var gameObj = parent == null ? stimuli.gameObject : parent.gameObject;
            if (OnHit != null) OnHit(gameObj);
        }

        public delegate void SensorEventHandler(GameObject other);
    }
}