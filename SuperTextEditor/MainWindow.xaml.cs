using Microsoft.Win32;
using System;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;

namespace SuperTextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddBaseData();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            const int NULL = 0;
            const int TIMER_SECONDS = 10;
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(SaveTextPerSecondsInFile);
            dispatcherTimer.Interval = new TimeSpan(NULL, NULL, TIMER_SECONDS);
            dispatcherTimer.Start();

        }

        private void AddBaseData()
        {
            const int MINIMUM_FONT_SIZE = 8;
            const int MAXIMUM_FONT_SIZE = 73;
            InstalledFontCollection fonts = new InstalledFontCollection();

            foreach (var font in fonts.Families)
            {
                fontFamilyComboBox.Items.Add(font.Name);
            }

            for (int i = MINIMUM_FONT_SIZE; i < MAXIMUM_FONT_SIZE; i++)
            {
                fontSizeComboBox.Items.Add(i);
            }
        }

        private void SaveTextPerSecondsInFile(object sender, EventArgs e)
        {
            const int OFFSET = 0;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string text = new TextRange(userText.Document.ContentStart, userText.Document.ContentEnd).Text;
            using (FileStream stream = new FileStream(path + @"\UserText.txt", FileMode.Create))
            {
                byte[] bytes = Encoding.Unicode.GetBytes(text);
                stream.Write(bytes, OFFSET, bytes.Length);
            }
        }

        private void SaveTextInFile()
        {
            string messageBoxText = "Сохранить изменения в файле?";
            string caption = "Сохранение файла";
            MessageBoxButton buttonMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage imageMessageBox = MessageBoxImage.Question;

            MessageBoxResult resultMessageBox = MessageBox.Show(messageBoxText, caption, buttonMessageBox, imageMessageBox);

            switch (resultMessageBox)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        private void UnderlineButtonClick(object sender, RoutedEventArgs e)
        {
            if (userText.Selection.GetPropertyValue(Inline.TextDecorationsProperty).Equals(TextDecorations.Underline))
            {
                userText.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
                return;
            }

            userText.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }

        private void BoldButtonClick(object sender, RoutedEventArgs e)
        {
            if (userText.FontWeight == FontWeights.Bold)
            {
                userText.FontWeight = FontWeights.Normal;
                return;
            }

            userText.FontWeight = FontWeights.Bold;
        }

        private void ItalicButtonClick(object sender, RoutedEventArgs e)
        {
            if (userText.FontStyle == FontStyles.Italic)
            {
                userText.FontStyle = FontStyles.Normal;
                return;
            }

            userText.FontStyle = FontStyles.Italic;
        }

        private void FontFamilyComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) 
            => userText.FontFamily = new FontFamily(fontFamilyComboBox.SelectedItem.ToString());

        private void FontSizeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) 
            => userText.FontSize = Double.Parse(fontSizeComboBox.SelectedItem.ToString());

        private void ColorPickerSelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
            => userText.Foreground = new SolidColorBrush(colorPicker.SelectedColor.Value);

        private void SaveFileDialog()
        {
            string text = new TextRange(userText.Document.ContentStart, userText.Document.ContentEnd).Text;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, text);
            }
        }

        private void NewFileClick(object sender, RoutedEventArgs e)
        {
            SaveTextInFile();
            userText.Document.Blocks.Clear();
        }

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            SaveTextInFile();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                userText.Document.Blocks.Clear();
                userText.AppendText(File.ReadAllText(openFileDialog.FileName, Encoding.Default));
            }
        }

        private void SaveAsFileClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog();
        }

        private void PrintFileClick(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            IDocumentPaginatorSource source = userText.Document;

            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(source.DocumentPaginator, "Document");
            }
        }

        private void ExitFileClick(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Сохранить изменения в файле?";
            string caption = "Сохранение файла";
            MessageBoxButton buttonMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage imageMessageBox = MessageBoxImage.Warning;

            MessageBoxResult resultMessageBox = MessageBox.Show(messageBoxText, caption, buttonMessageBox, imageMessageBox);

            switch (resultMessageBox)
            {
                case MessageBoxResult.Yes:
                    SaveFileDialog();
                    Close();
                    break;

                case MessageBoxResult.No:
                    Close();
                    break;

                case MessageBoxResult.Cancel:
                    break;
            }
        }

    }
}
