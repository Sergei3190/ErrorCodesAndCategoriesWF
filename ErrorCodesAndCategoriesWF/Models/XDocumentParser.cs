using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ErrorCodesAndCategoriesWF.Models
{
    public class XDocumentParser
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public void GetErrorCodes(string responseUrl)
        {
            Logger.Debug("Обработка результата запроса https://pastebin.com/raw/JK7WiMax");
            var command = new SqlCommands();
            XDocument xDocument = XDocument.Parse(responseUrl);
            foreach (var item in xDocument.Element("ErrorCodes").Elements("ErrorCode"))
            {
                var code = item.Attribute("code");
                var text = item.Attribute("text");
                command.AddErrorCodes(Convert.ToInt32(code.Value), text.Value.ToString());
            }
        }

        public List<Category> GetCategories(string responseUrl)
        {
            Logger.Debug("Обработка результата запроса https://pastebin.com/raw/0RpLbQ19 создание списка категорий для построяния treeView");
            var command = new SqlCommands();
            var categories = new List<Category>();
            XDocument xDocument1 = XDocument.Parse(responseUrl);
            foreach (var item in xDocument1.Element("Categories").Elements("category"))
            {
                var id = item.Attribute("id");
                var name = item.Attribute("name");
                var parent = item.Attribute("parent");
                var image = item.Attribute("image");
                categories.Add(new Category
                {
                    ID = Convert.ToInt32(id.Value),
                    Name = name.Value.ToString(),
                    Parent = Convert.ToInt32(parent.Value)
                });
                command.AddCategories(Convert.ToInt32(id.Value), name.Value.ToString(),
                                      Convert.ToInt32(parent.Value), image.Value.ToString());
            }
            return categories;
        }
    }
}
