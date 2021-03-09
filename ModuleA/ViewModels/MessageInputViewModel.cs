#region License

// author:         吴经纬
// created:        12:20
// description:

#endregion

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismDemo.Core.Events;

namespace ModuleA.ViewModels
{
    public class MessageInputViewModel : BindableBase
    {
        private string _message = "Message to Send";

        private readonly IEventAggregator _eventAggregator;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand SendMessageCommand { get; }

        public MessageInputViewModel(IEventAggregator eventAggregator)
        {
            SendMessageCommand = new DelegateCommand(SendMessage);
            _eventAggregator = eventAggregator;
        }

        private void SendMessage()
        {
            _eventAggregator.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
