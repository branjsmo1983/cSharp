namespace HeadsetEmulator
{
    internal class ActionResult
    {
        public string Message { get;private set; }
        public bool Success { get;private set; }

        public ActionResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ActionResult(bool success) : this(success, string.Empty)
        {
        }
    }
}