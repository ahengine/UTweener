using UnityEngine;
using UnityEngine.Events;
using Serializable = System.SerializableAttribute;

namespace Tweener.Components
{
    [Serializable]
    public record TweenPingPong 
    {
        [field: SerializeField] public bool Enable;
        [field: SerializeField] public int Count;
    }

    [Serializable]
    public record TweenEvents
    {
        [field: SerializeField] public UnityEvent OnCompleteEvent { private set; get; }
        [field: SerializeField] public UnityEvent OnReverseCompleteEvent { private set; get; }
    }
}
