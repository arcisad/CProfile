using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using CSML;


namespace cProfile
{
    public class coltab : IDisposable
    {
        public DataTable T_N = new DataTable();
        public DataTable shifts = new DataTable();
        public DataTable tGamma = new DataTable();
        CSML.Matrix mat = new CSML.Matrix();
        public  coltab()
        {
            this.T_N.Columns.Add("LR", typeof(double));
            this.T_N.Columns.Add("MG", typeof(double));
            this.T_N.Columns.Add("SB", typeof(double));

            this.T_N.Rows.Add(1.00,    0.00,    0.00);
            this.T_N.Rows.Add(0.00,    1.00,    0.00);
            this.T_N.Rows.Add(0.00,    0.00,    1.00);
            /////////////////////////////////////////////////
            this.mat = new CSML.Matrix(new double[,] { { 0.0208, 0.0476, 0.0063 }, { 0.0063, 0.0466, 0.0090 }, { 0.0007, 0.0021, 0.0367 } });
            /////////////////////////////////////////////////
            this.shifts.Columns.Add("L", typeof(double));
            this.shifts.Columns.Add("M", typeof(double));
            this.shifts.Columns.Add("S", typeof(double));

            this.shifts.Rows.Add(0.0026,    0.0210,    0.0068);
            this.shifts.Rows.Add(0.0033,    0.0218,    0.0064);
            this.shifts.Rows.Add(0.0042,    0.0223,    0.0060);
            this.shifts.Rows.Add(0.0052,    0.0227,    0.0056);
            this.shifts.Rows.Add(0.0063,    0.0230,    0.0052);
            this.shifts.Rows.Add(0.0076,    0.0231,    0.0049);
            this.shifts.Rows.Add(0.0090,    0.0230,    0.0046);
            this.shifts.Rows.Add(0.0105,    0.0228,    0.0043);
            this.shifts.Rows.Add(0.0120,    0.0225,    0.0040);
            this.shifts.Rows.Add(0.0136,    0.0220,    0.0038);
            /////////////////////////////////////////////////

            this.tGamma.Columns.Add("Rgamma", typeof(double));
            this.tGamma.Columns.Add("Ggamma", typeof(double));
            this.tGamma.Columns.Add("Bgamma", typeof(double));

            this.tGamma.Rows.Add(197.0680, 567.800, 60.9840);
            this.tGamma.Rows.Add(- 82.1288, - 416.5316,- 17.159); 
            this.tGamma.Rows.Add(0.0101 , 0.0323, 0.0035);
            this.tGamma.Rows.Add(0.0621, 0.0565, 0.0483);

           
        }
        ~coltab()
        {
            this.Dispose();
        }
        public void Dispose()
        {
            this.shifts = null;
            this.mat = null;
            GC.SuppressFinalize(this);
        }
        public CSML.Matrix normalize(CSML.Matrix nonNorm)
        {
            CSML.Matrix normMat = new CSML.Matrix(3,3);
            double ijk = 0.00;
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    ijk = nonNorm[i, j].Re;
                    normMat[i, j].Re = ijk;
                }
            }
            double sum = 0.00;
            for (int i = 1; i <= 3; i++ )
            {
                sum = normMat[i, 1].Re + normMat[i, 1].Re + normMat[i, 1].Re;
                normMat[i, 1].Re = normMat[i, 1].Re / sum;
                normMat[i, 2].Re = normMat[i, 2].Re / sum;
                normMat[i, 3].Re = normMat[i, 3].Re / sum;
            }
                return normMat;
        }

        public DataTable tblMake(CSML.Matrix mtx, DataTable tble, int IL, int IM, int IS, int defInd)
        {
            DataTable table = new DataTable();
            table.Columns.Add("LR", typeof(double));
            table.Columns.Add("MG", typeof(double));
            table.Columns.Add("SB", typeof(double));
            CSML.Matrix newMTX = new CSML.Matrix(3, 3); 
            CSML.Matrix invmat = new CSML.Matrix(3, 3);
            CSML.Matrix defmat = new CSML.Matrix(3, 3);
            CSML.Matrix NnewMTX = new CSML.Matrix(3, 3);
            CSML.Matrix Nmat = new CSML.Matrix(3, 3);
            double iL = mtx[1, 1].Re;
            double jL = mtx[1, 2].Re;
            double kL = mtx[1, 3].Re;
            double iM = mtx[2, 1].Re;
            double jM = mtx[2, 2].Re;
            double kM = mtx[2, 3].Re;
            double iS = mtx[3, 1].Re;
            double jS = mtx[3, 2].Re;
            double kS = mtx[3, 3].Re;

            if (IL != -1)
            {
                iL = Convert.ToDouble(tble.Rows[IL][0]);
                jL = Convert.ToDouble(tble.Rows[IL][1]);
                kL = Convert.ToDouble(tble.Rows[IL][2]);
            }
            if (IM != -1)
            {
                iM = Convert.ToDouble(tble.Rows[IM][0]);
                jM = Convert.ToDouble(tble.Rows[IM][1]);
                kM = Convert.ToDouble(tble.Rows[IM][2]);
            }
            if (IS != -1)
            {
                iS = Convert.ToDouble(tble.Rows[IS][0]);
                jS = Convert.ToDouble(tble.Rows[IS][1]);
                kS = Convert.ToDouble(tble.Rows[IS][2]);
            }
 
            if (defInd == 0)
                table = this.T_N;
            else
            {
                newMTX[1, 1].Re = iL;
                newMTX[1, 2].Re = jL;
                newMTX[1, 3].Re = kL;
                newMTX[2, 1].Re = iM;
                newMTX[2, 2].Re = jM;
                newMTX[2, 3].Re = kM;
                newMTX[3, 1].Re = iS;
                newMTX[3, 2].Re = jS;
                newMTX[3, 3].Re = kS;
                try
                {
                    NnewMTX = normalize(newMTX);
                    invmat = NnewMTX.Inverse();
                    //MessageBox.Show(this.mat[1, 1].ToString() + " " + this.mat[1, 2].ToString() + " " + this.mat[1, 3].ToString() + "\n" + this.mat[2, 1].ToString() + " " + this.mat[2, 2].ToString() + " " + this.mat[2, 3].ToString() + "\n" + this.mat[3, 1].ToString() + " " + this.mat[3, 2].ToString() + " " + this.mat[3, 3].ToString());
                    //MessageBox.Show(newMTX[1, 1].ToString() + " " + newMTX[1, 2].ToString() + " " + newMTX[1, 3].ToString() + "\n" + newMTX[2, 1].ToString() + " " + newMTX[2, 2].ToString() + " " + newMTX[2, 3].ToString() + "\n" + newMTX[3, 1].ToString() + " " + newMTX[3, 2].ToString() + " " + newMTX[3, 3].ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Singular matrix. Select another wavelength.");
                }
                Nmat = normalize(this.mat);
                defmat = invmat * Nmat;
                //MessageBox.Show(defmat[1, 1].ToString() + " " + defmat[1, 2].ToString() + " " + defmat[1, 3].ToString() + "\n" + defmat[2, 1].ToString() + " " + defmat[2, 2].ToString() + " " + defmat[2, 3].ToString() + "\n" + defmat[3, 1].ToString() + " " + defmat[3, 2].ToString() + " " + defmat[3, 3].ToString());
                table.Rows.Add(defmat[1, 1].Re, defmat[1, 2].Re, defmat[1, 3].Re);
                table.Rows.Add(defmat[2, 1].Re, defmat[2, 2].Re, defmat[2, 3].Re);
                table.Rows.Add(defmat[3, 1].Re, defmat[3, 2].Re, defmat[3, 3].Re);
            }


            return table;
        }
        public int[] transalg(int R, int G, int B)
        {
            if (R > 255) R = 255;
            if (R < 0) R = 0;
            if (G > 255) G = 255;
            if (G < 0) G = 0;
            if (B > 255) B = 255;
            if (B < 0) B = 0;
            int[] RGB = new int[3] { R, G, B };
            return RGB;
        }
        public int[] shiftcol(int[] RGB, DataTable tab)
        {
            double Rp, Gp, Bp;
            int Rpi, Gpi, Bpi;
            Rp = Convert.ToDouble(tab.Rows[0][0]) * RGB[0] + Convert.ToDouble(tab.Rows[0][1]) * RGB[1] + Convert.ToDouble(tab.Rows[0][2]) * RGB[2];
            Gp = Convert.ToDouble(tab.Rows[1][0]) * RGB[0] + Convert.ToDouble(tab.Rows[1][1]) * RGB[1] + Convert.ToDouble(tab.Rows[1][2]) * RGB[2];
            Bp = Convert.ToDouble(tab.Rows[2][0]) * RGB[0] + Convert.ToDouble(tab.Rows[2][1]) * RGB[1] + Convert.ToDouble(tab.Rows[2][2]) * RGB[2];

                Rpi = (int)Math.Round(Rp);
                Gpi = (int)Math.Round(Gp);
                Bpi = (int)Math.Round(Bp);

                int[] RGBt = transalg(Rpi, Gpi, Bpi);
              return RGBt;
        }
        public int[] RGBcalc(int[] RGB, int indeL, int indeM, int indeS, int defIndex)
            {

                DataTable transmat = new DataTable();
                transmat = this.tblMake(this.mat, this.shifts, indeL, indeM, indeS, defIndex);
                int[] RGBc = shiftcol(RGB, transmat);

                return RGBc;
            }
        }
}
