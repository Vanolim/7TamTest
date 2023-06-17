# 7TamTest
Тестовое задание студии 7Tam.

![hippo](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExODkyYWMxNzJmNjViYTdlM2Q4MjNkMDFlZTA4ZWZhYTIxMzViMDlkNCZlcD12MV9pbnRlcm5hbF9naWZzX2dpZklkJmN0PWc/hPbYbRqTe1YvPlanU2/giphy.gif)

<details>
<summary>Задание</summary>
<br>
Задача
1)  Создать 2D игру для Android на Unity, где 2 и более игроков с
разных Android устройств смогут зайти в лобби;
2) Обязательно использовать следующую версию Unity 2021.3.9f1.

Требования к игре
Сцены
1) В игре должны присутствовать 3 сцены: Loading, Lobby, Game.
Описание стека технологий
2) Для выполнения задания можно использовать любой бесплатный
сетевой движок и облачный сервис для создания масштабируемых
кроссплатформенных многопользовательских игр.
Лобби
1) В лобби должна быть возможность создать комнату и войти в неё,
а также подключиться к комнате, уже созданной другим игроком.
Сцена лобби: есть два поля с кнопками, в одно поле игрок может
написать название комнаты, а затем нажать кнопку “Создать”, в
другом поле игрок пишет название созданной комнаты, нажимает
кнопку "Войти" и ждет, когда на другом девайсе другой игрок
войдет в комнату с тем же названием.
Игровой процесс
2) После входа в комнату игроки попадают на боевой сервер и
начинается игровой процесс. Есть поле, ограниченное размером
экрана, на нем разбросаны лутабельные монеты, которые каждый
игрок может собрать;
3) Когда на игровом поле появляются минимум 2 игрока, каждый из
них имеет способность поворачиваться и перемещаться в
определенную сторону, а также стрелять в том направлении куда
смотрит. Для управления игроком используется экранный
виртуальный джойстик;
4) Игрок имеет полосу здоровья и шкалу сбора монет;
5) Если в игрока попадает снаряд, который выпустил другой игрок,
шкала здоровья уменьшается;
6) Игроки должны визуально отличаться друг от друга (имя, цвет или
изображение);
7) Игра заканчивается, когда в живых останется 1 игрок. После этого
появляется победный pop-up с информацией, где указаны имя
победителя и сколько монет он собрал.
</details>

# Основные особенности проекта:
1) Сетевая игра построенная на Photon.
2) Несмотря на Photon зависимости передаются с помощью Zenject.
3) Игра имеет лобби для установки ника игрока, создании и присоединения к комнате
<details>
<summary>Лобби</summary>
<br>
<img width="458" alt="image" src="https://github.com/Vanolim/7TamTest/assets/60060770/87303522-3476-44f6-9bbb-dbcb8328822c">
</details>

4)Есть система рейтинга, которая отображается в конце сессии комнаты
<details>
<summary>Лобби</summary>
<br>
<img width="458" alt="image" src="https://github.com/Vanolim/7TamTest/assets/60060770/455ad90d-019f-47ba-b821-c1c6813fea9c">
</details>

# Плагины, использованные в проекте:
1) DOTween
2) TextMeshPro
3) Photon
4) Zenject
