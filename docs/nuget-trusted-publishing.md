# NuGet Trusted Publishing (OIDC) для этого репозитория

Чеклист для пакета **`AIGuiders.WebcamMcp.Shared`** на [nuget.org](https://www.nuget.org/).

## 1. NuGet.org → Trusted publishers

1. **Account settings** → **Trusted publishers** (или страница пакета → **Manage**).
2. Добавить **GitHub**.
3. Указать:
   - **Owner:** `KarataevDmitry`
   - **Repository:** `webcam-mcp-shared` (имя репозитория на GitHub, не PackageId).
   - **Workflow filename:** `nuget-publish.yml`

Справка: [Trusted publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing).

## 2. Субъект NuGet в workflow

В `.github/workflows/nuget-publish.yml` шаг **NuGet/login** с `user: LonelySoul` — учётная запись NuGet.org, под которой заведены пакеты `AIGuiders.*`. При другом пользователе замени `user`.

## 3. Первый релиз

- Тег **`v0.1.0`** → версия пакета **`0.1.0`**, или
- **Actions** → **Publish to NuGet** → *Run workflow* → поле **package_version**.

Нужны права `permissions: id-token: write` в workflow (уже задано).

## 4. Проверка

После успешного job: [страница пакета](https://www.nuget.org/packages/AIGuiders.WebcamMcp.Shared) и тестовый `dotnet add package AIGuiders.WebcamMcp.Shared`.

## 5. Потребители

После публикации **webcam-capture-mcp** и **webcam-analysis-mcp** можно перевести с `ProjectReference` на соседнюю папку на **`PackageReference`** этой версии (как для `AIGuiders.DotNetBuildTestParsers`).
