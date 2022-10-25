using Telegram.Bot;
using Telegram.Bot.Types;

var botClient = new TelegramBotClient("");

User bot = botClient.GetMeAsync().Result;

List<long> users = new List<long>();

while (true)
{
    Update[] updates = await botClient.GetUpdatesAsync();

    for (int i = 0; i < updates.Length; i++)

    {
        if (!users.Contains(updates[i].Message.From.Id))
        {
            users.Add(updates[i].Message.From.Id);
        }

        ReplyToMessage(updates[i].Message);
        updates = await botClient.GetUpdatesAsync(updates[^1].Id + 1);// Пропускаем обновления, которые уже получили.

    }

}

async Task ReplyToMessage(Message message)
{
    for (int i = 0; i < users.Count; i++)
    {
        await botClient.SendTextMessageAsync(new ChatId(users[i]), message.Text);
    }

}
