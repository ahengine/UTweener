using UnityEngine.Events;
using Serializable = System.SerializableAttribute;

namespace Tweener.Components
{
    [Serializable]
    public class TweenPingPong 
    {
        public bool pingPong;
        public int pingPongCount;
    }

    [Serializable]
    public class TweenEvents
    {
        public UnityEvent onCompleteEvent;
        public UnityEvent onReverseCompleteEvent;
    }
}
