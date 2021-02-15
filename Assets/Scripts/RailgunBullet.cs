using UnityEngine;

public class RailgunBullet : bullet
{
    public GameObject explosion;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ship" || other.tag == "Enemy Bullet") return;
        var boom = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}