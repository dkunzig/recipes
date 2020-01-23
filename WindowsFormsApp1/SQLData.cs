using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Recipes

{
    public class SQLData
    {
        SqlConnection con;
        public SQLData(string connectionString)
        {
            con = new SqlConnection(connectionString);
        }

        public DataTable GetData(string sqlcommand)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand(sqlcommand, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            da.Dispose();
            con.Close();
            return dt;
        }
        public DataTable GetIngredientsFromRecipeID(long recipeID)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("select * from recipeingredients where recipeid = " + recipeID , con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            da.Dispose();
            con.Close();
            return dt;

        }

        public string GetRecipeNameFromRecipeID(long recipeID)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("select recipename from recipes where recipeid = " + recipeID, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            da.Dispose();
            con.Close();
            return dt.Rows[0]["RecipeName"].ToString();
        }

        public string GetCreditToFromRecipeID(long recipeID)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("select creditto from recipes where recipeid = " + recipeID, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            da.Dispose();
            con.Close();
            return dt.Rows[0]["CreditTo"].ToString();
        }

        public string GetInstructionsFromRecipeID(long recipeID)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("select instructions from recipes where recipeid = " + recipeID, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            da.Dispose();
            con.Close();
            return dt.Rows[0]["instructions"].ToString();
        }

        public decimal InsertRecipeName(string recipeName,string instructions,string creditTo)
        {
            SqlCommand command = new SqlCommand("insert into recipes(recipename,instructions,creditto) " +
                " values('" + recipeName + "','" + instructions + "','" + creditTo + "')", con);
            decimal id = 0;
            con.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred inserting recipe : {0}", ex.Message));
                id = -1;
            }
            command = new SqlCommand("select top 1 @@IDENTITY from recipes", con);
            try
            {
                if (id > -1)
                {
                    id = (decimal) command.ExecuteScalar();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred returning ID : {0}", ex.Message));
                id = -1;
            }
            con.Close();
            return id;
        }

        public decimal InsertIngedients(string recipeName,decimal recipeID,string[] ingredients)
        {
            //SqlCommand command = new SqlCommand("insert into recipes(recipename) values('" + recipeName + "')", con);
            decimal id = 0;
            con.Open();
            foreach (string st in ingredients)
            {
                try
                {
                    SqlCommand command = new SqlCommand("insert into RecipeIngredients(ingredient,recipeID) values('" + st + "','" + recipeID + "')", con);
                    command.ExecuteNonQuery();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(string.Format("An error occurred inserting recipe : {0}", ex.Message));
                    id = -1;
                    break;
                }
            }
            con.Close();
            return id;
        }

        public bool UpdateRecipeName(string recipeName, string instructions, string creditTo,long recipeID)
        {
            string query = "update recipes set recipename = '" + recipeName + "',instructions = '" + instructions +
                "',creditto = '" + creditTo + "' where recipeID = " + recipeID;
            SqlCommand command = new SqlCommand(query,con);
            bool ret = true;
            con.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred inserting recipe : {0}", ex.Message));
                ret = false;
            }          
            con.Close();
            return ret;
        }

        public decimal UpdateIngedients(string recipeName, decimal recipeID, string[] ingredients)
        {
            //SqlCommand command = new SqlCommand("insert into recipes(recipename) values('" + recipeName + "')", con);
            decimal id = 0;
            bool ret = true;
            con.Open();
            SqlCommand command = new SqlCommand("delete from recipeingredients where recipeid = " + recipeID, con);
            try
            {
                    command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred while updating Ingredients try again: {0}", ex.Message));
                ret = false;
            }
            if (ret)
            {
                foreach (string st in ingredients)
                {
                    try
                    {
                        command = new SqlCommand("insert into RecipeIngredients(ingredient,recipeID) values('" + st + "','" + recipeID + "')", con);
                        command.ExecuteNonQuery();
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show(string.Format("An error occurred inserting recipe : {0}", ex.Message));
                        id = -1;
                        break;
                    }
                }
            }
            con.Close();
            return id;
        }





        public bool DeleteThisRecipe(long recipeID)
        {
            bool ret = true;
            SqlCommand command = new SqlCommand("delete from recipes where recipeid = " + recipeID, con);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred deleting recipe : {0}", ex.Message));
                ret = false;
            }
            command = new SqlCommand("delete from recipeingredients where recipeid = " + recipeID, con);
            try
            {
                if(ret)
                    command.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred deleting Ingredients: {0}", ex.Message));
                ret = false;
            }
            con.Close();
            return ret;
        }
    }
}
