using MyMVVM.DataTransfer;

namespace AoW.WPF.Infrastructure.DataMessage
{
    internal class AowDataContainer : IDataContainer<WorkwearDataMessage>
    {
        private static AowDataContainer _instance;
        private AowDataContainer()
        {

        }

        public static AowDataContainer GetDataContainer()
        {
            if (_instance is null)
            {
                _instance = new();
            }
            return _instance;
        }

        private WorkwearDataMessage _dataMessage;

        public WorkwearDataMessage GetDataMessage()
        {
            return _dataMessage;
        }

        public void SendDataMessage(WorkwearDataMessage message)
        {
            _dataMessage = message; 
        }
    }
}
