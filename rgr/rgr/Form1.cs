using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace rgr
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private int[] numbers, ops;
        private int difficulty = 1, streak = 0, totalCount = 0, correctCount = 0;

        public Form1()
        {
            InitializeComponent();

            // Обмежуємо вводити тільки цифри та мінус першого символу
            txtAnswer.KeyPress += TxtAnswer_KeyPress;

            GenerateExercise();
        }

        private void TxtAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            printing(e, txtAnswer, btnSubmit);
        }

        /// <summary>
        /// Дозволяє цифри, мінус лише на початку, Enter – фокус на кнопку.
        /// </summary>
        private static void printing(KeyPressEventArgs e, TextBox textBox, Button nextButton)
        {
            char key = e.KeyChar;
            if (char.IsControl(key))
            {
                if (key == (char)Keys.Enter)
                    nextButton.Focus();
                return;
            }
            if (key == '-')
            {
                if (textBox.SelectionStart == 0 && !textBox.Text.Contains("-"))
                    return;
                e.Handled = true;
                return;
            }
            if (char.IsDigit(key))
                return;
            e.Handled = true;
        }

        private void cmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            difficulty = cmbDifficulty.SelectedIndex + 1;
            ResetSession();
            GenerateExercise();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;

            if (!int.TryParse(txtAnswer.Text, out int ans))
            {
                lblFeedback.ForeColor = Color.Red;
                lblFeedback.Text = "Введіть ціле число.";
                return;
            }

            totalCount++;
            int correct = ComputeCorrect();

            if (ans == correct)
            {
                correctCount++;
                streak++;
                lblScore.Text = streak.ToString();
                lblFeedback.ForeColor = Color.DarkGreen;
                lblFeedback.Text = streak >= 25 ? "Неймовірно!"
                                     : streak >= 20 ? "Фантастика!"
                                     : streak >= 15 ? "Чудово!"
                                     : streak >= 10 ? "Відмінно!"
                                     : streak >= 5 ? "Молодець!"
                                                    : "Правильно!";
            }
            else
            {
                streak = 0;
                lblScore.Text = "0";
                lblFeedback.ForeColor = Color.Red;
                lblFeedback.Text = $"Неправильно, має бути {correct}. Рахунок обнулено.";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            lblFeedback.Text = "";
            txtAnswer.Text = "";
            GenerateExercise();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            // Додаємо tabResults лише раз
            if (!tabControl.TabPages.Contains(tabResults))
                tabControl.TabPages.Add(tabResults);

            int incorrect = totalCount - correctCount;
            double accuracy = totalCount > 0
                ? 100.0 * correctCount / totalCount
                : 0.0;

            dgvResults.Rows.Add(
                totalCount,
                correctCount,
                incorrect,
                cmbDifficulty.SelectedItem.ToString(),  // поточний рівень
                accuracy.ToString("F1")
            );

            ResetSession();
        }

        private void ResetSession()
        {
            totalCount = 0;
            correctCount = 0;
            streak = 0;
            lblScore.Text = "0";
            lblFeedback.Text = "";
            txtAnswer.Text = "";
            btnSubmit.Enabled = true;
        }

        private void GenerateExercise()
        {
            int max = difficulty == 1 ? 5 : difficulty == 2 ? 10 : 20;
            int count = difficulty + 1;

            numbers = new int[count];
            if (difficulty == 1)
            {
                do
                {
                    numbers[0] = rnd.Next(-max, max + 1);
                    numbers[1] = rnd.Next(-max, max + 1);
                } while (numbers[0] == 0 || numbers[1] == 0);
            }
            else
            {
                for (int i = 0; i < count; i++)
                    numbers[i] = rnd.Next(-max, max + 1);
            }

            ops = new int[count - 1];
            for (int i = 0; i < ops.Length; i++)
                ops[i] = rnd.Next(2);

            var sb = new StringBuilder();
            sb.Append(numbers[0]);
            for (int i = 1; i < count; i++)
                sb.Append(ops[i - 1] == 0 ? " + " : " - ")
                  .Append(numbers[i]);
            sb.Append(" = ");
            lblExercise.Text = sb.ToString();
        }

        private int ComputeCorrect()
        {
            int res = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                res = ops[i - 1] == 0 ? res + numbers[i] : res - numbers[i];
            return res;
        }
    }
}
