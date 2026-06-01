#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT_SLN="$SCRIPT_DIR/Craftsmanship.sln"

# --- Lesson selection ---
echo ""
LESSONS=()
while IFS= read -r dir; do
    LESSONS+=("$(basename "$dir")")
done < <(find "$SCRIPT_DIR" -mindepth 1 -maxdepth 1 -type d \
    ! -name '.*' ! -name '.idea' ! -name '.claude' | sort)

if [[ ${#LESSONS[@]} -eq 0 ]]; then
    echo "No existing lessons found. Enter a name for the new lesson:"
    read -r LESSON
else
    echo "Lessons:"
    echo "  0) Create new lesson"
    for i in "${!LESSONS[@]}"; do
        echo "  $((i+1))) ${LESSONS[$i]}"
    done
    echo ""
    read -rp "Select an option: " CHOICE

    if [[ "$CHOICE" == "0" ]]; then
        read -rp "New lesson name: " LESSON
    elif [[ "$CHOICE" =~ ^[0-9]+$ ]] && (( CHOICE >= 1 && CHOICE <= ${#LESSONS[@]} )); then
        LESSON="${LESSONS[$((CHOICE-1))]}"
    else
        echo "Invalid selection" >&2
        exit 1
    fi
fi

# --- Kata name ---
echo ""
read -rp "Kata name: " KATA

# --- Scaffold ---
KATA_DIR="$SCRIPT_DIR/$LESSON/$KATA"
SRC_DIR="$KATA_DIR/src"
TESTS_DIR="$KATA_DIR/tests"
KATA_SLN="$KATA_DIR/$KATA.slnx"

if [[ -d "$KATA_DIR" ]]; then
    echo "Error: $KATA_DIR already exists" >&2
    exit 1
fi

mkdir -p "$SRC_DIR" "$TESTS_DIR"

cat > "$SRC_DIR/src.csproj" << 'CSPROJ'
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>net10.0</TargetFramework>
        <ImplicitUsings>enable</ImplicitUsings>
        <Nullable>enable</Nullable>
    </PropertyGroup>

</Project>
CSPROJ

cat > "$TESTS_DIR/tests.csproj" << 'CSPROJ'
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
CSPROJ

cp "$SCRIPT_DIR/.gitignore" "$KATA_DIR/.gitignore"

dotnet new sln -n "$KATA" -o "$KATA_DIR"
dotnet sln "$KATA_SLN" add "$SRC_DIR/src.csproj" "$TESTS_DIR/tests.csproj"

dotnet sln "$ROOT_SLN" add --solution-folder "$LESSON/$KATA" "$SRC_DIR/src.csproj" "$TESTS_DIR/tests.csproj"

echo ""
echo "Scaffolded $LESSON/$KATA"
echo "  $KATA_DIR/src/src.csproj"
echo "  $KATA_DIR/tests/tests.csproj"
echo "  $KATA_SLN"
echo "  Added to Craftsmanship.sln under $LESSON > $KATA"
