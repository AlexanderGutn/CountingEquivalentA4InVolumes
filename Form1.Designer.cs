﻿
namespace CountingEquivalentA4InVolumes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bCalculate = new System.Windows.Forms.Button();
            this.cbShowEmpty = new System.Windows.Forms.CheckBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bCalculate
            // 
            this.bCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCalculate.Location = new System.Drawing.Point(483, 415);
            this.bCalculate.Name = "bCalculate";
            this.bCalculate.Size = new System.Drawing.Size(201, 23);
            this.bCalculate.TabIndex = 0;
            this.bCalculate.Text = "Подсчет количества листов A4";
            this.bCalculate.UseVisualStyleBackColor = true;
            this.bCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbShowEmpty
            // 
            this.cbShowEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowEmpty.AutoSize = true;
            this.cbShowEmpty.Location = new System.Drawing.Point(483, 379);
            this.cbShowEmpty.Name = "cbShowEmpty";
            this.cbShowEmpty.Size = new System.Drawing.Size(201, 30);
            this.cbShowEmpty.TabIndex = 1;
            this.cbShowEmpty.Text = "Выводить листы с незаполенным \r\nполем Заголовок1";
            this.cbShowEmpty.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(455, 426);
            this.dataGridView.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.cbShowEmpty);
            this.Controls.Add(this.bCalculate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Посчитать число листов А4 в томах";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCalculate;
        private System.Windows.Forms.CheckBox cbShowEmpty;
        public System.Windows.Forms.DataGridView dataGridView;
    }
}

