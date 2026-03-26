# Bug Reports

## BUG-001: Role is derived from password instead of database role
- **Severity:** Critical
- **Environment:** `PetShopApp` (WinForms), PostgreSQL database `Зоомагазин`
- **Preconditions:** User exists in `Users` with `Role = Storekeeper`
- **Steps to reproduce:**
  1. Set user password value starting with `admin` (for example, `admin123`).
  2. Log in with this user.
  3. Observe opened main form.
- **Expected result:** Application should use `Users.Role` from DB and open `StorekeeperMainForm`.
- **Actual result:** Application sets role from password prefix and opens admin flow.
- **Affected code:** `PetShopApp/Authorization/Login.cs`
- **Notes:** Authorization escalation risk.

## BUG-002: Registration role assignment is based on password prefix
- **Severity:** Critical
- **Environment:** `PetShopApp` (WinForms), PostgreSQL database `Зоомагазин`
- **Preconditions:** Registration form is open.
- **Steps to reproduce:**
  1. Register a new user with password starting with `admin`.
  2. Check inserted row in `Users`.
- **Expected result:** Role should be explicitly selected by business logic/admin policy, not inferred from password.
- **Actual result:** `Role` is automatically set to `Admin` when password starts with `admin`.
- **Affected code:** `PetShopApp/Authorization/Registration.cs`
- **Notes:** Security defect; easy privilege escalation.

## BUG-003: Passwords are stored and compared as plain text
- **Severity:** High
- **Environment:** `PetShopApp` (WinForms), PostgreSQL database `Зоомагазин`
- **Preconditions:** Existing user in DB.
- **Steps to reproduce:**
  1. Register a user.
  2. Open table `Users` in DB.
  3. Compare login query behavior.
- **Expected result:** Passwords should be stored hashed and verified via secure hash comparison.
- **Actual result:** `PasswordHash` contains raw password value; login compares plain text.
- **Affected code:** `PetShopApp/Authorization/Registration.cs`, `PetShopApp/Authorization/Login.cs`
- **Notes:** Data breach impact and compliance issue.

## BUG-004: Category deletion creates orphan product data
- **Severity:** Medium
- **Environment:** `PetShopApp` (WinForms), PostgreSQL database `Зоомагазин`
- **Preconditions:** Products exist with `CategoryName = 'Кошки'`.
- **Steps to reproduce:**
  1. Delete category `Кошки` via category UI.
  2. Open product list.
- **Expected result:** Deletion should be blocked, cascaded safely, or products should be updated consistently.
- **Actual result:** Category is removed while products keep stale `CategoryName`.
- **Affected code:** `PetShopApp/Database/CategoryRepository.cs`
- **Notes:** Data integrity issue due to string-based relation without FK.

## BUG-005: No DB-level uniqueness guarantee for username
- **Severity:** Medium
- **Environment:** `PetShopApp` (WinForms), PostgreSQL database `Зоомагазин`
- **Preconditions:** Two parallel registrations with the same username.
- **Steps to reproduce:**
  1. Run two registration attempts nearly simultaneously for same `Username`.
  2. Commit both requests.
- **Expected result:** DB unique constraint should prevent duplicates.
- **Actual result:** App checks uniqueness in code only (`Any(...)`), race condition remains.
- **Affected code:** `PetShopApp/Authorization/Registration.cs`, DB schema for `Users`
- **Notes:** Requires DB unique index on `Users.Username`.

## BUG-006: Add/Edit product flows do not support stock quantity
- **Severity:** High
- **Requirement source:** ТС-05, ТС-06
- **Steps to reproduce:**
  1. Open Add product form.
  2. Check available inputs.
  3. Open Edit product form.
  4. Check available inputs.
- **Expected result:** Forms should allow entering and editing product quantity/stock.
- **Actual result:** Forms contain fields for article/name/category/unit/price only; quantity field is missing.
- **Affected code:** `PetShopApp/ProductWindow/AddProduct.cs`, `PetShopApp/ProductWindow/EditProduct.cs`, `PetShopApp/Database/ProductRepository.cs`

## BUG-007: Delete product flow has no confirmation dialog
- **Severity:** Medium
- **Requirement source:** ТС-07
- **Steps to reproduce:**
  1. Open delete product form.
  2. Delete product by article.
- **Expected result:** Confirmation dialog ("Вы уверены...?") with Yes/No before deletion.
- **Actual result:** Product is deleted immediately after action in the form; no confirmation stage.
- **Affected code:** `PetShopApp/ProductWindow/DeleteProduct.cs`, `PetShopApp/Database/ProductRepository.cs`

## BUG-008: No "Product info card" feature for storekeeper
- **Severity:** Medium
- **Requirement source:** ТС-11
- **Steps to reproduce:**
  1. Open storekeeper main form.
  2. Try to find "Информация о товаре" action.
- **Expected result:** User can open a detailed product card with extended attributes.
- **Actual result:** UI has list/search and shipment only; no product details action or screen.
- **Affected code:** `PetShopApp/MainForms/StorekeeperMainForm.cs`

## BUG-009: Test scenarios rely on named products absent in seeded data
- **Severity:** Medium
- **Requirement source:** ТС-07, ТС-08, ТС-11, ТС-12, ТС-13
- **Steps to reproduce:**
  1. Search products `Корм Феликс 5 кг`, `ProBalance 5 кг`, `Pro Plan 10 кг`.
- **Expected result:** Products exist for scenario execution.
- **Actual result:** These exact product names are not present in the current seed set.
- **Affected area:** Seed/test data consistency
- **Notes:** Add test fixtures or adapt scenarios to actual test catalog.
