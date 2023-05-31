using UnityEngine;

public class Heal : BonusEffect
{
    [SerializeField]
    private float _healValue;
    public override void ApplyEffect(Entity entity)
    {
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.Health.TakeHealPoints(_healValue);
    }
}
