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
                { "Москва", new List<string> { "Борщ", "Пельмени", "Блины", "Щи", "Холодец", "Кулебяка" } },
                { "Санкт-Петербург", new List<string> { "Рассольник", "Кулебяка", "Пышки", "Уха", "Оливье", "Селёдка под шубой" } },
                { "Казань", new List<string> { "Эчпочмак", "Кыстыбый", "Чак-чак", "Токмач", "Бишбармак", "Казы" } },
                { "Екатеринбург", new List<string> { "Шанги", "Уральские пельмени", "Вареники", "Солянка", "Голубцы", "Окрошка" } },
                { "Новосибирск", new List<string> { "Сибирские пельмени", "Солянка", "Жаркое", "Кулебяка", "Харчо", "Гурьевская каша" } },
                { "Сочи", new List<string> { "Хачапури", "Аджапсандал", "Шашлык", "Чебуреки", "Лобио", "Кубдари" } },
                { "Минск", new List<string> { "Драники", "Квас", "Сырники", "Мачанка", "Жур", "Кныши" } },
                { "Гродно", new List<string> { "Полендвица", "Зубровка", "Верещака", "Кулебяка", "Кисель", "Пирожки с капустой" } },
                { "Витебск", new List<string> { "Картофельная бабка", "Холодник", "Пироги", "Галушки", "Печёная рыба", "Гречневые блины" } },
                { "Гомель", new List<string> { "Крамбамбуля", "Тартар из селёдки", "Кулеш", "Медовик", "Щи", "Рулетики из капусты" } },
                { "Брест", new List<string> { "Пироги с мясом", "Тушеная капуста", "Салат с горчицей", "Картофельное пюре", "Салат «Витебский»", "Торт «Брест»" } },
                { "Алматы", new List<string> { "Бешбармак", "Кумыс", "Шужык", "Казы", "Айран", "Курт" } },
                { "Нур-Султан", new List<string> { "Бауырсак", "Куырдак", "Шилпек", "Кеспе", "Мясо по-казахски", "Карта" } },
                { "Шымкент", new List<string> { "Куырдак", "Айран", "Казы", "Лагман", "Мант", "Кумыс" } },
                { "Караганда", new List<string> { "Курт", "Мясо по-казахски", "Шурпа", "Плов", "Бауырсак", "Сало" } },
                { "Павлодар", new List<string> { "Бешбармак", "Карта", "Плов", "Шашлык", "Кумыс", "Айран" } },
                { "Тараз", new List<string> { "Айран", "Куырдак", "Бауырсак", "Кумыс", "Мясо с картофелем", "Шурпа" } },
                { "Пекин", new List<string> { "Утка по-пекински", "Димсам", "Жареный рис", "Суп с лапшой", "Бао", "Чоу мейн" } },
                { "Шанхай", new List<string> { "Шанхайский суп", "Лапша Дан Дан", "Жареная утка", "Спринг роллы", "Бабл-чай", "Тофу" } },
                { "Сиань", new List<string> { "Жареная свинина", "Том ям", "Китайские блины", "Сладкий суп", "Фондан", "Пельмени" } },
                { "Чэнду", new List<string> { "Сычуаньская кухня", "Хо гоу", "Лапша с кунжутом", "Дунпо свинина", "Цзяоцзы", "Хого" } },
                { "Гуанчжоу", new List<string> { "Дим сам", "Фенси", "Улитки", "Рыба с кунжутом", "Медовые ребра", "Тофу с перцем" } },
                { "Гонконг", new List<string> { "Жареная утка", "Чай с молоком", "Рис с яйцом", "Рисовая лапша", "Пирожные с ананасом", "Блины" } },
                { "Торонто", new List<string> { "Путин", "Кленовый сироп", "Канадский бекон", "Чизкейк", "Ягодные маффины", "Кленовые орехи" } },
                { "Монреаль", new List<string> { "Бублики", "Квас", "Канадские кексы", "Кленовый чай", "Чизкейк с сиропом", "Соленый бекон" } },
                { "Оттава", new List<string> { "Пироги", "Картофельные вафли", "Гамбургеры", "Сладкие оладьи", "Кленовые пряники", "Путин" } },
                { "Калгари", new List<string> { "Стейк", "Блины", "Кленовый пудинг", "Чизкейк", "Сладкий кофе", "Пельмени" } },
                { "Ванкувер", new List<string> { "Суши", "Лапша", "Молочный коктейль", "Чай латте", "Печенье", "Кленовый мед" } },
                { "Квебек", new List<string> { "Квебекский пудинг", "Блины", "Чизкейк с сиропом", "Печенье с кленом", "Мясные рулеты", "Пельмени" } }

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
                MessageBox.Show("Выберите города отправления и назначения.");
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
                return "Прямой маршрут недоступен.";

            var prices = travelPrices[fromCity][toCity];
            var dishes = string.Join(", ", cityFoodMap[toCity]);

            string result = $"Из {fromCity} в {toCity}:\n" +
                            $"Самолет: {prices.PlanePrice} руб.\n";

            // Условие для поездов
            if (IsCanadianCity(fromCity) || IsCanadianCity(toCity))
            {
                result += "Поезд: недоступен.";
            }
            else
            {
                result += $"Поезд: {prices.TrainPrice} руб.";
            }

            result += $"\nРекомендуемые блюда: {dishes}.";

            return result;
        }

        private string GetTransitRoute(string fromCity, string viaCitiesInput, string toCity)
        {
            if (string.IsNullOrWhiteSpace(viaCitiesInput))
                return "Введите хотя бы один город для пересадки.";

            var viaCities = viaCitiesInput.Split(',').Select(city => city.Trim()).ToList();

            if (viaCities.Any(city => !travelPrices.ContainsKey(city)))
                return "Один или несколько указанных городов пересадки недоступны.";

            // Проверка маршрута на всех участках
            string currentCity = fromCity;
            List<string> routeDetails = new List<string>();
            foreach (var nextCity in viaCities.Append(toCity))
            {
                if (!travelPrices[currentCity].ContainsKey(nextCity))
                    return $"Маршрут между {currentCity} и {nextCity} недоступен.";

                var prices = travelPrices[currentCity][nextCity];
                string section = $"{currentCity} -> {nextCity}:\n" +
                                 $"Самолет: {prices.PlanePrice} руб.";

                if (!IsCanadianCity(nextCity))
                {
                    section += $", Поезд: {prices.TrainPrice} руб.";
                }
                else
                {
                    section += $", Поезд: недоступен.";
                }

                routeDetails.Add(section);
                currentCity = nextCity;
            }

            var dishes = string.Join(", ", cityFoodMap[toCity]);

            return $"Маршрут из {fromCity} в {toCity} через {string.Join(", ", viaCities)}:\n\n" +
                   string.Join("\n\n", routeDetails) +
                   $"\n\nРекомендуемые блюда в {toCity}: {dishes}.";
        }

        private bool IsCanadianCity(string city)
        {
            var canadianCities = new List<string> { "Торонто", "Монреаль", "Оттава", "Калгари", "Ванкувер", "Квебек" };
            return canadianCities.Contains(city);
        }
    }
}
