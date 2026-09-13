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
- **Phase 3 (Reorder Responsibilities)** — Feature Envy is done: the
  `Board`-reaching logic that used to sit in `Game` (`Winner()`,
  `IsColumnTaken`, `IsThereSameSymbolInColumn`, and the tile-taken check
  in `ValidateMove`) has been moved into `Board` itself. `Game.Winner()`
  now just delegates to `Board.HasWinner()`; `Board` gained a private
  `ColumnTakenBy()` (replacing the old `IsColumnTaken`/
  `IsThereSameSymbolInColumn` pair) and a private `IsTileTaken()` used by
  `AddTileAt`, which now validates and throws "Invalid position" itself
  instead of `Game` doing it. All 10 tests stayed green throughout.
  **Data Class** (`Tile` is a bare property bag) is the remaining phase-3
  item and **hasn't been started yet**.
- Along the way, two unrelated readability nits were also fixed: the
  classes in `Constant/Column.cs` and `Constant/Row.cs` had been
  physically swapped (file `Column.cs` contained `class Row` and vice
  versa — same behaviour, since C# resolves by type name not filename,
  but confusing to navigate); and `Row.Center` was renamed to
  `Row.Middle`.
- **Not yet reached**: Phase 4 Refine Abstractions (Data Clump —
  `symbol`/`x`/`y` traveling together through `Play`/`ValidateMove`/
  `Board`; Primitive Obsession — raw `char`/`int` instead of value
  types), Phase 5 (check whether any Switch Statements apply here), and
  Phase 6 SOLID++ (Shotgun Surgery on `Tile.X`/`Tile.Y` → Single
  Responsibility — John intends to use the **Mikado Method** when this
  phase is reached, rather than ad hoc refactoring, given it likely
  touches several call sites). These come after Data Class is resolved,
  not before.
- The remaining `// TODO:` comments in the code are intentional
  checklist markers for smells not yet fixed, not an instance of the
  "Comments" smell itself — they get deleted as each one is resolved.

**Next step**: **Data Class** (`Tile`) — the last unclean phase-3 item —
confirmed 2026-09-12 as next session's starting point, ahead of Phase 4
(Data Clump/Primitive Obsession). John had initially planned to jump
straight to phase 4 next session but agreed, once flagged, that Data
Class comes first per the RPP.

## Open items

The running notepad — anything noticed that shouldn't be allowed to slip
off the radar (bugs, questions for Alex, loose ends, things to check
later) goes here as soon as it's noticed, whether or not it's related to
the current kata. Check `[x]` when resolved rather than deleting the
line, so there's a record of it — move genuinely stale/no-longer-relevant
items to the Progress log instead of leaving them cluttering this list.

- [ ] `Katas/LessonSeven/TicTacToeRefactor`: `Winner()` (now
  `Board.HasWinner()`/`ColumnTakenBy()`) only detects column wins (fixed
  X, varying Y) — no row or diagonal win detection. The tests are also
  named e.g. `DeclarePlayerXAsAWinnerIfThreeInTopRow` but the moves they
  play actually test a column win, not a row. John has **permanently
  parked** this for the current refactor pass (2026-09-12) — it's scope,
  not a smell to clean, so it's explicitly out of bounds for the RPP
  work here. Still unresolved as a functional gap; check with Alex or
  the Lesson 7 material separately if it turns out to matter. (flagged
  2026-09-12, parked 2026-09-12)

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
- **2026-09-12** — Worked through all six Feature Envy cases in
  `TicTacToeRefactor` via a rubber-duck review (John reasoning through
  each case unprompted; Claude confirming/reviewing only, per the
  Coaching contract). Moved the tile-taken check and its exception into
  `Board.AddTileAt`; consolidated the column-win detection that used to
  live in `Game` (`Winner()`, `IsColumnTaken`,
  `IsThereSameSymbolInColumn`) into `Board` as `HasWinner()`/
  `ColumnTakenBy()`. `Game` now only calls `board.AddTileAt(...)` and
  `board.HasWinner()` — no more reaching into `Board`'s data. Also fixed
  the swapped `Column`/`Row` class names and renamed `Row.Center` to
  `Row.Middle`. All 10 tests stayed green throughout. Decided to
  permanently park the `Winner()` row/column scope question (see Open
  items) rather than fix it as part of this refactor pass. Plan going
  forward: keep clearing phases in RPP order; when Phase 6's Shotgun
  Surgery is reached, use the **Mikado Method** rather than ad hoc
  changes.
