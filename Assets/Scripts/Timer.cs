using UnityEngine;
using UnityEngine.UI;
public class Timer: MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject _lose; 

    private float _timeLeft = 0f;
    private bool _timerOn = false;
 
    private void Start()
    {
        Time.timeScale = 1;
        _timeLeft = time;
        _timerOn = true;
        timerText = GetComponent<Text>();
    }
 
    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            } else
            {
                _timeLeft = time;
                _timerOn = false;
                Time.timeScale = 0;
                Lose();
            }
        }
    }
 
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void Lose()
    {       
        _lose.SetActive(true);
    }
}