using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace DefaultNamespace
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private RectTransform _scoreTextRectTransform;
        private void Start()
        {
            LeanTween.scale(_scoreTextRectTransform, Vector3.one * 1.5f, 0.4f).setOnComplete(() =>
            {
                LeanTween.move(_scoreTextRectTransform, new Vector3(-195, -50, 0), 0.4f).setDelay(2f).setEaseInSine();
                LeanTween.scale(_scoreTextRectTransform, Vector3.one, 0.4f).setDelay(2f).setEaseInSine();
            });
            _scoreText.text = "Score: 0";
            ScoreManager.Score.OnValueChanged += OnScoreChanged;
        }
        
        public void OnScoreChanged(int obj)
        {
            _scoreText.text = "Score: " + obj;
        }
    }
}