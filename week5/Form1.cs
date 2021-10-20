using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;

        public Form1()
        {
             InitializeComponent();
             Ticks = context.Ticks.ToList();
             dataGridView1.DataSource = Ticks;
        }

        List<PortfolioItem> Portfolio = new List<PortfolioItem>();

        public Form1()
        {
            // ...
           CreatePortfolio();
        }

        private void CreatePortfolio()
        {
           Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
           Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
           Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

           dataGridView2.DataSource = Portfolio;

        }

        PortfolioItem p = new PortfolioItem();
        p.Index = "OTP";
        p.Volume = 10;
        Portfolio.Add(p);

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in Ticks
                            where item.Index == x.Index.Trim() 
                               && date <= x.TradingDay
                            select x)
                            .First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }
    }
}
