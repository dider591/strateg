public class Helicopter : MainTarget, ITakeDamage
{
    private float _health = 1f;
    private float _maxHealth = 1f;
    private float _minHealth = 0;
    private float _timeDelayTask = 4f;
    private float _deltaHealing = 0f;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        Invoke(nameof(StartTaskMessage), _timeDelayTask);
    }
    public void TakeDamage(int damage)
    {
        _health -= (float)damage / 1500f;
        ProgressChanged?.Invoke(_health);

        if (_health <= _minHealth)
        {
            Defeat?.Invoke();
        }
    }

    public void Heal(float healing)
    {
        if (_health < _maxHealth)
        {
            _health += healing;
            ProgressChanged?.Invoke(_health);
        }
        if (_health >= _maxHealth)
        {
            Win?.Invoke();
        }
    }

    private void StartTaskMessage()
    {
        _taskMessage.Open();
    }
}
