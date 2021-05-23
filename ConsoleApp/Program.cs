using System;
using System.Threading.Tasks;
using ConsoleApp.Classes;
using Telegram.Bot;
using Telegram.Bot.Args;
using Tweetinvi;

namespace ConsoleApp
{
    class Program
    {
        static ITelegramBotClient botClient;

        static async Task Main(string[] args)
        {
            botClient = new TelegramBotClient(Credentials.TelegramToken);
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Files file = new Files();
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: $"You said: {e.Message.Text}\n"
                    );
                file.writeFile(@".\files\message.txt", $"{e.Message.Chat.Id}: {e.Message.Text}");
            }
        }
    }
}
