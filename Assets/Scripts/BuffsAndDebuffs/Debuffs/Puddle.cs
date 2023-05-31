using UnityEngine;

public class Puddle : Effect
{
    [SerializeField]
    private float _slowdownTime;
    [SerializeField]
    private float _slowdownValue;

    public override void ApplyEffect(Entity entity)
    {
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        player.Mover.SpeedDeceleration(_slowdownValue);
        player.EffectProcessing(_slowdownTime);
    }
}
