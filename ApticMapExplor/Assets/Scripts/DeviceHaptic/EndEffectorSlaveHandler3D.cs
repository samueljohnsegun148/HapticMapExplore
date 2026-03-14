using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EndEffectorSlaveHandler3D : EndEffectorSlaveHandler
{
 
    #region Member Vars

    private Rigidbody rb;
    private Collider col;

    #endregion

    #region Unity Functions

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.isTrigger) return;
        NumberOfCollisions++;
        OnCollision?.Invoke(IsTouching());
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.collider.isTrigger) return;
        NumberOfCollisions--;
        OnCollision?.Invoke(IsTouching());
    }
    
    #endregion

    #region Protected Functions

    protected override void FollowMasterEndEffector()
    {
        Vector3 direction = EndEffectorMaster.position - transform.position;
        Vector3 velocity = direction / Time.fixedDeltaTime;
        velocity.SetY(0);
        rb.velocity = velocity;
    }

    private void ToggleCollider(bool state)
    {
        col.enabled = !state;
    }

    #endregion
    
}


