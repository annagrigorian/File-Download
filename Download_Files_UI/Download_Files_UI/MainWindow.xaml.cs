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
using System.Net;
using System.IO;
using System.Threading;


namespace Download_Files_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private /*async*/ void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;  
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            //using (var client = new WebClient())
            //{

            //    downloadButton.IsEnabled = false;

            //    try
            //    {
            //        Uri url = new Uri(inputText.Text);

            //        string filename = System.IO.Path.Combine(Directory.GetCurrentDirectory(), System.IO.Path.GetFileName(url.ToString()));

            //        ouputText.Text = "Downloading...";                    

            //        await client.DownloadFileTaskAsync(url, filename);                  

            //        ouputText.Text = "Downloaded!";
            //    }
            //    catch (UriFormatException exception)
            //    {
            //        ouputText.Text = exception.Message;
            //    }
            //    catch (WebException exception)
            //    {
            //        ouputText.Text = exception.Message;
            //    }
            //    catch (NotSupportedException exception)
            //    {
            //        ouputText.Text = exception.Message;
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //    finally
            //    {
            //        downloadButton.IsEnabled = true;
            //    }
            //}


        }
    }
}
