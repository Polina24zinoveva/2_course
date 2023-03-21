namespace LR__automats_
{
    //repeat a[i] := b + c until d;
    //repeat a1[i] := bnd + ciiii until d1g6gh;
    //repeat a[i] := b until (g <= 6) xor ( t <> 8);
    //repeat a[i] := b[u] until (g <= 6) xor ( t <> 8);

    public partial class Form1 : Form
    {
        private string str;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void analizButton_Click(object sender, EventArgs e)
        {
            str = vvodTextBox.Text;
            //analizButton.Enabled = false;
            //vvodTextBox.Enabled = false;
            errorLabel.Visible = true;
            try
            {
                string resultParse = RepeatAnalizator.Main(str);
                errorLabel.Text = resultParse;
                if (resultParse == "Строка правильная!")
                {
                    semantikaButton.Enabled = true;
                }
            }
            catch (ExceptionWithPosition err)
            {
                repeatButton.Visible = true;
                errorLabel.Text = err.Message;
                vvodTextBox.Focus();
                vvodTextBox.SelectionStart = err.Position;
                vvodTextBox.SelectionLength = 1;

            }
            catch (Exception err)
            {
                errorLabel.Text = err.Message;
            }

            
        }

        
        private void repeatButton_Click(object sender, EventArgs e)
        {
            str = vvodTextBox.Text;
            //analizButton.Enabled = true;
            try
            {
                string resultParse = RepeatAnalizator.Main(str);
                errorLabel.Text = resultParse;
                if (resultParse == "Строка правильная!")
                {
                    semantikaButton.Enabled = true;
                }
            }
            catch (ExceptionWithPosition err)
            {
                repeatButton.Visible = true;
                errorLabel.Text = err.Message;
                vvodTextBox.Focus();
                vvodTextBox.SelectionStart = err.Position;
                vvodTextBox.SelectionLength = 1;

            }
            catch (Exception err)
            {
                errorLabel.Text = err.Message;
            }
        }

        

        private void semantikaButton_Click(object sender, EventArgs e)
        {
            analizButton.Enabled = false;
            repeatButton.Visible = false;
            str = vvodTextBox.Text;
            try
            {
                var result = RepeatAnalizatorSemantica.Main(str);
                string resultString = (result.Item3);
                if (resultString == "Строка правильная!")
                {
                    var listIdentificatorss = (result.Item1);
                    var listConst = (result.Item2);
                    semantikaButton.Enabled = true;
                    spisokIdentTextBox.Text = "Список идентификаторов:" + Environment.NewLine;
                    spisokIdentTextBox.Text = "Значение" + "\t" + "Вид" + Environment.NewLine;
                    for (int a = 0; a < listIdentificatorss.Count; a++)
                    {
                        //spisokIdentTextBox.Text += a + 1 + ". ";
                        for (int b = 0; b < listIdentificatorss[a].Count; b++)
                        {
                            spisokIdentTextBox.Text += listIdentificatorss[a][b] + "\t";
                        }
                        spisokIdentTextBox.Text += Environment.NewLine;
                    }
                    
                    spisokConstTextBox.Text = "Список констант:" + Environment.NewLine;
                    spisokConstTextBox.Text = "Значение" + "\t" + "Вид" + "\t" + "Тип" + Environment.NewLine;
                    for (int a = 0; a < listConst.Count; a++)
                    {
                        for (int b = 0; b < listConst[a].Count; b++)
                        {
                            spisokConstTextBox.Text += listConst[a][b] + "\t";
                        }
                        spisokConstTextBox.Text += Environment.NewLine;
                    }
                    errorLabel.Text = resultString;
                    spisokIdentTextBox.Visible = true;
                    spisokConstTextBox.Visible = true;
                }
            }
            catch (ExceptionWithPosition err)
            {
                errorLabel.Text = err.Message;
                vvodTextBox.Focus();
                vvodTextBox.SelectionStart = err.Position;
                vvodTextBox.SelectionLength = 1;
                spisokIdentTextBox.Visible = false;
                spisokConstTextBox.Visible = false;
            }
            catch (Exception err)
            {
                errorLabel.Text = err.Message;
            }
        }
    }
}