# Shop backend

Бэкенд интернет-магазина и web api для 'shop-frontend'

## Разработка

### Сборка проекта

- Если вы используете Visual Studio
  - Добавить все неуставновленные пакеты NuGet
  - Выполнить команду ``` update-database ```, чтобы выполнить миграции
  - Запустить проект через IDE

- Запустить проект через терминал
  ```
  dotnet restore
  dotnet ef database update
  dotnet build
  dotnet run
  ```

#### Назначение веток:

* `master` - ветка с рабочим, оттестированным кодом. Не должна иметь своих коммитов,
  только мёрджи отдельных веток
* `feature` - ветки - ветки для разработки фич.
* `fix` - ветки - ветки для фикса багов.
