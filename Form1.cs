using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cProfile
{
    public partial class Form1 : Form
    {
        public static cpHeader<byte> cheader = new cpHeader<byte>(4);
        public static cpTagCount<byte> tgcount = new cpTagCount<byte>(4);
        public static cpTagTable<byte> pdesctable = new cpTagTable<byte>(4);
        public static cpTagTable<byte> cprttable = new cpTagTable<byte>(4);
        public static cpTagTable<byte> wptable = new cpTagTable<byte>(4);
        public static cpTagTable<byte> bktable = new cpTagTable<byte>(4);
        public static cpTagTable<byte> AB0table = new cpTagTable<byte>(4);
        public static cpTagTable<byte> BA0table = new cpTagTable<byte>(4);
        //public static cpTagTable<byte> AB1table = new cpTagTable<byte>(4);
        //public static cpTagTable<byte> BA1table = new cpTagTable<byte>(4);
        //public static cpTagTable<byte> AB2table = new cpTagTable<byte>(4);
        //public static cpTagTable<byte> BA2table = new cpTagTable<byte>(4);
        public static PAD<byte> descPad = new PAD<byte>(3);
        public static PAD<byte> cprPad = new PAD<byte>(2);
        public static PAD<byte> lutPad = new PAD<byte>(1);
        public static cpTagData<byte> descdata = new cpTagData<byte>(109);
        public static cpTagData<byte> copydata = new cpTagData<byte>(42);
        public static cpTagData<byte> wpdata = new cpTagData<byte>(20);
        public static cpTagData<byte> bkdata = new cpTagData<byte>(20);
        public static LUT8<byte> lut8 = new LUT8<byte>(4);
        public static int indL = -1, indM = -1, indS = -1;
        public static int index = 0;

        public Form1()
        {
            InitializeComponent();
            //Task ta = Task.Run(() => Program.doDefalut());
           // ta.Wait();
            shiftL.Items.Add("525");
            shiftL.Items.Add("530");
            shiftL.Items.Add("535");
            shiftL.Items.Add("540");
            shiftL.Items.Add("545");
            shiftL.Items.Add("550");
            shiftL.Items.Add("555");
            shiftL.Items.Add("560");
            shiftL.Items.Add("565");
            shiftL.Items.Add("570");
            shiftM.Items.Add("525");
            shiftM.Items.Add("530");
            shiftM.Items.Add("535");
            shiftM.Items.Add("540");
            shiftM.Items.Add("545");
            shiftM.Items.Add("550");
            shiftM.Items.Add("555");
            shiftM.Items.Add("560");
            shiftM.Items.Add("565");
            shiftM.Items.Add("570");
            shiftS.Items.Add("525");
            shiftS.Items.Add("530");
            shiftS.Items.Add("535");
            shiftS.Items.Add("540");
            shiftS.Items.Add("545");
            shiftS.Items.Add("550");
            shiftS.Items.Add("555");
            shiftS.Items.Add("560");
            shiftS.Items.Add("565");
            shiftS.Items.Add("570");
            //Program.doDefalut();
            shiftL.SelectedIndex = 0;
            shiftM.SelectedIndex = 0;
            shiftS.SelectedIndex = 0;
            /*if (Protan.Checked == false) indL = -1;
            if (Deutan.Checked == false) indM = -1;
            if (Tritan.Checked == false) indS = -1;*/
        }


        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void export_Click(object sender, EventArgs e)
        {
            Program.doDefalut();
            makeProfile();
            WriteFile();
        }
        private void Protan_CheckedChanged(object sender, EventArgs e)
        {
            if (Protan.Checked == true)
            {
                normal.Checked = false;
                index = 1;
                indL = shiftL.SelectedIndex;
            }
        }

        private void Deutan_CheckedChanged(object sender, EventArgs e)
        {
            if (Deutan.Checked == true)
            {
                normal.Checked = false;
                index = 1;
                indM = shiftM.SelectedIndex;
            }
        }

        private void Tritan_CheckedChanged(object sender, EventArgs e)
        {
            if (Tritan.Checked == true)
            {
                normal.Checked = false;
                index = 1;
                indS = shiftS.SelectedIndex;
            }
        }

        private void normal_CheckedChanged(object sender, EventArgs e)
        {
            if (normal.Checked == true)
            {
                index = 0;
                indL = -1;
                indM = -1;
                indS = -1;
                Protan.Checked = false;
                Deutan.Checked = false;
                Tritan.Checked = false;
            }

        }

        private void shiftL_SelectionChanged(object sender, EventArgs e)
        {
            indL = shiftL.SelectedIndex;
        }

        private void shiftM_SelectionChanged(object sender, EventArgs e)
        {
            indM = shiftM.SelectedIndex;
        }

        private void shiftS_SelectionChanged(object sender, EventArgs e)
        {
            indS = shiftS.SelectedIndex;
        }
        public static void makeProfile()
        {
            //describe header
            cheader.size[0] = 0;
            cheader.size[1] = 0;
            cheader.size[2] = 129;
            cheader.size[3] = 24;
            cheader.type[0] = 0;
            cheader.type[1] = 0;
            cheader.type[2] = 0;
            cheader.type[3] = 0;
            cheader.version[0] = 2;
            cheader.version[1] = 0;
            cheader.version[2] = 0;
            cheader.version[3] = 0;
            cheader.clas[0] = 109;
            cheader.clas[1] = 110;
            cheader.clas[2] = 116;
            cheader.clas[3] = 114;
            cheader.c_space[0] = 82;
            cheader.c_space[1] = 71;
            cheader.c_space[2] = 66;
            cheader.c_space[3] = 32;
            cheader.PCS[0] =  76;
            cheader.PCS[1] =  97;
            cheader.PCS[2] =  98;
            cheader.PCS[3] = 32;
            cheader.DateTime[0] = 7;
            cheader.DateTime[1] = 223;
            cheader.DateTime[2] = 0;
            cheader.DateTime[3] = 2;
            cheader.DateTime[4] = 0;
            cheader.DateTime[5] = 11;
            cheader.DateTime[6] = 0;
            cheader.DateTime[7] = 16;
            cheader.DateTime[8] = 0;
            cheader.DateTime[9] = 21;
            cheader.DateTime[10] = 0;
            cheader.DateTime[11] = 32;
            cheader.Sign[0] = 97;
            cheader.Sign[1] = 99;
            cheader.Sign[2] = 115;
            cheader.Sign[3] = 112;
            cheader.Field[0] = 0;
            cheader.Field[1] = 0;
            cheader.Field[2] = 0;
            cheader.Field[3] = 0;
            cheader.Flags[0] = 0;
            cheader.Flags[1] = 0;
            cheader.Flags[2] = 0;
            cheader.Flags[3] = 0;
            cheader.d_Manu[0] = 0;
            cheader.d_Manu[1] = 0;
            cheader.d_Manu[2] = 0;
            cheader.d_Manu[3] = 0;
            cheader.d_Model[0] = 0;
            cheader.d_Model[1] = 0;
            cheader.d_Model[2] = 0;
            cheader.d_Model[3] = 0;
            //for above, write istead: obj.field = new type[size]{value1,value2,...};
            foreach(int ind in cheader.d_Atts)
            {
                cheader.d_Atts[ind] = 0;
            }
            foreach(int ind in cheader.Render)
            {
                cheader.Render[ind] = 0;
            }
            //cheader.Illum[0] = 0;
            //cheader.Illum[1] = 0;
            //cheader.Illum[2] = 246;
            //cheader.Illum[3] = 214;
            //cheader.Illum[4] = 0;
            //cheader.Illum[5] = 1;
            //cheader.Illum[6] = 0;
            //cheader.Illum[7] = 0;
            //cheader.Illum[8] = 0;
            //cheader.Illum[9] = 0;
            //cheader.Illum[10] = 211;
            //cheader.Illum[11] = 45;
            cheader.Illum = new byte[12] { 0, 0, 246, 214, 0, 1, 0, 0, 0, 0, 211, 45 };
            foreach(int ind in cheader.Creator)
            {
               cheader.Creator[ind] = 0;
            }
            foreach(int ind in cheader.ID)
            {
                cheader.ID[ind] = 0;
            }
            foreach(int ind in cheader.Reserved)
            {
                cheader.Reserved[ind] = 0;
            }
            ////----------------------------------------
            //describe tag count
            //tgcount.Count[0] = 0;
            //tgcount.Count[1] = 0;
            //tgcount.Count[2] = 0;
            //tgcount.Count[3] = 5;
            tgcount.Count = new byte[] { 0, 0, 0, 6 };
            //-------------------------------------------
            //desribe profile description tag
            //pdesctable.Sign[0] = 100;
            //pdesctable.Sign[1] = 101;
            //pdesctable.Sign[2] = 115;
            //pdesctable.Sign[3] = 99;
            pdesctable.Sign = new byte[4] {100,101,115,99};
            pdesctable.Offset = new byte[4] { 0, 0, 0, 204 };
            pdesctable.Size = new byte[4] { 0, 0, 0, 109 };
            //decribe copyright tag
            cprttable.Sign = new byte[4] { 99, 112, 114, 116 };
            cprttable.Offset = new byte[4] { 0, 0, 1, 60 };
            cprttable.Size = new byte[4] { 0, 0, 0, 42 };
            //describe White point tag
            wptable.Sign = new byte[4] { 119, 116, 112, 116 };
            wptable.Offset = new byte[4] { 0, 0, 1, 104 };
            wptable.Size = new byte[4] { 0, 0, 0, 20 };
            //describe black point
            bktable.Sign = new byte[4] { 98, 107, 112, 116 };
            bktable.Offset = new byte[4] { 0, 0, 1, 124 };
            bktable.Size = new byte[4] { 0, 0, 0, 20 };
            //describe the AB0 tag
            AB0table.Sign = new byte[4] { 65, 50, 66, 48 };
            AB0table.Offset = new byte[4] { 0, 0, 1, 144 };
            AB0table.Size = new byte[4] { 0, 0, 63, 195 };
            //describe the AB1 tag
            //AB1table.Sign = new byte[4] { 65, 50, 66, 49 };
            //AB1table.Offset = new byte[4] { 0, 0, 1, 192 };//{ 0, 0, 65, 132 };
            //AB1table.Size = new byte[4] { 0, 0, 63, 195 };
            //describe the AB2 tag
            //AB2table.Sign = new byte[4] { 65, 50, 66, 50 };
            //AB2table.Offset = new byte[4] { 0, 0, 1, 192 };//{ 0, 0, 129, 75 };
            //AB2table.Size = new byte[4] { 0, 0, 63, 195 };
            //describe BA0 tag
            BA0table.Sign = new byte[4] { 66, 50, 65, 48 };
            BA0table.Offset = new byte[4] { 0, 0, 65, 84 };//{ 0, 0, 193, 18 };
            BA0table.Size = new byte[4] { 0, 0, 63, 195 };
            //describe BA1 tag
            //BA1table.Sign = new byte[4] { 66, 50, 65, 49 };
            //BA1table.Offset = new byte[4] { 0, 0, 65, 132 };//{ 0, 1, 0, 217 };
            //BA1table.Size = new byte[4] { 0, 0, 63, 195 };
            //describe BA2 tag
            //BA2table.Sign = new byte[4] { 66, 50, 65, 50 };
            //BA2table.Offset = new byte[4] { 0, 0, 65, 132 };//{ 0, 1, 64, 160 };
            //BA2table.Size = new byte[4] { 0, 0, 63, 195 };
            //describe desc data 
            descdata.Data = new byte[109] { 100, 101, 115, 99, 0, 0, 0, 0, 0, 0, 0, 18, 65, 77, 73, 82, 32, 80, 82, 79, 70, 73, 76, 69, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            descPad.Padding = new byte[3] { 0, 0, 0 };
                //describe copyright data
            copydata.Data = new byte[42] { 116, 101, 120, 116, 0, 0, 0, 0, 110, 111, 110, 101, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            cprPad.Padding = new byte[2] { 0, 0 };
            //describe white point
            wpdata.Data = new byte[20] { 88, 89, 90, 32, 0, 0, 0, 0, 0, 0, 243, 81, 0, 1, 0, 0, 0, 1, 22, 204 };
            //descibe black point
            bkdata.Data = new byte[20] { 88, 89, 90, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //describe LUT
            lut8.Sign = new byte[4] { 109, 102, 116, 49 };
            lut8.Reserved = new byte[4] { 0, 0, 0, 0 };
            lut8.IChan[0] = 3;
            lut8.OChan[0] = 3;
            lut8.gPoints[0] = 17 ;
            lut8.PadReserved = new byte[1] { 0 };
            lut8.e1 = new byte[4] { 0, 1, 0, 0 };
            lut8.e2 = new byte[4] { 0, 0, 0, 0 };
            lut8.e3 = new byte[4] { 0, 0, 0, 0 };
            lut8.e4 = new byte[4] { 0, 0, 0, 0 };
            lut8.e5 = new byte[4] { 0, 1, 0, 0 };
            lut8.e6 = new byte[4] { 0, 0, 0, 0 };
            lut8.e7 = new byte[4] { 0, 0, 0, 0 };
            lut8.e8 = new byte[4] { 0, 0, 0, 0 };
            lut8.e9 = new byte[4] { 0, 1, 0, 0 };
            lut8.ITable = new byte[256, lut8.IChan[0]];
            lut8.OTable = new byte[256, lut8.OChan[0]];
            for (int ind = 0; ind <= 255; ind++)
            {
                lut8.ITable[ind, 0] = (byte)ind;
                lut8.ITable[ind, 1] = (byte)ind;
                lut8.ITable[ind, 2] = (byte)ind;
                lut8.OTable[ind, 0] = (byte)ind;
                lut8.OTable[ind, 1] = (byte)ind;
                lut8.OTable[ind, 2] = (byte)ind;
            }
            lutPad.Padding = new byte[1] { 0 };

        }
        public static void WriteFile()
        {
            const string filename = "Profile.icc";
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                // write header
                writer.Seek(0, SeekOrigin.Begin);
                writer.Write(cheader.size);
                writer.Write(cheader.type);
                writer.Write(cheader.version);
                writer.Write(cheader.clas);
                writer.Write(cheader.c_space);
                writer.Write(cheader.PCS);
                writer.Write(cheader.DateTime);
                writer.Write(cheader.Sign);
                writer.Write(cheader.Field);
                writer.Write(cheader.Flags);
                writer.Write(cheader.d_Manu);
                writer.Write(cheader.d_Model);
                writer.Write(cheader.d_Atts);
                writer.Write(cheader.Render);
                writer.Write(cheader.Illum);
                writer.Write(cheader.Creator);
                writer.Write(cheader.ID);
                writer.Write(cheader.Reserved);
                //write tag count
                writer.Write(tgcount.Count);
                //write profile description tag
                writer.Write(pdesctable.Sign);
                writer.Write(pdesctable.Offset);
                writer.Write(pdesctable.Size);
                //write copyright tag
                writer.Write(cprttable.Sign);
                writer.Write(cprttable.Offset);
                writer.Write(cprttable.Size);
                // write white point tag
                writer.Write(wptable.Sign);
                writer.Write(wptable.Offset);
                writer.Write(wptable.Size);
                //write black point tag
                writer.Write(bktable.Sign);
                writer.Write(bktable.Offset);
                writer.Write(bktable.Size);
                //write AB0 tag
                writer.Write(AB0table.Sign);
                writer.Write(AB0table.Offset);
                writer.Write(AB0table.Size);
                //write AB1 tag
                //writer.Write(AB1table.Sign);
                //writer.Write(AB1table.Offset);
                //writer.Write(AB1table.Size);
                //write AB2 tag
                //writer.Write(AB2table.Sign);
                //writer.Write(AB2table.Offset);
                //writer.Write(AB2table.Size);
                //write BA0 tag
                writer.Write(BA0table.Sign);
                writer.Write(BA0table.Offset);
                writer.Write(BA0table.Size);
                //write BA1 tag
                //writer.Write(BA1table.Sign);
                //writer.Write(BA1table.Offset);
                //writer.Write(BA1table.Size);
                //write BA2 tag
                //writer.Write(BA2table.Sign);
                //writer.Write(BA2table.Offset);
                //writer.Write(BA2table.Size);
                //write desc tag data
                writer.Write(descdata.Data);
                writer.Write(descPad.Padding);
                //write copyright data
                writer.Write(copydata.Data);
                writer.Write(cprPad.Padding);
                //write white point data
                writer.Write(wpdata.Data);
                //write black point data
                writer.Write(bkdata.Data);
                //write AB tags data
                writer.Write(lut8.Sign);
                writer.Write(lut8.Reserved);
                writer.Write((byte)lut8.IChan[0]);
                writer.Write((byte)lut8.OChan[0]);
                writer.Write((byte)lut8.gPoints[0]);
                writer.Write(lut8.PadReserved);
                writer.Write(lut8.e1);
                writer.Write(lut8.e2);
                writer.Write(lut8.e3);
                writer.Write(lut8.e4);
                writer.Write(lut8.e5);
                writer.Write(lut8.e6);
                writer.Write(lut8.e7);
                writer.Write(lut8.e8);
                writer.Write(lut8.e9);
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.ITable[ind, 0]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.ITable[ind, 1]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.ITable[ind, 2]);
                }
                for (int ind = 0; ind <= 4912; ind++)
                {
                    writer.Write((byte)Program.dLUT[ind, 0]);
                    writer.Write((byte)Program.dLUT[ind, 1]);
                    writer.Write((byte)Program.dLUT[ind, 2]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.OTable[ind, 0]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.OTable[ind, 1]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.OTable[ind, 2]);
                }
                writer.Write(lutPad.Padding);
                //write BA tags data
                writer.Write(lut8.Sign);
                writer.Write(lut8.Reserved);
                writer.Write((byte)lut8.IChan[0]);
                writer.Write((byte)lut8.OChan[0]);
                writer.Write((byte)lut8.gPoints[0]);
                writer.Write(lut8.PadReserved);
                writer.Write(lut8.e1);
                writer.Write(lut8.e2);
                writer.Write(lut8.e3);
                writer.Write(lut8.e4);
                writer.Write(lut8.e5);
                writer.Write(lut8.e6);
                writer.Write(lut8.e7);
                writer.Write(lut8.e8);
                writer.Write(lut8.e9);
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.ITable[ind, 0]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.ITable[ind, 1]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.ITable[ind, 2]);
                }
                for (int ind = 0; ind <= 4912; ind++)
                {
                    writer.Write((byte)Program.tLUT[ind, 0]);
                    writer.Write((byte)Program.tLUT[ind, 1]);
                    writer.Write((byte)Program.tLUT[ind, 2]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.OTable[ind, 0]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.OTable[ind, 1]);
                }
                for (int ind = 0; ind <= 255; ind++)
                {
                    writer.Write(lut8.OTable[ind, 2]);
                }
                writer.Write(lutPad.Padding);
            }

        }

 

    }
}
