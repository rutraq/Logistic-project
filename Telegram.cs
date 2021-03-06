﻿using System;
using System.Collections.Generic;
using System.IO;
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

        static Excel excel = new Excel();
        static Sql sql = new Sql();

        public static List<Registry> reg = new List<Registry>();
        public static List<Transport> transport = new List<Transport>();
        public static List<Shipping> shipping = new List<Shipping>();
        public static List<int> updateByFile = new List<int>();

        private static List<string> commands = new List<string>() { "/all_data_bases", "/registry", "/transport", "/shipping", "/excel", "/update" };

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
            var document = e?.Message?.Document?.FileId;

            if (text == null || document != null)
            {
                if (updateByFile.Contains(Convert.ToInt32(e.Message.Chat.Id)))
                {
                    await botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text: "Файл обрабатывается"
                                );
                    var file = await botClient.GetFileAsync(document);
                    FileStream fs2 = new FileStream("saveFromTelegram.xlsx", FileMode.Create);
                    await botClient.DownloadFileAsync(file.FilePath, fs2);
                    fs2.Close();
                    fs2.Dispose();

                    try
                    {
                        sql.UpdateTransport(excel.LoadFromExcelTransport());
                        sql.UpdateShipping(excel.LoadFromExcelShipping());
                        sql.UpdateRegistry(excel.LoadFromExcelRegistry());

                        await botClient.SendTextMessageAsync(
                                chatId: e.Message.Chat,
                                text: "Файл обработан, идёт загрузка в базу данных"
                                );
                        await botClient.SendTextMessageAsync(
                                    chatId: e.Message.Chat,
                                    text: "Информация загружена"
                                    );
                        Form1 f = new Form1();
                        f.LoadData();

                        updateByFile.Remove(Convert.ToInt32(e.Message.Chat.Id));
                    }
                    catch (Exception ex)
                    {
                        await botClient.SendTextMessageAsync(
                                    chatId: e.Message.Chat,
                                    text: ex.Message
                                    );
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: startText
                    );
                }
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
                    fs.Close();
                    fs.Dispose();
                }
            }
            else if (text == "/update")
            {
                updateByFile.Add(Convert.ToInt32(e.Message.Chat.Id));
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Отредактируйте файл Excel для обновления базы данных"
                    );
                using (FileStream fs = File.OpenRead("Save.xlsx"))
                {
                    InputOnlineFile inputOnlineFile = new InputOnlineFile(fs, "Info.xlsx");
                    await botClient.SendDocumentAsync(
                        chatId: e.Message.Chat,
                        document: inputOnlineFile
                        );
                    fs.Close();
                    fs.Dispose();
                }
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