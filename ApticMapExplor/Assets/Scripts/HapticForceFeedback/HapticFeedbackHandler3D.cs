public class HapticFeedbackHandler3D : HapticFeedbackHandler

{
    private void LateUpdate()
    {
        if (!IsTouchingSurface)
        {
            FlushForces();
            return;
        }
        CalculateForces(is3D:true);
    }
}


