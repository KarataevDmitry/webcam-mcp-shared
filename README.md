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

## Расположение в монорепо (опционально)

Раньше оба MCP тянули **webcam-mcp-shared** как соседний каталог (`ProjectReference`). Сейчас зависимость — **NuGet** `AIGuiders.WebcamMcp.Shared`. Репозиторий [webcam-mcp-shared](https://github.com/KarataevDmitry/webcam-mcp-shared) остаётся источником кода пакета.

```text
open/
  webcam-capture-mcp/   → PackageReference AIGuiders.WebcamMcp.Shared
  webcam-analysis-mcp/  → PackageReference AIGuiders.WebcamMcp.Shared
```
