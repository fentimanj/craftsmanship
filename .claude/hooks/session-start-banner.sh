#!/usr/bin/env bash
set -euo pipefail

ROOT="$(git rev-parse --show-toplevel 2>/dev/null || pwd)"
SKILLS_DIR="$ROOT/.claude/skills"

SKILLS=$(find "$SKILLS_DIR" -maxdepth 1 -mindepth 1 -type d -exec basename {} \; | sort | paste -sd, - | sed 's/,/, /g')

BANNER="Craftsmanship — Software Craftsmanship mentoring repo (mentor: Alex).
Skills: ${SKILLS}
Just start a chat and I'll update you on where you're at."

jq -n --arg banner "$BANNER" \
      --arg ctx "Before responding to anything else this session, invoke the letsGo skill (via the Skill tool) to orient on the current kata state recorded in CLAUDE.md, then continue normally with whatever John asks." \
  '{systemMessage: $banner, hookSpecificOutput: {hookEventName: "SessionStart", additionalContext: $ctx}}'
