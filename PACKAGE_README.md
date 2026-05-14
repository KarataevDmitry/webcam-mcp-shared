# AIGuiders.WebcamMcp.Shared

Небольшая библиотека **без зависимости от MCP SDK**: общие вещи для серверов **webcam-capture-mcp** и **webcam-analysis-mcp** — разбор аргументов инструментов из JSON (`ToolArgs`), константы путей вывода под workspace (`.cascade-ide\…`, `McpDefaults`), грубая классификация движения по скору для `analyze_burst_sequence` (`MotionAnalysis`).

**Целевой фреймворк:** .NET 10 (`net10.0`). **Лицензия:** MIT.

## Установка

```bash
dotnet add package AIGuiders.WebcamMcp.Shared
```

Пакет на NuGet: [AIGuiders.WebcamMcp.Shared](https://www.nuget.org/packages/AIGuiders.WebcamMcp.Shared). Исходники: [github.com/KarataevDmitry/webcam-mcp-shared](https://github.com/KarataevDmitry/webcam-mcp-shared).

## Зачем

Два MCP-сервера делят один контракт путей и один стиль разбора опциональных полей из `arguments` у MCP-тула — чтобы не дублировать парсинг и магические строки в двух репозиториях.

## Пример

```csharp
using System.Text.Json;
using WebcamMcp.Shared;

var args = /* IReadOnlyDictionary<string, JsonElement> from MCP */;
var workspace = ToolArgs.GetRequiredString(args, "workspace_path");
var duration = ToolArgs.GetOptionalInt(args, "duration_sec", McpDefaults.DefaultBurstDurationSec);
var motion = MotionAnalysis.ClassifyMotion(12.3); // "low", "medium", …
```

Подробности — в XML-комментариях в репозитории.
