using System;
using System.Windows;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Download_Files_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource token = new CancellationTokenSource();
        string filename;

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
                cancelButton.Visibility = Visibility.Visible;
               
                client.DownloadProgressChanged += (send, args) =>
                {
                    progressBar1.Value = args.ProgressPercentage;
                };

                token.Token.Register(() =>
                {
                    cancelButton.Visibility = Visibility.Collapsed;
                    progressBar1.Visibility = Visibility.Collapsed;
                    
                    client.CancelAsync();
                    client.Dispose();

                    var file = new FileInfo(filename);
                    file.Attributes = file.Attributes & ~FileAttributes.ReadOnly;
                   
                    try
                    {
                        file.Delete();
                    }
                    catch (IOException ex)
                    {
                        ouputText.Text =  ex.Message;
                    }
                });

                try
                {
                    Uri url = new Uri(inputText.Text);

                    filename = Path.Combine(path, Path.GetFileName(url.ToString()));

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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {           
            token.Cancel();
            token.Dispose();
        }
    }
}
