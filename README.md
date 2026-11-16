Тестовое задание. API для клиентов и их учредителей на ASP.NET Core 8 и PostgreSQL.

Для запуска нужны .NET 8 SDK и Docker. Из папки с ClientRegistry.slnx:

```sh
docker compose up -d
dotnet tool restore
dotnet ef database update --project DataAccess --startup-project Api
dotnet run --project Api --launch-profile https
```

Swagger: https://localhost:7012/swagger

Тип клиента: `1` - юрлицо, `2` - ИП. У ИП учредителей нет.

Методы API:

- GET /api/clients — список клиентов.
- GET /api/clients/{id} — клиент по ID вместе с учредителями.
- POST /api/clients — создать клиента.
- PUT /api/clients/{id} — обновить клиента и его учредителей.
- DELETE /api/clients/{id} — удалить клиента вместе с учредителями.

В PUT передаётся весь список учредителей. Для существующих нужно указывать id, для новых не нужно. Учредители, которых убрали из списка, удалятся.