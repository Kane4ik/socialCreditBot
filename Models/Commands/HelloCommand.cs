using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using System.Threading;

namespace socialCreditBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

         

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: bot logic;

            client.SendTextMessageAsync(chatId, "Test successful", replyToMessageId: messageId);
            
            
        }
    }
}