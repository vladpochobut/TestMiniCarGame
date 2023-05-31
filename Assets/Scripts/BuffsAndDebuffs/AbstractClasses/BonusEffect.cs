using System.Collections;
using UnityEngine;

public abstract class BonusEffect : Effect
{
    public float BonusToPlayerSpeed = 4f;

    private bool _isMoving = false;

    public void Update()
    {
        if (_isMoving)
        {
            MoveToCenter();
        }
    }

    private void MoveToCenter()
    {
        var targetPosition = CurrentEntity.GetComponent<BoxCollider2D>().bounds.center;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, BonusToPlayerSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            _isMoving = false;
            ApplyEffect(CurrentEntity);
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CurrentEntity = collision.GetComponent<Entity>();
            _isMoving = true;
        }
    }
}
