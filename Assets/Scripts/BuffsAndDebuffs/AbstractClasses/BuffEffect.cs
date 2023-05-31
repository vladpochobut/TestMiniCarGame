using System;
using System.Collections;
using UnityEngine;

public abstract class BuffEffect : BonusEffect
{
    public static event Action OnNewBuffEffect;
    public static event Action<float, Sprite, string> OnStartEffect;
    [SerializeField]
    private BUFF_EFFECTS _effectName;
    [SerializeField]
    private Sprite _effectBar;
    [SerializeField]
    private float _effectDuration = 15f;
    [SerializeField]
    private Sprite _carBunusPoint;
    [SerializeField]
    private Sprite _carBonusEffect;

    public abstract void SetStates(Entity entity);

    public override void ApplyEffect(Entity entity)
    {
        var playerStates = entity.GetComponent<PlayerController>();
        OnNewBuffEffect?.Invoke();//PlayerController
        OnStartEffect?.Invoke(_effectDuration,_effectBar,_effectName.ToString());//UpperBars
        SetSpritesToEntity();
        SetStates(entity);
        playerStates.EffectProcessing(_effectDuration);

    }

    private void SetSpritesToEntity()
    {
        var player = CurrentEntity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.CarBunusPoint.sprite = _carBunusPoint;
        player.CarBonusEffect.sprite = _carBonusEffect;
    }
}

public enum BUFF_EFFECTS
{
    Nitro,
    Shield,
    Magnit
}
