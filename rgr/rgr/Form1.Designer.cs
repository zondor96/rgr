using System;
using System.Drawing;
using System.Windows.Forms;

namespace rgr
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Основні вкладки
        private TabControl tabControl;
        private TabPage tabLesson, tabPractice, tabResults;

        // Урок
        private TableLayoutPanel tlpLesson;
        private GroupBox grpRules, grpExamples;
        private TableLayoutPanel tableRules, tableExamples;
        private Panel pnlFooter;
        private Label lblFooter;

        // Практика
        private TableLayoutPanel tlpPractice;
        private Label lblExercise, lblScore, lblFeedback, lblTip;
        private TextBox txtAnswer;
        private ComboBox cmbDifficulty;
        private FlowLayoutPanel flpButtons;
        private Button btnSubmit, btnNext, btnFinish;

        // Результати
        private DataGridView dgvResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new TabControl();
            this.tabLesson = new TabPage();
            this.tabPractice = new TabPage();
            this.tabResults = new TabPage();

            // Урок
            this.tlpLesson = new TableLayoutPanel();
            this.grpRules = new GroupBox();
            this.tableRules = new TableLayoutPanel();
            this.grpExamples = new GroupBox();
            this.tableExamples = new TableLayoutPanel();
            this.pnlFooter = new Panel();
            this.lblFooter = new Label();

            // Практика
            this.tlpPractice = new TableLayoutPanel();
            this.lblExercise = new Label();
            this.lblScore = new Label();
            this.txtAnswer = new TextBox();
            this.cmbDifficulty = new ComboBox();
            this.flpButtons = new FlowLayoutPanel();
            this.btnSubmit = new Button();
            this.btnNext = new Button();
            this.btnFinish = new Button();
            this.lblFeedback = new Label();
            this.lblTip = new Label();

            // Результати
            this.dgvResults = new DataGridView();

            // 
            // Form1
            // 
            this.SuspendLayout();
            this.ClientSize = new Size(700, 500);
            this.Text = "Додавання й віднімання негативних чисел";
            this.Font = new Font("Segoe UI", 10F);
            this.BackColor = Color.WhiteSmoke;

            //
            // tabControl
            //
            this.tabControl.Dock = DockStyle.Fill;
            // спочатку тільки Урок і Практика
            this.tabControl.TabPages.AddRange(new[] {
                this.tabLesson,
                this.tabPractice
            });

            //
            // tabLesson
            //
            this.tabLesson.Text = "Урок";
            this.tabLesson.BackColor = Color.White;

            // tlpLesson
            this.tlpLesson.Dock = DockStyle.Fill;
            this.tlpLesson.ColumnCount = 1;
            this.tlpLesson.RowCount = 3;
            this.tlpLesson.Padding = new Padding(20);
            this.tlpLesson.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tlpLesson.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tlpLesson.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // grpRules
            this.grpRules.Text = "Правила";
            this.grpRules.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.grpRules.Dock = DockStyle.Fill;
            this.grpRules.Padding = new Padding(10);

            // tableRules
            this.tableRules.Dock = DockStyle.Fill;
            this.tableRules.ColumnCount = 3;
            this.tableRules.RowCount = 2;
            for (int i = 0; i < 3; i++) this.tableRules.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            for (int i = 0; i < 2; i++) this.tableRules.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            string[,] rules = {
                { "(-a)+(-b)=-(a+b)", "a+(-b)=a-b",     "(-a)+b=b-a"   },
                { "a-(-b)=a+b",       "(-a)-b=-(a+b)", "(-a)-(-b)=b-a" }
            };
            for (int r = 0; r < 2; r++)
                for (int c = 0; c < 3; c++)
                    this.tableRules.Controls.Add(new Label
                    {
                        Text = rules[r, c],
                        Font = new Font("Segoe UI", 12F),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(5)
                    }, c, r);

            this.grpRules.Controls.Add(this.tableRules);
            this.tlpLesson.Controls.Add(this.grpRules, 0, 0);

            // grpExamples
            this.grpExamples.Text = "Приклади";
            this.grpExamples.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.grpExamples.Dock = DockStyle.Fill;
            this.grpExamples.Padding = new Padding(10);

            // tableExamples
            this.tableExamples.Dock = DockStyle.Fill;
            this.tableExamples.ColumnCount = 3;
            this.tableExamples.RowCount = 2;
            for (int i = 0; i < 3; i++) this.tableExamples.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            for (int i = 0; i < 2; i++) this.tableExamples.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            string[] examples = {
                "(-3)+(-5) = -8",
                "7+(-2)   =  5",
                "(-4)-(-6)=  2",
                "2+(-7)   = -5",
                "(-1)+4   =  3",
                "5-(-3)   =  8"
            };
            for (int i = 0; i < examples.Length; i++)
                this.tableExamples.Controls.Add(new Label
                {
                    Text = examples[i],
                    Font = new Font("Segoe UI", 11F),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                }, i % 3, i / 3);

            this.grpExamples.Controls.Add(this.tableExamples);
            this.tlpLesson.Controls.Add(this.grpExamples, 0, 1);

            // pnlFooter
            this.pnlFooter.Dock = DockStyle.Fill;
            this.pnlFooter.Padding = new Padding(10);
            this.pnlFooter.BackColor = Color.FromArgb(245, 245, 245);

            this.lblFooter.Text = "Перейдіть на вкладку «Практика» для закріплення матеріалу.";
            this.lblFooter.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            this.lblFooter.Dock = DockStyle.Fill;
            this.lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            this.pnlFooter.Controls.Add(this.lblFooter);
            this.tlpLesson.Controls.Add(this.pnlFooter, 0, 2);

            this.tabLesson.Controls.Add(this.tlpLesson);

            //
            // tabPractice
            //
            this.tabPractice.Text = "Практика";

            this.tlpPractice.Dock = DockStyle.Fill;
            this.tlpPractice.Padding = new Padding(20);
            this.tlpPractice.ColumnCount = 2;
            this.tlpPractice.RowCount = 5;
            this.tlpPractice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            this.tlpPractice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            this.tlpPractice.RowStyles.Clear();
            for (int i = 0; i < 4; i++)
                this.tlpPractice.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tlpPractice.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // lblExercise
            this.lblExercise.AutoSize = true;
            this.lblExercise.Font = new Font("Consolas", 14F, FontStyle.Bold);
            this.lblExercise.Dock = DockStyle.Fill;
            this.lblExercise.TextAlign = ContentAlignment.MiddleLeft;

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblScore.Dock = DockStyle.Fill;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = ContentAlignment.MiddleCenter;

            // txtAnswer
            this.txtAnswer.Dock = DockStyle.Fill;
            this.txtAnswer.Width = 150;

            // cmbDifficulty
            this.cmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDifficulty.Items.AddRange(new object[] { "Легкий", "Середній", "Складний" });
            this.cmbDifficulty.SelectedIndexChanged += new EventHandler(this.cmbDifficulty_SelectedIndexChanged);
            this.cmbDifficulty.SelectedIndex = 0;
            this.cmbDifficulty.Dock = DockStyle.Fill;
            this.cmbDifficulty.Width = 120;

            // flpButtons
            this.flpButtons.FlowDirection = FlowDirection.LeftToRight;
            this.flpButtons.AutoSize = true;
            this.flpButtons.Dock = DockStyle.Left;
            this.flpButtons.Controls.AddRange(new Control[] { this.btnSubmit, this.btnNext });

            // btnSubmit
            this.btnSubmit.Text = "Перевірити";
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            // btnNext
            this.btnNext.Text = "Наступне";
            this.btnNext.AutoSize = true;
            this.btnNext.Click += new EventHandler(this.btnNext_Click);

            // btnFinish
            this.btnFinish.Text = "Завершити";
            this.btnFinish.AutoSize = true;
            this.btnFinish.Click += new EventHandler(this.btnFinish_Click);
            this.btnFinish.Anchor = AnchorStyles.Right;

            // lblFeedback
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.ForeColor = Color.DarkGreen;
            this.lblFeedback.Dock = DockStyle.Fill;
            this.lblFeedback.Margin = new Padding(0, 10, 0, 0);

            // lblTip
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblTip.ForeColor = Color.DimGray;
            this.lblTip.Dock = DockStyle.Fill;
            this.lblTip.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTip.Text = "Практикуйтесь регулярно!";

            // Додаємо до tlpPractice
            this.tlpPractice.Controls.Add(this.lblExercise, 0, 0);
            this.tlpPractice.Controls.Add(this.lblScore, 1, 0);
            this.tlpPractice.Controls.Add(this.txtAnswer, 0, 1);
            this.tlpPractice.Controls.Add(this.cmbDifficulty, 1, 1);
            this.tlpPractice.Controls.Add(this.flpButtons, 0, 2);
            this.tlpPractice.Controls.Add(this.btnFinish, 1, 2);
            this.tlpPractice.Controls.Add(this.lblFeedback, 0, 3);
            this.tlpPractice.SetColumnSpan(this.lblFeedback, 2);
            this.tlpPractice.Controls.Add(this.lblTip, 0, 4);
            this.tlpPractice.SetColumnSpan(this.lblTip, 2);

            this.tabPractice.Controls.Add(this.tlpPractice);

            //
            // tabResults
            //
            this.tabResults.Text = "Результати";
            this.dgvResults = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.dgvResults.Columns.Add("Total", "Всього");
            this.dgvResults.Columns.Add("Correct", "Правильних");
            this.dgvResults.Columns.Add("Incorrect", "Неправильних");
            this.dgvResults.Columns.Add("Difficulty", "Рівень");
            this.dgvResults.Columns.Add("Accuracy", "Точність %");
            this.tabResults.Controls.Add(this.dgvResults);

            // Додаємо тільки tabControl зараз
            this.Controls.Add(this.tabControl);
            this.ResumeLayout(false);
        }
    }
}
