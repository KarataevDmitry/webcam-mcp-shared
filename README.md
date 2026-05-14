# WebcamMcp.Shared

Лицензия: **MIT** — см. [LICENSE](LICENSE).

Общая библиотека для [webcam-capture-mcp](../webcam-capture-mcp) и [webcam-analysis-mcp](../webcam-analysis-mcp): разбор аргументов MCP-тулов, константы путей `.cascade-ide\...`, классификация движения для `analyze_burst_sequence`.

Собирается как зависимость; отдельный publish не требуется.

## NuGet

Пакет: **`AIGuiders.WebcamMcp.Shared`** ([nuget.org](https://www.nuget.org/packages/AIGuiders.WebcamMcp.Shared)). Установка:

```bash
dotnet add package AIGuiders.WebcamMcp.Shared
```

Публикация на nuget.org — **Trusted Publishing (OIDC)** из GitHub Actions; workflow: `.github/workflows/nuget-publish.yml` (тег `v*` или ручной запуск с версией).

## Расположение

Репозиторий задуман как **соседний каталог** с обоими MCP:

```text
open/
  webcam-mcp-shared/
  webcam-capture-mcp/   → ProjectReference ..\webcam-mcp-shared\...
  webcam-analysis-mcp/  → ProjectReference ..\webcam-mcp-shared\...
```
