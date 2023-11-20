using UnityEngine;
using UnityEngine.Events;
using Serializable = System.SerializableAttribute;

namespace UTweener.Components
{
    [Serializable]
    public record UTweenPingPong 
    {
        [field: SerializeField] public bool Enable;
        [field: SerializeField] public int Count;
    }

    [Serializable]
    public record UTweenEvents
    {
        [field: SerializeField] public UnityEvent OnCompleteEvent { private set; get; }
        [field: SerializeField] public UnityEvent OnReverseCompleteEvent { private set; get; }
    }
}
