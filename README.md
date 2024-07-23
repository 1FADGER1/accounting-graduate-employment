# Web приложение для хранения данных о трудоустройстве выпускников
Данное веб приложение разрабатывалось для учебных целей. Было желание познакомится с ASP.Net и научиться работать с HTML, CSS и JavaScript 
## ТЗ для Web приложения
Веб-приложение ведёт учёт трудоустройства выпускников. По выпускникам мы храним следующую информацию:
1.	ФИО
2.	Дата рождения
3.	Пол
4.	Гражданство
5.	Адрес проживания (по КЛАДР)
6.	Телефон (с форматом)
7.	Электронная почта (с форматом)
8.	СНИЛС (с форматом)
9.	Код направления подготовки
10.	Название направления подготовки
11.	Профиль направления подготовки
12.	Год поступления
13.	Год окончания
14.	Форма обучения

Выпускник может работать, включая самозанятость, быть безработным, проходить службу в вооруженных силах.
Если он работает, то мы собираем по нему следующую информацию:
1.	Наличие трудовой книжки
2.	Место работы (полное название организации, ОКВЭД, ИНН, регион регистрации)
3.	Должность

Если он самозанятый, то указываем род деятельность.
Если он безработный, то указываем дату постановки на учёт.
Если он служит в ВС, то указываем, где и кем.
Система должна вести хронологию смены работ выпускника (переход между вариантами трудоустройства, службой в армии и т.д.), начиная с момента выпуска и далее с отметкой по дате смены статуса, например: 
- 30.06.21 Завершение обучения по направлению подготовки (указать).
- 01.08.21 Безработный, поставлен на учёт. 
- 01.10.21 Служба в ВС РФ, в/ч 66666, рядовой.
- 01.12.22 Трудоустройство в ООО "Рога и копыта", должность – инженер.
- 02.04.23 Трудоустройство в ЗАО "Тяпки и грабли", должность – техник.
- 01.05.23 Безработный, поставлен на учёт.

Система должна позволять выводить список работодателей (п.2 второго перечня).
Система должна иметь удобный для неопытного пользователя интерфейс.

## Инструменты разработки
ASP.Net, Entity Framework Core, PostgreSQL, HTML, CSS, JavaScript
