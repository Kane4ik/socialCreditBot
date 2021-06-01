using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using socialCreditBot.Models;
using System.Threading.Tasks;
using System.Threading;


namespace socialCreditBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook url part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();
            Task task = null;

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    task = Task.Run(()=>command.Execute(message, client));
                    await task;
                    break;
                }
            }

            return Ok();
        }
    }
}
