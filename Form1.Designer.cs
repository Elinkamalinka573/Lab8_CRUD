namespace Lab8_CRUD
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
            dataGridViewStudents = new DataGridView();
            labelName = new Label();
            labelAge = new Label();
            labelGroup = new Label();
            labelGrade = new Label();
            labelStatus = new Label();
            textBoxName = new TextBox();
            numericAge = new NumericUpDown();
            textBoxGroup = new TextBox();
            numericGrade = new NumericUpDown();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            buttonExport = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(317, 12);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.Size = new Size(383, 187);
            dataGridViewStudents.TabIndex = 0;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(89, 238);
            labelName.Name = "labelName";
            labelName.Size = new Size(37, 15);
            labelName.TabIndex = 1;
            labelName.Text = "ФИО:";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.Location = new Point(89, 283);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(53, 15);
            labelAge.TabIndex = 2;
            labelAge.Text = "Возраст:";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(89, 327);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(49, 15);
            labelGroup.TabIndex = 3;
            labelGroup.Text = "Группа:";
            // 
            // labelGrade
            // 
            labelGrade.AutoSize = true;
            labelGrade.Location = new Point(89, 367);
            labelGrade.Name = "labelGrade";
            labelGrade.Size = new Size(88, 15);
            labelGrade.TabIndex = 4;
            labelGrade.Text = "Средний балл:";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(164, 433);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(45, 15);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Готово";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(188, 235);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 6;
            textBoxName.TextChanged += textBoxName_TextChanged;
            // 
            // numericAge
            // 
            numericAge.Location = new Point(188, 281);
            numericAge.Name = "numericAge";
            numericAge.Size = new Size(120, 23);
            numericAge.TabIndex = 7;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(188, 319);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(100, 23);
            textBoxGroup.TabIndex = 8;
            // 
            // numericGrade
            // 
            numericGrade.Location = new Point(188, 359);
            numericGrade.Name = "numericGrade";
            numericGrade.Size = new Size(120, 23);
            numericGrade.TabIndex = 9;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(369, 231);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(80, 29);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(369, 266);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(80, 27);
            buttonUpdate.TabIndex = 11;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(369, 299);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(80, 26);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(369, 331);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(80, 25);
            buttonClear.TabIndex = 13;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(543, 265);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(106, 23);
            buttonExport.TabIndex = 14;
            buttonExport.Text = "Экспорт в CSV";
            buttonExport.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(544, 310);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(77, 24);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(buttonCancel);
            Controls.Add(buttonExport);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(numericGrade);
            Controls.Add(textBoxGroup);
            Controls.Add(numericAge);
            Controls.Add(textBoxName);
            Controls.Add(labelStatus);
            Controls.Add(labelGrade);
            Controls.Add(labelGroup);
            Controls.Add(labelAge);
            Controls.Add(labelName);
            Controls.Add(dataGridViewStudents);
            Name = "Form1";
            Text = "Лабораторная работа №8 - CRUD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGrade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStudents;
        private Label labelName;
        private Label labelAge;
        private Label labelGroup;
        private Label labelGrade;
        private Label labelStatus;
        private TextBox textBoxName;
        private NumericUpDown numericAge;
        private TextBox textBoxGroup;
        private NumericUpDown numericGrade;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
        private Button buttonExport;
        private Button buttonCancel;
    }
}
