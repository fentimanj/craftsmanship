#!/bin/bash
# Builds the kata and writes the current compile errors to a timestamped
# file under mikado-errors/, so each attempt's error list is kept for
# diffing against a previous one instead of being overwritten.
#
# Usage: ./mikado-build.sh
# Then:  diff mikado-errors/<older>.txt mikado-errors/<newer>.txt

cd "$(dirname "$0")" || exit 1

mkdir -p mikado-errors
timestamp=$(date +%Y%m%d-%H%M%S)
outfile="mikado-errors/errors-${timestamp}.txt"

dotnet build 2>&1 | grep "error CS" > "$outfile"

count=$(wc -l < "$outfile" | tr -d ' ')
echo "Wrote $count error line(s) to $outfile"
