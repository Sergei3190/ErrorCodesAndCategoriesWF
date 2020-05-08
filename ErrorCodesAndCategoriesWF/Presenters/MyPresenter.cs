using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorCodesAndCategoriesWF.Models;
using ErrorCodesAndCategoriesWF.Domains;
using System.Windows.Forms;
using ErrorCodesAndCategoriesWF.Views;
using System.Threading;

namespace ErrorCodesAndCategoriesWF.Presenters
{
    public class MyPresenter
    {
        NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IModel model;
        private readonly IDomain domain;
        private readonly IView view;

        public MyPresenter(IView _view, IModel _model, IDomain _domain)
        {
            Logger.Debug("Создание экземпляра класса MyPresenter");
            model = _model;
            domain = _domain;
            view = _view;
        }

        public void ActivateTasks()
        {
            Logger.Debug("Синхронная активация задач");
            model.ExecuteTasksAsync();
        }

        public void LoadCategories()
        {
            try
            {
                var categories = model.Categories;
                var treeNodes = domain.GetTreeNodes(categories);
                Logger.Debug("Получение списка узлов дерева категорий и заполнение его в treeView");
                view.SetTreeNodes(treeNodes);
            }
            catch (Exception ex)
            {
                Logger.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
