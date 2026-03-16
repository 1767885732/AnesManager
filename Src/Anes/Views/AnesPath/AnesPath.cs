using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Wis.Anes.Framework.Views;
using System.Windows.Forms;
using Wis.Anes.Custom;

namespace Wis.Anes.Views
{
    [Serializable(), ToolboxItem(false)]
    public partial class AnesPath : BaseView
    {
        public AnesPath()
        {
            InitializeComponent();
        }

        private void btnCheckBeforeInPath_Click(object sender, EventArgs e)
        {
            InfoCheckBeforeOperation anesPath = new InfoCheckBeforeOperation();
            DialogHostForm dialogHostForm = new DialogHostForm("麻醉前检查", 800, 600);
            dialogHostForm.Child = anesPath;
            dialogHostForm.ShowDialog();
        }

        private void AnesPath_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAnesMethod.Text == "气管内麻醉" || comboAnesMethod.Text == "支气管内麻醉")
            {
                webBrowserDetail.Navigate(Application.StartupPath + "\\AnesWorkDoc\\气管内插管全身麻醉.htm");
            }
            else if (comboAnesMethod.Text == "骶管神经阻滞" || comboAnesMethod.Text == "肋间神经阻滞")
            {
                webBrowserDetail.DocumentText = "";
            }
            else
            {
                webBrowserDetail.Navigate(Application.StartupPath + "\\AnesWorkDoc\\" + comboAnesMethod.Text + "操作常规.htm");
            }
        }

        private void comboPath_SelectedIndexChanged(object sender, EventArgs e)
        {

            string pathDetail = "";
            if (comboPath.Text == "一号")
            {

                pathDetail = "1.年龄<70岁 \r\n";
                pathDetail += "2.ASA Ⅰ或Ⅱ\r\n";
                pathDetail += "3.手术历时在2-3小时内的中，小手术\r\n";
                pathDetail += "4.手术出血量<1000ml\r\n";
                pathDetail += "\r\n";
                pathDetail += "常见手术：\r\n";
                pathDetail += "1.普外手术：阑尾手术、疝气修补、甲状腺瘤切除术、急慢性胆囊炎并结石（包括腹腔镜内）、单纯乳房切除或改良癌症根治、胰腺囊肿切除\r\n";
                pathDetail += "2.血管外科手术：大隐静脉剥脱术、动静脉内取栓术\r\n";
                pathDetail += "3.骨科手术：股骨颈骨折、下肢中下段骨折内固定、平台骨折内固定、上肢骨折复位固定\r\n";
                pathDetail += "4.妇产科手术：子宫切除、剖宫产、宫外孕尚未休克、卵巢囊肿切除\r\n";
                pathDetail += "5.泌尿外科手术：泌尿强劲电切手术\r\n";
                pathDetail += "6.除去喉切除清扫外的ENT手术，所有眼科手术\r\n";
                pathDetail += "7.颅内血肿清除术等\r\n";

            
                txtPathDetail.Text = pathDetail;



                comboAnesMethod.Items.Clear();
                comboAnesMethod.Items.Add("臂丛神经阻滞");
                comboAnesMethod.Items.Add("颈丛神经阻滞");
                comboAnesMethod.Items.Add("骶管神经阻滞");
                comboAnesMethod.Items.Add("肋间神经阻滞");
                comboAnesMethod.Items.Add("蛛网膜下腔阻滞");
                comboAnesMethod.Items.Add("硬膜外神经阻滞");
                comboAnesMethod.Items.Add("联合椎管内神经阻滞");
                comboAnesMethod.Items.Add("静脉麻醉");
                comboAnesMethod.Items.Add("气管内麻醉");
                comboAnesMethod.Items.Add("支气管内麻醉");
            }
            else if (comboPath.Text == "二号")
            {

                pathDetail = "1.年龄>70岁 \r\n";
                pathDetail += "2.ASA Ⅲ或Ⅳ\r\n";
                pathDetail += "3.手术历时大于3小时内的大手术\r\n";
                pathDetail += "4.手术出血量>1000ml\r\n";
                pathDetail += "5.血流动力学波动大及需要作控制性低血压手术\r\n";
                pathDetail += "\r\n";
                pathDetail += "常见手术：\r\n";
                pathDetail += "1.普外手术：巨大肝癌切除、根治性直肠癌切除、深爱根除性切除、胰腺癌切除等、恶心肿瘤切除术\r\n";
                pathDetail += "2.胸外科：贲门癌、食管中下段切除、胸腺瘤切除、动脉导管未闭结扎、全肺叶切除\r\n";
                pathDetail += "3.骨科手术：严重复合伤、脊柱侧弯矫正术、全髋置换术、股骨颈骨折\r\n";
                pathDetail += "4.妇产科手术：卵巢癌根除加清扫\r\n";
                pathDetail += "5.泌尿外科手术：同种异体肾移植\r\n";
                pathDetail += "6.五官科手术：除全喉切除清扫外的ENT手术\r\n";
                pathDetail += "7.颅内巨大肿瘤切除、脑动脉畸形、脑膜瘤切除等\r\n";


                txtPathDetail.Text = pathDetail;

                comboAnesMethod.Items.Clear();
     
                comboAnesMethod.Items.Add("硬膜外神经阻滞");
                comboAnesMethod.Items.Add("气管内麻醉");
                comboAnesMethod.Items.Add("支气管内麻醉");
            }
            else if (comboPath.Text == "三号")
            {
                pathDetail = "常见手术：\r\n";
                pathDetail += "心血管手术、体外循环手术、肝、肺、心等脏器官移植手术\r\n";
                comboAnesMethod.Items.Clear();
                comboAnesMethod.Items.Add("气管内麻醉");
                comboAnesMethod.Items.Add("支气管内麻醉");

            }
            
        }

    }
}
