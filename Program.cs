using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("");

User bot = botClient.GetMeAsync().Result;

while (true)
{
    Update[] updates = await botClient.GetUpdatesAsync();

    for (int i = 0; i < updates.Length; i++)
    {
        Console.WriteLine(updates[i].Message.Text);
        Console.WriteLine(updates[i].Message.From.FirstName);
        Console.WriteLine(updates[i].Message.From.Id); 
        ReplyToMessage(updates[i].Message);
        updates = await botClient.GetUpdatesAsync(updates[^1].Id + 1);// Пропускаем обновления, которые уже получили.
       
    }

}

async Task ReplyToMessage(Message message)
{
await botClient.SendTextMessageAsync(new ChatId(message.From.Id),"Hello");
}