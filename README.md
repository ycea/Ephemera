## Что это такое (Руководство для пользователя)
Это программа представляет собой подобие Paint, художественная. Изначально дается 4 цвета. Эти 4 цвета можно между собой смешивать (не все цвета можу меду собой соединять). Каждый цвет представляет собой уникальный элемент. 
Огонь, вода, земля и камень.
### Что нажимать
на форме справа есть 4 кнопки покрашенные в цвета, их нужно нажимать для смена цвета кисточки. Ниже находится кнопка в виде треугольника, после нажатия на нее картинка "Оживет". После нажатия на кнопку с квадратиком
черным картинка очиститься. Ниже поле с числом, это размер кисточки
## Руководство разработчика
Скажу только основное

Структура:
* есть папка с Elements, она собственно хранит в себе элементы. Внутри базовый элемент, абстрактный класс от которого все наследуются
* Есть папка с перечислениями (игра основана на состояниях).
* Есть папка с менеджерами, они отвечают за цикл игры, за обновление элементов, контроль коллизий
* Основная форма, которая оркестрирует всем этим.
  
Для управления поведением всех элементов в общем стоит корректировать базовый класс элементов.

## Как установить и запустить
Если вам интересно потрогать чисто приложение, то вот ссылка на скачивание [папки](https://drive.google.com/drive/folders/1bzyAlJvODvoBnnvTO0CBSQo0U8oqVR68?usp=sharing)

Если же вы хотите поиграться с кодом приложения, то вам потребуется visual studio с установленным .NET 9.0 (по крайней мере я разрабатывал на этой платформе, поэтому она работать точно должна). 

Вы можете скачать как просто Zip папку так и импортировать через гит (указать эту ссылку: https://github.com/ycea/ResourceMarket.git). Также возможны проблемы с безопасностью файла, поэтому я советую вам сделать форк репозитория и скачать уже его как свой репозиторий (импортировать через Visual Studio). 
Visual Studio скорее всего заблокирует форму и не даст собрать проект. Для решения этой проблемы нужно войти в PowerShell и ввести вот эти команды:
```
Unblock-File -Path "{Путь куда вы распаковали}\Ephemera-master\MainForm.resx"
Unblock-File -Path "{Путь куда вы распаковали}\Projects\Ephemera-master\Properties\Resources.resx"
```
Вуаля  и у вас без проблем должна собраться форма.

## Я открыт к любому фидбеку
