using System;
using System.Windows.Forms;
using Utils;

namespace Ex05_Othelo
{
    public partial class FormSetting : Form
    {
        private int m_ButtonSize = 6;
        private playerType m_PlayerType = playerType.Manual;

        public int ButtonSize
        {
            get
            {
                return m_ButtonSize;
            }
        }

        public FormSetting()
        {
            InitializeComponent();
        }
        private void buttonSize_Click(object sender, EventArgs e)
        {
            if (m_ButtonSize == 12)
            {
                m_ButtonSize = 6;
            }
            else
            {
                m_ButtonSize += 2;
            }
            buttonSize.Text = string.Format("Board Size {0}X{0} (click to increase)", m_ButtonSize);
        }

        private void buttonAgainstComputer_Click(object sender, EventArgs e)
        {
            m_PlayerType = playerType.Computer;
            this.Close();
        }
        private void buttonAgainstFriend_Click(object sender, EventArgs e)
        {
            m_PlayerType = playerType.Manual;
            this.Close();


        }
        public int BoardSize
        {
            get { return m_ButtonSize; }
        }
        public playerType PlayerType
        {
            get { return m_PlayerType; }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {

        }
    }
}
