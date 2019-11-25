using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public class Dado
    {
        //numero del dado
        int numero;

        //Método para tirar el dado
        public void TirarDado()
        {
            Random n = new Random();
            numero = n.Next(6) + 1;
        }

        public int GetNum()
        {
            return numero;
        }

        //Mostrar cara del dado
        public PictureBox MostrarCara(PictureBox picb)
        {
            switch (numero)
            {
                case 1:
                    picb.Image = WindowsFormsApplication1.Properties.Resources._1;
                    break;
                case 2:
                    picb.Image = WindowsFormsApplication1.Properties.Resources._2;
                    break;
                case 3:
                    picb.Image = WindowsFormsApplication1.Properties.Resources._3;
                    break;
                case 4:
                    picb.Image = WindowsFormsApplication1.Properties.Resources._4;
                    break;
                case 5:
                    picb.Image = WindowsFormsApplication1.Properties.Resources._5;
                    break;
                case 6:
                    picb.Image = WindowsFormsApplication1.Properties.Resources._6;
                    break;
            }
            return picb;
        }



    }

