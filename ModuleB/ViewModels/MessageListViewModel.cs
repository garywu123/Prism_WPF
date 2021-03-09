#region License

// author:         吴经纬
// created:        14:45
// description:

#endregion

using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismDemo.Core.Events;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages =
            new ObservableCollection<string>();

        public ObservableCollection<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public DelegateCommand UnsubscribeCommand { get; }

        // 构造器，接收来自 IEventAggregator 中 MessageSentEvent 事件
        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            // 获取一个事件，然后注册一个方法到该事件上
            var messageEvent = eventAggregator.GetEvent<MessageSentEvent>();

            // 获取一个事件注册完成后的 Token 句柄，方便之后解除注册
            var eventToken = messageEvent.Subscribe(OnMessageReceived,
                ThreadOption.PublisherThread, false, message => message.Contains("Gary"));

            // 用来解除
            UnsubscribeCommand = new DelegateCommand(() =>
            {
                messageEvent.Unsubscribe(eventToken);
            });
        }

        // The handler for event 
        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
