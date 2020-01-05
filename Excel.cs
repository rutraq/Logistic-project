using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            string path = Application.StartupPath.ToString() + @"\" + "Save.xlsx";
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
            registrySheet.Rows[1].Columns[2] = "Номер отгрузки";
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
                for (int j = 0; j < shipping.Count; j++)
                {
                    if (shipping[j].Date == registry[i].Date)
                    {
                        registrySheet.Rows[i + 2].Columns[2] = shipping[j].Number; 
                    }
                }
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
                r.HorizontalAlignment = ExcelFile.XlHAlign.xlHAlignCenter;
                ExcelFile.Range r2 = transportSheet.Cells[2, i] as ExcelFile.Range;
                r2.EntireColumn.AutoFit();
                r2.Font.Size = defautFontSize;
            }

            for (int i = 1; i <= 5; i++)
            {
                ExcelFile.Range r = shippingSheet.Cells[1, i] as ExcelFile.Range;
                r.Font.Bold = true;
                r.Font.Size = headerFontSize;
                r.HorizontalAlignment = ExcelFile.XlHAlign.xlHAlignCenter;
                ExcelFile.Range r2 = shippingSheet.Cells[2, i] as ExcelFile.Range;
                r2.EntireColumn.AutoFit();
                r2.Font.Size = defautFontSize;
            }

            for (int i = 1; i <= 7; i++)
            {
                ExcelFile.Range r = registrySheet.Cells[1, i] as ExcelFile.Range;
                r.Font.Bold = true;
                r.Font.Size = headerFontSize;
                r.HorizontalAlignment = ExcelFile.XlHAlign.xlHAlignCenter;
                ExcelFile.Range r2 = registrySheet.Cells[2, i] as ExcelFile.Range;
                r2.EntireColumn.AutoFit();
                r2.Font.Size = defautFontSize;
            }

            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
        }

        public int CheckSheets(ExcelFile.Worksheet sheet, string table)
        {
            int column = -1;
            int j = 2;

            if (table == "transport")
            {
                for (; ; )
                {

                    if (Convert.ToString(sheet.Rows[j].Columns[1].Value) == null)
                    {
                        break;
                    }
                    else
                    {
                        for (int i = 1; i <= 7; i++)
                        {
                            if (sheet.Rows[j].Columns[i].Value == null)
                            {
                                column = i;
                            }
                        }

                        j++;
                    }
                }
            }
            else if (table == "shipping")
            {
                for (; ; )
                {

                    if (Convert.ToString(sheet.Rows[j].Columns[1].Value) == null)
                    {
                        break;
                    }
                    else
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            if (sheet.Rows[j].Columns[i].Value == null)
                            {
                                column = i;
                            }
                        }

                        j++;
                    }
                }
            }
            else if (table == "registry")
            {
                for (; ; )
                {

                    if (Convert.ToString(sheet.Rows[j].Columns[1].Value) == null)
                    {
                        break;
                    }
                    else
                    {
                        for (int i = 1; i <= 7; i++)
                        {
                            if (sheet.Rows[j].Columns[i].Value == null)
                            {
                                column = i;
                            }
                        }

                        j++;
                    }
                }
            }
            return column;
        }

        public List<Transport> LoadFromExcelTransport()
        {
            List<Transport> transports = new List<Transport>();
            string path = Application.StartupPath.ToString() + @"\" + "saveFromTelegram.xlsx";
            ExcelFile.Application excelapp = new ExcelFile.Application();
            ExcelFile.Workbook workbook = excelapp.Workbooks.Open(path, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ExcelFile.Worksheet sheet = (ExcelFile.Worksheet)workbook.Sheets[3];
            int j = 2;
            for (; ; )
            {
                
                Transport transport = new Transport();

                if (Convert.ToString(sheet.Rows[j].Columns[1].Value) == null)
                {
                    break;
                }
                else
                {
                    int column = CheckSheets(sheet, "transport");
                    if (column != -1)
                    {
                        throw new Exception("Заполните все поля в таблице транспорт");
                    }
                    transport.Number = Convert.ToInt32(sheet.Rows[j].Columns[1].Value);
                    transport.StateNubmer = Convert.ToString(sheet.Rows[j].Columns[2].Value);
                    transport.DateShipping = Convert.ToString(sheet.Rows[j].Columns[3].Value);
                    transport.DateShipped = Convert.ToString(sheet.Rows[j].Columns[4].Value);
                    transport.Weight = Convert.ToInt32(sheet.Rows[j].Columns[5].Value);
                    transport.Price = Convert.ToInt32(sheet.Rows[j].Columns[6].Value);
                    transport.Currency = Convert.ToString(sheet.Rows[j].Columns[7].Value);

                    transports.Add(transport);

                    j++;
                }
            }
            workbook.Close(false, Type.Missing, Type.Missing);
            excelapp.Quit();
            return transports;
        }
        public List<Shipping> LoadFromExcelShipping()
        {
            List<Shipping> shippings = new List<Shipping>();
            string path = Application.StartupPath.ToString() + @"\" + "saveFromTelegram.xlsx";
            ExcelFile.Application excelapp = new ExcelFile.Application();
            ExcelFile.Workbook workbook = excelapp.Workbooks.Open(path, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ExcelFile.Worksheet sheet = (ExcelFile.Worksheet)workbook.Sheets[2];
            int j = 2;
            for (; ; )
            {

                Shipping shipping = new Shipping();

                if (Convert.ToString(sheet.Rows[j].Columns[1].Value) == null)
                {
                    break;
                }
                else
                {
                    int column = CheckSheets(sheet, "shipping");
                    if (column != -1)
                    {
                        throw new Exception("Заполните все поля в таблице отгрузка по дням");
                    }

                    shipping.Number = Convert.ToInt32(sheet.Rows[j].Columns[1].Value);
                    shipping.Date = Convert.ToString(sheet.Rows[j].Columns[2].Value);
                    shipping.Trucks = Convert.ToInt32(sheet.Rows[j].Columns[3].Value);
                    shipping.Weight = Convert.ToInt32(sheet.Rows[j].Columns[4].Value);
                    shipping.Pipes = Convert.ToInt32(sheet.Rows[j].Columns[5].Value);

                    shippings.Add(shipping);

                    j++;
                }
            }
            workbook.Close(false, Type.Missing, Type.Missing);
            excelapp.Quit();
            return shippings;
        }
        public List<Registry> LoadFromExcelRegistry()
        {
            List<Registry> registries = new List<Registry>();
            string path = Application.StartupPath.ToString() + @"\" + "saveFromTelegram.xlsx";
            ExcelFile.Application excelapp = new ExcelFile.Application();
            ExcelFile.Workbook workbook = excelapp.Workbooks.Open(path, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            ExcelFile.Worksheet sheet = (ExcelFile.Worksheet)workbook.Sheets[1];
            int j = 2;
            for (; ; )
            {

                Registry registry = new Registry();

                if (Convert.ToString(sheet.Rows[j].Columns[1].Value) == null)
                {
                    break;
                }
                else
                {
                    int column = CheckSheets(sheet, "registry");
                    if (column != -1)
                    {
                        throw new Exception("Заполните все поля в таблице реестр отгрузки");
                    }

                    registry.Number = Convert.ToInt32(sheet.Rows[j].Columns[1].Value);
                    registry.Date = Convert.ToString(sheet.Rows[j].Columns[2].Value);
                    registry.Diameter = Convert.ToInt32(sheet.Rows[j].Columns[3].Value);
                    registry.PipeNumber = Convert.ToInt32(sheet.Rows[j].Columns[4].Value);
                    registry.Length = Convert.ToInt32(sheet.Rows[j].Columns[5].Value);
                    registry.Thickness = Convert.ToInt32(sheet.Rows[j].Columns[6].Value);
                    registry.Weight = Convert.ToInt32(sheet.Rows[j].Columns[7].Value);

                    registries.Add(registry);

                    j++;
                }
            }
            workbook.Close(false, Type.Missing, Type.Missing);
            excelapp.Quit();
            return registries;
        }
    }
}