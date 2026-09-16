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
- **When John has a list of candidate smells/prerequisites and wants to
  rubber-duck through them**, the process is three questions per
  candidate, in order: (1) is it still valid — re-check against the
  current code, it may already be stale; (2) if so, why — what makes it
  a smell here, tying back to the RPP phase and underlying principle;
  (3) how do we fix it. **Don't even offer guiding or Socratic questions
  unprompted while he works through step 1 or 2 himself** — he wants to
  reason out loud, unaided. Only step in once he explicitly says he has
  no idea, or he's visibly gone down a wrong track — and even then, guide
  minimally rather than answering outright. This is a stricter reading
  than plain "ask questions, nudge": here even the questions themselves
  must not steer him. (Corrected 2026-09-12 after opening a rubber-duck
  pass with leading questions before John had said anything himself.)
- **For Shotgun Surgery, and more generally any refactor with a wide or
  uncertain blast radius** (touching many call sites, where the full
  extent isn't knowable upfront), John's preferred technique is the
  **Mikado Method** rather than ad hoc refactoring — see the Primitive
  Obsession work in the Current kata section for the mechanics in
  practice. For a large but *already-mapped* change (scope known, just
  big), **Parallel Change** (expand/migrate/contract, see the Part 2
  Lesson 1 slide deck) is usually the better fit — Mikado's specific
  value is for undiscovered scope, not size alone.
- Explaining *concepts* (why a smell is a problem, what a technique is,
  how the RPP/Mikado Method/etc. work) is not the same as solving the
  kata, and is fair game to answer directly and fully when asked — the
  restriction is on handing over the fix to John's own code, not on
  discussing theory or mechanics.

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
- **Per-exercise working notes**: when a specific technique needs its own
  live scratch space (e.g. a Mikado Method graph's text summary), it
  lives as a `.md`/script alongside that kata's own files rather than in
  this top-level file — e.g. `Katas/LessonSeven/TicTacToeRefactor/
  MikadoNotes.md` and `mikado-build.sh`. This file (`CLAUDE.md`) links to
  them from the relevant Current-kata section rather than duplicating
  their detail.

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
- **Phase 3 (Reorder Responsibilities)** is now fully clean: **Data
  Class** was resolved in the 2026-09-13 session — `Tile` gained real
  behaviour (`AddSymbol` enforces its own "already taken" invariant and
  throws; `GetSymbol` replaced the public settable `Symbol` property).
- **Phase 4 (Refine Abstractions)** — Data Clump is done: a `Position`
  record (`Column`, `Row`) now travels through `Play`/`Board`/`Tile`
  instead of loose `x`/`y` ints, added via expand/migrate/contract
  (`Play(char, int, int)`'s public signature was kept — it's the tested
  contract — and converts to `Position` on entry). Along the way,
  `Column`/`Row` in `Constant/` were also converted from int constants to
  real C# `enum`s, which incidentally resolved the `Tile.X`/`Tile.Y`
  Shotgun Surgery concern flagged back in phase 3 — that TODO is stale
  now and can be removed when next touching `Tile.cs`.
  **Primitive Obsession** (`char` → Enum for the player symbol) is
  **in progress**, using the **Mikado Method** — see below.
- **Not yet reached**: Phase 5 (check whether any Switch Statements
  apply here), and Phase 6 SOLID++ (nothing currently flagged there
  beyond what Phase 4's `Column`/`Row` work already resolved — recheck
  once Primitive Obsession is done).
- The remaining `// TODO:` comments in the code are intentional
  checklist markers for smells not yet fixed, not an instance of the
  "Comments" smell itself — they get deleted as each one is resolved.

### Primitive Obsession (char → Enum) — Mikado Method in progress

John is deliberately practising a **strict** Mikado Method pass on this
one (originally the plan was to reserve Mikado for Phase 6's Shotgun
Surgery, but a first ad hoc attempt at this char→Enum conversion turned
out messier than expected, so Mikado is being used here too — partly to
build a feel for the method before hitting a genuinely large system).

- **Goal**: the player symbol is represented as an Enum rather than a
  `char`.
- The graph itself is being drawn on paper — **the live text summary of
  where it stands, plus process insights learned along the way, is kept
  in `Katas/LessonSeven/TicTacToeRefactor/MikadoNotes.md`**. Read that
  file for the actual current state before resuming this work; don't
  rely on this summary being current.
- `Katas/LessonSeven/TicTacToeRefactor/mikado-build.sh` is a helper
  script John uses to capture `dotnet build` error output to timestamped
  files (`mikado-errors/`) for diffing between naive attempts.
- As of 2026-09-16: four sibling prerequisite nodes have been identified
  under the goal (Game.cs comparisons, Tile's space-check, `lastSymbol`,
  Board.cs), one (`lastSymbol`) has been explored one layer deep and
  fully reverted again since the branch couldn't reach a committable
  green state alone. Code is currently back at the clean, fully-green
  baseline — see `MikadoNotes.md` for detail.

**Next step**: resume the Primitive Obsession Mikado graph — see
`MikadoNotes.md` in the kata folder for exactly where it was left off.

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
- **2026-09-13** — Fixed a stray git index issue on `Column.cs` (index
  had reverted to the pre-Feature-Envy-fix state while `HEAD` and the
  working tree already agreed on the correct version — resolved with
  `git restore --staged`, nothing was actually lost). Discussed the Data
  Class smell conceptually (DTOs as the legitimate exception; why it
  violates Tell-Don't-Ask, invites Feature Envy, loses invariants, risks
  duplication) before touching code. Found and resolved three more
  Feature Envy cases, this time in `Board.cs` (`SymbolAt`, `AddTileAt`,
  `IsTileTaken` were all reaching into `Tile.Symbol` directly): `Symbol`
  became a private field on `Tile`, which gained `GetSymbol()` and
  `AddSymbol()` — the latter enforcing the "already taken" invariant
  itself and throwing "Invalid position" (message text deliberately kept
  as-is, since it's pinned by an existing test). `IsTileTaken` disappeared
  from `Board` entirely. Confirmed via review that `Tile` is no longer a
  Data Class — Phase 3 fully clean. Committed and pushed.
- **2026-09-14** — Discussed Mikado Method vs. classic small-step
  refactoring as a general technique-selection question: landed on
  **Parallel Change** (expand/migrate/contract) for the Data Clump work,
  since that blast radius was large but already mapped, not uncertain —
  Mikado's value is specifically for undiscovered scope. Resolved Data
  Clump: introduced a `Position` record (`Column`, `Row`) threaded
  through `Play`/`Board`/`Tile`, keeping `Play(char, int, int)`'s public
  signature intact (tested contract) and converting to `Position` on
  entry. `Column`/`Row` were also converted from int constants to real
  `enum`s as part of this, incidentally resolving the `Tile.X`/`Tile.Y`
  Shotgun Surgery flag from phase 3. Moved to Primitive Obsession
  (`char` → Enum for the player symbol); a first ad hoc attempt got
  complicated fast, so decided to practise a **strict Mikado Method**
  pass on it instead — partly to build a feel for the method before
  hitting a genuinely large system, even though Mikado was originally
  earmarked only for phase 6's Shotgun Surgery. First real walkthrough of
  Mikado mechanics (goal → naive attempt → log discovered prerequisites
  as siblings → revert to green → recurse → only implement for real once
  a leaf is found *and* the whole build is committable). Hit and resolved
  a process snag along the way: `HEAD` was green but not clean — it
  contained leftover scaffolding (`SymbolNew`/`charToSymbol`) from an
  earlier abandoned ad hoc attempt at this same conversion, which muddied
  the first naive attempt's error signal until swept clean. Built
  `mikado-build.sh` and started `MikadoNotes.md` (both in the kata
  folder) to support this work — see the "Primitive Obsession" section
  above for where the graph currently stands.
- **2026-09-16** — John asked for a portable, git-tracked way to resume
  "Claude/me" work seamlessly across computers, without needing to
  re-explain anything. The mentoring-style refinements that had only
  been living in Claude's local, per-machine session memory (the strict
  no-leading-questions rubber-duck rule; that explaining concepts is fair
  game even though handing over kata solutions isn't) have been folded
  into this file's Coaching contract above, since that local memory
  won't travel between machines — this file, being git-tracked, will.
  Brought the Current-kata section fully up to date to cover the 9/13
  and 9/14 work, and pointed it at `MikadoNotes.md` for the Primitive
  Obsession graph's live state. **Reminder for future sessions**: this
  file only travels between machines once it's committed and pushed —
  local edits alone won't be there on a different computer.
