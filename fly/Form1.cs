using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TravelApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, List<string>> cityFoodMap;
        private Dictionary<string, Dictionary<string, (int PlanePrice, int TrainPrice)>> travelPrices;

        public MainForm()
        {
            InitializeComponent();
            InitializeCityData();
            PopulateCityDropdowns();
        }

        private void InitializeCityData()
        {
            cityFoodMap = new Dictionary<string, List<string>>
            {
                { "������", new List<string> { "����", "��������", "�����", "��", "�������", "��������" } },
                { "�����-���������", new List<string> { "����������", "��������", "�����", "���", "������", "������ ��� �����" } },
                { "������", new List<string> { "��������", "��������", "���-���", "������", "���������", "����" } },
                { "������������", new List<string> { "�����", "��������� ��������", "��������", "�������", "�������", "�������" } },
                { "�����������", new List<string> { "��������� ��������", "�������", "������", "��������", "�����", "���������� ����" } },
                { "����", new List<string> { "��������", "�����������", "������", "��������", "�����", "�������" } },
                { "�����", new List<string> { "�������", "����", "�������", "�������", "���", "�����" } },
                { "������", new List<string> { "����������", "��������", "��������", "��������", "������", "������� � ��������" } },
                { "�������", new List<string> { "������������ �����", "��������", "������", "�������", "������� ����", "��������� �����" } },
                { "������", new List<string> { "�����������", "������ �� ������", "�����", "�������", "��", "�������� �� �������" } },
                { "�����", new List<string> { "������ � �����", "������� �������", "����� � ��������", "������������ ����", "����� ����������", "���� ������" } },
                { "������", new List<string> { "���������", "�����", "�����", "����", "�����", "����" } },
                { "���-������", new List<string> { "��������", "�������", "������", "�����", "���� ��-��������", "�����" } },
                { "�������", new List<string> { "�������", "�����", "����", "������", "����", "�����" } },
                { "���������", new List<string> { "����", "���� ��-��������", "�����", "����", "��������", "����" } },
                { "��������", new List<string> { "���������", "�����", "����", "������", "�����", "�����" } },
                { "�����", new List<string> { "�����", "�������", "��������", "�����", "���� � ����������", "�����" } },
                { "�����", new List<string> { "���� ��-��������", "������", "������� ���", "��� � ������", "���", "��� ����" } },
                { "������", new List<string> { "���������� ���", "����� ��� ���", "������� ����", "������ �����", "����-���", "����" } },
                { "�����", new List<string> { "������� �������", "��� ��", "��������� �����", "������� ���", "������", "��������" } },
                { "�����", new List<string> { "����������� �����", "�� ���", "����� � ��������", "����� �������", "�������", "����" } },
                { "��������", new List<string> { "��� ���", "�����", "������", "���� � ��������", "������� �����", "���� � ������" } },
                { "�������", new List<string> { "������� ����", "��� � �������", "��� � �����", "������� �����", "�������� � ��������", "�����" } },
                { "�������", new List<string> { "�����", "�������� �����", "��������� �����", "�������", "������� �������", "�������� �����" } },
                { "��������", new List<string> { "�������", "����", "��������� �����", "�������� ���", "������� � �������", "������� �����" } },
                { "������", new List<string> { "������", "������������ �����", "����������", "������� ������", "�������� �������", "�����" } },
                { "�������", new List<string> { "�����", "�����", "�������� ������", "�������", "������� ����", "��������" } },
                { "��������", new List<string> { "����", "�����", "�������� ��������", "��� �����", "�������", "�������� ���" } },
                { "������", new List<string> { "���������� ������", "�����", "������� � �������", "������� � ������", "������ ������", "��������" } }

            };

            travelPrices = new Dictionary<string, Dictionary<string, (int PlanePrice, int TrainPrice)>>();

            foreach (var fromCity in cityFoodMap.Keys)
            {
                travelPrices[fromCity] = new Dictionary<string, (int, int)>();
                foreach (var toCity in cityFoodMap.Keys)
                {
                    if (fromCity != toCity)
                    {
                        travelPrices[fromCity][toCity] = (new Random().Next(2000, 30000), new Random().Next(1000, 15000));
                    }
                }
            }
        }

        private void PopulateCityDropdowns()
        {
            var cities = cityFoodMap.Keys.ToList();
            comboBoxFrom.DataSource = new List<string>(cities);
            comboBoxTo.DataSource = new List<string>(cities);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fromCity = comboBoxFrom.SelectedItem?.ToString();
            string toCity = comboBoxTo.SelectedItem?.ToString();
            string viaCity = txtViaCity.Text;

            if (string.IsNullOrWhiteSpace(fromCity) || string.IsNullOrWhiteSpace(toCity))
            {
                MessageBox.Show("�������� ������ ����������� � ����������.");
                return;
            }

            string result = rbDirect.Checked
                ? GetDirectRoute(fromCity, toCity)
                : GetTransitRoute(fromCity, viaCity, toCity);

            txtResult.Text = result;
        }

        private string GetDirectRoute(string fromCity, string toCity)
        {
            if (!travelPrices[fromCity].ContainsKey(toCity))
                return "������ ������� ����������.";

            var prices = travelPrices[fromCity][toCity];
            var dishes = string.Join(", ", cityFoodMap[toCity]);

            string result = $"�� {fromCity} � {toCity}:\n" +
                            $"�������: {prices.PlanePrice} ���.\n";

            // ������� ��� �������
            if (IsCanadianCity(fromCity) || IsCanadianCity(toCity))
            {
                result += "�����: ����������.";
            }
            else
            {
                result += $"�����: {prices.TrainPrice} ���.";
            }

            result += $"\n������������� �����: {dishes}.";

            return result;
        }

        private string GetTransitRoute(string fromCity, string viaCitiesInput, string toCity)
        {
            if (string.IsNullOrWhiteSpace(viaCitiesInput))
                return "������� ���� �� ���� ����� ��� ���������.";

            var viaCities = viaCitiesInput.Split(',').Select(city => city.Trim()).ToList();

            if (viaCities.Any(city => !travelPrices.ContainsKey(city)))
                return "���� ��� ��������� ��������� ������� ��������� ����������.";

            // �������� �������� �� ���� ��������
            string currentCity = fromCity;
            List<string> routeDetails = new List<string>();
            foreach (var nextCity in viaCities.Append(toCity))
            {
                if (!travelPrices[currentCity].ContainsKey(nextCity))
                    return $"������� ����� {currentCity} � {nextCity} ����������.";

                var prices = travelPrices[currentCity][nextCity];
                string section = $"{currentCity} -> {nextCity}:\n" +
                                 $"�������: {prices.PlanePrice} ���.";

                if (!IsCanadianCity(nextCity))
                {
                    section += $", �����: {prices.TrainPrice} ���.";
                }
                else
                {
                    section += $", �����: ����������.";
                }

                routeDetails.Add(section);
                currentCity = nextCity;
            }

            var dishes = string.Join(", ", cityFoodMap[toCity]);

            return $"������� �� {fromCity} � {toCity} ����� {string.Join(", ", viaCities)}:\n\n" +
                   string.Join("\n\n", routeDetails) +
                   $"\n\n������������� ����� � {toCity}: {dishes}.";
        }

        private bool IsCanadianCity(string city)
        {
            var canadianCities = new List<string> { "�������", "��������", "������", "�������", "��������", "������" };
            return canadianCities.Contains(city);
        }
    }
}
