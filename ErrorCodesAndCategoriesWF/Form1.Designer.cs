namespace ErrorCodesAndCategoriesWF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewCategories = new System.Windows.Forms.TreeView();
            this.btnLoadTreeNodes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewCategories
            // 
            this.treeViewCategories.Location = new System.Drawing.Point(12, 12);
            this.treeViewCategories.Name = "treeViewCategories";
            this.treeViewCategories.Size = new System.Drawing.Size(574, 416);
            this.treeViewCategories.TabIndex = 0;
            // 
            // btnLoadTreeNodes
            // 
            this.btnLoadTreeNodes.Location = new System.Drawing.Point(613, 12);
            this.btnLoadTreeNodes.Name = "btnLoadTreeNodes";
            this.btnLoadTreeNodes.Size = new System.Drawing.Size(161, 46);
            this.btnLoadTreeNodes.TabIndex = 1;
            this.btnLoadTreeNodes.Text = "Загрузить категории";
            this.btnLoadTreeNodes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadTreeNodes);
            this.Controls.Add(this.treeViewCategories);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Категории";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCategories;
        private System.Windows.Forms.Button btnLoadTreeNodes;
    }
}

