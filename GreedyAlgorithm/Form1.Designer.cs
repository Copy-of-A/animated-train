namespace GreedyAlgorithm
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
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dGV_Cities = new System.Windows.Forms.DataGridView();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lB_Way = new System.Windows.Forms.ListBox();
            this.dGV_Result = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Cities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Result)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(853, 449);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.Text = "Условие";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(934, 449);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dGV_Cities
            // 
            this.dGV_Cities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Cities.Location = new System.Drawing.Point(12, 12);
            this.dGV_Cities.Name = "dGV_Cities";
            this.dGV_Cities.Size = new System.Drawing.Size(524, 460);
            this.dGV_Cities.TabIndex = 2;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Location = new System.Drawing.Point(770, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(228, 23);
            this.btnAddFile.TabIndex = 3;
            this.btnAddFile.Text = "Добавить города из файла";
            this.btnAddFile.UseVisualStyleBackColor = true;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(770, 65);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(228, 20);
            this.textBoxCity.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(770, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить город";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(770, 138);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(228, 23);
            this.btnRandom.TabIndex = 6;
            this.btnRandom.Text = "Заполнить случайными расстояниями";
            this.btnRandom.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(770, 449);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lB_Way
            // 
            this.lB_Way.FormattingEnabled = true;
            this.lB_Way.Location = new System.Drawing.Point(559, 12);
            this.lB_Way.Name = "lB_Way";
            this.lB_Way.Size = new System.Drawing.Size(190, 290);
            this.lB_Way.TabIndex = 8;
            // 
            // dGV_Result
            // 
            this.dGV_Result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Result.Location = new System.Drawing.Point(559, 322);
            this.dGV_Result.Name = "dGV_Result";
            this.dGV_Result.Size = new System.Drawing.Size(190, 150);
            this.dGV_Result.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 484);
            this.Controls.Add(this.dGV_Result);
            this.Controls.Add(this.lB_Way);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.dGV_Cities);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAbout);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Cities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dGV_Cities;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox lB_Way;
        private System.Windows.Forms.DataGridView dGV_Result;
    }
}

