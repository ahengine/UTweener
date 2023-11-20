using System;
using System.Collections.Generic;
using UnityEngine;

namespace UTweener
{
    public interface IUTween
    {
        void Update();
    } 

    public class UTweener : MonoBehaviour
    {
        private static UTweener instance;
        public static UTweener Instance => instance ?? (instance = new GameObject("Tweener").AddComponent<UTweener>());

        private List<IUTween> items = new List<IUTween>();

        public static void Add(IUTween newTween) => Instance.items.Add(newTween);
        public static void Remove(IUTween tween) => Instance.items.Remove(tween);

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