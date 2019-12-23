using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace LogisticProgram
{
    class Telegram
    {
        private static string startText = "Выберите команду\n" +
                    "/all_data_bases - Вывести все таблицы\n" +
                    "/registry - Вывести таблицу Реестр отгрузки\n";
        private static ITelegramBotClient botClient;
        public static List<Registry> reg = new List<Registry>();
        private static List<string> commands = new List<string>() { "/all_data_bases", "/registry" };

        public List<Registry> registry { get => reg; set => reg = value; }

        public void Bot()
        {
            botClient = new TelegramBotClient("640616392:AAFbJ4MLr-EHV4BqdeoSqxxABss1CRUzQxU") { Timeout = TimeSpan.FromSeconds(10) };
            botClient.OnMessage += Message;
            botClient.StartReceiving();
        }
        public void Probe(EventHandler<MessageEventArgs> Method)
        {
            botClient.OnMessage += Method;
        }
        public static async void Message(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null)
            {
                return;
            }
            else if (!commands.Contains(text))
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: startText
                    );
            }
            else if (text == "/all_data_bases")
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: registryStr()
                    );
            }
        }

        public static string registryStr()
        {
            string info = "";
            string name = "Реестр отгрузки\n";
            int i = 1;
            foreach (var el in reg)
            {
                info += $"Запись {i}\n";
                info += "-------------------------------------------------------\n";
                info += $" Номер: {el.Number}\n Дата: {el.Date}\n Номер трубы: {el.PipeNumber}\n Длина: {el.Length}\n Толщина: {el.Thickness}\n Вес: {el.Weight}\n";
                if (i != reg.Count)
                {
                    info += "-------------------------------------------------------\n"; 
                }
                i++;
            }
            return name + info;
        }
    }
}
