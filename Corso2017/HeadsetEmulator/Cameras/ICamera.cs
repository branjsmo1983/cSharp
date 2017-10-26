namespace HeadsetEmulator.Cameras
{
    internal interface ICamera
    {
        Photo TakeSnap();
        bool IsActive { get; }
        ActionResult Activate();
        ActionResult Deactivate();
    }
}