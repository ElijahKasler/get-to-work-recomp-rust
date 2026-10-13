
$Root = (Get-Location).Path
$Out = Join-Path $env:USERPROFILE "Desktop\AssetRipper_Report"
New-Item -ItemType Directory -Path $Out -Force | Out-Null

Write-Host "Scanning: $Root"

# Every file and folder, with size and timestamps
Get-ChildItem -LiteralPath $Root -Recurse -Force -ErrorAction SilentlyContinue |
    Select-Object FullName, PSIsContainer, Length, Extension, LastWriteTime |
    Export-Csv (Join-Path $Out "file_inventory.csv") -NoTypeInformation

# Count file extensions
Get-ChildItem -LiteralPath $Root -Recurse -File -Force -ErrorAction SilentlyContinue |
    Group-Object Extension |
    Sort-Object Count -Descending |
    Select-Object Count, Name |
    Export-Csv (Join-Path $Out "extension_counts.csv") -NoTypeInformation

# Find JSON files containing only {}, and record their paths
Get-ChildItem -LiteralPath $Root -Recurse -File -Filter "*.json" -ErrorAction SilentlyContinue |
    ForEach-Object {
        try {
            $Content = Get-Content -LiteralPath $_.FullName -Raw -ErrorAction Stop
            if ($Content.Trim() -eq "{}") {
                $_.FullName
            }
        } catch {}
    } | Set-Content (Join-Path $Out "empty_json_files.txt")

# Record contents of smaller text/config/source files
$TextExtensions = @(
    ".json", ".txt", ".xml", ".yaml", ".yml", ".ini",
    ".config", ".manifest", ".cs", ".shader", ".asmdef"
)
$TextReport = Join-Path $Out "text_file_contents.txt"
"ROOT: $Root`r`n" | Set-Content $TextReport

Get-ChildItem -LiteralPath $Root -Recurse -File -Force -ErrorAction SilentlyContinue |
    Where-Object {
        $_.Extension.ToLowerInvariant() -in $TextExtensions -and
        $_.Length -le 100KB
    } | ForEach-Object {
        Add-Content $TextReport "`r`n`r`n========== $($_.FullName) =========="
        try {
            Get-Content -LiteralPath $_.FullName -Raw -ErrorAction Stop |
                Add-Content $TextReport
        } catch {
            Add-Content $TextReport "[Could not read file]"
        }
    }

# Recent log files and errors, where available
Get-ChildItem -LiteralPath $Root -Recurse -File -Force -ErrorAction SilentlyContinue |
    Where-Object {
        $_.Extension -in @(".log", ".txt") -and $_.Length -le 20MB
    } | ForEach-Object {
        Select-String -LiteralPath $_.FullName `
            -Pattern "error|exception|failed|typetree|serialization|unsupported" `
            -CaseSensitive:$false -ErrorAction SilentlyContinue
    } | ForEach-Object {
        "$($_.Path):$($_.LineNumber): $($_.Line)"
    } | Set-Content (Join-Path $Out "possible_errors.txt")

Write-Host "`nFinished. Report folder: $Out"
Write-Host "Files:"
Get-ChildItem $Out | Select-Object Name, Length
