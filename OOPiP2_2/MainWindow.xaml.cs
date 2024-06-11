using Microsoft.Win32;
using MyLib;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnFileStream_Click(object sender, RoutedEventArgs e)
        {
                string text = txtInput.Text; // Получить текст из txtInput
                if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(selectedFilePath))
                {
                    using (FileStream fileStream = new FileStream(selectedFilePath, FileMode.Create))
                    {
                        var decorator = new FileStreamDecorator(fileStream, new byte[] { (byte)'A', (byte)'B', (byte)'C' });
                        var bytes = Encoding.UTF8.GetBytes(text);
                        try
                        {
                            decorator.Write(bytes, 0, bytes.Length);
                            fileStream.Seek(0, SeekOrigin.Begin);
                            fileStream.CopyTo(fileStream);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show("Обнаружена комбинация байт. Сохранение прервано.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        finally
                        {
                            MessageBox.Show("Файл успешно сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        fileStream.Flush();
                        fileStream.Close(); // Закрыть поток, если обнаружена комбинация байт
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите текст и выберите файл.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }

        private void BtnMemoryStream_Click(object sender, RoutedEventArgs e)
        {
                string text = txtInput.Text; // Получить текст из txtInput
                if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(selectedFilePath))
                {
                    var memoryStream = new MemoryStream();
                    var decorator = new MemoryStreamDecorator(memoryStream, new byte[] { (byte)'G', (byte)'H', (byte)'I' });
                    var bytes = Encoding.UTF8.GetBytes(text);
                    try
                    {
                        decorator.Write(bytes, 0, bytes.Length);
                        // Сохранить содержимое в выбранный файл
                        using (FileStream fileStream = new FileStream(selectedFilePath, FileMode.Create))
                        {
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            memoryStream.CopyTo(fileStream);
                        }
                        MessageBox.Show("Файл успешно сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show("Обнаружена комбинация байт. Сохранение прервано.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        memoryStream.Close(); // Закрыть поток, если обнаружена комбинация байт
                        memoryStream.Flush();
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите текст и выберите файл.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }

        private string selectedFilePath; // Добавляем переменную для хранения пути выбранного файла

        private void BtnBufferStream_Click(object sender, RoutedEventArgs e)
        {

                string text = txtInput.Text; // Получить текст из txtInput
                if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(selectedFilePath))
                {
                    var bufferStream = new MemoryStream();
                    var decorator = new BufferStreamDecorator(bufferStream, new byte[] { (byte)'G', (byte)'H', (byte)'I' });
                    var bytes = Encoding.UTF8.GetBytes(text);
                    try
                    {
                        decorator.Write(bytes, 0, bytes.Length);
                        // Сохранить содержимое в выбранный файл
                        using (FileStream fileStream = new FileStream(selectedFilePath, FileMode.Create))
                        {
                            bufferStream.Seek(0, SeekOrigin.Begin);
                            bufferStream.CopyTo(fileStream);
                        }
                        MessageBox.Show("Файл успешно сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show("Обнаружена комбинация байт. Сохранение прервано.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        bufferStream.Close(); // Закрыть поток, если обнаружена комбинация байт
                        bufferStream.Flush();
                    }
                  
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите текст и выберите файл.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName; // Сохраняем путь к выбранному файлу
                txtOutput.Text = File.ReadAllText(selectedFilePath);
            }
        }
    }
}