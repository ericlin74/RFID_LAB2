namespace 電子錢包
{
    public partial class Form1 : Form
    {
        MW_EasyPOD EasyPOD;

        private string Gv_KEY_TYPE = "A";              //卡片KEY_TYPE
        private string Gv_KEY_VALUE = "FFFFFFFFFFFF";  //卡片KEY_VALUE
        private CARD_SET_ADDRESS Gv_MEMBER_ID;
        private CARD_SET_ADDRESS Gv_MEMEBER_NAME;
        private CARD_SET_ADDRESS Gv_MEMEBER_POINTS;
        private CARD_SET_ADDRESS Gv_MEMEBER_DATE;
        private UInt32 Gv_uiPointLimit = 1000000;

        struct CARD_SET_ADDRESS
        {
            public uint SECTOR;
            public uint BLOCK;
        }

        enum MyEnum : byte
        {
            Read_Tag_Data = 0x1,
            Reader_Action_Command = 0x2,
            Set_Reader_Parameter = 0x3,
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
            Gv_MEMBER_ID.SECTOR = 0;
            Gv_MEMBER_ID.BLOCK = 2;
            Gv_MEMEBER_NAME.SECTOR = 0;
            Gv_MEMEBER_NAME.BLOCK = 1;
            Gv_MEMEBER_POINTS.SECTOR = 3;
            Gv_MEMEBER_POINTS.BLOCK = 0;
            Gv_MEMEBER_DATE.SECTOR = 3;
            Gv_MEMEBER_DATE.BLOCK = 1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbID.Text.Trim() == "")
            {
                MessageBox.Show("請輸入會員編號");
                tbID.Focus();
                return;
            };
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("請輸入姓名");
                tbID.Focus();
                return;
            };
            if (tbPoint.Text.Trim() == "")
            {
                MessageBox.Show("請輸入點數");
                tbID.Focus();
                return;
            };

            if (Convert.ToUInt32(tbPoint.Text.Trim())>Gv_uiPointLimit)
            {
                MessageBox.Show($"超過儲值上限： {Gv_uiPointLimit} 無法開卡");
                tbID.Focus();
                return;
            }
            try
            {
                byte[] WriteBuffer = new byte[] { 0x2, 0x2, 0x1, 0x1 }; //Command {STX, LEN, CMD, DATA1, DATA2.....}
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMBER_ID, Gv_KEY_TYPE, Gv_KEY_VALUE, tbID.Text.Trim());                //設定會員編號
                Write_tRFIDData(WriteBuffer);
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_NAME, Gv_KEY_TYPE, Gv_KEY_VALUE, tbName.Text.Trim());           //設定會員名稱
                Write_tRFIDData(WriteBuffer);
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE, tbPoint.Text.Trim());        //設定會員點數
                Write_tRFIDData(WriteBuffer);
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_DATE, Gv_KEY_TYPE, Gv_KEY_VALUE, tbDate.Text.Trim());          //設定日期
                Write_tRFIDData(WriteBuffer);


                MessageBox.Show("寫入完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private byte[] Get_Read_CMD_Data(CARD_SET_ADDRESS CS_INFO, string KEY_TYPE, string KEY_VALUE)
        {
            //[Key Type] + [Key Value] + [Sector Number] +[Block Number]
            byte L_Key_Type = (byte)(KEY_TYPE == "A" ? 0x60 : 0x61);
            byte[] L_aryKEY_VALUE = Enumerable.Range(0, KEY_VALUE.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(KEY_VALUE.Substring(x, 2), 16))
                                 .ToArray();
            List<byte> L_Return_array = new List<byte>();//Command {STX, LEN, CMD, DATA1, DATA2.....}
            L_Return_array.AddRange(new byte[] { 0x2, 0xA, 0x15, L_Key_Type });
            L_Return_array.AddRange(L_aryKEY_VALUE);
            L_Return_array.Add(Convert.ToByte(CS_INFO.SECTOR));
            L_Return_array.Add(Convert.ToByte(CS_INFO.BLOCK));
            return L_Return_array.ToArray();
        }

        private byte[] Get_Write_CMD_Data(CARD_SET_ADDRESS CS_INFO, string KEY_TYPE, string KEY_VALUE, string DATA_VALUE)
        {
            //[Key Type] + [Key Value] + [Sector Number] +[Block Number]
            byte L_Key_Type = (byte)(KEY_TYPE == "A" ? 0x60 : 0x61);
            byte[] L_aryKEY_VALUE = Enumerable.Range(0, KEY_VALUE.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(KEY_VALUE.Substring(x, 2), 16))
                                 .ToArray();
            List<byte> L_Return_array = new List<byte>();//Command {STX, LEN, CMD, DATA1, DATA2.....}
            L_Return_array.AddRange(new byte[] { 0x2, 0x1A, 0x16, L_Key_Type });
            L_Return_array.AddRange(L_aryKEY_VALUE);
            L_Return_array.Add(Convert.ToByte(CS_INFO.SECTOR));
            L_Return_array.Add(Convert.ToByte(CS_INFO.BLOCK));
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(DATA_VALUE.PadRight(16, '\0'));
            L_Return_array.AddRange(byteArray);
            byte[] numberBytes = BitConverter.GetBytes(L_Return_array.Count());

            return L_Return_array.ToArray();
        }
        unsafe string Read_tRFIDData(byte[] WriteBuffer, uint TIMEOUT = 200)
        {
            //MW_EasyPOD mW_EasyPOD = new MW_EasyPOD();
            EasyPOD.VID = 0xe6a;
            EasyPOD.PID = 0x317;
            EasyPOD.ReadTimeOut = TIMEOUT;
            EasyPOD.WriteTimeOut = TIMEOUT;
            uint Index = 1;
            uint uiWritten;
            uint dwResult;
            fixed (MW_EasyPOD* pPOD = &EasyPOD)
            {
                dwResult = PODfuncs.ConnectPOD(pPOD, Index);
                if ((dwResult != 0)) { throw new Exception("Not connected yet"); }

                dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, (uint)WriteBuffer.Length, &uiWritten);    //Send a request command to reader
                if ((dwResult != 0)) { throw new Exception("Write Error"); }

                byte[] ReadBuffer = new byte[0x40];
                uint uiLength = 64;
                uint uiRead = 0;
                uint uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);
                if (ReadBuffer[3] == 0)
                {
                    return System.Text.Encoding.UTF8.GetString(ReadBuffer, 4, (Int32)uiRead);
                    // return BitConverter.ToString(ReadBuffer, 4, (Int32)uiRead);
                }
                if (ReadBuffer[3] == 1)
                {
                    throw new Exception("No card or invalid Key");
                }
                else if (ReadBuffer[3] == 0x10)
                {
                    throw new Exception("Command error");
                }
                else
                {
                    throw new Exception("unKnown error");
                }
            }
        }

        unsafe uint Write_tRFIDData(byte[] WriteBuffer, uint TIMEOUT = 200)
        {
            Thread.Sleep(200);
            // MW_EasyPOD mW_EasyPOD = new MW_EasyPOD();
            EasyPOD.VID = 0xe6a;
            EasyPOD.PID = 0x317;
            EasyPOD.ReadTimeOut = TIMEOUT;
            EasyPOD.WriteTimeOut = TIMEOUT;
            uint Index = 1;
            uint uiWritten;
            uint dwResult;

            fixed (MW_EasyPOD* pPOD = &EasyPOD)
            {
                dwResult = PODfuncs.ConnectPOD(pPOD, Index);
                if ((dwResult != 0)) { throw new Exception("Not connected yet"); }

                dwResult = PODfuncs.WriteData(pPOD, WriteBuffer, (uint)WriteBuffer.Length, &uiWritten);    //Send a request command to reader
                if ((dwResult != 0)) { throw new Exception("Write Error"); }

                byte[] ReadBuffer = new byte[0x40];
                uint uiLength = 64;
                uint uiRead = 0;
                uint uiResult = PODfuncs.ReadData(pPOD, ReadBuffer, uiLength, &uiRead);
                if (ReadBuffer[3] == 0)
                {
                    return dwResult;

                }
                if (ReadBuffer[3] == 1)
                {
                    throw new Exception("No card or invalid Key");
                }
                else if (ReadBuffer[3] == 0x10)
                {
                    throw new Exception("Command error");
                }
                else
                {
                    throw new Exception("unKnown error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] WriteBuffer = new byte[] { 0x2, 0x2, 0x1, 0x1 }; //Command {STX, LEN, CMD, DATA1, DATA2.....}
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMBER_ID, Gv_KEY_TYPE, Gv_KEY_VALUE, "");        //清除會員編號
                Write_tRFIDData(WriteBuffer);
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_NAME, Gv_KEY_TYPE, Gv_KEY_VALUE, "");    //清除會員名稱
                Write_tRFIDData(WriteBuffer);
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE, "");  //清除會員點數
                Write_tRFIDData(WriteBuffer);
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_DATE, Gv_KEY_TYPE, Gv_KEY_VALUE, "");    //清除日期
                Write_tRFIDData(WriteBuffer);
                MessageBox.Show("清空完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] WriteBuffer = new byte[] { 0x2, 0x2, 0x1, 0x1 }; //Command {STX, LEN, CMD, DATA1, DATA2.....}
                WriteBuffer = Get_Read_CMD_Data(Gv_MEMBER_ID, Gv_KEY_TYPE, Gv_KEY_VALUE);               //讀取會員編號
                tbID_DSP.Text = Read_tRFIDData(WriteBuffer);

                WriteBuffer = Get_Read_CMD_Data(Gv_MEMEBER_NAME, Gv_KEY_TYPE, Gv_KEY_VALUE);            //讀取會員名稱
                tbName_DSP.Text = Read_tRFIDData(WriteBuffer);

                WriteBuffer = Get_Read_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE);          //讀取會員點數
                tbPoints_DSP.Text = Read_tRFIDData(WriteBuffer);

                WriteBuffer = Get_Read_CMD_Data(Gv_MEMEBER_DATE, Gv_KEY_TYPE, Gv_KEY_VALUE);          //讀取日期
                tbDate_DSP.Text = Read_tRFIDData(WriteBuffer);

                MessageBox.Show("讀取完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //強制僅能輸入數字
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblPoints_Remark.Text = "";
            if (tbPoints_Save.Text == "")
            {
                MessageBox.Show("請先輸入儲值點數");
                return;
            }

            try
            {
                //取得目前點數
                byte[] WriteBuffer = Get_Read_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE);
                UInt32 Lv_iPoints = Convert.ToUInt32(Read_tRFIDData(WriteBuffer));
                //加上目前儲值點數
                Lv_iPoints += Convert.ToUInt32(tbPoints_Save.Text);

                if (Lv_iPoints> Gv_uiPointLimit)
                {
                    throw new Exception($"超過儲值上限： {Gv_uiPointLimit} 無法儲值");
                }
                //寫入目前點數
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE, Lv_iPoints.ToString());        //設定會員點數
                Write_tRFIDData(WriteBuffer);
                lblPoints_Remark.Text = $"儲值：{tbPoints_Save.Text} 可用餘額：{Lv_iPoints.ToString()}";
                MessageBox.Show("儲值完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblUsed_Remark.Text = "";
            if (tbUsed_Points.Text == "")
            {
                MessageBox.Show("請先輸入消費點數");
                return;
            }

            try
            {
                //取得目前點數
                byte[] WriteBuffer = Get_Read_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE);
                Int32 Lv_iPoints = Convert.ToInt32(Read_tRFIDData(WriteBuffer));
                //扣除目前儲值點數
                Lv_iPoints -= Convert.ToInt32(tbUsed_Points.Text);
                if (Lv_iPoints < 0)
                {
                    if (!cbAutoTopUp.Checked)
                    {
                        throw new Exception($"餘額不足 {Math.Abs(Lv_iPoints).ToString()} 請先進行儲值");
                    }

                    Int32 Lv_iTopUp_Value = Convert.ToInt32(tbTopUp_Value.Text);
                    Int32 Lv_iTopUp_Count = (Int32)Math.Ceiling((double)Math.Abs(Lv_iPoints) / (double)Lv_iTopUp_Value);    //計算自動儲值次數

                    Lv_iPoints += Lv_iTopUp_Value * Lv_iTopUp_Count;                //計算自動儲值後餘額
                    if ((Lv_iTopUp_Value * Lv_iTopUp_Count) > Gv_uiPointLimit)
                    {
                        throw new Exception($"超過儲值上限： {Gv_uiPointLimit} 無法自動儲值");
                    }
                    lblUsed_Remark.Text = $@"由於您的消費金額不足，系統進行自動儲值！
                        自動加值：{Lv_iTopUp_Value} 次數：{Lv_iTopUp_Count} 總計自動加值：{Lv_iTopUp_Value * Lv_iTopUp_Count}　
                        消費：{tbUsed_Points.Text} 可用餘額：{Lv_iPoints.ToString()}";
                }
                else
                {
                    lblUsed_Remark.Text = $"消費：{tbUsed_Points.Text} 可用餘額：{Lv_iPoints}";
                }
                //寫入目前點數
                WriteBuffer = Get_Write_CMD_Data(Gv_MEMEBER_POINTS, Gv_KEY_TYPE, Gv_KEY_VALUE, Lv_iPoints.ToString());        //設定會員點數
                Write_tRFIDData(WriteBuffer);
                MessageBox.Show("消費完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbAutoTopUp_CheckedChanged(object sender, EventArgs e)
        {
            tbTopUp_Value.ReadOnly = !cbAutoTopUp.Checked;
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}