using UnityEngine;

public class Coin : BonusEffect
{
    [SerializeField]
    private int _coinValue;
    public override void ApplyEffect(Entity entity)
    {
        ScoreController.instance.SetCurrentScore(_coinValue);    
    }
}
