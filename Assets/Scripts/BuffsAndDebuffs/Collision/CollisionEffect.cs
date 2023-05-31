using System.Collections;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _collisionEffect; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionPosition = collision.GetContact(0).point;
        _collisionEffect.transform.position = collisionPosition;
        _collisionEffect.SetActive(true);

        StartCoroutine(HideCollisionEffect());
    }

    private IEnumerator HideCollisionEffect()
    {
        yield return new WaitForSeconds(1f);
        _collisionEffect.SetActive(false);
    }
}
