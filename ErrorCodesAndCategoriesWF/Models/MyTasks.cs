using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ErrorCodesAndCategoriesWF.Presenters;
using System.Threading;
using System.Windows.Forms;

namespace ErrorCodesAndCategoriesWF.Models
{
    public class MyTasks : IModel
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private MyHttpClient client = new MyHttpClient();
        public List<Category> Categories { get; set; }

        public async Task ExecuteTasksAsync()
        {
            Task allTasks = null;

            try
            {
                Task getCategories = GetSetCategoriesAsync();
                Task getErrorCodes = GetSetErrorCodesAsync();
                Task getTextFile = JsonConvertedAsync();
                allTasks = Task.WhenAll(new Task[] { getCategories, getErrorCodes, getTextFile });
                await allTasks;
            }
            catch (Exception)
            {
                foreach (var item in allTasks.Exception.InnerExceptions)
                {
                    Logger.Error($"{item.Message}\n{item.StackTrace}");
                }
            }
        }

        private async Task JsonConvertedAsync()
        {
            using (StreamReader sr = new StreamReader("Users.json"))
            {
                Logger.Debug($"Считывание и обработка данных из файла \"Users.json\"");
                var jsonString = await sr.ReadToEndAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(jsonString);
                var countPeoples = (users).Count();
                var minDate = users.Min(u => u.CreatedAt);
                var maxDate = users.Max(u => u.CreatedAt);
                var addInfo = string.Format("${0}|{1}@{2}", countPeoples, minDate.UtcDateTime, maxDate.UtcDateTime);
                StringBuilder stringBuilder = new StringBuilder(jsonString);
                for (int i = 0; i < stringBuilder.Length; i++)
                {
                    stringBuilder.Replace(',', ';');
                }
                stringBuilder.AppendLine();
                stringBuilder.Append(addInfo);
                var result = stringBuilder.ToString();

                using (StreamWriter sw = new StreamWriter("UserConverted.txt"))
                {
                    await sw.WriteLineAsync(result);
                    Logger.Debug($"Создание файла \"UserConverted.txt\"");
                }
            }
        }

        public async Task GetSetCategoriesAsync()
        {
            var xDocParser = new XDocumentParser();
            Logger.Debug("Отправка запроса на https://pastebin.com/raw/0RpLbQ19");
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://pastebin.com/raw/0RpLbQ19");
            httpResponseMessage.EnsureSuccessStatusCode();
            var res = await httpResponseMessage.Content.ReadAsStringAsync();
            Logger.Debug($"Получение ответа на запрос https://pastebin.com/raw/0RpLbQ19, \nРезультат - список категорий:\n{res}");
            Categories = xDocParser.GetCategories(res);
        }

        private async Task GetSetErrorCodesAsync()
        {
            var xDocParser = new XDocumentParser();
            Logger.Debug("Отправка запроса на https://pastebin.com/raw/JK7WiMax");
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://pastebin.com/raw/JK7WiMax");
            httpResponseMessage.EnsureSuccessStatusCode();
            var res = await httpResponseMessage.Content.ReadAsStringAsync();
            Logger.Debug("Получение ответа на запрос https://pastebin.com/raw/JK7WiMax, \nРезультат - список кодов ошибок:\n{res}");
            xDocParser.GetErrorCodes(res);
        }
    }
}
