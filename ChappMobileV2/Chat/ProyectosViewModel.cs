using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ChappMobileV2.Vistas;
using System;

namespace ChappMobileV2.ViewModels
{
    public class ProyectosViewModel : INotifyPropertyChanged
    {
        private string _newMessage;
        private int? _selectedChatId;

        // Propiedad vinculada al Entry 
        public string NewMessage
        {
            get => _newMessage;
            set
            {
                _newMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        // Propiedad para almacenar el ID del chat seleccionado
        public int? SelectedChatId
        {
            get => _selectedChatId;
            set
            {
                _selectedChatId = value;
                OnPropertyChanged(nameof(SelectedChatId));
                LoadChatMessages();
            }
        }

        // Diccionario para almacenar los mensajes de cada chat por su ID
        private Dictionary<int, ObservableCollection<Message>> ChatMessages { get; set; }

        // Colección de mensajes del chat
        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }

        // Colección de chats
        public ObservableCollection<Chat> Chats { get; set; }

        // Comando para enviar mensajes
        public ICommand SendMessageCommand { get; }

        // Comando para navegar a un chat
        public ICommand NavigateToChatCommand => new Command<int>(chatId =>
        {
            SelectedChatId = chatId;
            IsChatDetailVisible = true;
            IsChatListVisible = false;
        });

        // Comando para volver a la lista de chats
        public ICommand GoBackToChatsCommand => new Command(() =>
        {
            IsChatDetailVisible = false;
            IsChatListVisible = true;
        });

        // Propiedades para controlar la visibilidad de las vistas
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

        private bool _isChatDetailVisible;
        public bool IsChatDetailVisible
        {
            get => _isChatDetailVisible;
            set
            {
                _isChatDetailVisible = value;
                OnPropertyChanged(nameof(IsChatDetailVisible));
            }
        }

        // Constructor
        public ProyectosViewModel()
        {
            // Inicialización de las colecciones de mensajes
            ChatMessages = new Dictionary<int, ObservableCollection<Message>>
            {
                {
                    1, new ObservableCollection<Message>
                    {
                        new Message { UserName = "Juan", Content = "Hola, ¿cómo estás?", IsOwnMessage = false },
                        new Message { UserName = "Tú", Content = "Todo bien, ¿y tú?", IsOwnMessage = true }
                    }
                },
                {
                    2, new ObservableCollection<Message>
                    {
                        new Message { UserName = "María", Content = "¿Te gustaría salir?", IsOwnMessage = false }
                    }
                }
            };

            // Inicialización de la colección de chats
            Chats = new ObservableCollection<Chat>
            {
                new Chat { ChatId = 1, UserName = "Juan", LastMessage = "Todo bien, ¿y tú?", ProfileImage = "dotnet_bot.png" },
                new Chat { ChatId = 2, UserName = "María", LastMessage = "¿Te gustaría salir?", ProfileImage = "dotnet_bot.png" }
            };

            // Inicialización del comando de envío de mensajes
            SendMessageCommand = new Command(SendMessage);
        }

        // Método para enviar mensajes
        private void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage) && SelectedChatId.HasValue)
            {
                // Añadir el mensaje a la lista de mensajes del chat actual
                var newMessage = new Message { UserName = "Tú", Content = NewMessage, IsOwnMessage = true };
                ChatMessages[SelectedChatId.Value].Add(newMessage);

                // Actualizar la colección de mensajes mostrada en la interfaz
                Messages = new ObservableCollection<Message>(ChatMessages[SelectedChatId.Value]);

                // Encontrar el chat correspondiente y actualizar su 'LastMessage'
                var chat = Chats.FirstOrDefault(c => c.ChatId == SelectedChatId.Value);
                if (chat != null)
                {
                    chat.LastMessage = newMessage.Content;
                }

                OnPropertyChanged(nameof(Chats));

                // Limpiar el campo de texto después de enviar el mensaje
                NewMessage = string.Empty;
            }
        }

        // Método para cargar los mensajes del chat seleccionado
        private void LoadChatMessages()
        {
            if (SelectedChatId.HasValue)
            {
                Messages = new ObservableCollection<Message>(ChatMessages[SelectedChatId.Value]);
            }
        }

        // Implementación del INotifyPropertyChanged para las actualizaciones de la UI
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Modelo del chat
    public class Chat
    {
        public int ChatId { get; set; }
        public string? UserName { get; set; }
        public string? LastMessage { get; set; }
        public string? ProfileImage { get; set; }
    }

    // Modelo del mensaje
    public class Message
    {
        public string? UserName { get; set; }
        public string? Content { get; set; }
        public bool IsOwnMessage { get; set; }
    }
}
