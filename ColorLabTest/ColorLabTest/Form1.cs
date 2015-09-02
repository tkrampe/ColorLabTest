using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorLabTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void spinBxClr1_red_ValueChanged(object sender, EventArgs e)
        {
            SetColor1LabValsFromRGB();
        }

        private void spinBxClr1_green_ValueChanged(object sender, EventArgs e)
        {
            SetColor1LabValsFromRGB();
        }

        private void spinBxClr1_blue_ValueChanged(object sender, EventArgs e)
        {
            SetColor1LabValsFromRGB();
        }

        private void spinBxClr1_L_ValueChanged(object sender, EventArgs e)
        {
            SetColor1RGBValsFromLab();
        }

        private void spinBxClr1_a_ValueChanged(object sender, EventArgs e)
        {
            SetColor1RGBValsFromLab();
        }

        private void spinBxClr1_b_ValueChanged(object sender, EventArgs e)
        {
            SetColor1RGBValsFromLab();
        }

        private void spinBxClr2_red_ValueChanged(object sender, EventArgs e)
        {
            SetColor2LabValsFromRGB();
        }

        private void spinBxClr2_green_ValueChanged(object sender, EventArgs e)
        {
            SetColor2LabValsFromRGB();
        }

        private void spinBxClr2_blue_ValueChanged(object sender, EventArgs e)
        {
            SetColor2LabValsFromRGB();
        }

        private void spinBxClr2_L_ValueChanged(object sender, EventArgs e)
        {
            SetColor2RGBValsFromLab();
        }

        private void spinBxClr2_a_ValueChanged(object sender, EventArgs e)
        {
            SetColor2RGBValsFromLab();
        }

        private void spinBxClr2_b_ValueChanged(object sender, EventArgs e)
        {
            SetColor2RGBValsFromLab();
        }

        private ColorMine.ColorSpaces.IRgb Color1_RGB
        {
            get
            {
                return new ColorMine.ColorSpaces.Rgb { R = (double)this.spinBxClr1_red.Value, G = (double)this.spinBxClr1_green.Value, B = (double)this.spinBxClr1_blue.Value };
            }
            set
            {
                this.spinBxClr1_red.ValueChanged -= new System.EventHandler(this.spinBxClr1_red_ValueChanged);
                this.spinBxClr1_green.ValueChanged -= new System.EventHandler(this.spinBxClr1_green_ValueChanged);
                this.spinBxClr1_blue.ValueChanged -= new System.EventHandler(this.spinBxClr1_blue_ValueChanged);

                this.spinBxClr1_red.Value = (decimal)value.R;
                this.spinBxClr1_green.Value = (decimal)value.G;
                this.spinBxClr1_blue.Value = (decimal)value.B;

                this.spinBxClr1_red.ValueChanged += new System.EventHandler(this.spinBxClr1_red_ValueChanged);
                this.spinBxClr1_green.ValueChanged += new System.EventHandler(this.spinBxClr1_green_ValueChanged);
                this.spinBxClr1_blue.ValueChanged += new System.EventHandler(this.spinBxClr1_blue_ValueChanged);
            }
        }

        private ColorMine.ColorSpaces.ILab Color1_Lab
        {
            get
            {
                return new ColorMine.ColorSpaces.Lab { L = (double)this.spinBxClr1_L.Value, A = (double)this.spinBxClr1_a.Value, B = (double)this.spinBxClr1_b.Value };
            }
            set
            {
                this.spinBxClr1_L.ValueChanged -= new System.EventHandler(this.spinBxClr1_L_ValueChanged);
                this.spinBxClr1_a.ValueChanged -= new System.EventHandler(this.spinBxClr1_a_ValueChanged);
                this.spinBxClr1_b.ValueChanged -= new System.EventHandler(this.spinBxClr1_b_ValueChanged);

                this.spinBxClr1_L.Value = (decimal)value.L;
                this.spinBxClr1_a.Value = (decimal)value.A;
                this.spinBxClr1_b.Value = (decimal)value.B;

                this.spinBxClr1_L.ValueChanged += new System.EventHandler(this.spinBxClr1_L_ValueChanged);
                this.spinBxClr1_a.ValueChanged += new System.EventHandler(this.spinBxClr1_a_ValueChanged);
                this.spinBxClr1_b.ValueChanged += new System.EventHandler(this.spinBxClr1_b_ValueChanged);
            }
        }

        private void SetColor1LabValsFromRGB()
        {
            Color1_Lab = Color1_RGB.To<ColorMine.ColorSpaces.Lab>();
            UpdateColor1Label();
            UpdateDeltaE();
        }

        private void SetColor1RGBValsFromLab()
        {
            Color1_RGB = Color1_Lab.To<ColorMine.ColorSpaces.Rgb>();
            UpdateColor1Label();
            UpdateDeltaE();
        }

        private void UpdateColor1Label()
        {
            var rgb = Color1_RGB;
            lblClr_1.BackColor = Color.FromArgb(255, (int)rgb.R, (int)rgb.G, (int)rgb.B);
        }

        private ColorMine.ColorSpaces.IRgb Color2_RGB
        {
            get
            {
                return new ColorMine.ColorSpaces.Rgb { R = (double)this.spinBxClr2_red.Value, G = (double)this.spinBxClr2_green.Value, B = (double)this.spinBxClr2_blue.Value };
            }
            set
            {
                this.spinBxClr2_red.ValueChanged -= new System.EventHandler(this.spinBxClr2_red_ValueChanged);
                this.spinBxClr2_green.ValueChanged -= new System.EventHandler(this.spinBxClr2_green_ValueChanged);
                this.spinBxClr2_blue.ValueChanged -= new System.EventHandler(this.spinBxClr2_blue_ValueChanged);

                this.spinBxClr2_red.Value = (decimal)value.R;
                this.spinBxClr2_green.Value = (decimal)value.G;
                this.spinBxClr2_blue.Value = (decimal)value.B;

                this.spinBxClr2_red.ValueChanged += new System.EventHandler(this.spinBxClr2_red_ValueChanged);
                this.spinBxClr2_green.ValueChanged += new System.EventHandler(this.spinBxClr2_green_ValueChanged);
                this.spinBxClr2_blue.ValueChanged += new System.EventHandler(this.spinBxClr2_blue_ValueChanged);
            }
        }

        private ColorMine.ColorSpaces.ILab Color2_Lab
        {
            get
            {
                return new ColorMine.ColorSpaces.Lab { L = (double)this.spinBxClr2_L.Value, A = (double)this.spinBxClr2_a.Value, B = (double)this.spinBxClr2_b.Value };
            }
            set
            {
                this.spinBxClr2_L.ValueChanged -= new System.EventHandler(this.spinBxClr2_L_ValueChanged);
                this.spinBxClr2_a.ValueChanged -= new System.EventHandler(this.spinBxClr2_a_ValueChanged);
                this.spinBxClr2_b.ValueChanged -= new System.EventHandler(this.spinBxClr2_b_ValueChanged);

                this.spinBxClr2_L.Value = (decimal)value.L;
                this.spinBxClr2_a.Value = (decimal)value.A;
                this.spinBxClr2_b.Value = (decimal)value.B;

                this.spinBxClr2_L.ValueChanged += new System.EventHandler(this.spinBxClr2_L_ValueChanged);
                this.spinBxClr2_a.ValueChanged += new System.EventHandler(this.spinBxClr2_a_ValueChanged);
                this.spinBxClr2_b.ValueChanged += new System.EventHandler(this.spinBxClr2_b_ValueChanged);
            }
        }

        private void SetColor2LabValsFromRGB()
        {
            Color2_Lab = Color2_RGB.To<ColorMine.ColorSpaces.Lab>();
            UpdateColor2Label();
            UpdateDeltaE();
        }

        private void SetColor2RGBValsFromLab()
        {
            Color2_RGB = Color2_Lab.To<ColorMine.ColorSpaces.Rgb>();
            UpdateColor2Label();
            UpdateDeltaE();
        }

        private void UpdateColor2Label()
        {
            var rgb = Color2_RGB;
            lblClr_2.BackColor = Color.FromArgb(255, (int)rgb.R, (int)rgb.G, (int)rgb.B);
        }

        private void UpdateDeltaE()
        {
            double deltaE = Color1_RGB.Compare(Color2_RGB, new ColorMine.ColorSpaces.Comparisons.Cie1976Comparison());
            this.lblDeltaEVal.Text = deltaE.ToString();
        }
    }
}
