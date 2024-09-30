using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ChappMobileV2.ViewModels
{
    public class ProyectosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Chat> Chats { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public ICommand NavigateToChatCommand { get; }
        public ICommand GoBackToChatsCommand { get; }
        public ICommand SendMessageCommand { get; }

        private bool _isChatListVisible = true;
        public bool IsChatListVisible
        {
            get => _isChatListVisible;
            set
            {
                _isChatListVisible = value;
                OnPropertyChanged(nameof(IsChatListVisible));
            }
        }

        private bool _isChatDetailVisible = false;
        public bool IsChatDetailVisible
        {
            get => _isChatDetailVisible;
            set
            {
                _isChatDetailVisible = value;
                OnPropertyChanged(nameof(IsChatDetailVisible));
            }
        }

        public ProyectosViewModel()
        {
            // Inicializar los chats
            Chats = new ObservableCollection<Chat>
            {
                new Chat { ChatId = 1, UserName = "Juan", LastMessage = "Hola!", ProfileImage = "juan.png" },
                new Chat { ChatId = 2, UserName = "Maria", LastMessage = "Nos vemos luego", ProfileImage = "maria.png" }
            };

            Messages = new ObservableCollection<Message>();

            // Comandos
            NavigateToChatCommand = new Command<int>(OnNavigateToChat);
            GoBackToChatsCommand = new Command(GoBackToChats);
            SendMessageCommand = new Command<string>(SendMessage);
        }

        private void OnNavigateToChat(int chatId)
        {
            // Cambiar la visibilidad
            IsChatListVisible = false;
            IsChatDetailVisible = true;

            // Cargar mensajes simulados
            Messages.Clear();
            Messages.Add(new Message { UserName = "Juan", Content = "Hola, ¿cómo estás?" });
            Messages.Add(new Message { UserName = "Tú", Content = "Todo bien, ¿y tú?" });
        }

        private void GoBackToChats()
        {
            // Cambiar la visibilidad
            IsChatListVisible = true;
            IsChatDetailVisible = false;
        }

        private void SendMessage(string messageContent)
        {
            if (!string.IsNullOrWhiteSpace(messageContent))
            {
                Messages.Add(new Message { UserName = "Tú", Content = messageContent });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class Chat
    {
        public int ChatId { get; set; }
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        public string ProfileImage { get; set; }
    }

    public class Message
    {
        public string UserName { get; set; }
        public string Content { get; set; }
    }
}
