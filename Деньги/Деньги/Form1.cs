using System;
using System.Drawing;
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
            rc.outputBefore(oblBefore, stocksBefore);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            rc.outputRate(obligationsRateGrowth, stocksRateGrowth,riskTakingBox);
        }

        private void label3_Click(object sender, EventArgs e)
        {

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
            name = "Investor";
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
            expectedRiskTaking = 1;
            actualRiskTaking = 0;
            invObl = q.obligationsSum();
            invSt = q.stocksSum();
        }
        public void outputBefore(Label oblBefore, Label stocksBefore)
        {
            actualRiskTaking = invObl / invSt;
            if (actualRiskTaking > 1)
            {
                double obligationRate = (actualRiskTaking - 1) * 50;
                double stocksRate = (1 - actualRiskTaking) * 50;
                stocksBefore.Text = "↓" + " " + Math.Abs(stocksRate).ToString() + "%";
                stocksBefore.ForeColor = Color.Red;
                oblBefore.Text = "↑" + " " + Math.Abs(obligationRate).ToString() + "%";
                oblBefore.ForeColor = Color.Green;
            }
            else
            {
                double obligationRate = (1 - actualRiskTaking) * 50;
                double stocksRate = (actualRiskTaking - 1) * 50;
                stocksBefore.Text = "↑" + " " + Math.Abs(stocksRate).ToString() + "%";
                stocksBefore.ForeColor = Color.Green;
                oblBefore.Text = "↓" + " " + Math.Abs(obligationRate).ToString() + " %";
                oblBefore.ForeColor = Color.Red;
            }
        }
        public void outputRate(Label obligations,Label stocks,TextBox textBox)
        {
            invObl = q.obligationsSum();
            invSt = q.stocksSum();
            if (textBox.Text != "")
            { 
                expectedRiskTaking = Convert.ToDouble(textBox.Text); 
            }
            Console.WriteLine(expectedRiskTaking);
            double rate = invObl / invSt;
            
            actualRiskTaking = rate*expectedRiskTaking;
            
            if (actualRiskTaking > 1)
            {
                double obligationRate = (actualRiskTaking - 1)*50;
                double stocksRate = (1 - actualRiskTaking) *50;
                stocks.Text = "↓" + " " + Math.Abs(stocksRate).ToString() + "%";
                stocks.ForeColor = Color.Red;
                obligations.Text = "↑" + " " + Math.Abs(obligationRate).ToString() + "%";
                obligations.ForeColor = Color.Green;
            }
            else 
            {
                double obligationRate = (1 - actualRiskTaking) *50;
                double stocksRate = (actualRiskTaking - 1)*50;
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
                for (int i = 0; i < 1000; i++)
                {
                    Investor newinvestor = new Investor();
                    newinvestor.buyFinancialInstruments(25);
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
            label1.Text = "Obligations: " + s.obligationsSum();
            label2.Text = "Stocks: " + s.stocksSum();

        }
    }
}
