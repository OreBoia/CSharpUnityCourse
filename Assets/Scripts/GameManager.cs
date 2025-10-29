using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private int _score = 0;

    private bool _startTimer = false;
    [SerializeField] private float _timer = 0;

    [SerializeField] private float _lastTime = 0;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (_startTimer)
        {
            _timer += Time.deltaTime;
        }
    }

    public int IncrementaScore(int amount)
    {
        _score += amount;
        return _score;
    }

    public void StartTimer()
    {
        _startTimer = true;
    }

    public void StopTimer()
    {
        _startTimer = false;
        _lastTime = _timer;
        _timer = 0;
    }
    
    public bool IsTimerStarted()
    {
        return _startTimer;
    }
}
