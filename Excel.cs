using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelFile = Microsoft.Office.Interop.Excel;

namespace LogisticProgram
{
    class Excel
    {
        public void WriteToExcel()
        {
            Telegram telegram = new Telegram();
            List<Transport> transport = telegram.Transport;
            List<Shipping> shipping = telegram.Shipping;
            List<Registry> registry = telegram.registry;

            string path = Directory.GetCurrentDirectory() + @"\" + "Save.xlsx";
            ExcelFile.Application excelapp = new ExcelFile.Application();
            ExcelFile.Workbook workbook = excelapp.Workbooks.Add();
            ExcelFile.Worksheet transportSheet = workbook.ActiveSheet;
            ExcelFile.Worksheet shippingSheet = workbook.Worksheets.Add();
            ExcelFile.Worksheet registrySheet = workbook.Worksheets.Add();

            transportSheet.Name = "Транспорт";
            shippingSheet.Name = "Отгрузка по дням";
            registrySheet.Name = "Реестр отгрузки";

            //Шапка
            transportSheet.Rows[1].Columns[1] = "№";
            transportSheet.Rows[1].Columns[2] = "Гос. номер";
            transportSheet.Rows[1].Columns[3] = "Дата отгрузки";
            transportSheet.Rows[1].Columns[4] = "Дата выгрузки";
            transportSheet.Rows[1].Columns[5] = "Вес";
            transportSheet.Rows[1].Columns[6] = "Стоимость";
            transportSheet.Rows[1].Columns[7] = "Валюта";

            shippingSheet.Rows[1].Columns[1] = "№";
            shippingSheet.Rows[1].Columns[2] = "Дата";
            shippingSheet.Rows[1].Columns[3] = "Количество машин";
            shippingSheet.Rows[1].Columns[4] = "Вес";
            shippingSheet.Rows[1].Columns[5] = "Количество труб";

            registrySheet.Rows[1].Columns[1] = "№";
            registrySheet.Rows[1].Columns[2] = "Дата";
            registrySheet.Rows[1].Columns[3] = "Диаметр";
            registrySheet.Rows[1].Columns[4] = "Номер трубы";
            registrySheet.Rows[1].Columns[5] = "Длина";
            registrySheet.Rows[1].Columns[6] = "Толщина";
            registrySheet.Rows[1].Columns[7] = "Вес";

            //Добавление информации
            for (int i = 0; i < transport.Count; i++)
            {
                transportSheet.Rows[i + 2].Columns[1] = transport[i].Number;
                transportSheet.Rows[i + 2].Columns[2] = transport[i].StateNubmer;
                transportSheet.Rows[i + 2].Columns[3] = transport[i].DateShipping;
                transportSheet.Rows[i + 2].Columns[4] = transport[i].DateShipped;
                transportSheet.Rows[i + 2].Columns[5] = transport[i].Weight;
                transportSheet.Rows[i + 2].Columns[6] = transport[i].Price;
                transportSheet.Rows[i + 2].Columns[7] = transport[i].Currency;
            }

            for (int i = 0; i < shipping.Count; i++)
            {
                shippingSheet.Rows[i + 2].Columns[1] = shipping[i].Number;
                shippingSheet.Rows[i + 2].Columns[2] = shipping[i].Date;
                shippingSheet.Rows[i + 2].Columns[3] = shipping[i].Trucks;
                shippingSheet.Rows[i + 2].Columns[4] = shipping[i].Weight;
                shippingSheet.Rows[i + 2].Columns[5] = shipping[i].Pipes;
            }

            for (int i = 0; i < registry.Count; i++)
            {
                registrySheet.Rows[i + 2].Columns[1] = registry[i].Number;
                registrySheet.Rows[i + 2].Columns[2] = registry[i].Date;
                registrySheet.Rows[i + 2].Columns[3] = registry[i].Diameter;
                registrySheet.Rows[i + 2].Columns[4] = registry[i].PipeNumber;
                registrySheet.Rows[i + 2].Columns[5] = registry[i].Length;
                registrySheet.Rows[i + 2].Columns[6] = registry[i].Thickness;
                registrySheet.Rows[i + 2].Columns[7] = registry[i].Weight;
            }

            //Выравнивание
            int headerFontSize = 12, defautFontSize = 10;
            for (int i = 1; i <= 7; i++)
            {
                ExcelFile.Range r = transportSheet.Cells[1, i] as ExcelFile.Range;
                r.Font.Bold = true;
                r.Font.Size = headerFontSize;
                ExcelFile.Range r2 = transportSheet.Cells[2, i] as ExcelFile.Range;
                r2.EntireColumn.AutoFit();
                r2.Font.Size = defautFontSize;
            }

            for (int i = 1; i <= 5; i++)
            {
                ExcelFile.Range r = shippingSheet.Cells[1, i] as ExcelFile.Range;
                r.Font.Bold = true;
                r.Font.Size = headerFontSize;
                ExcelFile.Range r2 = shippingSheet.Cells[2, i] as ExcelFile.Range;
                r2.EntireColumn.AutoFit();
                r2.Font.Size = defautFontSize;
            }

            for (int i = 1; i <= 7; i++)
            {
                ExcelFile.Range r = registrySheet.Cells[1, i] as ExcelFile.Range;
                r.Font.Bold = true;
                r.Font.Size = headerFontSize;
                ExcelFile.Range r2 = registrySheet.Cells[2, i] as ExcelFile.Range;
                r2.EntireColumn.AutoFit();
                r2.Font.Size = defautFontSize;
            }

            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
        }
    }
}
