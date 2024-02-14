using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SystemProgramming_Intro;

public partial class MainWindow : Window
{
    public List<Proces> processes { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        processes = new List<Proces>();

        foreach (var item in Process.GetProcesses())
        {
            Proces p = new Proces();

            p.Name = item.ProcessName;
            p.Id = item.Id;
            p.MachineName = item.MachineName;
            p.ThreadsCount = item.Threads.Count;

            processes.Add(p);
        }

        listview1.ItemsSource = processes;
    }

    private void endtask_btn_Click(object sender, RoutedEventArgs e)
    {
        Proces proces = listview1.SelectedItem as Proces;

        if (proces != null)
        {
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == proces.Name && item.Id == proces.Id && item.MachineName == proces.MachineName && item.Threads.Count == proces.ThreadsCount)
                {
                    item.Kill();
                }
            }
        }

        else
        {
            MessageBox.Show("Proccess'i sec");
        }
    }
}