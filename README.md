### Stepik course on Design in C # (SKB Kontur)

### Photoshop
Задание: Рефакторинг с выделением класса

### FailureReportMaker
Практика «Сбои»
Некто N. написал код, выводящий список устройств, в которых за последний месяц до определенной даты случились критические сбои. К сожалению, N. учился программированию в начале 90-х годов, и не знаком с современными практиками.

Скачайте проект Incapsulation.Failures и помогите N. отрефакторить его код:

Выделите новый статический метод FindDevicesFailedBeforeDate. Метод должен принимать не более 4-х аргументов. В сигнатуре метода не должно быть Dictionary - типов и коллекций с вложенными дженерик - типами, например, List<List<object>>.
Данные из аргументов devices и failureTypes должны быть инкапсулированы в сущности Device и Failure.
IsFailureSerious, очевидно, не на своем месте.
С day и times тоже не все в порядке.
Сигнатуру старого метода сохраните, чтобы проходили тесты. Старый метод должен преобразовывать аргументы и вызывать новый метод.

### EnterpriseTask
Практика «Предприятие»
Некто M. написал код, описывающий предприятие. Он даже озаботился проверкой целостности для полей этого класса, но, к сожалению, он учился программировать в конце 90-х годов, и знаком лишь со слегка устаревшими практиками проверки целостности.

Скачайте проект Incapsulation.EnterpriseTask и помогите M. отрефакторить его код.

### IncapsulationWeights
Практика «Веса»
Нейронная сеть состоит из нейронов, каждый из которых имеет вектор весов. Иногда нужно иметь доступ к весам отдельных нейронов, например, при их инициализации. Однако, при разработке алгоритмов обучения оказывается удобным работать со всеми весами в сети как с единым вектором. Таким образом, нужно организовать различные виды доступа к одним и тем же данным.

Скачайте проект Incapsulation.Weights и напишите класс Indexer, который создается как обертка над массивом double[], и открывает доступ к его подмассиву некоторой длины, начиная с некоторого элемента. Ваше решение должно проходить тесты, содержащиеся в проекте. Как и всегда, вы должны следить за целостностью данных в Indexer.

### Incapsulation.RationalNumbers
Практика «Рациональные числа»
При работе над математическими или геометрическими задачами часто приходится создавать "фундаментальные" классы, подобные int или double, для комплексных чисел, кватернионов и т.д. Скачайте проект Incapsulation.RationalNumbers и напишите класс рационального числа.

Ваше решение должно проходить тесты, содержащиеся в проекте.
