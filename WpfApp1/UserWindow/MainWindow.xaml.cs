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
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Entity;
using System.Windows.Forms;
using System.Security.Policy;
using System.Data;

namespace WpfApp1.UserWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Users user)
        {
            InitializeComponent();
            Load();
            DataContext = user;

            Title = $"Информационная ситема «Анализ ключевых показателей работы» для ФГБОУ ВО СибГМУ Минздрава России — {user.LastName}";

            // График 1
            ChartTreatmentResult.Titles.Add("График распределения выписанных больных по результатам лечения");
            // создаю область построения ChartAreas и добавляю колекцию "TreatmentResult"
            ChartTreatmentResult.ChartAreas.Add(new ChartArea("TreatmentResult"));
            // добавляю серию
            var currentSeries1 = new Series("Кол-во \nвыписанных \nбольных");
            // добавляю созданную серию в колекцию Series
            ChartTreatmentResult.Series.Add(currentSeries1);
            // получаю типы диаграмм из перечисления SeriesChartType
            CmBChartTypes1.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

            // График 2
            ChartCountPatientsAtTheDoctor.Titles.Add("График соотношения персонала и пациентов");
            ChartCountPatientsAtTheDoctor.ChartAreas.Add(new ChartArea("CountPatientsAtTheDoctor"));

            var currentSeries2 = new Series("Ко-во \nпациентов \nу врача");

            ChartCountPatientsAtTheDoctor.Series.Add(currentSeries2);
            CmBChartTypes2.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

            // График 3
            ChartCountDeadPatients.Titles.Add("График количества умерших пациентов по дате");
            ChartCountDeadPatients.ChartAreas.Add(new ChartArea("ChartCountDeadPatients"));

            var currentSeries3 = new Series("Кол-во \nумерших \nпациентов");

            ChartCountDeadPatients.Series.Add(currentSeries3);
            CmBChartTypes3.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

            // График 4
            ChartCountPatientsInDepartments.Titles.Add("График количества находящихся на лечении пациентов в разрезе отделений");
            ChartCountPatientsInDepartments.ChartAreas.Add(new ChartArea("ChartCountPatientsInDepartments"));

            var currentSeries4 = new Series("Кол-во \nпациентов \nпо отделениям");

            ChartCountPatientsInDepartments.Series.Add(currentSeries4);
            CmBChartTypes4.ItemsSource = Enum.GetValues(typeof(SeriesChartType));

            // Диаграммы по умолчанию
            CmBChartTypes1.SelectedIndex = 10;
            CmBChartTypes2.SelectedIndex = 10;
            CmBChartTypes3.SelectedIndex = 10;
            CmBChartTypes4.SelectedIndex = 10;
        }

        private void Load()
        {
            CmBDoctor.ItemsSource = Helper.context.MEDECINS.OrderBy(x => x.SURNAME_IO).ToList();
            CmBDepartments.ItemsSource = Helper.context.FM_DEP.OrderBy(x => x.LABEL).ToList();
        }

        // График 1
        // если значение в комбобоксе изменилось, то вызываю метод UpdateChartTreatmentResult
        private void UpdateChartTreatmentResult(object sender, SelectionChangedEventArgs e)
        {
            // получаю выбранное значение в выпадающем списке 
            if (CmBChartTypes1.SelectedItem is SeriesChartType currentType)
            {
                // получаю первую и единственную серию данных диаграммы из коллекции Series
                Series currentSeries = ChartTreatmentResult.Series.FirstOrDefault();
                // устанавливаю выбранный тип диаграммы
                currentSeries.ChartType = currentType;
                // очищаю предыдущее значение
                currentSeries.Points.Clear();

                // получаю список результатов лечения из БД
                var patientResultStatus = Helper.context.ED_PATIENTS_STATUS.ToList();
                // прохожусь по списку через цикл
                foreach (var patientStatus in patientResultStatus)
                {
                    // добаляю для каждого результата лечения точку через коллекцию Points
                    currentSeries.Points.AddXY(patientStatus.NAME,
                        Helper.context.DATA_STAT_HOSPITALIZATION.ToList()
                        .Count(x => x.ED_PATIENTS_STATUS == patientStatus));
                }
            }
        }

        // График 2
        private void UpdateChartCountPatientsAtTheDoctor(object sender, SelectionChangedEventArgs e)
        {
            // получаю выбранные значения в выпадающем списке
            if (CmBDoctor.SelectedItem is MEDECINS currentMEDECINS
                && CmBChartTypes2.SelectedItem is SeriesChartType currentType)
            {
                // получаю первую и единственную серию данных диаграммы из коллекции Series
                Series currentSeries2 = ChartCountPatientsAtTheDoctor.Series.FirstOrDefault();
                // устанавливаю выбранный тип диаграммы
                currentSeries2.ChartType = currentType;
                // очищаю предыдущее значение
                currentSeries2.Points.Clear();

                // отсчитываю 1 месяц назад, 2 месяца назад и т.д.
                var today = DateTime.Today;
                var thisMonth = new DateTime(today.Year, today.Month, 1);
                var oneMonthAgo = thisMonth.AddMonths(-1);
                var twoMonthAgo = thisMonth.AddMonths(-2);
                var threeMonthAgo = thisMonth.AddMonths(-3);
                var fourMonthAgo = thisMonth.AddMonths(-4);
                var fiveMonthAgo = thisMonth.AddMonths(-5);
                var sixMonthAgo = thisMonth.AddMonths(-6);

                // шесть месяцев назад
                currentSeries2.Points.AddXY(sixMonthAgo.Month.ToString() + "." + sixMonthAgo.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ >= sixMonthAgo && x.DATA_NAZNAHENIQ < fiveMonthAgo));

                // пять месяца назад
                currentSeries2.Points.AddXY(fiveMonthAgo.Month.ToString() + "." + fiveMonthAgo.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ >= fiveMonthAgo && x.DATA_NAZNAHENIQ < fourMonthAgo));

                // четыре месяца назад
                currentSeries2.Points.AddXY(fourMonthAgo.Month.ToString() + "." + fourMonthAgo.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ >= fourMonthAgo && x.DATA_NAZNAHENIQ < threeMonthAgo));

                // три месяца назад
                currentSeries2.Points.AddXY(threeMonthAgo.Month.ToString() + "." + threeMonthAgo.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ >= threeMonthAgo && x.DATA_NAZNAHENIQ < twoMonthAgo));

                // два месяца назад
                currentSeries2.Points.AddXY(twoMonthAgo.Month.ToString() + "." + twoMonthAgo.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ >= twoMonthAgo && x.DATA_NAZNAHENIQ < oneMonthAgo));

                // один месяц назад
                currentSeries2.Points.AddXY(oneMonthAgo.Month.ToString() + "." + oneMonthAgo.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ >= oneMonthAgo && x.DATA_NAZNAHENIQ < thisMonth));

                // количество пациентов за текущий месяц
                currentSeries2.Points.AddXY(thisMonth.Month.ToString() + "." + thisMonth.Year.ToString(),
                    Helper.context.DATA_DOCTOR_IN_CHARGE
                    .Count(x => x.MEDECINS.SURNAME_IO == currentMEDECINS.SURNAME_IO
                    && x.DATA_NAZNAHENIQ == thisMonth));
            }
        }

        // График 3
        private void UpdateChartCountDeadPatients(object sender, SelectionChangedEventArgs e)
        {
            // получаю выбранные значения в выпадающем списке
            if (CmBChartTypes3.SelectedItem is SeriesChartType currentType)
            {
                // получаю первую и единственную серию данных диаграммы из коллекции Series
                Series currentSeries3 = ChartCountDeadPatients.Series.FirstOrDefault();
                // устанавливаю выбранный тип диаграммы
                currentSeries3.ChartType = currentType;
                // очищаю предыдущее значение
                currentSeries3.Points.Clear();

                // отсчитываю даты
                var today = DateTime.Today;
                var oneDayAgo = today.AddDays(-1);
                var oneMonthAgo = today.AddMonths(-1);
                var oneYearAgo = today.AddMonths(-12);

                currentSeries3.Points.AddXY("На начало года",
                    Helper.context.PATIENTS.Count(x => x.DATA_SMERTI > oneYearAgo));

                currentSeries3.Points.AddXY("За месяц",
                    Helper.context.PATIENTS.Count(x => x.DATA_SMERTI >= oneMonthAgo));

                currentSeries3.Points.AddXY("За последние сутки",
                    Helper.context.PATIENTS.Count(x => x.DATA_SMERTI >= oneDayAgo));
            }
        }

        // График 4
        private void UpdateChartCountPatientsInDepartments(object sender, SelectionChangedEventArgs e)
        {
            // получаю выбранные значения в выпадающем списке
            if (CmBDepartments.SelectedItem is FM_DEP currentFM_DEP
                && CmBChartTypes4.SelectedItem is SeriesChartType currentType)
            {
                // получаю первую и единственную серию данных диаграммы из коллекции Series
                Series currentSeries4 = ChartCountPatientsInDepartments.Series.FirstOrDefault();
                // устанавливаю выбранный тип диаграммы
                currentSeries4.ChartType = currentType;
                // очищаю предыдущее значение
                currentSeries4.Points.Clear();

                // отсчитываю месяцы
                var today = DateTime.Today;
                var thisMonth = new DateTime(today.Year, today.Month, 1);
                var oneMonthAgo = thisMonth.AddMonths(-1);
                var twoMonthAgo = thisMonth.AddMonths(-2);
                var threeMonthAgo = thisMonth.AddMonths(-3);

                // три месца назад
                currentSeries4.Points.AddXY(threeMonthAgo.Month.ToString() + "." + threeMonthAgo.Year.ToString(),
                    Helper.context.DATA_TRANSFERS
                    .Count(x => x.HO_RESERV.MEDDEP.FM_DEP.LABEL == currentFM_DEP.LABEL
                    && x.FK_PATIENTS_ID == x.PATIENTS.PATIENTS_ID && x.DEPART_DATE >= threeMonthAgo && x.DEPART_DATE < twoMonthAgo));

                // два месяца назад
                currentSeries4.Points.AddXY(twoMonthAgo.Month.ToString() + "." + twoMonthAgo.Year.ToString(),
                    Helper.context.DATA_TRANSFERS
                    .Count(x => x.HO_RESERV.MEDDEP.FM_DEP.LABEL == currentFM_DEP.LABEL
                    && x.FK_PATIENTS_ID == x.PATIENTS.PATIENTS_ID && x.DEPART_DATE >= twoMonthAgo && x.DEPART_DATE < oneMonthAgo));

                // месяц назад
                currentSeries4.Points.AddXY(oneMonthAgo.Month.ToString() + "." + oneMonthAgo.Year.ToString(),
                    Helper.context.DATA_TRANSFERS
                    .Count(x => x.HO_RESERV.MEDDEP.FM_DEP.LABEL == currentFM_DEP.LABEL
                    && x.FK_PATIENTS_ID == x.PATIENTS.PATIENTS_ID && x.DEPART_DATE >= oneMonthAgo && x.DEPART_DATE < thisMonth));

                // за текущий месяц
                currentSeries4.Points.AddXY(thisMonth.Month.ToString() + "." + thisMonth.Year.ToString(),
                    Helper.context.DATA_TRANSFERS
                    .Count(x => x.HO_RESERV.MEDDEP.FM_DEP.LABEL == currentFM_DEP.LABEL
                    && x.FK_PATIENTS_ID == x.PATIENTS.PATIENTS_ID && x.DEPART_DATE == thisMonth));

                // считаю максимальное количество коек в отделении
                var countBed = Helper.context.HO_ROOM.Count(x => x.MEDDEP.FM_DEP.FM_DEP_ID == currentFM_DEP.FM_DEP_ID);

                // отображение красной линии
                StripLine stripline = new StripLine();
                stripline.Interval = 0;
                stripline.IntervalOffset = countBed;
                stripline.StripWidth = countBed / 100.0;
                stripline.BackColor = System.Drawing.Color.Red;
                ChartCountPatientsInDepartments.ChartAreas[0].AxisY.StripLines.Clear();
                ChartCountPatientsInDepartments.ChartAreas[0].AxisY.StripLines.Add(stripline);
                ChartCountPatientsInDepartments.ChartAreas[0].AxisY.Maximum = countBed + 1;

                ChartCountPatientsInDepartments.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
                ChartCountPatientsInDepartments.ChartAreas[0].AxisY.MinorGrid.Interval = 1;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new AuthWindow().Show();
            Close();
        }
    }
}