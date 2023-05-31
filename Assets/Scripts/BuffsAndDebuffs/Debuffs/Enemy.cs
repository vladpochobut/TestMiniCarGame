public class Enemy : Effect
{
    public override void ApplyEffect(Entity entity)
    {
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.Health.Die();
    }
}
