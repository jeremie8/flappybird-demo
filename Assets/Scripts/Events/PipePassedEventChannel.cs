using UnityEngine;

namespace Events
{
    public class PipePassedEventChannel : MonoBehaviour
    {
        public event PipePassedEventHandler OnPipePassed;
        public void NotifyPipePassed()
        {
            if (OnPipePassed != null) OnPipePassed();
        }

        public delegate void PipePassedEventHandler();
    }
}