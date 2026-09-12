# Craftsmanship — Mentoring Record

This repo holds John Fentiman's work for a Software Craftsmanship mentoring
course. Mentor: Alessandro Di Gioia ("Alex"), who designed the course.
Weekly format: discuss a slide-deck theme, then work a code dojo through
katas.

## How we work

**Coaching contract — Alex guides, he does not give answers. Do the same.**

- Ask questions, nudge, and surface the next small step rather than handing
  over a solution.
- Only give a direct answer or fix if John is genuinely stuck and explicitly
  asks for it.
- This applies to every skill in `.claude/skills/` here, including the
  Socratic understanding-check (`revise`) and the status/orientation skills
  — none of them should hand over solutions to open problems, even when
  summarizing.

**The Refactoring Priority Premise (RPP) always drives which smell to
tackle next — never invent a priority order.** It's the diagram in
`docs/CourseResources/RefactoringPriorityPremise.pdf`:

1. **Refactor Readability** → clean: Comments, Dead Code, Magic Strings
   and Numbers, Scope of variables and methods
2. **Reduce Complexity** → clean: Long Method, Duplicated Code
3. **Reorder Responsibilities** → clean: Long Class, Feature Envy,
   Inappropriate Intimacy, Data Class, Message Chain
4. **Refine Abstractions** → clean: Long Parameter List, Data Clump,
   Primitive Obsession, Middle Man
5. **Refactor to Design Patterns** → clean Switch Statements using:
   Dictionary/Hashmap, Strategy, State, Command
6. **Refactor to SOLID++** → Refused Bequest→Liskov Substitution /
   Interface Segregation, Divergent Change→Single Responsibility,
   Shotgun Surgery→Single Responsibility, Speculative Generality→YAGNI,
   Parallel Inheritance→Interface Segregation

When recommending or naming a "next step" (in `whatsNext`, `revise`,
`whereAreWe`, or elsewhere), point at the earliest unclean phase per this
list — don't jump ahead to a later-phase smell just because it looks
easier or more interesting.

## Locations

- **Slide decks**: `docs/CourseSlideDecks/` (Alex's weekly theme decks)
- **Extra resources**: `docs/CourseResources/` (cheat sheets, reference PDFs
  from Alex — e.g. Code Smells cheatsheet, Refactoring Priority Premise)
- **Course notes**: Notion, via the `notion` MCP server. Treat these as
  John's own understanding — messy but useful — to be checked against the
  code and the decks, not taken as ground truth on their own.
- **Katas**: `Katas/` — one folder per lesson (`LessonOne`, `LessonTwo`, …
  plus a `CodeWars/` lesson-agnostic set), each kata with its own
  `src/`, `tests/`, `ReadMe.md`, and a small per-kata `.slnx`.
- **Solution**: `Craftsmanship.sln` at the repo root — references every
  kata's `src`/`tests` projects. Open this in Rider to work across katas.
- **New kata scripts**: `new-kata.ps1` / `new-kata.sh` at the repo root —
  scaffold a new kata under `Katas/<Lesson>/<Kata>/` and register it with
  both the per-kata `.slnx` and the root `Craftsmanship.sln`.

## Current kata

**Kata**: `Katas/LessonSeven/TicTacToeRefactor`

**Objective**: identify and unwind code smells in a working TicTacToe
implementation. This is a pure refactoring exercise — the game logic
already works and is protected by a green test suite; the point is to
recognize the smells and remove them without changing behavior.

**Status — what's done** (per the RPP phases above):

- Baseline implementation is complete and green: 10 xUnit tests pass,
  covering move validation (first player must be `X`, players alternate,
  no replaying a taken tile) and win detection.
- **Phase 1 (Readability)** — done: comments, dead code, magic
  strings/numbers, and variable/method scope have been cleaned up.
- **Phase 2 (Reduce Complexity)** — done: long methods and duplicated
  code addressed.
- **Phase 3 (Reorder Responsibilities)** — in progress: currently working
  through **Feature Envy** — `Game.Winner()`, `IsColumnTaken`, and
  `IsThereSameSymbolInColumn` all reach repeatedly into `Board`. Found
  this one genuinely confusing to resolve cleanly, which is what prompted
  setting up this mentoring memory system in the first place. **Data
  Class** (`Tile` is a bare property bag) is also phase 3 and hasn't been
  started yet.
- **Not yet reached**: Phase 4 Refine Abstractions (Data Clump —
  `symbol`/`x`/`y` traveling together through `Play`/`ValidateMove`/
  `Board`; Primitive Obsession — raw `char`/`int` instead of value
  types), and Phase 6 SOLID++ (Shotgun Surgery on `Tile.X`/`Tile.Y` →
  Single Responsibility). These come after Feature Envy and Data Class
  are resolved, not before.
- The remaining `// TODO:` comments in the code are intentional
  checklist markers for smells not yet fixed, not an instance of the
  "Comments" smell itself — they get deleted as each one is resolved.

**Next step**: keep working through Feature Envy (phase 3) — don't jump
ahead to Data Clump/Primitive Obsession (phase 4) until phase 3 (Feature
Envy, then Data Class) is clean, per the RPP.

## Open items

The running notepad — anything noticed that shouldn't be allowed to slip
off the radar (bugs, questions for Alex, loose ends, things to check
later) goes here as soon as it's noticed, whether or not it's related to
the current kata. Check `[x]` when resolved rather than deleting the
line, so there's a record of it — move genuinely stale/no-longer-relevant
items to the Progress log instead of leaving them cluttering this list.

- [ ] `Katas/LessonSeven/TicTacToeRefactor`: `Winner()` only detects
  column wins (fixed X, varying Y) — no row or diagonal win detection.
  The tests are also named e.g. `DeclarePlayerXAsAWinnerIfThreeInTopRow`
  but the moves they play actually test a column win, not a row. Need to
  check with Alex or the Lesson 7 material whether this is in scope for
  the refactor exercise or a separate gap to fix. (flagged 2026-09-12)

## Progress log

Update this log, the Current-kata section, and Open items above at the
end of every working session — the skills in `.claude/skills/` rely on
all three staying accurate. Add a new dated entry; don't rewrite history.

- **2026-09-12** — Repo reorganisation: renamed the inner `craftsmanship/`
  folder to `Katas/`, lifted `Craftsmanship.sln` and both `new-kata`
  scripts to the repo root, rewrote the solution's project paths
  accordingly, and absorbed `LessonOne/FizzBuzzKata`'s stray embedded git
  repo into the main history. Verified the solution builds clean from the
  root and that both new-kata scripts still scaffold and register katas
  correctly. Built this `CLAUDE.md` and the six mentoring skills
  (`letsGo`, `revise`, `whereAreWe`, `whichKata`, `whatsNext`,
  `whatHaveWeDone`) in `.claude/skills/`.
- **2026-09-12** — Corrected the Current-kata reconstruction above after
  John flagged it: I'd wrongly read "no commits since the 'Ready for
  refactoring (AGAIN)' checkpoint" as "no refactoring has happened,"
  when actually RPP phases 1–2 (Readability, Reduce Complexity) were
  already clean by that point — John is mid-phase-3 (Reorder
  Responsibilities), working through Feature Envy. Added the RPP order
  itself to "How we work" as a standing reference so future "next step"
  guidance is read off it rather than invented.
- **2026-09-12** — Added an **Open items** section as a running notepad
  so flagged issues (like the `Winner()` row/column mismatch below)
  don't get lost once a session ends. Updated the standing
  end-of-session instruction to cover it alongside the Progress log and
  Current-kata section.
