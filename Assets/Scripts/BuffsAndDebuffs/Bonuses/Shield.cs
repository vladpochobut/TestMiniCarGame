public class Shield : BuffEffect
{
    public override void SetStates(Entity entity)
    {
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.Health.BlockDamage(true);
    }
}
