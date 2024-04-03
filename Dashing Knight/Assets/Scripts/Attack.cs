using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;


    // Start is called before the first frame update


    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if it can be hit
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
           bool gotHit= damageable.Hit(attackDamage, knockback);
        }
    }
}
