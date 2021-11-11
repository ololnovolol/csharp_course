namespace Solution.Capture5
{
    interface ITelePhone
    {
        public void IncomingCall();
        public void OutgoingCall();
        public void IncomingMessage(string mesasage);
        public void OutgoingMessage();
    }
}
