using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cProfile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        public static int[,] dLUT = new int[4913, 3];
        public static int[,] tLUT = new int[4913, 3];

        public static int[] RGBF = new int[3];
        public static int[] LABF = new int[3];

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
        public static void doDefalut()
        {
            int[] ind_col = new int[17] { 0, 15, 31, 47, 63, 79, 95, 111, 127, 143, 159, 175, 191, 207, 223, 239, 255 };
            int st_ind = 0;
            //Form1 f1 = new Form1();
            while (st_ind <= 4912)
            {
                for (int i = 0; i <= 16; i++)
                {
                    for (int j = 0; j <= 16; j++)
                    {
                        for (int k = 0; k <= 16; k++)
                        {
                            using (coltab tb = new coltab())
                            {
                                int[] rgb = new int[3] { ind_col[i], ind_col[j], ind_col[k] };
                                RGBF = tb.RGBcalc(rgb, Form1.indL, Form1.indM, Form1.indS, Form1.index);
                            }

                            int[] lab_col = new int[3];
                            lab_col = RGBtoLab(RGBF[0], RGBF[1], RGBF[2]);
                            dLUT[st_ind, 0] = lab_col[0];
                            dLUT[st_ind, 1] = lab_col[1];
                            dLUT[st_ind, 2] = lab_col[2];

                            int[] rgb_col = new int[3];
                            rgb_col = LabtoRGB(ind_col[i], ind_col[j], ind_col[k]);
                            using (coltab tb = new coltab())
                            {
                                RGBF = tb.RGBcalc(rgb_col, Form1.indL, Form1.indM, Form1.indS, Form1.index);
                            }
                            tLUT[st_ind, 0] = RGBF[0];
                            tLUT[st_ind, 1] = RGBF[1];
                            tLUT[st_ind, 2] = RGBF[2];
                            st_ind++;
                        }
                    }
                }
            }
        }
        public static int[] RGBtoLab(int R,int G,int B)
        {
  
            double var_R = ( (double)R / 255.00 );
            double var_G = ( (double)G / 255.00 );
            double var_B = ( (double)B / 255.00 );
            
            if ( var_R > 0.04045 ) var_R = Math.Pow(( ( var_R + 0.055 ) / 1.055 ) , 2.4);
            else                   var_R = var_R / 12.92;
            if ( var_G > 0.04045 ) var_G = Math.Pow(( ( var_G + 0.055 ) / 1.055 ) , 2.4);
            else                   var_G = var_G / 12.92;
            if ( var_B > 0.04045 ) var_B = Math.Pow(( ( var_B + 0.055 ) / 1.055 ) , 2.4);
            else                   var_B = var_B / 12.92;

            var_R = var_R * 100;
            var_G = var_G * 100;
            var_B = var_B * 100;

            //Observer. = 2°, Illuminant = D65
            //Form2 f2 = new Form2();
            double X = var_R * 0.4124 + var_G * 0.3576 + var_B * 0.1805;
            double Y = var_R * 0.2126 + var_G * 0.7152 + var_B * 0.0722;
            double Z = var_R * 0.0193 + var_G * 0.1192 + var_B * 0.9505;

            double var_X = X / 95.047;          //ref_X =  95.047   Observer= 2°, Illuminant= D65
            double var_Y = Y / 100.000;          //ref_Y = 100.000
            double var_Z = Z / 108.883;          //ref_Z = 108.883

            if ( var_X > 0.008856 ) var_X = Math.Pow(var_X , ( 1.00/3.00 ));
            else                    var_X = ( 7.787 * var_X ) + ( 16.00 / 116.00 );
            if ( var_Y > 0.008856 ) var_Y = Math.Pow(var_Y , ( 1.00/3.00 ));
            else                    var_Y = ( 7.787 * var_Y ) + ( 16.00 / 116.00 );
            if ( var_Z > 0.008856 ) var_Z = Math.Pow(var_Z , ( 1.00/3.00 ));
            else                    var_Z = ( 7.787 * var_Z ) + ( 16.00 / 116.00 );

            double CIEL = ( 116.00 * var_Y ) - 16.00;
            double CIEa = 500.00 * ( var_X - var_Y );
            double CIEb = 200.00 * (var_Y - var_Z);

            CIEL = CIEL * 255.00 / 100.00;
            CIEa = CIEa + 128.00;
            CIEb = CIEb + 128.00;

            int cieL = (int)CIEL ;
            int cieA = (int)CIEa ;
            int cieB = (int)CIEb ;

            int[] LAB = new int[3] { cieL, cieA, cieB };
            return LAB;
 
        }
        public static int[] LabtoRGB(double L, double a, double b)
        {
             L = L * 100.00 / 255.00;
             a = a - 128.00;
             b = b - 128.88;

            double var_Y = ( L + 16.00 ) / 116.00;
            double var_X = a / 500.00 + var_Y;
            double var_Z = var_Y - b / 200.00;

            if ( Math.Pow(var_Y,3.00) > 0.008856 ) var_Y = Math.Pow(var_Y,3.00);
            else                      var_Y = ( var_Y - 16.00 / 116.00 ) / 7.787;
            if ( Math.Pow(var_X,3.00) > 0.008856 ) var_X = Math.Pow(var_X,3.00);
            else                      var_X = ( var_X - 16.00 / 116.00 ) / 7.787;
            if ( Math.Pow(var_Z,3.00) > 0.008856 ) var_Z = Math.Pow(var_Z,3.00);
            else                      var_Z = ( var_Z - 16.00 / 116.00 ) / 7.787;

            double X = 95.047 * var_X;     //ref_X =  95.047     Observer= 2°, Illuminant= D65
            double Y = 100.000 * var_Y;     //ref_Y = 100.000
            double Z = 108.883 * var_Z;     //ref_Z = 108.883

            var_X = X / 100.00;        //X from 0 to  95.047      (Observer = 2°, Illuminant = D65)
            var_Y = Y / 100.00;        //Y from 0 to 100.000
            var_Z = Z / 100.00;        //Z from 0 to 108.883

            double var_R = var_X *  3.2406 + var_Y * -1.5372 + var_Z * -0.4986;
            double var_G = var_X * -0.9689 + var_Y *  1.8758 + var_Z *  0.0415;
            double var_B = var_X *  0.0557 + var_Y * -0.2040 + var_Z *  1.0570;

            if (var_R > 1) var_R = 1;
            if (var_G > 1) var_G = 1;
            if (var_B > 1) var_B = 1;
            if (var_R < 0) var_R = 0;
            if (var_G < 0) var_G = 0;
            if (var_B < 0) var_B = 0;

            if ( var_R > 0.0031308 ) var_R = 1.055 * ( Math.Pow(var_R , ( 1.00 / 2.4 ) ) ) - 0.055;
            else                     var_R = 12.92 * var_R;
            if ( var_G > 0.0031308 ) var_G = 1.055 * ( Math.Pow(var_G , ( 1.00 / 2.4 ) ) ) - 0.055;
            else                     var_G = 12.92 * var_G;
            if ( var_B > 0.0031308 ) var_B = 1.055 * ( Math.Pow(var_B , ( 1.00 / 2.4 ) ) ) - 0.055;
            else                     var_B = 12.92 * var_B;

            double rr = Math.Round(var_R * 255.00);
            double gg = Math.Round(var_G * 255.00);
            double bb = Math.Round(var_B * 255.00);

            int R = (int)rr;
            int G = (int)gg;
            int B = (int)bb;


            int[] RGB = new int[3] { R, G, B };

            return RGB;

        }
    }
}
