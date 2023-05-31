using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    [SerializeField]
    private SpriteRenderer _carBunusPoint;
    [SerializeField]
    private SpriteRenderer _carBonusEffect;

    private SerializablePlayerStates _startStates;
    private CircleCollider2D _circleCollider;
    private Health _health;
    private Mover _mover;

    public Mover Mover => _mover;
    public Health Health => _health;
    public CircleCollider2D CircleCollider => _circleCollider;
    public SpriteRenderer CarBunusPoint => _carBunusPoint;
    public SpriteRenderer CarBonusEffect => _carBonusEffect;

    private void OnEnable()
    {
        BuffEffect.OnNewBuffEffect += SetStartStates;
    }

    private void Start()
    {
        _health = GetComponent<Health>();
        _mover = GetComponent<Mover>();
        _circleCollider = GetComponent<CircleCollider2D>();
        CaptureState();  
    }

    private void CaptureState()
    {
        _startStates = new SerializablePlayerStates(_mover.GetSpeed(),_circleCollider.radius,_carBonusEffect.sprite,_carBunusPoint.sprite);
    }

    private void SetStartStates()
    {
        Debug.Log("HERE!!!");
        _health.BlockDamage(false);
        _mover.RiseSpeed(_startStates.GetSpeed() - _mover.GetSpeed());
        _circleCollider.radius = _startStates.GetCircleRadius();
        _carBonusEffect.sprite = _startStates.GetBonusEffectSprite();
        _carBunusPoint.sprite = _startStates.GetBonusPointSprite();
    }

    public void EffectProcessing(float effectDuration)
    {
        StartCoroutine(EffectEndsCorutine(effectDuration));
    }

    private IEnumerator EffectEndsCorutine(float effectDuration)
    {
        yield return new WaitForSeconds(effectDuration);
        SetStartStates();
    }

    private void OnDisable()
    {
        BuffEffect.OnNewBuffEffect -= SetStartStates;
    }
}
