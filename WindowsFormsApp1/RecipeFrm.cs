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
using System.Net;
using System.Net.Mail;

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
             // Replace sender@example.com with your "From" address. 
             // This address must be verified with Amazon SES.
             String FROM = "donkunzig@gmail.com";
             String FROMNAME = "Don Kunzig";

            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.
            String TO = emailTextBox.Text;

                // Replace smtp_username with your Amazon SES SMTP user name.
                String SMTP_USERNAME = "AKIA2QLCKE7BMRJCKAGF";

                // Replace smtp_password with your Amazon SES SMTP user name.
                String SMTP_PASSWORD = "BJwKED7vYzHWLJCHto2qNSEJn7VFWqg7pB17Ky8V9nY5?";

                // (Optional) the name of a configuration set to use for this message.
                // If you comment out this line, you also need to remove or comment out
                // the "X-SES-CONFIGURATION-SET" header below.
                //String CONFIGSET = "ConfigSet";

                // If you're using Amazon SES in a region other than US West (Oregon), 
                // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
                // endpoint in the appropriate AWS Region.
                String HOST = "email-smtp.us-east-1.amazonaws.com";

                // The port you will connect to on the Amazon SES SMTP endpoint. We
                // are choosing port 587 because we will use STARTTLS to encrypt
                // the connection.
                int PORT = 587;

                // The subject line of the email
                String SUBJECT =
                    "Recipe for " + RecipeNameTextBox.Text;

                // The body of the email
                String BODY = 
                    "Recipe name : " + RecipeNameTextBox.Text + 
                    "\n\n\n" + InstructionsTextBox.Text + "\n\n\n" +  
                     IngredientsTextBox.Text;

                // Create and build a new MailMessage object
                MailMessage message = new MailMessage();
                message.IsBodyHtml = false;
                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                message.Subject = SUBJECT;
                message.Body = BODY;
                // Comment or delete the next line if you are not using a configuration set
                //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
                {
                    // Pass SMTP credentials
                    client.Credentials =
                        new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                    // Enable SSL encryption
                    client.EnableSsl = true;

                    // Try to send the message. Show status in console.
                    try
                    {
                        //Console.WriteLine("Attempting to send email...");
                        client.Send(message);
                        MessageBox.Show("eMail Message Sent", "eMail Successful",MessageBoxButtons.OK);
                    //Console.WriteLine("Email sent!");
                }
                    catch (Exception ex)
                    {
                    MessageBox.Show("message failed", "message failed", MessageBoxButtons.OK);
                        //Console.WriteLine("Error message: " + ex.Message);
                    }
                }
            
        }
    }
}
