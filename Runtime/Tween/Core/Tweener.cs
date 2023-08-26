using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tweener
{
    public interface ITween
    {
        void Update();
    } 

    public class Tweener : MonoBehaviour
    {
        private static Tweener instance;
        public static Tweener Instance => instance ?? (instance = new GameObject("Tweener").AddComponent<Tweener>());

        private List<ITween> items = new List<ITween>();

        public static void Add(ITween newTween) => Instance.items.Add(newTween);
        public static void Remove(ITween tween) => Instance.items.Remove(tween);

        private void Update()
        {
            if (items.Count == 0) return;

            for (int i = 0; i < items.Count; i++)
                items[i].Update();
        }

        private void OnDestroy() =>
            instance = null;
    }
}