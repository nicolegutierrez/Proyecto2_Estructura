using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x1;
        int x2;
        int y1;
        int y2;
       

        void dibujarArista()
        {
            Graphics grafico = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Purple, 2);
            SolidBrush sb = new SolidBrush(Color.DarkRed);

               x1 = Convert.ToInt16(text_x1.Text);
               y1 = Convert.ToInt16(text_y1.Text);
               x2 = Convert.ToInt16(text_x2.Text);
               y2 = Convert.ToInt16(text_y2.Text);

            //      Vertice VOrigen = this.GetVertice(x1,y1);
            //

            Vertice VDestino = this.GetVertice(x2, y2);
            
      //      misariastas.add(VOrigen,VDestino, costo):

            

            grafico.DrawLine(lapiz, x1, y1, x2, y2);
            limpiar();

        }
        
        void limpiar()
        {
            text_x1.Clear();
            text_y1.Clear();
            text_x2.Clear();
            text_y2.Clear();
            lblOrigen.Text = "";
            label9.Text = "";
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        
            x1 = e.X;
            y1 = e.Y;
            x2 = e.X;
            y2 = e.Y;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics grafico = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Purple,2);
            SolidBrush sb = new SolidBrush(Color.DarkRed);

            /*   if(text_x1.Text=="" && text_y1.Text == "")
               {

                   text_x1.Text = Convert.ToString(x1);
                   text_y1.Text = Convert.ToString(y1);
                   grafico.DrawRectangle(lapiz, x1, y1, 4, 4);
                   grafico.FillRectangle(sb, x1, y1, 4, 4);
               }
                   else if(text_x1.Text != "" && text_y1.Text != "")
               {
                   text_x2.Text = Convert.ToString(x2);
                   text_y2.Text = Convert.ToString(y2);
                   grafico.DrawRectangle(lapiz, x2, y2, 4, 4);
                  grafico.FillRectangle(sb, x2, y2, 4,4 );

               }*/
        
         
           Vertice verticeSeleccionado = this.GetVertice(x1, y1);

            if (lblOrigen.Text == "")
            {
                if (verticeSeleccionado == null)
                {
                    grafico.DrawRectangle(lapiz, x1, y1, 4, 4);
                    grafico.FillRectangle(sb, x1, y1, 4, 4);
                    this.misVertices.Add(new Vertice(x1, y1));//agregar el nombre del vertice

                }
                else {
                    x1 = verticeSeleccionado.x;
                    y1 = verticeSeleccionado.y;
                }
                text_x1.Text = Convert.ToString(x1);
                text_y1.Text = Convert.ToString(y1);
                lblOrigen.Text = "(" + text_x1.Text + "," + text_y1.Text + ")";
            }
            else if (lblOrigen.Text != "")
            {
                if (verticeSeleccionado == null)
                {
                    grafico.DrawRectangle(lapiz, x2, y2, 4, 4);
                    grafico.FillRectangle(sb, x2, y2, 4, 4);
                    this.misVertices.Add(new Vertice(x2, y2));//agregar el nombre del vertice

                }
                else
                {
                    x2 = verticeSeleccionado.x;
                    y2 = verticeSeleccionado.y;
                }
                text_x2.Text = Convert.ToString(x2);
                text_y2.Text = Convert.ToString(y2);
                label9.Text = "(" + text_x2.Text + "," + text_y2.Text + ")";
            }


        }


        Vertice GetVertice(int x, int y)
        {

            foreach (Vertice v in misVertices)
                if (x < v.x + 15 && x > v.x - 15 && y < v.y + 15 && y > v.y - 15)
                    return v;
               return null;
        }

        List<Vertice> misVertices = new List<Vertice>();
        class Vertice {
            public int x, y;
            public String nombre;
            public Vertice(int x, int y) {
                this.x = x;
                    this.y = y;
            }
        }

        class Arista {
            Vertice origen, destino;
        }
        private void b_dibujar_Click(object sender, EventArgs e)
        {

            dibujarArista();
        }
    }
    }

