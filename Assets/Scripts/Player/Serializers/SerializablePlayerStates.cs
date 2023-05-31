using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializablePlayerStates
{
    private float _speed, _circleRadius;
    private Sprite _bonusEffectSprite, _bonusPointSprite;

    public SerializablePlayerStates(float speed, float circleRadius, Sprite bonusEffectSprite, Sprite bonusPointSprite)
    {
        _speed = speed;
        _circleRadius = circleRadius;
        _bonusEffectSprite = bonusEffectSprite;
        _bonusPointSprite = bonusPointSprite;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetCircleRadius()
    {
        return _circleRadius;
    }

    public Sprite GetBonusEffectSprite()
    {
        return _bonusEffectSprite;
    }

    public Sprite GetBonusPointSprite()
    {
        return _bonusPointSprite;
    }
}
