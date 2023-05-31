using UnityEngine;

public class Nitro : BuffEffect
{
    [SerializeField]
    private float _speedUpValue;

    public override void SetStates(Entity entity)
    {
        var player = entity.GetComponent<PlayerController>();
        if (player == null)
            return;
        //SetSpritesToPlayer();
        player.Mover.RiseSpeed(_speedUpValue);
    }
}
