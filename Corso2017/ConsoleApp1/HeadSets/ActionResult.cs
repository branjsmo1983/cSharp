namespace Emulator.HeadSets
{
    internal class ActionResult
    {
        public string Message { get; private set; }  // Non ha senso che i set siano pubblici, perche da fuori non posso settare qualcosa di diverso al costruttore. Se li metto pubblici, i valori li posso modificare anche dopo aver chiamato il metodo.
        public bool Success { get; private set; }  // questa è una property



        public ActionResult( bool success, string message)
        {
            Message = message;
            Success = success;
        }

        public ActionResult(bool success) : this(success, string.Empty)   // E' un costruttore che chiama un altro costrutture (locale) This serve a chiamare qualcosa sull'istanza corrente
        {
            
        }
    }
}