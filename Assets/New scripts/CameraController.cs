public static class CameraController
{
    public static void StartPreviewCamera()
    {
        PreviewCamera.SwitchStartPosition(FollowCamera.GetCurrentPosition());
        PreviewCamera.SetFOV(FollowCamera.GetCurrentFOV());
        PreviewCamera.EnabledDisable(true);
        FollowCamera.EnabledDisable(false);
        PreviewCamera.Condition(true); 
        FollowCamera.SetFollowTarget(null);
        FollowCamera.ResetPosition();
    }
    public static void DisablePreviewCamera()
    {
        PreviewCamera.EnabledDisable(false);
        FollowCamera.EnabledDisable(true);
    }
    public static void FollowCar(Car car)
    {
        PreviewCamera.EnabledDisable(false);
        FollowCamera.EnabledDisable(true);
        FollowCamera.SetFollowTarget(car);
    }
}
