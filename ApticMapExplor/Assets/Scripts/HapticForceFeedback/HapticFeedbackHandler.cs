using UnityEngine;

[RequireComponent(typeof(EndEffectorController))]
public class HapticFeedbackHandler : MonoBehaviour
{
    protected bool IsTouchingSurface;

    #region Sfield Vars

    [SerializeField] private GameObject endEffectorSlave;
    [SerializeField] private GameObject endEffectorMaster;
    [SerializeField] private float proportionalGain;
    [SerializeField] private float derivativeGain;
    [SerializeField] private float derivativeSmoothing;

    #endregion

    #region Member Vars

    private EndEffectorController endEffectorController;
    private Vector3 slaveToMaster = Vector3.zero;
    private float distX;
    private float distY;
    private float buffX;
    private float buffY;
    private float diffX;
    private float diffY;
    private float oldX;
    private float oldY;
    private float xForce;
    private float yForce;

    #endregion

    #region Unity Functions

    private void Awake()
    {
        endEffectorController = GetComponent<EndEffectorController>();
    }

    private void OnEnable()
    {
        endEffectorSlave.GetComponent<EndEffectorSlaveHandler>().OnCollision += SetCollisionState;
    }

    private void OnDisable()
    {
        endEffectorSlave.GetComponent<EndEffectorSlaveHandler>().OnCollision -= SetCollisionState;
    }
    
    private void LateUpdate()
    {
        if (!IsTouchingSurface)
        {
            FlushForces();
            return;
        }
        CalculateForces();
    }

    private void OnDestroy() => FlushForces();

    private void OnApplicationQuit() => FlushForces();

    #endregion

    #region Protected Functions

    protected void CalculateForces(bool is3D = false)
    {
        slaveToMaster = endEffectorMaster.transform.position - endEffectorSlave.transform.position;
        distX = slaveToMaster.x;
        distY = is3D? slaveToMaster.z : slaveToMaster.y;
        buffX = (distX - oldX)/Time.deltaTime;
        buffY = (distY - oldY)/Time.deltaTime;
        diffX = derivativeSmoothing * diffX + (1 - derivativeSmoothing) * buffX;
        diffY = derivativeSmoothing * diffY + (1 - derivativeSmoothing) * buffY;
        xForce = proportionalGain * distX + derivativeGain * diffX;
        yForce = proportionalGain * distY + derivativeGain * diffY;
        endEffectorController.SetForces(xForce, yForce);
        oldX = distX;
        oldY = distY;
    }
    
    protected void FlushForces()
    {
        endEffectorController.SetForces(0, 0);
    }

    #endregion

    #region Private Functions

    private void SetCollisionState(bool state)
    {
        IsTouchingSurface = state;
    }

    #endregion
}

