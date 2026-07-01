param(
    [string]$Lesson,
    [string]$Kata,
    [string]$Description,
    [switch]$DryRun
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$rootSln = Join-Path $scriptDir 'Craftsmanship.sln'

function Invoke-Step {
    param(
        [string]$Message,
        [scriptblock]$Action
    )

    if ($DryRun) {
        Write-Host "[dry-run] $Message"
        return
    }

    & $Action
}

function Write-FileUtf8NoBom {
    param(
        [string]$Path,
        [string]$Content
    )

    $utf8NoBom = New-Object System.Text.UTF8Encoding($false)
    [System.IO.File]::WriteAllText($Path, $Content, $utf8NoBom)
}

Write-Host ''
$lessons = @(Get-ChildItem -Path $scriptDir -Directory |
    Where-Object { -not $_.Attributes.HasFlag([IO.FileAttributes]::Hidden) } |
    Where-Object { $_.Name -notin @('.idea', '.claude') } |
    Sort-Object Name |
    Select-Object -ExpandProperty Name)

if ([string]::IsNullOrWhiteSpace($Lesson)) {
    if ($lessons.Count -eq 0) {
        $Lesson = Read-Host 'No existing lessons found. Enter a name for the new lesson'
    }
    else {
        Write-Host 'Lessons:'
        Write-Host '  0) Create new lesson'
        for ($i = 0; $i -lt $lessons.Count; $i++) {
            Write-Host ("  {0}) {1}" -f ($i + 1), $lessons[$i])
        }
        Write-Host ''

        $choice = Read-Host 'Select an option'
        if ($choice -eq '0') {
            $Lesson = Read-Host 'New lesson name'
        }
        elseif ($choice -match '^\d+$') {
            $index = [int]$choice
            if ($index -ge 1 -and $index -le $lessons.Count) {
                $Lesson = $lessons[$index - 1]
            }
            else {
                throw 'Invalid selection'
            }
        }
        else {
            throw 'Invalid selection'
        }
    }
}

if ([string]::IsNullOrWhiteSpace($Kata)) {
    Write-Host ''
    $Kata = Read-Host 'Kata name'
}

if ([string]::IsNullOrWhiteSpace($Description)) {
    Write-Host ''
    $Description = Read-Host 'Short description'
}

$kataDir = Join-Path (Join-Path $scriptDir $Lesson) $Kata
$srcDir = Join-Path $kataDir 'src'
$testsDir = Join-Path $kataDir 'tests'
$kataSln = Join-Path $kataDir ("{0}.slnx" -f $Kata)

if (Test-Path $kataDir) {
    throw "Error: $kataDir already exists"
}

Invoke-Step "Create kata directories" {
    New-Item -Path $srcDir -ItemType Directory -Force | Out-Null
    New-Item -Path $testsDir -ItemType Directory -Force | Out-Null
}

$srcCsproj = @'
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
    </PropertyGroup>

</Project>
'@

$testsCsproj = @'
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
        <IsPackable>false</IsPackable>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="coverlet.collector" Version="6.0.4"/>
        <PackageReference Include="FluentAssertions" Version="8.10.0" />
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1"/>
        <PackageReference Include="xunit" Version="2.9.3"/>
        <PackageReference Include="xunit.runner.visualstudio" Version="3.1.4"/>
    </ItemGroup>

    <ItemGroup>
        <Using Include="Xunit"/>
    </ItemGroup>

    <ItemGroup>
        <ProjectReference Include="..\src\src.csproj" />
    </ItemGroup>

</Project>
'@

$testClass = @"
public class ${Kata}Should
{
    [Fact]
    public void Return_When_Given()
    {
        throw new NotImplementedException();
    }
}
"@

$readme = @"
# $Kata

$Description
"@

Invoke-Step "Write src/src.csproj" {
    Write-FileUtf8NoBom -Path (Join-Path $srcDir 'src.csproj') -Content $srcCsproj
}

Invoke-Step "Write tests/tests.csproj" {
    Write-FileUtf8NoBom -Path (Join-Path $testsDir 'tests.csproj') -Content $testsCsproj
}

Invoke-Step ("Write tests/{0}Should.cs" -f $Kata) {
    Write-FileUtf8NoBom -Path (Join-Path $testsDir ("{0}Should.cs" -f $Kata)) -Content $testClass
}

Invoke-Step "Write ReadMe.md" {
    Write-FileUtf8NoBom -Path (Join-Path $kataDir 'ReadMe.md') -Content $readme
}

$rootGitIgnore = Join-Path $scriptDir '.gitignore'
if (Test-Path $rootGitIgnore) {
    Invoke-Step "Copy .gitignore" {
        Copy-Item -Path $rootGitIgnore -Destination (Join-Path $kataDir '.gitignore') -Force
    }
}

Invoke-Step ("Create kata solution {0}" -f $kataSln) {
    dotnet new sln -n $Kata -o $kataDir | Out-Host
}

Invoke-Step "Add src/tests projects to kata solution" {
    dotnet sln $kataSln add (Join-Path $srcDir 'src.csproj') (Join-Path $testsDir 'tests.csproj') | Out-Host
}

Invoke-Step "Add src/tests projects to Craftsmanship.sln" {
    dotnet sln $rootSln add --solution-folder "$Lesson/$Kata" (Join-Path $srcDir 'src.csproj') (Join-Path $testsDir 'tests.csproj') | Out-Host
}

Write-Host ''
Write-Host ("Scaffolded {0}/{1}" -f $Lesson, $Kata)
Write-Host ("  {0}" -f (Join-Path $kataDir 'src/src.csproj'))
Write-Host ("  {0}" -f (Join-Path $kataDir 'tests/tests.csproj'))
Write-Host ("  {0}" -f (Join-Path $testsDir ("{0}Should.cs" -f $Kata)))
Write-Host ("  {0}" -f $kataSln)
Write-Host ("  {0}" -f (Join-Path $kataDir 'ReadMe.md'))
Write-Host ("  Added to Craftsmanship.sln under {0} > {1}" -f $Lesson, $Kata)

