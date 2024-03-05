# SeleniumInitialize

Набор задач для реализации по теме "Инициализация Selenium WebDriver"
Методы для данной задачи реализуются в классе SeleniumBuilder.cs по паттерну Builder (Строитель)

## Задача № 1:

Запустить ChromeDriver, вернув экземпляр, реализующий интерфейс IWebDriver для проверке в тесте BuildTest1, запустить тест, удостовериться в правильной инициализации.
По завершению этого теста браузер не закроется и chromedriver.exe останется в процессах. Найдите процесс и закройте вручную или с помощью кода.

## Задача № 2:

Реализовать метод Dispose интерфейса IDisposable, чтобы освободить нетронутые сборщиком мусора ресурсы. 
Текущие состояние ресурсов (освобождены или нет) должно	быть зафиксировано в переменной IsDisposed.
Исполнить тест DisposeTest1.
После прохождения тестов добавить TearDown метод (NUnit), чтобы ресурсы освобождались после каждого теста.

## Задача № 3:

Реализовать метод ChangePort класса SeleniumBuilder, чтобы можно было изменить порт для экземпляра драйвера. 
В решении данной задачи будет использоваться класс DriverService соответствующего драйвера. Ознакомиться с методами и свойствами данного класса.
Необходимо добавить код, меняющий состояние свойства Port класса SeleniumBuilder для отслеживания порта после изменения.
Пройти тесты: PortTest1, PortTest2

## Задача № 4:

Реализовать метод SetArgument класса SeleniumBuilder, чтобы можно было добавить специфичные аргументы для запускаемого браузера.
Изменения в аргументах необходимо отобразить в свойстве ChangedArguments для отслеживания.
Пройти тест ArgumentTest1.

## Задача № 5: 

Запустить браузер в headless режиме. Этого можно добиться несколькими способами.
Самостоятельно добавьте свойство для отслеживания состояния headless в класс SeleniumBuilder и напишите тест для проверки запуска в данном режиме.
Для наглядности рекомендую отслеживать процессы в диспетчере задач, поскольку при headless запуске никаких визуальных следов браузера быть видно не должно.

## Задача № 6:

Добавить настройки пользователя. Реализовать метод SetUserOption класса SeleniumBuilder.
Все изменения отслеживать в свойстве ChangedUserOptions.
Пройти тесты: UserOptionTest, UserOptionStressTest

### Примечание: Задания 7 и 8 можно реализовать с помощью манипулирования объектами Options и DefaultService или же с помощью изменения процесса инициализации в методе Build().
### Выбирайте способ, который вам более предпочтителен, на подумать: почему вы считаете этот способ более верным? Для интереса можно попробовать оба способа.

## Задача № 7: Запустить с заданным таймаутом.
Реализовать метод WithTimeout класса SeleniumBuilder с целью запускать браузер с заданным параметром ожидания элементов.
Изменение таймаута отслеживать в свойстве Timeout.
Пройти тест - TimeoutTest

## Задача № 8: Запустить с заданным URL.
Реализовать метод WithURL класса SeleniumBuilder с целью запускать браузер с заданным параметром стартового URL.
Изменение стартового URL отслеживать в свойстве URL.
Пройти тест - URLTest

В качестве итога по всем задачам пройти тест ComplexTest
