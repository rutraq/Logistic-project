using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace LogisticProgram
{
    class Telegram
    {
        private static string startText = "Выберите команду\n" +
                    "/all_data_bases - Вывести все таблицы\n" +
                    "/transport - Вывести таблицу Транспорт\n" +
                    "/shipping - Вывести таблицу Отгрузка по дням\n" +
                    "/registry - Вывести таблицу Реестр отгрузки\n" +
                    "/excel - Вывести информацию в Excel\n";
        private static ITelegramBotClient botClient;

        public static List<Registry> reg = new List<Registry>();
        public static List<Transport> transport = new List<Transport>();
        public static List<Shipping> shipping = new List<Shipping>();

        private static List<string> commands = new List<string>() { "/all_data_bases", "/registry", "/transport", "/shipping", "/excel" };

        public List<Registry> registry { get => reg; set => reg = value; }
        public List<Transport> Transport { get => transport; set => transport = value; }
        public List<Shipping> Shipping { get => shipping; set => shipping = value; }

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
                    text: transportStr()
                    );
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: shippingStr()
                    );
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: registryStr()
                    );
            }
            else if (text == "/registry")
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: registryStr()
                    );
            }
            else if (text == "/transport")
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: transportStr()
                    );
            }
            else if (text == "/shipping")
            {
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: shippingStr()
                    );
            }
            else if (text == "/excel")
            {
                using (FileStream fs = File.OpenRead("Save.xlsx"))
                {
                    InputOnlineFile inputOnlineFile = new InputOnlineFile(fs, "Info.xlsx");
                    await botClient.SendDocumentAsync(
                        chatId: e.Message.Chat,
                        document: inputOnlineFile
                        );
                }
                File.Delete("Save.xlsx");
            }
        }

        public static string registryStr()
        {
            string info = "";
            string name = "Реестр отгрузки\n\n";
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

        public static string transportStr()
        {
            string info = "";
            string name = "Транспорт\n\n";
            int i = 1;
            foreach (var el in transport)
            {
                info += $"Запись {i}\n";
                info += "-------------------------------------------------------\n";
                info += $" Номер: {el.Number}\n Гос. номер: {el.StateNubmer}\n Дата отгрузки: {el.DateShipping}\n Дата выгрузки: {el.DateShipped}\n Вес: {el.Weight}\n Стоимость: {el.Price} {el.Currency}\n";
                if (i != transport.Count)
                {
                    info += "-------------------------------------------------------\n";
                }
                i++;
            }
            return name + info;
        }

        public static string shippingStr()
        {
            string info = "";
            string name = "Отгрузка по дням\n\n";
            int i = 1;
            foreach (var el in shipping)
            {
                info += $"Запись {i}\n";
                info += "-------------------------------------------------------\n";
                info += $" Номер: {el.Number}\n Дата: {el.Date}\n Количество машин: {el.Trucks}\n Вес: {el.Weight}\n Количество труб: {el.Pipes}\n";
                if (i != shipping.Count)
                {
                    info += "-------------------------------------------------------\n";
                }
                i++;
            }
            return name + info;
        }
    }
}
