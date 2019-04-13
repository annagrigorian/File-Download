using System;
using System.Windows;
using System.Net;
using System.Windows.Forms;


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

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog window = new FolderBrowserDialog();
            window.Description = "Select a Folder";
            string path = null;

            do
            {
                if (window.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = window.SelectedPath;
                }
            } while (path == null);          
            

            using (var client = new WebClient())
            {                
                progressBar1.Visibility = Visibility.Visible;
                downloadButton.IsEnabled = false;
                ouputText.Text = string.Empty;

                client.DownloadProgressChanged += (send, args) =>
                {
                    progressBar1.Value = args.ProgressPercentage;
                };

                try
                {
                    Uri url = new Uri(inputText.Text);

                    string filename = System.IO.Path.Combine(path, System.IO.Path.GetFileName(url.ToString()));
                    
                    await client.DownloadFileTaskAsync(url, filename);
                   
                }
                catch (UriFormatException exception)
                {
                    ouputText.Text = exception.Message;
                }
                catch (WebException exception)
                {
                    ouputText.Text = exception.Message;
                }
                catch (NotSupportedException exception)
                {
                    ouputText.Text = exception.Message;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    downloadButton.IsEnabled = true;
                    progressBar1.Visibility = Visibility.Hidden;
                }
            }
        }      
    }
}
