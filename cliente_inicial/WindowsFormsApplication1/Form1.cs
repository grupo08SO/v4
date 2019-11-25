using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Connectivity server = new Connectivity();
        bool Logged;
        Thread atender;
        string user;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public bool GetLogged()
        {
            return Logged;
        }
        public void SetLogged()
        {
            Logged = true;
        }
        public string GetUser()
        {
            return user;
        }

        //Abre el form de partida
        private void Jugar_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        //Para Iniciar el cliente con Logged false
        private void Form1_Load(object sender, EventArgs e)
        {
            Logged = false;
            Conectados.ColumnCount = 1;
            Conectados.Columns[0].HeaderText = "Conectados";
        }

        //Iniciar sesión
        private void LogIN_Click(object sender, EventArgs e)
        {
            if (!Logged)
            {
                if (server.ConnectServer() == 1)
                {
                    Login();
                    ThreadStart ts = delegate { EjecutarThread(); };
                    atender = new Thread(ts);
                    atender.Start();

                }
                else
                    MessageBox.Show("Hubo algún problema con la conexión.");
            }
            else
            {
                MessageBox.Show("Ya estás Loggeado.");
            }

        }
        //Registrarse
        private void SignUP_Click_1(object sender, EventArgs e)
        {

            if (!Logged)
            {
                if (server.ConnectServer() == 1)
                {
                    Register();
                    ThreadStart ts = delegate { EjecutarThread(); };
                    atender = new Thread(ts);
                    atender.Start();
                }
                else
                    MessageBox.Show("Hubo algún problema con la conexión.");
            }
            else
            {
                MessageBox.Show("Cuidado estas loggeado por el moment.");
            }
        }
        //Consultas
        private void QueryButton_Click(object sender, EventArgs e)
        {
            if (Logged)
            {
                if (puntotal.Checked)
                {
                    GetPunTotal();
                }

                if (tiempo.Checked)
                {
                    GetTiempoTotal();
                }

                if (veces.Checked)
                {
                    GetVictorias();
                }
                else if ((!veces.Checked) && (!tiempo.Checked) && (!puntotal.Checked))
                {
                    MessageBox.Show("Selecciona primero una categoria");
                }
            }
            else
                MessageBox.Show("Para Usar estas funciones deberías estar Loggeado.");
        }
       
        //Actualizar lista conectados
        public void ActualizarLista(string lista)
        {
            Conectados.Rows.Clear();
            string[] conectados = lista.Split(' ');
            for (int i = 0; i < conectados.Length-1; i++)
            {
                Conectados.Rows.Add(conectados[i]);
            }
        }
        //Enviar invitaciones (Modo 1v1 y modo 4 jugadores)
        private void Invitar_Click(object sender, EventArgs e)
        {
            if (Conectados.SelectedRows.Count == 1)
            {
                server.SendToServer(7, Conectados.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show("Enviamos: " + Conectados.SelectedRows[0].Cells[0].Value.ToString());
            }
            if (Conectados.SelectedRows.Count == 0)
                MessageBox.Show("Selecciona a alguien primero");
            if ((Conectados.SelectedRows.Count != 0) && (Conectados.SelectedRows.Count != 1))
                MessageBox.Show("Selecciona 1 jugador");
        }
        //FUNCIONES PARA LOS BOTONES:
        private void Register()
        {
            if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
            else
            {
                server.SendToServer(2, usuario.Text + " " + contraseña.Text);
            }
        }

        private void Login()
        {
            if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
            else
            {
                user = usuario.Text;
                server.SendToServer(1, usuario.Text + " " + contraseña.Text);
            }
        }

        private bool GetPunTotal()
        {
            if (string.IsNullOrEmpty(usuarioPuntos.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return false;
            }
            else
            {
                server.SendToServer(3, usuarioPuntos.Text);
                return true;
            }
        }

        private bool GetTiempoTotal()
        {
            if (string.IsNullOrEmpty(usuarioTiempo.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return false;
            }
            else
            {
                server.SendToServer(4, usuarioTiempo.Text);
                return true;
            }
        }

        private bool GetVictorias()
        {
            if (string.IsNullOrEmpty(usuarioVeces.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return false;
            }
            else
            {
                server.SendToServer(5, usuarioVeces.Text);
                return true;
            }
        }
        //Desconectar
        private void Disconnect_Click(object sender, EventArgs e)
        {
            atender.Abort();
            server.SendToServer(0, user);
            server.DisconnectServer();
            Logged = false;
        }
        //Al cerrar se desconecta
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Estas seguro que quieres salir?", "Exit", MessageBoxButtons.OKCancel);
            if (Logged)
            {
                if (res == DialogResult.OK)
                {
                    server.SendToServer(0, user);
                    server.DisconnectServer();
                }
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        //Funcion que ejecuta el thread
        private void EjecutarThread()
        {
            while (true)
            {
                string msg = server.ReceiveFromServer();
                int respuesta;

                switch (server.GetCodigo())
                {
                    case 1:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 1)
                        {
                            Logged = true;
                            MessageBox.Show("Loggeado");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("Hubo algún problema.");
                            server.SetCodigo();
                        }
                        break;
                    case 2:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 1)
                        {
                            MessageBox.Show("Correctamente Registrado y Loggeado.");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("Hubo algún problema.");
                            server.SetCodigo();
                        }
                        break;
                    case 3:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta >= 0)
                        {
                            MessageBox.Show("Sus puntos totales" + " son: " + respuesta.ToString());
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe o hubo algun problema");
                            server.SetCodigo();
                        }
                        break;
                    case 4:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta >= 0)
                        {
                            MessageBox.Show("Su tiempo total jugado es" + respuesta.ToString());
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe o hubo algun problema");
                            server.SetCodigo();
                        }
                        break;
                    case 5:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta >= 0)
                        {
                            MessageBox.Show("Le ha ganado" + " " + respuesta.ToString() + " " + "veces");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe o hubo algun problema");
                            server.SetCodigo();
                        }
                        break;
                    case 6:
                        ActualizarLista(msg);
                        server.SetCodigo();
                        break;
                    case 7:
                        DialogResult result = MessageBox.Show(msg + " " + "te invita a jugar una partida, aceptas?", "Invitación recibida", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Has aceptado la invitación");
                            server.SendToServer(8, msg);
                            server.SetCodigo();
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("Invitación rechazada");
                            server.SendToServer(9, msg);
                            server.SetCodigo();
                        }
                        break;
                    case 8:
                        MessageBox.Show(msg + " ha aceptado la invitación");
                        server.SetCodigo();
                        break;
                    case 9:
                        MessageBox.Show(msg + " ha rechazado la invitación");
                        server.SetCodigo();
                        break;
                    case 10:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 1)
                            MessageBox.Show("Invitacion enviada");
                        if (respuesta == 0)
                            MessageBox.Show("Hubo algun problema");
                        server.SetCodigo();
                        break;
                    case 11:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 0)
                            MessageBox.Show("Hubo algun problema");
                        server.SetCodigo();
                        break;
                    case 12:
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 0)
                            MessageBox.Show("Hubo algun problema");
                        server.SetCodigo();
                        break;
                }
            }

        }
    }
}
       
            
        


      



    



