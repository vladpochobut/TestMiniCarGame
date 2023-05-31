using UnityEngine;

public class Obstacle : Effect
{
    public override void ApplyEffect(Entity entity)
    {
        Debug.Log("HERE");
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.Health.Die();
    }
}
