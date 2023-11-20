using UnityEngine;

namespace UTweener.Components
{
    public class UTweenAnimation : MonoBehaviour
    {
        public enum PlayType { Play, ReversePlay }

        [field:SerializeField] public PlayType Type { private set; get; }
        [SerializeField] private UTweenPlayer[] players;

        public void PlayDefault()
        {
            switch (Type)
            {
                case PlayType.Play:
                    Play();
                    break;
                case PlayType.ReversePlay:
                    ReversePlay();
                    break;
            }
        }

        public void Play()
        {
            for (int i = 0; i < players.Length; i++)
                players[i].Play();
        }

        public void ReversePlay()
        {
            for (int i = 0; i < players.Length; i++)
                players[i].ReversePlay();
        }
    }
}