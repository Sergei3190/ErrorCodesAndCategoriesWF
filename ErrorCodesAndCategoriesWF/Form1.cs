using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorCodesAndCategoriesWF.Presenters;
using ErrorCodesAndCategoriesWF.Views;
using ErrorCodesAndCategoriesWF.Models;
using ErrorCodesAndCategoriesWF.Domains;

namespace ErrorCodesAndCategoriesWF
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
            MyPresenter myPresenter = new MyPresenter(this, new MyTasks(), new MyTreeNodes());
            myPresenter.ActivateTasks();
            btnLoadTreeNodes.Click += delegate
            {
                myPresenter.LoadCategories();
            };
        }

        void IView.SetTreeNodes(SortedSet<TreeNode> treeNodes)
        {
            treeViewCategories.Nodes.Clear();
            foreach (var item in treeNodes)
            {
                treeViewCategories.Nodes.Add(item);
            }
        }
    }
}
