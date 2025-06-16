using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField, Tooltip("Максимальный уровеь здоровья")]
    private float _healthMax = 10;

    [SerializeField, Tooltip("Текущее значение здоровья")]
    private float _healthCur = 10;

    [SerializeField, Tooltip("Секунды невосприимчивости к урону после поподания")]
    private float _invincibilityFramesMax = 1;

    [SerializeField, Tooltip("Оставшиеся секутды невосприимчивости")]
    private float _invincibilityFramesCur = 0;

    [SerializeField, Tooltip("Мертв ли оъект")]
    private bool _isDead = false;


    void Update()
    {
        if(_invincibilityFramesCur > 0)
        {
            _invincibilityFramesCur -= Time.deltaTime;

            if (_invincibilityFramesCur < 0)
                _invincibilityFramesCur = 0;
        }
        if (IsDead())
            GameObject.Destroy(gameObject);
    }

    public float AdjustCurHealth(float change)
    {
        if (_invincibilityFramesCur > 0)
            return _healthCur;
        
        _healthCur += change;

        if (_healthCur <= 0)
        {
            onDeath();
        }
        else if (_healthCur >= _healthMax)
            _healthCur = _healthMax;

        if (change < 0 && _invincibilityFramesMax > 0)
            _invincibilityFramesCur = _invincibilityFramesMax;

        return _healthCur;
    }

    void onDeath()
    {
        if (_healthCur > 0)
        {
            Debug.Log(gameObject.name + "Считать мертвым до обнуления здоровья.");
        }
        _isDead = true;
    }

    public bool IsDead()
    {
        return _isDead;
    }

    public void Reset()
    {
        _isDead = false;
        _healthCur = _healthMax;
        _invincibilityFramesCur = 0;
    }
}
