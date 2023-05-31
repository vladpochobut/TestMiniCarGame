using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpperBars : MonoBehaviour
{
    [SerializeField]
    private GameObject _buffEffectBar;
    [SerializeField]
    private Image _healthSlider;
    [SerializeField]
    private Image _buffSlider;
    [SerializeField]
    private Text _buffEffectText;

    private float _currentEffectDuration = 0f;
    private bool _isEffectActive = false;
    private float _elapsedTime = 0f;
    private const int _maxHealth = 100;

    private void OnEnable()
    {
        Health.OnHealthChenged += UpdateHealthBar;
        BuffEffect.OnStartEffect += StartEffect;
    }

    private void StartEffect(float duration, Sprite effectBar, string name)
    {
        if (!_isEffectActive)
        {
            _buffEffectBar.SetActive(true);
            _buffSlider.sprite = effectBar;
            _buffEffectText.text = name;
            _isEffectActive = true;
            _elapsedTime = 0f;
            _currentEffectDuration = duration;
        }
    }

    private void Update()
    {
        if (_isEffectActive)
        {
            _elapsedTime += Time.deltaTime;
            UpdateEffectBar(_elapsedTime, _currentEffectDuration);
            if (_elapsedTime >= _currentEffectDuration)
            {
                _isEffectActive = false;
                _elapsedTime = 0f;
                _buffEffectBar.SetActive(false);
            }
        }
    }

    private void UpdateEffectBar(float elapsedTime,float effectDuration)
    {
        var normalizedTime = elapsedTime / effectDuration;
        _buffSlider.fillAmount = 1f - normalizedTime;
    }

    private void UpdateHealthBar(float hpValue)
    {
        _healthSlider.fillAmount = hpValue / _maxHealth;
    }

    private void OnDisable()
    {
        Health.OnHealthChenged -= UpdateHealthBar;
        BuffEffect.OnStartEffect -= StartEffect;
    }
}
