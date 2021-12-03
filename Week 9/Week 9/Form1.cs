using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:/Temp/nép-teszt.csv");
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (var sr = new Streamreader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    var p = new Person();
                    p.BirthYear = int.Parse(line[0]);
                    p.Gender = Enum.Parse(typeof(Gender), line[1]);
                }
            }

            reutrn population;
        }
    }
}
