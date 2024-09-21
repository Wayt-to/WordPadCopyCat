using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WordPadCopyCat
{
    public partial class ColoursForm : Form
    {
        public event Action<Color> ColorSelected;
        public ColoursForm()
        {
            InitializeComponent();
        }

        public void btn_black_Click(object sender, EventArgs e)
        {
            ColorSelected?.Invoke(Color.Black);
            this.Close();
        }

        public void btn_green_Click(object sender, EventArgs e)
        {
            ColorSelected?.Invoke(Color.Green);
            this.Close();
        }

        public void btn_red_Click(object sender, EventArgs e)
        {
            ColorSelected?.Invoke(Color.Red);
            this.Close();
        }

        public void btn_blue_Click(object sender, EventArgs e)
        {
            ColorSelected?.Invoke(Color.Blue);
            this.Close();
        }
        

       
    }
}
