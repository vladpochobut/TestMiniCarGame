using UnityEngine;

public class Magnit : BuffEffect
{
    [SerializeField]
    private float _radius;

    public override void SetStates(Entity entity)
    {
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.CircleCollider.radius = _radius;
    }
}
