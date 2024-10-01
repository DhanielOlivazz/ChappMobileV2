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

        // Propiedad vinculada al Entry (para escribir nuevos mensajes)
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
                LoadChatMessages(); // Cargar mensajes al seleccionar el chat
            }
        }

        // Colección de mensajes del chat
        public ObservableCollection<Message> Messages { get; set; }

        // Colección de chats
        public ObservableCollection<Chat> Chats { get; set; }

        // Comando para enviar mensajes
        public ICommand SendMessageCommand { get; }

        // Comando para navegar a un chat
        public ICommand NavigateToChatCommand => new Command<int>(chatId =>
        {
            SelectedChatId = chatId;
            IsChatDetailVisible = true; // Muestra la vista de detalles del chat
            IsChatListVisible = false;  // Oculta la lista de chats
        });

        // Comando para volver a la lista de chats
        public ICommand GoBackToChatsCommand => new Command(() =>
        {
            IsChatDetailVisible = false; // Oculta los detalles del chat
            IsChatListVisible = true;     // Muestra la lista de chats
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
            // Inicialización de la colección de mensajes
            Messages = new ObservableCollection<Message>
            {
                new Message { UserName = "Juan", Content = "Hola, ¿cómo estás?", IsOwnMessage = false },
                new Message { UserName = "Tú", Content = "Todo bien, ¿y tú?", IsOwnMessage = true }
            };

            // Inicialización de la colección de chats
            Chats = new ObservableCollection<Chat>
            {
                new Chat { ChatId = 1, UserName = "Juan", LastMessage = "Hola, ¿cómo estás?", ProfileImage = "dotnet_bot.png" },
                new Chat { ChatId = 2, UserName = "María", LastMessage = "¿Te gustaría salir?", ProfileImage = "dotnet_bot.png" }
            };

            // Inicialización del comando de envío de mensajes
            SendMessageCommand = new Command(SendMessage);
        }

        // Método para enviar mensajes
        private void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                // Añadir el mensaje a la lista de mensajes
                Messages.Add(new Message { UserName = "Tú", Content = NewMessage, IsOwnMessage = true });

                // Limpiar el Entry después de enviar el mensaje
                NewMessage = string.Empty;
            }
        }

        // Método para cargar los mensajes del chat seleccionado
        private void LoadChatMessages()
        {
            if (SelectedChatId.HasValue)
            {
                // Lógica para cargar los mensajes del chat basado en SelectedChatId
                // Por ejemplo, podrías filtrar una lista de mensajes previamente cargada
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
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        public string ProfileImage { get; set; }
    }

    // Modelo del mensaje
    public class Message
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public bool IsOwnMessage { get; set; }
    }
}
