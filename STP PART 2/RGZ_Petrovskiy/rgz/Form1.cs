using System;
using System.Linq;
using System.Windows.Forms;

namespace rgz
{
    public partial class Form1 : Form
    {
        ADT_Control<TFrac, TEditor> fracController;

        const string operation_signs = "+-/*";
        string memmory_buffer = string.Empty;

        public Form1()
        {
            fracController = new ADT_Control<TFrac, TEditor>();
            InitializeComponent();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memmory_buffer = textBox1.Text;
            MessageBox.Show("Скопировано в буфер обмена - " + memmory_buffer,
                    "Информация",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void EnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (memmory_buffer == string.Empty)
            {
                MessageBox.Show("Буфер обмена пуст.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            textBox1.Text = memmory_buffer;
        }

        private static int CharToEditorCommand(char ch)
        {
            int command = 66;
            switch (ch)
            {
                case '0':
                    command = 0;
                    break;
                case '1':
                    command = 1;
                    break;
                case '2':
                    command = 2;
                    break;
                case '3':
                    command = 3;
                    break;
                case '4':
                    command = 4;
                    break;
                case '5':
                    command = 5;
                    break;
                case '6':
                    command = 6;
                    break;
                case '7':
                    command = 7;
                    break;
                case '8':
                    command = 8;
                    break;
                case '9':
                    command = 9;
                    break;
                case '.':
                    command = 10;
                    break;
                case '-':
                    command = 11;
                    break;
            }

            return command;
        }
        private static int CharToOperationsCommand<T>(char ch) where T : TFrac, new()
        {
            int command = 0;
            switch (ch)
            {
                case '+':
                    command = 1;
                    break;
                case '-':
                    command = 2;
                    break;
                case '*':
                    command = 3;
                    break;
                case '/':
                    command = 4;
                    break;
            }

            return command;
        }

        private static int KeyCodeToEditorCommand(Keys ch)
        {
            int command = 14;
            switch (ch)
            {
                case Keys.Back:
                    command = 12;
                    break;
                case Keys.Delete:
                case Keys.Escape:
                    command = 13;
                    break;
            }

            return command;
        }


        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Калькулятор простых дробей\n\nВариант 13\nТип числа - простая дробь\nПрецеденты - 1-6\nОперанды могут браться из:\n  памяти - да\n  буфера обмена - да\nИстория - нет\nНастройки - нет\n\nРазработчики: Петровский В.Е., Альхимович М.В., Заескова В.В. ИП-014", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button_Number_Edit(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag_command = Convert.ToInt32(button.Tag.ToString());
            textBox1.Text = fracController.ExecComandEditor(tag_command);
        }

        private void Button_Number_Operation(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag_command = Convert.ToInt32(button.Tag.ToString());
            textBox1.Text = fracController.ExecOperation(tag_command);
        }

        private void Button_Number_Function(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag_command = Convert.ToInt32(button.Tag.ToString());
            textBox1.Text = fracController.ExecFunction(tag_command);
        }

        private void Button_Memory(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int tag_command = Convert.ToInt32(button.Tag.ToString());
            dynamic exec = fracController.ExecCommandMemory(tag_command, textBox1.Text);
            if (tag_command == 3)
                textBox1.Text = exec.Item1.ToString();
            label1.Text = exec.Item2 == true ? "M" : string.Empty;
        }

        private void Button_Reset(object sender, EventArgs e)
        {
            textBox1.Text = fracController.Reset();
            label1.Text = string.Empty;
        }

        private void Button_Calculate(object sender, EventArgs e)
        {
            textBox1.Text = fracController.Calculate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
     
            if (e.KeyCode == Keys.Enter)
                CalculateButton.PerformClick();
            else
            {
                int command = KeyCodeToEditorCommand(e.KeyCode);
                if (command != 14)
                    textBox1.Text = fracController.ExecComandEditor(command);
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.')
                textBox1.Text = fracController.ExecComandEditor(CharToEditorCommand(e.KeyChar));
            else if (operation_signs.Contains(e.KeyChar))
                textBox1.Text = fracController.ExecOperation(CharToOperationsCommand<TFrac>(e.KeyChar));
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show($"KeyUp code: {e.KeyCode}, value: {e.KeyValue}, modifiers: {e.Modifiers}" + "\r\n");
            
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(button4, "Очистить память");
            toolTip.SetToolTip(button10, "Читать значение из памяти");
            toolTip.SetToolTip(button11, "Сохранить значение в памяти");
            toolTip.SetToolTip(button12, "Добавить к значению в памяти");
        }
    }
}
