using gyakorlás.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyakorlás
{
    public partial class Form1 : Form
    {
        BindingList<Child> childs = new BindingList<Child>();
        SantaClausPack scp = new SantaClausPack();
        public Form1()
        {
            InitializeComponent();
            BindingSource cbs = new BindingSource();
            cbs.DataSource = childs;
            dataGridView1.DataSource = cbs;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var child = new Child();
            int beh = int.Parse(behTxtBox.Text);
            if (!child.CheckBehaviour(beh))
            {
                MessageBox.Show("1-5 közötti számot adj meg!");
                return;
            }
            child.Name = nameTxtBox.Text;
            child.Behaviour = (Behaviour)beh;
            childs.Add(child);
            var bad = (from x in childs
                       where x.Behaviour == (Behaviour)1 || x.Behaviour == (Behaviour)2
                       select x).Count();
            badNumberLabel.Text = "Rosszak száma:"+bad;
            child.gifts = scp.GetGifts(beh);
        }
    }
}
