using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickup : MonoBehaviour
{
    // Start is called before the first frame update


    public int healthRestore = 20; 
    public Vector3 spinRotationspeed= new Vector3 (0,180,0);
    
    // Update is called once per frame
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable)
        {
            damageable.Heal(healthRestore);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.eulerAngles += spinRotationspeed * Time.deltaTime; 
    }


}
