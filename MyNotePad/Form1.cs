using System.Drawing.Printing;
using System.Windows.Forms;

namespace MyNotePad
{
    public partial class Form1 : Form
    {
        private string docName = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Unsave document";
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 || string.IsNullOrEmpty(docName))
            {
                DialogResult result = MessageBox.Show("Do you want to save current file ?", "Save File", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)

                    return;

                else if (result == DialogResult.Yes) ;

                // activate save option

            }
            docName = string.Empty;
            textBox1.Text = string.Empty;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shutting Down");
            Application.Exit();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = @"S:\";
            openFileDialog1.Filter = "Text File(*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                docName = openFileDialog1.FileName;
                this.Text = docName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(docName))
                // if file is not already saved then show save dialog and save under user saved
                saveAsToolStripMenuItem_Click(sender, e);
            else
                File.WriteAllText(docName, textBox1.Text);

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Document(*.txt)|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "new doc";
            saveFileDialog1.InitialDirectory = @"S:\";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                docName = saveFileDialog1.FileName;
                this.Text = docName;
                File.WriteAllText(docName, textBox1.Text);
            }
            else
            {
                return;
            }
;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;

            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.ForeColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                textBox1.ForeColor = colorDialog1.Color;
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
                textBox1.BackColor = colorDialog1.Color;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show print dialog
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                // Create PrintDocument
                PrintDocument printDocument = new PrintDocument();

                // Set printDocument to printDialog
                printDialog1.Document = printDocument;

                // Set event handler for printing
                printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

                // Start printing
                printDocument.Print();
            }
        }

        // Event handler for printing
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Get text to print
            string textToPrint = textBox1.Text;

            // Set up print font
            Font printFont = textBox1.Font;

            // Set up print area
            RectangleF printArea = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);

            // Draw text to print
            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, printArea);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size + 2);


        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font.FontFamily, textBox1.Font.Size - 2);

        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the font size back to the default value
            textBox1.Font = new Font(textBox1.Font.FontFamily, 8); // Assuming 8 is the default font size
        }

    }
}
