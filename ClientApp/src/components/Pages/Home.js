import React, { Component } from 'react';

function Home() {

    return (
      <div>
        <h1>Тестовое задание ITPDevelopment</h1>
          <h3>Для перехода к просмотру нажмите вкладку DashBoard</h3>
        <ul>
          <li>Backend : <strong>ASP.NET CORE MVC | EF CORE | </strong></li>
          <li>Frontend : <strong>React | JS | Bootstrap | Native-css</strong></li>
          <li>DB: <strong>MSSQL</strong></li>
        </ul>
          <p>Краткое руководство :</p>
        <ul>
          <li><strong>Создание проекта</strong>: Введите название проекта в input и нажмите кнопку "Create project" и вы сможете выбрать его в dropdown menu</li>
          <li><strong>Создание задачи</strong>: Нажмите кнопку "Create task" и введите необходимые данные</li>
          <li><strong>Редактирование задачи</strong>: Нажмите на задачу которую вы хотите отредактировать и вас перенаправит на страницу редактирования, далее заполните необходимые поля и нажмите "Edit task"</li>
        </ul>
          <p>Я являюсь Junior DotNet разработчиком и буду рад если вы дадите развернутый фидбек</p>
          <p>Надеюсь вы оцените мое тестовое задание и пригласите на тех. собеседование</p>
          <p>Хорошего дня!</p>
      </div>
    );
}

export default Home;