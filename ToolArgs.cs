using System.Text.Json;

namespace WebcamMcp.Shared;

public static class ToolArgs
{
    public static string GetRequiredString(IReadOnlyDictionary<string, JsonElement> args, string key)
    {
        if (!args.TryGetValue(key, out var raw))
        {
            throw new ArgumentException($"{key} is required.");
        }

        var value = raw.GetString();
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{key} is required.");
        }

        return value;
    }

    public static int GetOptionalInt(IReadOnlyDictionary<string, JsonElement> args, string key, int fallback)
    {
        if (!args.TryGetValue(key, out var raw))
        {
            return fallback;
        }

        return raw.ValueKind == JsonValueKind.Number && raw.TryGetInt32(out var value)
            ? value
            : fallback;
    }

    public static int? GetOptionalMonitorNumber(IReadOnlyDictionary<string, JsonElement> args, string key)
    {
        if (!args.TryGetValue(key, out var raw))
        {
            return null;
        }

        if (raw.ValueKind == JsonValueKind.Number && raw.TryGetInt32(out var numeric))
        {
            if (numeric == 0)
            {
                return null;
            }

            if (numeric > 0)
            {
                return numeric;
            }

            throw new ArgumentException($"{key} must be a positive monitor number or 'all'.");
        }

        if (raw.ValueKind == JsonValueKind.String)
        {
            var value = raw.GetString()?.Trim();
            if (string.IsNullOrWhiteSpace(value) || string.Equals(value, "all", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (int.TryParse(value, out var parsed) && parsed > 0)
            {
                return parsed;
            }

            throw new ArgumentException($"{key} must be a positive monitor number or 'all'.");
        }

        throw new ArgumentException($"{key} must be a positive monitor number or 'all'.");
    }

    public static bool GetOptionalBool(IReadOnlyDictionary<string, JsonElement> args, string key, bool fallback)
    {
        if (!args.TryGetValue(key, out var raw))
        {
            return fallback;
        }

        return raw.ValueKind switch
        {
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            _ => fallback
        };
    }

    public static double GetOptionalDouble(IReadOnlyDictionary<string, JsonElement> args, string key, double fallback)
    {
        if (!args.TryGetValue(key, out var raw))
        {
            return fallback;
        }

        return raw.ValueKind == JsonValueKind.Number && raw.TryGetDouble(out var value)
            ? value
            : fallback;
    }

    public static string? GetOptionalString(IReadOnlyDictionary<string, JsonElement> args, string key)
    {
        if (!args.TryGetValue(key, out var raw))
        {
            return null;
        }

        return raw.ValueKind == JsonValueKind.String ? raw.GetString() : null;
    }

    public static string NormalizeImageFormat(string value)
    {
        var normalized = value.Trim().ToLowerInvariant();
        return normalized switch
        {
            "jpeg" => "jpg",
            "jpg" => "jpg",
            "png" => "png",
            _ => throw new ArgumentException("image_format must be 'jpg' or 'png'.")
        };
    }

    public static string NormalizeVideoFormat(string value)
    {
        var normalized = value.Trim().ToLowerInvariant();
        return normalized switch
        {
            "mp4" => "mp4",
            "avi" => "avi",
            _ => throw new ArgumentException("video_format must be 'mp4' or 'avi'.")
        };
    }

    public static string MakeSafeFileName(string baseName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        var filtered = new string(baseName.Trim().Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray());
        return string.IsNullOrWhiteSpace(filtered) ? $"webcam-{DateTime.UtcNow:yyyyMMdd-HHmmss-fff}" : filtered;
    }
}
