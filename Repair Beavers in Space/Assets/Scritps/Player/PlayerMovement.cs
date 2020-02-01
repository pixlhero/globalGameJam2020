using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float force;

    public float maxVelocity;

    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var currentVel = this._rigidbody.velocity;
        if (currentVel.magnitude > maxVelocity)
        {
            var newVel = currentVel.normalized * maxVelocity;
            this._rigidbody.velocity = newVel;
        }
    }

    public void Flap()
    {
        _rigidbody.AddForce(force * this.transform.up, ForceMode2D.Impulse);
    }

    public void AdjustDirection(Vector2 direction)
    {
        if (direction.magnitude < 0.1)
            return;



        // weird fix. don't judge me. :'(
        direction = new Vector2(direction.y, -direction.x);

        Vector3 direction3 = new Vector3(direction.x, direction.y, 0);
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * direction3;
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        // changed this from a lerp to a RotateTowards because you were supplying a "speed" not an interpolation value
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);


        //this.transform.rotation = Quaternion.LookRotation(direction3, Vector3.forward);
    }
}
