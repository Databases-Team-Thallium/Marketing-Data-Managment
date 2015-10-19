namespace MarketingDataManagment.ConsoleClient
{
    using System;

    using Tasks;

    public class Startup
    {
        //TODO: Add ability to Dispose databases data ?
        //TODO: Where you check if record exists, instead of .All() implement Find()
        //TODO: In IDataWriters and IDataReaders check for file extension, if its invalid replace it with valid
        //TODO: Add DeleteAll to IGenericRepository
        //TODO: In the IDataReaders pass db.SaveChanges as delegate
        //TODO: Add try catch to the commands so exceptions thrown by inner libraries dont terminate program execution
        //TODO: Refactor the switch cases below with command pattern and simple factory

        public static void Main()
        {
            string taskResult = string.Empty;

            while(true)
            {
                Console.Clear();

                ShowMenu();

                if (string.IsNullOrEmpty(taskResult) == false)
                {
                    Console.WriteLine(taskResult);
                }

                int taskIndex = int.Parse(Console.ReadLine());

                taskResult = ExecuteTask(taskIndex);
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("1 - Seed MongoDB products catalog with data.");
            Console.WriteLine("2 - Import MongoDB products into MSSQL Store database.");
            Console.WriteLine("3 - Import zipped sales info excels into MSSQL Store database.");
            Console.WriteLine("4 - Generate pdf report with top sold products.");
            Console.WriteLine("5 - Generate json sales reports.");
        }

        private static string ExecuteTask(int taskIndex)
        {
            switch(taskIndex)
            {
                case 1: return SeedMongoDBProductsCatalog.Execute();
                case 2: return ImportMongoDBProductsToMSSQLStoreDatabase.Execute();
                case 3: return ImportZippedSalesExcelsIntoMSSQLStoreDatabase.Execute();
                case 4: return GeneratePdfReportWithTopSoldProducts.Execute();
                case 5: return GenerateJsonSalesReports.Execute();
                default: return "Wrong task index.";
            }
        }
    }
}
