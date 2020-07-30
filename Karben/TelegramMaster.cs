using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace Karben
{
    class TelegramMaster
    {
        public TelegramMaster()
        {
            var me = Bot.GetMeAsync().Result;
            Console.Title = me.Username;
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($"Start listening for @{me.Username}");
            Thread.Sleep(Timeout.Infinite);
            Bot.StopReceiving();
        }

        public TelegramBotClient Bot { get; } = new TelegramBotClient(ConfigurationManager.AppSettings["telegramKey"]);

        private void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }

        private async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            var telegramMessage = message.Text.Split(' ').First();

            if (telegramMessage == "/easy")
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var test = await Bot.SendTextMessageAsync(message.Chat.Id, "test");
                await Bot.EditMessageTextAsync(message.Chat.Id, test.MessageId, "test2");
            }
        }
    }
}
