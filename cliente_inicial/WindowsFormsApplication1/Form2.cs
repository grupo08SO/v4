using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Dado dadito = new Dado();
        int cont = 0;

        public Form2()
        {
            InitializeComponent();
            
        }
        private void Timear()
        {
            timer1.Enabled = true;
        }
       
        private void TirarDado_Click(object sender, EventArgs e)
        {
            Timear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval=250;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                dadopb.Image = WindowsFormsApplication1.Properties.Resources._1;
                dadopb.Refresh();
            }
            if (cont == 1)
            {
                dadopb.Image = WindowsFormsApplication1.Properties.Resources._2;
                dadopb.Refresh();
            }
            if (cont == 2)
            {
                dadopb.Image = WindowsFormsApplication1.Properties.Resources._3;
                dadopb.Refresh();
            }
            if (cont == 3)
            {
                dadopb.Image = WindowsFormsApplication1.Properties.Resources._4;
                dadopb.Refresh();
            }
            if (cont == 4)
            {
                dadopb.Image = WindowsFormsApplication1.Properties.Resources._5;
                dadopb.Refresh();
            }
            if (cont == 5)
            {
                dadopb.Image = WindowsFormsApplication1.Properties.Resources._6;
                dadopb.Refresh();
            }
            if (cont == 6)
            {
                dadito.TirarDado();
                dadopb = dadito.MostrarCara(dadopb);
                dadopb.Refresh();
                timer1.Enabled = false;
                
            }
            if (cont != 6)
                cont++;
            else cont = 0;
        }  
    
       
    }
}
