using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EASendMail;
namespace Recipes

{
    public partial class RecipeFrm : Form
    {
        long recipeID;
        SQLData sqldata;
        private System.Windows.Forms.Button printButton;
        private Font printFont;

        public RecipeFrm(long recipeID_, SQLData sqldata_,string newChange)
        {
            recipeID = recipeID_;
            sqldata = sqldata_;
            InitializeComponent();
            DataTable dtIngredients = sqldata.GetIngredientsFromRecipeID(recipeID);
            string instructions = sqldata.GetInstructionsFromRecipeID(recipeID);
            CreditToTextBox.Text = sqldata.GetCreditToFromRecipeID(recipeID);
            FillIngredients(dtIngredients);
            FillInstructions(instructions);
            RecipeNameTextBox.Text = sqldata.GetRecipeNameFromRecipeID(recipeID);
            this.Text = newChange;
        }
        public RecipeFrm(SQLData sqldata_, string newChange)
        {
            sqldata = sqldata_;
            recipeID = -1; //-1 indicates this is a new recipe
            InitializeComponent();
            this.Text = newChange;
        }

        private void FillIngredients(DataTable dt)
        {
            foreach(DataRow dr in dt.Rows)
            {
                IngredientsTextBox.Text += dr["ingredient"].ToString() + Environment.NewLine; 
            }
        }

        private void FillInstructions(string instructions)
        {
            string[] instruct = instructions.Split('.');
            foreach(string st in instruct)
            {
                InstructionsTextBox.Text += st + Environment.NewLine;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    pd.Print();
                }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            // Print each line of the file.
            string[] ingredients = IngredientsTextBox.Text.Split('\n');
            string[] instructions = InstructionsTextBox.Text.Split('\n');
            string name = RecipeNameTextBox.Text;
            string creditto = CreditToTextBox.Text;
            List<string> printstring = new List<string>();
            printstring.Add(name);
            printstring.Add(Environment.NewLine);
            foreach (string st in instructions)
            {
                printstring.Add(st);
            }
            foreach (string st in ingredients)
            {
                printstring.Add(st);
            }
            
            printstring.Add(creditto);

            printString(printstring,ev);
            // If more lines exist, print another page.
            ev.HasMorePages = false;
        }

        private void printString(List<string>  str, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);
            foreach (string st in str)
            {
                if(count == 0)
                    printFont = new Font("Arial", 20,FontStyle.Bold);
                else
                    printFont = new Font("Arial", 10);
                line = st;
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool success = true;
            if(recipeID > -1)
            { 
                UpdateRecipe();
                return;
            }
            if(success)
            {
                SaveNewRecipe();
            }
        }

        private void SaveNewRecipe()
        {
            string[] ingedients = IngredientsTextBox.Text.Split('\n');
            string instructions = InstructionsTextBox.Text;
            string creditTo = CreditToTextBox.Text;
            string recipeName = RecipeNameTextBox.Text;
            decimal recipeKey = sqldata.InsertRecipeName(recipeName,instructions,creditTo);
            sqldata.InsertIngedients(recipeName, recipeKey, ingedients);
        }

        private void UpdateRecipe()
        {
            string[] ingedients = IngredientsTextBox.Text.Split('\n');
            string instructions = InstructionsTextBox.Text;
            string creditTo = CreditToTextBox.Text;
            string recipeName = RecipeNameTextBox.Text;
            if (sqldata.UpdateRecipeName(recipeName, instructions, creditTo, recipeID))
               sqldata.UpdateIngedients(recipeName, recipeID, ingedients);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void eMailButton_Click(object sender, EventArgs e)
        {
            if (!emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("You need to enter an eMail address below", "Improper eMail address", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = "donkunzig@gmail.com";
                // Set recipient email address
                oMail.To = "donkunzig@gmail.com";

                // Set email subject
                oMail.Subject = "test email from gmail account";
                // Set email body
                oMail.TextBody = "this is a test email sent from c# project with gmail.";

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "donkunzig@gmail.com";
                oServer.Password = "64533456Aa?";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                MessageBox.Show("email was sent successfully!");
            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message,"email was sent successfully!");
                Console.WriteLine(ep.Message);
            }
        }

    }
    }

