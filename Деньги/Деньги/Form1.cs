using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Деньги
{
    public partial class Form1 : Form
    {
        Investor inv1 = new Investor();
        RateCalculator rc = new RateCalculator();
        sql data = new sql();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            data.fillInvestors();
            data.showBasket(obligationsText,stocksText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            rc.outputRate(obligationsRateGrowth, stocksRateGrowth,riskTakingBox);
        }
    }

    public class Investor
    {
        public string name;
        public int riskTaking;
        public int obligations = 0;
        public int stocks = 0;
        Random rnd = new Random();
        public Investor()
        {
            name = "John";
            riskTaking = rnd.Next(0, 100);
        }

        public void buyFinancialInstruments(int amount)
        {
            for (int i = 0;i < amount;i++)
            {
                int number = (riskTaking * rnd.Next(0, 100));
                if (number > 2500)
                {
                    stocks++;
                }
                else 
                {
                    obligations++;
                }
            }
        }
        

    }
    public class RateCalculator
    {
        double expectedRiskTaking = 1;
        double actualRiskTaking = 1;
        sql q = new sql();
        double invObl;
        double invSt;
        
        public RateCalculator()
        {
            expectedRiskTaking = 0.95;
            actualRiskTaking = 0;
            invObl = q.obligationsSum();
            invSt = q.stocksSum();
        }
        
        public void outputRate(Label obligations,Label stocks,TextBox textBox)
        {
            invObl = q.obligationsSum();
            invSt = q.stocksSum();
            if (textBox.Text != "")
            { 
                expectedRiskTaking = double.Parse(textBox.Text); 
            }
            Console.WriteLine(expectedRiskTaking);
            double rate = invObl / invSt;
            
            actualRiskTaking = (rate+expectedRiskTaking)/2;
            
            if (actualRiskTaking > 1)
            {
                double obligationRate = (actualRiskTaking - 1)*100;
                double stocksRate = (1 - actualRiskTaking) *100;
                stocks.Text = "↓" + " " + Math.Abs(stocksRate).ToString() + "%";
                stocks.ForeColor = Color.Red;
                obligations.Text = "↑" + " " + Math.Abs(obligationRate).ToString() + "%";
                obligations.ForeColor = Color.Green;
            }
            else 
            {
                double obligationRate = (1 - actualRiskTaking) *100;
                double stocksRate = (actualRiskTaking - 1)*100;
                stocks.Text = "↑" + " " + Math.Abs(stocksRate).ToString() + "%";
                stocks.ForeColor = Color.Green;
                obligations.Text = "↓" + " " + Math.Abs(obligationRate).ToString() + " %";
                obligations.ForeColor = Color.Red;
            }
        }
        

    }
    public class sql
    {
        static string connectionString = @"Server = localhost; Database = Investors;Integrated Security = SSPI; ";
        
        
        public void fillInvestors()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                for (int i = 0; i < 100; i++)
                {
                    Investor newinvestor = new Investor();
                    newinvestor.buyFinancialInstruments(5);
                    SqlCommand command = new SqlCommand($"INSERT INTO Investor (id,name,risktaking,obligations,stocks) VALUES ({i},'{newinvestor.name}', {newinvestor.riskTaking}, {newinvestor.obligations}, {newinvestor.stocks})", connection);
                    int number = command.ExecuteNonQuery();
                }
                
                
                
            }
        }
        public int obligationsSum()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand($"SELECT SUM(obligations) FROM Investor", connection);
                int suma = (int)command.ExecuteScalar();



                return suma;
            }
            
        }
        public int stocksSum()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT SUM(stocks) FROM Investor", connection);
                int suma = (int)command.ExecuteScalar();



                return suma;
            }

        }
        public void showBasket(Label label1, Label label2)
        {
            sql s = new sql();
            label1.Text = "Облигации: " + s.obligationsSum();
            label2.Text = "Акции: " + s.stocksSum();

        }
    }
}
