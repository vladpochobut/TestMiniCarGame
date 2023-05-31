using UnityEditor;
using UnityEngine;
public abstract class Effect : MonoBehaviour
{
    public Entity CurrentEntity;
    public abstract void ApplyEffect(Entity entity);

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision is BoxCollider2D)
        {
            Debug.Log("Collision");
            CurrentEntity = collision.GetComponent<Entity>();
            ApplyEffect(CurrentEntity);
        }
    }
}
   
