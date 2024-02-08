namespace ADOLAB1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 426);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 445);
            button1.Name = "button1";
            button1.Size = new Size(776, 23);
            button1.TabIndex = 1;
            button1.Text = "Инициализация.";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 474);
            button2.Name = "button2";
            button2.Size = new Size(776, 23);
            button2.TabIndex = 2;
            button2.Tag = "A";
            button2.Text = "Нажмите чтобы добавить информацию о сотруднике";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 503);
            button3.Name = "button3";
            button3.Size = new Size(776, 23);
            button3.TabIndex = 3;
            button3.Tag = "B";
            button3.Text = "Нажмите  чтобы запросить рабочий № и имя сотрудника с указанной суммой зарплаты";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 532);
            button4.Name = "button4";
            button4.Size = new Size(776, 23);
            button4.TabIndex = 4;
            button4.Tag = "C";
            button4.Text = "Нажмите чтобы чтобы запросить имена и номера должностей сотрудников, с посещаемостью x";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button2_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 562);
            button5.Name = "button5";
            button5.Size = new Size(776, 23);
            button5.TabIndex = 5;
            button5.Tag = "D";
            button5.Text = "Нажмите чтобы запросить данные о сотрудниках с посещаемостью k и зарплатой менее r";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 597);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}