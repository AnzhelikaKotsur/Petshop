# Test Report

## Scope covered
- Build verification of application after EF migration.
- Database structure checks for `Users`, `Categories`, `Products`.
- Exploratory code-based QA review for authentication and data integrity flows.
- Scenario-based requirement verification from `Тестовые сценарии (1).docx`.

## Executed checks
- Application build: passed (`Debug`).
- Seeded data presence: `Categories = 8`, `Products = 50`.
- Manual DB checks: table structure and mappings are consistent with EF attributes.
- Unit tests: `12/12` passed (`PetShopApp.Tests`).

## Scenario coverage (ТС-01..ТС-13)
- **ТС-01 Успешная регистрация:** `PASS` (happy path implemented; user creation and success message exist).
- **ТС-02 Несовпадающие пароли:** `PASS` (validation message implemented).
- **ТС-03 Успешная авторизация:** `FAIL` (role behavior differs; app derives role from password prefix).
- **ТС-04 Неверный пароль:** `PASS` (shows "Неверный логин или пароль", main form does not open).
- **ТС-05 Создание карточки товара:** `FAIL` (scenario expects quantity input and realtime stock result; quantity field absent in add form).
- **ТС-06 Редактирование товара:** `FAIL` (scenario expects quantity editing; edit form has no stock field).
- **ТС-07 Удаление товара:** `FAIL` (scenario requires confirmation dialog; not implemented).
- **ТС-08 Оформление отгрузки:** `PARTIAL PASS` (shipment exists and decreases stock, but test data product names differ).
- **ТС-09 Просмотр списка товаров (кладовщик):** `PASS` (main grid with products and stock is present).
- **ТС-10 Просмотр списка товаров (админ):** `PASS` (main grid with products and stock is present).
- **ТС-11 Просмотр информации о товаре:** `FAIL` (no "Информация о товаре" feature in UI).
- **ТС-12 Множественная отгрузка разных товаров:** `PARTIAL PASS` (flow supported, but exact product fixtures differ).
- **ТС-13 Отгрузка > остатка:** `PASS` (insufficient stock error branch implemented in shipment logic).

## Limitations
- GUI end-to-end interaction was not automated in this run; scenario verdicts are based on implemented behavior analysis plus data checks.

## Artifacts
- Bug reports: `QA/bug-reports.md`
- Unit tests: `PetShopApp.Tests/*`
- Extracted scenarios (working copy): `QA/test-scenarios-clean.txt`
