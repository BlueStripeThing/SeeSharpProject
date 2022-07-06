# SeeSharpProject

Данный проект выполнил Проничев Владислав, в рамках курсовой работы по курсам SeeSharp. 
При указании пути к файлу, рекомендуется не пользоваться путем, который генерирует проводник, так как иногда приложение его не видит. 
При обновлении файла с данными и желанием обновить данные в приложении, ледует сохранить и закрыть файл источник.

Реализованные функциональные требования:
1. Начальный уровень
Создано приложение принимающее в себя .txt файл, обрабатывая его Default-декодировкой. 
Для передачи файла следует указать его путь в соответствующем поле и загрузить из него данные.
Реализован функционал дешифровки сообщения и возможности сохранения в отдельный файл текстовый файл. 
Шифровка происходит методом Виженера, и работает только на русский алфавит. Изменения регистра символов сообщения не проиходит.
Для сохранения в формате .txt выбирается путь указанный в поле пути.


2. Ожидаемый результат
Приложение позволяет дешифровать и зашифровывать сообщения с указанием своего собственного ключа и возможность сохранять результаты в отдельный файл. 
Методы шифровки и дешифровки покрыты юнит-тестами

3. Продвинутый результат.
При указании файла формата .docx/.doc, также будет загружена незашифрованная информация. 
Результат шифрования возможно сохранить в виде .docx файла, при указании данного расширения в пути сохранения. 
Однако будет произведено уточнение сохранения пути, посредством выбора места сохранения и названия файла через проводник системы.
