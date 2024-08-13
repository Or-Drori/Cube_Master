using System;
using UnityEngine;

namespace DefaultNamespace
{
    public static class ScoreManager
    {
        public static Observable<int> Score = new Observable<int>();
        
        public static  void AddScore()
        {
            Score.Value++;
        }
    }
    
    public class Observable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (!Equals(_value, value))
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
        }

        public event Action<T> OnValueChanged;
    }
}