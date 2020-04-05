﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TranslatorLibrary;

namespace MisakaTranslator_WPF.SettingsPages.TranslatorPages
{
    /// <summary>
    /// BaiduTransSettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class BaiduTransSettingsPage : Page
    {
        public BaiduTransSettingsPage()
        {
            InitializeComponent();
            BDTransAppIDBox.Text = Common.appSettings.BDappID;
            BDTransSecretKeyBox.Text = Common.appSettings.BDsecretKey;
        }

        private void AuthTestBtn_Click(object sender, RoutedEventArgs e)
        {
            Common.appSettings.BDappID = BDTransAppIDBox.Text;
            Common.appSettings.BDsecretKey = BDTransSecretKeyBox.Text;
            ITranslator BDTrans = new BaiduTranslator();
            BDTrans.TranslatorInit(BDTransAppIDBox.Text,BDTransSecretKeyBox.Text);
            
            if (BDTrans.Translate("apple", "zh", "en") != null)
            {
                HandyControl.Controls.Growl.Success("百度翻译API工作正常!");
            }
            else
            {
                HandyControl.Controls.Growl.Error("百度翻译API工作异常\n" + BDTrans.GetLastError());
            }
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(BaiduTranslator.GetUrl_allpyAPI());
        }

        private void DocBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(BaiduTranslator.GetUrl_Doc());
        }

        private void BillBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(BaiduTranslator.GetUrl_bill());
        }

        private void TransTestBtn_Click(object sender, RoutedEventArgs e)
        {
            ITranslator BDTrans = new BaiduTranslator();
            BDTrans.TranslatorInit(Common.appSettings.BDappID, Common.appSettings.BDsecretKey);
            string res = BDTrans.Translate(TestSrcText.Text, TestDstLang.Text, TestSrcLang.Text);
            
            if (res != null)
            {
                HandyControl.Controls.MessageBox.Show(res, "翻译结果");
            }
            else
            {
                HandyControl.Controls.Growl.Error("百度翻译API工作异常\n" + BDTrans.GetLastError());
            }
        }
    }
}
