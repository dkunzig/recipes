using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipes
{
    public partial class RecipeMainForm : Form
    {
        DataTable dt;
        SQLData SQLConnection = new SQLData("Server= localhost\\SQLEXPRESS; Database=recipe;Trusted_Connection=True;");
        List<long> ids = new List<long>();

         public RecipeMainForm()
        {
            InitializeComponent();
            FillListBox();

        }
        void FillListBox()
        {
            ids.Clear();
            RecipelistBox.Items.Clear();
            dt = SQLConnection.GetData("select * from recipes order by recipename");
            foreach (DataRow dr in dt.Rows)
            {
                RecipelistBox.Items.Add(dr[1]);
                ids.Add((long) dr[0]);
            }
        }

        private void RecipelistBox_DoubleClick(object sender, EventArgs e)
        {
            ListBox test = (ListBox)sender; 
            RecipeFrm ef = new RecipeFrm(ids[test.SelectedIndex],SQLConnection,"Edit / Print Recipe" );
            ef.ShowDialog();
            FillListBox();
            ef.Dispose();
        }

        private void AddRecipeButton_Click(object sender, EventArgs e)
        {
            RecipeFrm ef = new RecipeFrm(SQLConnection, "Add Recipe");
            ef.ShowDialog();
            FillListBox();
            ef.Dispose();
        }
    }
    
}
