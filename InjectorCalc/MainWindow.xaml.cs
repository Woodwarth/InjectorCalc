using System;
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

namespace InjectorCalc
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

        private void QSTAT_TextChanged(object sender, TextChangedEventArgs e)
        {
            double QSTAT = 0;
            double vol = 0;
            int time = 0;
            double factor = 0;

            if (rb_Qstat_nheptan.IsChecked.Value)
            {
                factor = 1.05;
            }
            else
            {
                factor = 1;
            }


            try
            {
                time = Convert.ToInt32(tb_Qstat_time.Text);
                vol = Convert.ToDouble(tb_Qstat_vol.Text);
            }
            catch
            { }
            finally
            {
                QSTAT = vol/time*60*factor;
                tb_Qstat_QSTAT.Text = QSTAT.ToString();
            }



        }

        private void KRKTE_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            double Vhzyl = 1;
            double Qstat = 1;
            double rkti;

            try
            {
                Vhzyl = Convert.ToDouble(tb_KRKTE_VHzyl.Text);
                Qstat = Convert.ToDouble(tb_KRKTE_QSTAT.Text);
            }
            catch
            {

            }
            finally
            {
                rkti = 50.2624 * Vhzyl / Qstat;
                tb_KRKTE_KRKTE.Text = rkti.ToString();
            }
            


            
        }

        void calc_TVUB()
        {
            try
            {
                int pulses = Convert.ToInt32(tb_TVUB_pulses.Text);
                int time = Convert.ToInt32(tb_TVUB_time.Text);
                double QSTAT = Convert.ToDouble(tb_TVUB_QSTAT.Text);
                double volume = Convert.ToDouble(tb_TVUB_volume.Text);
                double tv = 0;

                double expected_volume = QSTAT * (pulses * time) / 60000;
                double prozent = volume / expected_volume;

                tv = time * prozent;

                tb_TVUB_tv.Text = tv.ToString();
            }
            catch
            {
                
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calc_TVUB();
        }
    }
}
